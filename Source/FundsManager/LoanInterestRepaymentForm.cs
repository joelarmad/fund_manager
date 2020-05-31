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
    public partial class LoanInterestRepaymentForm : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public LoanInterestRepaymentForm()
        {
            InitializeComponent();
        }

        private void LoanInterestRepaymentForm_Load(object sender, EventArgs e)
        {
            

            this.creditorsTableAdapter.FillByFund(this.fundsDBDataSet.Creditors, manager.Selected);

            loadLoansInterest();

        }

        private void loadLoansInterest()
        {
            int lenderId = 0;

            if (cbLender.SelectedValue != null && int.TryParse(cbLender.SelectedValue.ToString(), out lenderId))
            {
                this.loanGeneratedInterestViewTableAdapter.FillByLenderId(this.fundsDBDataSet.LoanGeneratedInterestView, lenderId);
            }
        }

        private void cbLender_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadLoansInterest();
        }

        private void cmdPay_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                decimal totalAmount = 0;

                Account account470 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "470" && x.FK_Accounts_Funds == manager.Selected);

                if (account470 != null)
                {
                    Subaccount subaccount470 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account470.Id && x.number == "02");

                    if (subaccount470 != null)
                    {
                        AccountingMovement _accountingMovement = new AccountingMovement();

                        _accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                        _accountingMovement.description = "Loan Interest Repayment";
                        _accountingMovement.date = dtpDate.Value;
                        _accountingMovement.reference = KeyDefinitions.NextAccountMovementReference(dtpDate.Value.Year);                        
                        _accountingMovement.original_reference = "";
                        _accountingMovement.contract = "";

                        manager.My_db.AccountingMovements.Add(_accountingMovement);

                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            int id = 0;

                            if (int.TryParse(row.Cells[0].Value.ToString(), out id))
                            {
                                LoanGeneratedInterestDetail detail = manager.My_db.LoanGeneratedInterestDetails.FirstOrDefault(x => x.Id == id);

                                if (detail != null)
                                {
                                    if (_accountingMovement.FK_AccountingMovements_Currencies == 0)
                                    {
                                        _accountingMovement.FK_AccountingMovements_Currencies = detail.Loan.currency_id;
                                    }

                                    Loan_InterestRepayments interestRepayment = new Loan_InterestRepayments();
                                    interestRepayment.interest_detail_id = detail.Id;
                                    interestRepayment.repayment_date = dtpDate.Value.Date;
                                    interestRepayment.AccountingMovement = _accountingMovement;

                                    manager.My_db.Loan_InterestRepayments.Add(interestRepayment);

                                    totalAmount += detail.generated_interest;
                                }
                                else
                                {
                                    //TODO: no detail
                                }
                            }
                        }

                        Movements_Accounts _maccount470 = new Movements_Accounts();

                        _maccount470.AccountingMovement = _accountingMovement;
                        _maccount470.FK_Movements_Accounts_Funds = manager.Selected;
                        _maccount470.FK_Movements_Accounts_Accounts = account470.Id;
                        _maccount470.FK_Movements_Accounts_Subaccounts = subaccount470.Id;
                        _maccount470.subaccount_type = 4;
                        _maccount470.subaccount = int.Parse(cbLender.SelectedValue.ToString());
                        _maccount470.debit = Math.Round(totalAmount, 2);
                        _maccount470.credit = 0;

                        manager.My_db.Movements_Accounts.Add(_maccount470);

                        GeneralLedgerForm gledger = new GeneralLedgerForm();
                        gledger.StartPosition = FormStartPosition.CenterScreen;
                        gledger.FromExternalOperation = true;
                        gledger.ExternalAccountMovemet = _accountingMovement;
                        gledger.ExternalCredit = totalAmount;
                        gledger.ControlBox = false;
                        gledger.ShowDialog();

                        if (!gledger.OperationCompleted)
                        {
                            throw new Exception("Ledger operation has been failed. The interest repayment has been rolled back.");
                        }
                        else
                        {
                            MessageBox.Show("Selected interest has been repaid.");
                        }
                    }
                    else
                    {
                        //TODO: no subaccount
                    }
                }
                else
                {
                    //TODO: no account
                }
            }
            else
            {
                MessageBox.Show("No row selected.");
            }
        }
    }
}
