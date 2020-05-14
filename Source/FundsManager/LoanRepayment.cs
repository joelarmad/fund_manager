using FundsManager.Classes.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FundsManager
{
    public partial class LoanRepayment : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public LoanRepayment()
        {
            InitializeComponent();
            clear();
        }

        private void LoanRepayment_Load(object sender, EventArgs e)
        {
            this.creditorsTableAdapter.FillByFund(this.fundsDBDataSet.Creditors, manager.Selected);
            loadLoans();
        }

        private void clear()
        {
            txtAmount.Text = "";
            txtInterest.Text = "";
            txtStart.Text = "";
            txtEnd.Text = "";
            cmdRepay.Enabled = false;
        }

        private void loadLoans()
        {
            if (cbLender.SelectedValue != null)
            {
                int id = int.Parse(cbLender.SelectedValue.ToString());

                this.loansTableAdapter.Fill(this.fundsDBDataSet.Loans, manager.Selected, id, false);
                loadRepayments();

                if (cbLoan.SelectedValue != null)
                {
                    id = int.Parse(cbLoan.SelectedValue.ToString());

                    Loans_View loan = manager.My_db.Loans_View.FirstOrDefault(x => x.Id == id);

                    if (loan != null)
                    {
                        txtAmount.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", loan.amount);
                        txtInterest.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", loan.interest);
                        txtStart.Text = loan.start_date.ToShortDateString();
                        txtEnd.Text = loan.end_date.ToShortDateString();
                        cmdRepay.Enabled = true;
                    }
                    else
                    {
                        clear();
                    }
                }
                else
                {
                    clear();
                }
            }
        }

        private void loadRepayments()
        {
            int id = 55;
            if (cbLoan.SelectedValue != null)
            {
                id = int.Parse(cbLoan.SelectedValue.ToString());
            }
            this.loan_RepaymentsTableAdapter.FillByLoan(this.fundsDBDataSet.Loan_Repayments, id);
        }

        private void cbLender_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadLoans();
        }

        private void cbLoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRepayments();
        }

        private void cmdRepay_Click(object sender, EventArgs e)
        {
            try
            {
                if (manager.My_db.ClosedPeriods.FirstOrDefault(x => x.year == DateTime.Now.Year) == null)
                {
                    int lenderId = Convert.ToInt32(cbLender.SelectedValue);

                    int loan_id = int.Parse(cbLoan.SelectedValue.ToString());

                    Loan loan = manager.My_db.Loans.FirstOrDefault(x => x.Id == loan_id);

                    Loan_Repayments repayment = new Loan_Repayments();
                    repayment.Loan = loan;
                    repayment.repayment_date = DateTime.Now;
                    repayment.AccountingMovement = generateAccountingMovement(repayment);

                    manager.My_db.Loan_Repayments.Add(repayment);
                    manager.My_db.SaveChanges();

                    loadRepayments();
                }
                else
                {
                    ErrorMessage.showErrorMessage(new Exception("No movement allowed in closed period."));
                }
                
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private AccountingMovement generateAccountingMovement(Loan_Repayments repayment)
        {
            AccountingMovement _accountingMovement = new AccountingMovement();

            Account account110 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "110" && x.FK_Accounts_Funds == manager.Selected);
            Account account470 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "470" && x.FK_Accounts_Funds == manager.Selected);

            if (account110 != null && account470 != null)
            {
                Currency currency = manager.My_db.Currencies.FirstOrDefault(x => x.Id == repayment.Loan.currency_id && x.FK_Currencies_Funds == manager.Selected);
                Subaccount subacct110 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account110.Id && x.name == "Bank " + currency.symbol);
                Subaccount subacct470_01 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account470.Id && x.name == "Principal Loan");
                Subaccount subacct470_02 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account470.Id && x.name == "Interest Loan");

                if (currency != null && subacct110 != null && subacct470_01 != null && subacct470_02 != null)
                {


                    _accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                    _accountingMovement.description = "";
                    _accountingMovement.date = repayment.repayment_date;
                    _accountingMovement.reference = _accountingMovement.contract = KeyDefinitions.NextAccountMovementReference(repayment.repayment_date.Year);
                    _accountingMovement.FK_AccountingMovements_Currencies = repayment.Loan.currency_id;
                    _accountingMovement.original_reference = "";

                    manager.My_db.AccountingMovements.Add(_accountingMovement);

                    Movements_Accounts _maccount110 = new Movements_Accounts();

                    _maccount110.AccountingMovement = _accountingMovement;
                    _maccount110.FK_Movements_Accounts_Funds = manager.Selected;
                    _maccount110.FK_Movements_Accounts_Accounts = account110.Id;
                    if (subacct110 != null)
                        _maccount110.FK_Movements_Accounts_Subaccounts = subacct110.Id;
                    _maccount110.debit = 0;
                    _maccount110.credit = Math.Round(repayment.Loan.amount, 2);
                    
                    manager.My_db.Movements_Accounts.Add(_maccount110);

                    Movements_Accounts _maccount470_01 = new Movements_Accounts();

                    _maccount470_01.AccountingMovement = _accountingMovement;
                    _maccount470_01.FK_Movements_Accounts_Funds = manager.Selected;
                    _maccount470_01.FK_Movements_Accounts_Accounts = account470.Id;
                    _maccount470_01.debit = Math.Round(repayment.Loan.amount, 2);
                    _maccount470_01.credit = 0;
                    
                    manager.My_db.Movements_Accounts.Add(_maccount470_01);

                    Movements_Accounts _maccount470_02 = new Movements_Accounts();

                    _maccount470_02.AccountingMovement = _accountingMovement;
                    _maccount470_02.FK_Movements_Accounts_Funds = manager.Selected;
                    _maccount470_02.FK_Movements_Accounts_Accounts = account470.Id;
                    _maccount470_02.debit = Math.Round(repayment.Loan.interest, 2);
                    _maccount470_02.credit = 0;
                    
                    manager.My_db.Movements_Accounts.Add(_maccount470_02);
                }

                return _accountingMovement;
            }

            return null;
        }
    }
}
