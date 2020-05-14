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
    public partial class BondsTFAMActivation : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public BondsTFAMActivation()
        {
            InitializeComponent();
        }

        private void BondsTFAMActivation_Load(object sender, EventArgs e)
        {
            this.bondsTFAMTableAdapter.FillByActivation(this.fundsDBDataSet.BondsTFAM, manager.Selected);
        }

        private void cmdActivate_Click(object sender, EventArgs e)
        {
            try
            {
                if (manager.My_db.ClosedPeriods.FirstOrDefault(x => x.year == dtpActivationDate.Value.Year) == null)
                {
                    if (cbBond.SelectedItem != null)
                    {
                        int bondId = int.Parse(cbBond.SelectedValue.ToString());

                        BondsTFAM bond = manager.My_db.BondsTFAMs.FirstOrDefault(x => x.Id == bondId);

                        if (bond != null)
                        {
                            Account account540 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "540" && x.FK_Accounts_Funds == manager.Selected);

                            if (account540 != null)
                            {
                                AccountingMovement _accountingMovement = new AccountingMovement();

                                _accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                                _accountingMovement.description = bond.number + " Activation";
                                _accountingMovement.date = dtpActivationDate.Value;
                                _accountingMovement.reference = KeyDefinitions.NextAccountMovementReference(dtpActivationDate.Value.Year);
                                _accountingMovement.FK_AccountingMovements_Currencies = bond.currency_id;
                                _accountingMovement.original_reference = "";
                                _accountingMovement.contract = "";

                                manager.My_db.AccountingMovements.Add(_accountingMovement);

                                bond.AccountingMovement = _accountingMovement;
                                bond.active = 1;
                                bond.can_generate_interest = 1;

                                Subaccount subacct = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account540.Id && x.name == "Principal Bonds");

                                Movements_Accounts _maccount = new Movements_Accounts();

                                _maccount.AccountingMovement = _accountingMovement;
                                _maccount.FK_Movements_Accounts_Funds = manager.Selected;
                                _maccount.FK_Movements_Accounts_Accounts = account540.Id;
                                if (subacct != null)
                                    _maccount.FK_Movements_Accounts_Subaccounts = subacct.Id;
                                _maccount.subaccount = bond.Id;
                                _maccount.subaccount_type = 9;
                                _maccount.debit = 0;
                                _maccount.credit = Math.Round(bond.amount, 2);

                                manager.My_db.Movements_Accounts.Add(_maccount);

                                GeneralLedgerForm gledger = new GeneralLedgerForm();
                                gledger.StartPosition = FormStartPosition.CenterScreen;
                                gledger.FromExternalOperation = true;
                                gledger.ExternalAccountMovemet = _accountingMovement;
                                gledger.ExternalDebit = bond.amount;
                                gledger.ControlBox = false;
                                gledger.ShowDialog();

                                if (!gledger.OperationCompleted)
                                {
                                    throw new Exception("Ledger operation has been failed. The bond activation has been rolled back.");
                                }
                            }
                            else
                            {
                                ErrorMessage.showErrorMessage(new Exception("Account 540 not found."));
                            }
                        }
                    }

                    this.bondsTFAMTableAdapter.FillByActivation(this.fundsDBDataSet.BondsTFAM, manager.Selected);
                }
                else
                {
                    ErrorMessage.showErrorMessage(new Exception("No movement allowed in closed period."));
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsTFAMActivation.cmdActivate_Click: " + _ex.Message);
                ErrorMessage.showErrorMessage(_ex);
            }
        }
    }
}
