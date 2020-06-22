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
    public partial class BondsTFAMRepaymentForm : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        int idIndex = 0;
        int referenceIndex = 1;
        int principalIndex = 3;
        int interestAccruedIndex = 4;
        int principalCollectionIndex = 5;
        int interestCollectionIndex = 6;

        public BondsTFAMRepaymentForm()
        {
            InitializeComponent();
        }

        private void BondsTFAMRepaymentForm_Load(object sender, EventArgs e)
        {
            this.bondsTFAMToBeRepaidTableAdapter.FillByFund(this.fundsDBDataSet.BondsTFAMToBeRepaid, manager.Selected);
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
                                    errors += "\rBond " + reference + " has too much repayment value.";
                                }
                            }
                            else
                            {
                                errors += "\r  Bond " + reference + " has wrong repayment value.";
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
                            BondsTFAMRepayment bondRepayment = new BondsTFAMRepayment();
                            bondRepayment.repayment_date = dtpDate.Value;

                            Account account540 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "540" && x.FK_Accounts_Funds == manager.Selected);

                            if (account540 != null)
                            {
                                Subaccount subAcct01 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account540.Id && x.name == "Principal Bonds");
                                Subaccount subAcct02 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account540.Id && x.name == "Interest Bond");

                                if (subAcct01 != null && subAcct02 != null)
                                {
                                    manager.My_db.BondsTFAMRepayments.Add(bondRepayment);

                                    AccountingMovement accountingMovement = new AccountingMovement();

                                    accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                                    accountingMovement.description = "Bond Repayment";
                                    accountingMovement.date = dtpDate.Value;
                                    accountingMovement.reference = KeyDefinitions.NextAccountMovementReference(dtpDate.Value.Year);
                                    accountingMovement.original_reference = "";
                                    accountingMovement.contract = "";
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

                                        int bondId = int.Parse(rowId);

                                        BondsTFAM bond = manager.My_db.BondsTFAMs.FirstOrDefault(x => x.Id == bondId);

                                        if (bond != null)
                                        {
                                            Currency currency = manager.My_db.Currencies.FirstOrDefault(x => x.Id == bond.currency_id && x.FK_Currencies_Funds == manager.Selected);

                                            if (currency != null)
                                            {
                                                if (accountingMovement.FK_AccountingMovements_Currencies == 0)
                                                {
                                                    accountingMovement.FK_AccountingMovements_Currencies = currency.Id;

                                                    manager.My_db.AccountingMovements.Add(accountingMovement);

                                                    bondRepayment.AccountingMovement = accountingMovement;
                                                }

                                                BondsTFAMRepaymentDetail repaymentDetail = new BondsTFAMRepaymentDetail();

                                                repaymentDetail.BondsTFAMRepayment = bondRepayment;
                                                repaymentDetail.bond_id = bondId;
                                                repaymentDetail.principal_repaid = Math.Round(principalToBeCollected, 2);
                                                repaymentDetail.interest_repaid = Math.Round(interestToBeCollected, 2);

                                                if (bond.can_generate_interest == 0 && principal - principalToBeCollected <= 0 && interestAccrued - interestToBeCollected <= 0)
                                                {
                                                    bond.paid = 1;
                                                }

                                                manager.My_db.BondsTFAMRepaymentDetails.Add(repaymentDetail);

                                                if (principalToBeCollected > 0)
                                                {
                                                    Movements_Accounts _maccount01 = new Movements_Accounts();

                                                    _maccount01.AccountingMovement = accountingMovement;
                                                    _maccount01.FK_Movements_Accounts_Funds = manager.Selected;
                                                    _maccount01.FK_Movements_Accounts_Accounts = account540.Id;
                                                    if (subAcct01 != null)
                                                        _maccount01.FK_Movements_Accounts_Subaccounts = subAcct01.Id;
                                                    _maccount01.subaccount = bond.Id;
                                                    _maccount01.subaccount_type = 9;
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
                                                    _maccount02.FK_Movements_Accounts_Accounts = account540.Id;
                                                    if (subAcct02 != null)
                                                        _maccount02.FK_Movements_Accounts_Subaccounts = subAcct02.Id;
                                                    _maccount02.subaccount = bond.Id;
                                                    _maccount02.subaccount_type = 9;
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
                                                msg += "\rCurrency is missing. No repayment has been generated for bond with Id=\"" + bondId + "\".";
                                            }
                                        }
                                        else
                                        {
                                            msg += "\rBond with Id=\"" + bondId.ToString() + "\" not found.";
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
                                            throw new Exception("Ledger operation has been failed. The bond repayment has been rolled back.");
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
                                ErrorMessage.showErrorMessage(new Exception("Account 540 is missing."));
                            }
                        }
                        else
                        {
                            ErrorMessage.showErrorMessage(new Exception("No bond found."));
                        }
                    }

                    this.bondsTFAMToBeRepaidTableAdapter.FillByFund(this.fundsDBDataSet.BondsTFAMToBeRepaid, manager.Selected);
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
