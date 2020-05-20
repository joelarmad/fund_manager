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
    public partial class BondsTFAMInterestPayment : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public BondsTFAMInterestPayment()
        {
            InitializeComponent();
        }

        private void BondsTFAMInterestPayment_Load(object sender, EventArgs e)
        {
            this.bondsTFAMInterestToPayTableAdapter.FillByFundId(this.fundsDBDataSet.BondsTFAMInterestToPay, manager.Selected);

        }

        private void cmdPay_Click(object sender, EventArgs e)
        {
            decimal totalPaid = 0;

            Account account540 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "540" && x.FK_Accounts_Funds == manager.Selected);

            AccountingMovement _accountingMovement = new AccountingMovement();

            try
            {
                if (manager.My_db.ClosedPeriods.FirstOrDefault(x => x.year == dtpDate.Value.Year) == null)
                {
                    if (account540 != null)
                    {
                        if (dataGridView1.SelectedRows.Count > 0)
                        {
                            foreach (DataGridViewRow _item in dataGridView1.SelectedRows)
                            {
                                int interestId = 0;

                                if (int.TryParse(_item.Cells[0].Value.ToString(), out interestId))
                                {
                                    BondsTFAMGeneratedInterestDetail toPay = manager.My_db.BondsTFAMGeneratedInterestDetails.FirstOrDefault(x => x.Id == interestId);

                                    if (toPay != null)
                                    {
                                        toPay.payment_interest_date = dtpDate.Value;

                                        _accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                                        _accountingMovement.description = toPay.BondsTFAM.number + " Interest Payment";
                                        _accountingMovement.date = toPay.payment_interest_date.Value;
                                        _accountingMovement.reference = KeyDefinitions.NextAccountMovementReference(toPay.payment_interest_date.Value.Year);
                                        _accountingMovement.FK_AccountingMovements_Currencies = toPay.BondsTFAM.currency_id;
                                        _accountingMovement.original_reference = "";
                                        _accountingMovement.contract = "";

                                        manager.My_db.AccountingMovements.Add(_accountingMovement);

                                        toPay.AccountingMovement1 = _accountingMovement;

                                        Subaccount subacct40 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account540.Id && x.name == "Interest Bond");

                                        Movements_Accounts _maccount540 = new Movements_Accounts();

                                        _maccount540.AccountingMovement = _accountingMovement;
                                        _maccount540.FK_Movements_Accounts_Funds = manager.Selected;
                                        _maccount540.FK_Movements_Accounts_Accounts = account540.Id;
                                        if (subacct40 != null)
                                            _maccount540.FK_Movements_Accounts_Subaccounts = subacct40.Id;
                                        _maccount540.subaccount = toPay.Id;
                                        _maccount540.subaccount_type = 9;
                                        _maccount540.debit = Math.Round(toPay.generated_bond_interest + toPay.generated_tff_interest, 2);
                                        _maccount540.credit = 0;

                                        totalPaid += _maccount540.debit;

                                        manager.My_db.Movements_Accounts.Add(_maccount540);
                                    }
                                }
                            }

                            GeneralLedgerForm gledger = new GeneralLedgerForm();
                            gledger.StartPosition = FormStartPosition.CenterScreen;
                            gledger.FromExternalOperation = true;
                            gledger.ExternalAccountMovemet = _accountingMovement;
                            gledger.ExternalCredit = totalPaid;
                            gledger.ControlBox = false;
                            gledger.ShowDialog();

                            if (!gledger.OperationCompleted)
                            {
                                throw new Exception("Ledger operation has been failed. The bonds interest payment has been rolled back.");
                            }
                        }
                        else
                        {
                            ErrorMessage.showErrorMessage(new Exception("Please, select the interest."));
                        }
                    }
                    else
                    {
                        ErrorMessage.showErrorMessage(new Exception("Account 540 not found."));
                    }
                }
                else
                {
                    ErrorMessage.showErrorMessage(new Exception("No movement allowed in closed period."));
                }
                
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsTFAMInterestPayment.cmdPay_Click: " + _ex.Message);
                ErrorMessage.showErrorMessage(_ex);
            }

            this.bondsTFAMInterestToPayTableAdapter.FillByFundId(this.fundsDBDataSet.BondsTFAMInterestToPay, manager.Selected);
        }
    }
}
