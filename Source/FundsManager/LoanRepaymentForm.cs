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

    public partial class LoanRepaymentForm : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        int idIndex = 0;
        int referenceIndex = 1;
        int principalIndex = 3;
        int interestAccruedIndex = 4;
        int principalCollectionIndex = 5;
        int interestCollectionIndex = 6;


        public LoanRepaymentForm()
        {
            InitializeComponent();
        }

        private void LoanRepaymentForm_Load(object sender, EventArgs e)
        {
            this.creditorsTableAdapter.FillByFund(this.fundsDBDataSet.Creditors, manager.Selected);

            cbLender_SelectedIndexChanged(null, null);

            cbContract_SelectedIndexChanged(null, null);
        }

        private void cbLender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLender.SelectedValue != null)
            {
                int id = int.Parse(cbLender.SelectedValue.ToString());

                this.loansTableAdapter.FillWithEmpty(this.fundsDBDataSet.Loans, "Any reference", manager.Selected, id);
            }

            cbContract_SelectedIndexChanged(null, null);
        }

        private void cbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lenderId = 0;

            if (cbLender.SelectedValue != null && int.TryParse(cbLender.SelectedValue.ToString(), out lenderId))
            {
                int refId = 0;

                if (cbContract.SelectedValue != null && int.TryParse(cbContract.SelectedValue.ToString(), out refId))
                {
                    this.loansToBeRepaidViewTableAdapter.FillByFilter(this.fundsDBDataSet.LoansToBeRepaidView, lenderId, refId);
                }

                
            }

            
        }

        private void cmdRepay_Click(object sender, EventArgs e)
        {
            try
            {
                if (manager.My_db.ClosedPeriods.FirstOrDefault(x => x.year == dtpDate.Value.Year) == null)
                {
                    List<string> rowIds = new List<string>();
                    List<string> references = new List<string>();
                    List<decimal> principals = new List<decimal>();
                    List<decimal> interestAccrueds = new List<decimal>();
                    List<decimal> principalCollections = new List<decimal>();
                    List<decimal> interestCollections = new List<decimal>();

                    String errors = "";

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string rowId = row.Cells[idIndex].Value.ToString();
                        string reference = row.Cells[referenceIndex].Value.ToString();
                        decimal principal = decimal.Parse(row.Cells[principalIndex].Value.ToString());
                        decimal interestAccrued = decimal.Parse(row.Cells[interestAccruedIndex].Value.ToString());
                        string principalToBeCollectedStr = row.Cells[principalCollectionIndex].Value != null ? row.Cells[principalCollectionIndex].Value.ToString() : "0";
                        string interestToBeCollectedStr = row.Cells[interestCollectionIndex].Value != null ? row.Cells[interestCollectionIndex].Value.ToString() : "0";

                        decimal principalToBeCollected = 0;
                        decimal interestToBeCollected = 0;

                        if (principalToBeCollectedStr != "0" || interestToBeCollectedStr != "0")
                        {                            

                            if (decimal.TryParse(principalToBeCollectedStr, out principalToBeCollected) &&
                                    decimal.TryParse(interestToBeCollectedStr, out interestToBeCollected))
                            {
                                if (principal - principalToBeCollected >= 0 && interestAccrued - interestToBeCollected >= 0)
                                {
                                    rowIds.Add(rowId);
                                    references.Add(reference);
                                    principals.Add(principal);
                                    interestAccrueds.Add(interestAccrued);
                                    principalCollections.Add(principalToBeCollected);
                                    interestCollections.Add(interestToBeCollected);
                                }
                                else
                                {
                                    errors += "\rLoan " + reference + " has too much collection value.";
                                }
                            }
                            else
                            {
                                errors += "\r  Loan " + reference + " has wrong collection value.";
                            }
                        }
                    }

                    if (errors != "")
                    {
                        string msg = "Please, fix these errors:" + errors;

                        ErrorMessage.showErrorMessage(new Exception(msg));
                        return;
                    }
                    else
                    {
                        string msg = "";

                        if (rowIds.Count > 0)
                        {
                            Loan_Repayments loanRepayment = new Loan_Repayments();
                            loanRepayment.repayment_date = dtpDate.Value;

                            Account account470 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "470" && x.FK_Accounts_Funds == manager.Selected);

                            if (account470 != null)
                            {
                                Subaccount subAcct01 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account470.Id && x.number == "01");
                                Subaccount subAcct02 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account470.Id && x.number == "02");

                                if (subAcct01 != null && subAcct02 != null)
                                {
                                    manager.My_db.Loan_Repayments.Add(loanRepayment);

                                    AccountingMovement accountingMovement = new AccountingMovement();

                                    accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                                    accountingMovement.description = "Loan Repayment";
                                    accountingMovement.date = dtpDate.Value;
                                    accountingMovement.reference = KeyDefinitions.NextAccountMovementReference(dtpDate.Value.Year);
                                    accountingMovement.original_reference = cbContract.Text;
                                    accountingMovement.contract = cbContract.Text;
                                    accountingMovement.FK_AccountingMovements_Currencies = 0;

                                    bool showGL = false;
                                    decimal totalPaid = 0;

                                    for (int i = 0; i < rowIds.Count; i++)
                                    {
                                        string rowId = rowIds[i];
                                        decimal principal = principals[i];
                                        decimal interestAccrued = interestAccrueds[i];
                                        decimal principalToBeCollected = principalCollections[i];
                                        decimal interestToBeCollected = interestCollections[i];

                                        int loandId = int.Parse(rowId);

                                        Loan loan = manager.My_db.Loans.FirstOrDefault(x => x.Id == loandId);

                                        if (loan != null)
                                        {
                                            Currency currency = manager.My_db.Currencies.FirstOrDefault(x => x.Id == loan.currency_id && x.FK_Currencies_Funds == manager.Selected);

                                            if (currency != null)
                                            {
                                                if (accountingMovement.FK_AccountingMovements_Currencies == 0)
                                                {
                                                    accountingMovement.FK_AccountingMovements_Currencies = currency.Id;

                                                    manager.My_db.AccountingMovements.Add(accountingMovement);

                                                    loanRepayment.AccountingMovement = accountingMovement;
                                                }

                                                LoanRepaymentDetail repaymentDetail = new LoanRepaymentDetail();

                                                repaymentDetail.Loan_Repayments = loanRepayment;
                                                repaymentDetail.loan_id = loandId;
                                                repaymentDetail.principal_repaid = Math.Round(principalToBeCollected, 2);
                                                repaymentDetail.interest_repaid = Math.Round(interestToBeCollected, 2);

                                                if (loan.can_generate_interest == 0 && principal - principalToBeCollected <= 0 && interestAccrued - interestToBeCollected <= 0)
                                                {
                                                    loan.paid = 1;
                                                }

                                                manager.My_db.LoanRepaymentDetails.Add(repaymentDetail);

                                                if (principalToBeCollected > 0)
                                                {
                                                    Movements_Accounts _maccount01 = new Movements_Accounts();

                                                    _maccount01.AccountingMovement = accountingMovement;
                                                    _maccount01.FK_Movements_Accounts_Funds = manager.Selected;
                                                    _maccount01.FK_Movements_Accounts_Accounts = account470.Id;
                                                    if (subAcct01 != null)
                                                        _maccount01.FK_Movements_Accounts_Subaccounts = subAcct01.Id;
                                                    _maccount01.subaccount = loan.lender_id;
                                                    _maccount01.subaccount_type = 4;
                                                    _maccount01.debit = Math.Round(principalToBeCollected, 2);
                                                    _maccount01.credit = 0;

                                                    manager.My_db.Movements_Accounts.Add(_maccount01);

                                                    repaymentDetail.Movements_Accounts = _maccount01;
                                                }

                                                if (interestToBeCollected > 0)
                                                {
                                                    Movements_Accounts _maccount02 = new Movements_Accounts();

                                                    _maccount02.AccountingMovement = accountingMovement;
                                                    _maccount02.FK_Movements_Accounts_Funds = manager.Selected;
                                                    _maccount02.FK_Movements_Accounts_Accounts = account470.Id;
                                                    if (subAcct02 != null)
                                                        _maccount02.FK_Movements_Accounts_Subaccounts = subAcct02.Id;
                                                    _maccount02.subaccount = loan.lender_id;
                                                    _maccount02.subaccount_type = 4;
                                                    _maccount02.debit = Math.Round(interestToBeCollected, 2);
                                                    _maccount02.credit = 0;

                                                    manager.My_db.Movements_Accounts.Add(_maccount02);

                                                    repaymentDetail.Movements_Accounts1 = _maccount02;
                                                }

                                                totalPaid += principalToBeCollected + interestToBeCollected;

                                                showGL = true;
                                            }
                                            else
                                            {
                                                msg += "\rCurrency is missing. No repayment has been generated for loan with Id=\"" + loandId + "\".";
                                            }
                                        }
                                        else
                                        {
                                            msg += "\rLoan with Id=\"" + loandId.ToString() + "\" not found.";
                                        }
                                    }

                                    if (msg != "")
                                    {
                                        MessageBox.Show("Warning:\r\r" + msg);
                                    }

                                    if (showGL)
                                    {
                                        GeneralLedgerForm gledger = new GeneralLedgerForm();
                                        gledger.StartPosition = FormStartPosition.CenterScreen;
                                        gledger.FromExternalOperation = true;
                                        gledger.ExternalAccountMovemet = accountingMovement;
                                        gledger.ExternalCredit = totalPaid;
                                        gledger.ControlBox = false;
                                        gledger.ShowDialog();

                                        if (!gledger.OperationCompleted)
                                        {
                                            throw new Exception("Ledger operation has been failed. The loan repayment has been rolled back.");
                                        }

                                    }
                                }
                                else
                                {
                                    ErrorMessage.showErrorMessage(new Exception("Sub Account 01 or 02 are missing."));
                                }
                            }
                            else
                            {
                                ErrorMessage.showErrorMessage(new Exception("Account 470 is missing."));
                            }
                        }
                        else
                        {
                            ErrorMessage.showErrorMessage(new Exception("No loan found."));
                        }
                    }

                    cbContract_SelectedIndexChanged(null, null);
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
    }
}
