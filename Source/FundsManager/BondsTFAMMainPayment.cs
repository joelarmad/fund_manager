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
    public partial class BondsTFAMMainPayment : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public BondsTFAMMainPayment()
        {
            InitializeComponent();
        }

        private void BondsTFAMMainPayment_Load(object sender, EventArgs e)
        {
            this.bondsTFAMTableAdapter.FillByPayment(this.fundsDBDataSet.BondsTFAM, manager.Selected);
        }

        private void cmdPay_Click(object sender, EventArgs e)
        {
            decimal totalPaid = 0;

            Account account540 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "540" && x.FK_Accounts_Funds == manager.Selected);

            AccountingMovement _accountingMovement = new AccountingMovement();

            try
            {
                if (account540 != null)
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        foreach (DataGridViewRow _item in dataGridView1.SelectedRows)
                        {
                            int bondId = 0;

                            if (int.TryParse(_item.Cells[0].Value.ToString(), out bondId))
                            {
                                BondsTFAM toPay = manager.My_db.BondsTFAMs.FirstOrDefault(x => x.Id == bondId);

                                if (toPay != null)
                                {
                                    toPay.payment_date = dtpDate.Value;
                                    toPay.paid = 1;

                                    _accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                                    _accountingMovement.description = toPay.number + " Payment";
                                    _accountingMovement.date = toPay.payment_date.Value;
                                    _accountingMovement.reference = KeyDefinitions.NextAccountMovementReference(toPay.payment_date.Value.Year);
                                    _accountingMovement.FK_AccountingMovements_Currencies = toPay.currency_id;
                                    _accountingMovement.original_reference = "";
                                    _accountingMovement.contract = "";

                                    manager.My_db.AccountingMovements.Add(_accountingMovement);

                                    toPay.AccountingMovement1 = _accountingMovement;

                                    Subaccount subacct33 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account540.Id && x.name == "Principal Bonds");

                                    Movements_Accounts _maccount540 = new Movements_Accounts();

                                    _maccount540.AccountingMovement = _accountingMovement;
                                    _maccount540.FK_Movements_Accounts_Funds = manager.Selected;
                                    _maccount540.FK_Movements_Accounts_Accounts = account540.Id;
                                    if (subacct33 != null)
                                        _maccount540.FK_Movements_Accounts_Subaccounts = subacct33.Id;
                                    //TODO: other details
                                    //_maccount540.subaccount = toPay.client_id;
                                    //_maccount540.subaccount_type = 1;
                                    _maccount540.debit = Math.Round(toPay.amount, 2);
                                    _maccount540.credit = 0;

                                    totalPaid += toPay.amount;
                                    
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
                            throw new Exception("Ledger operation has been failed. The bonds payment has been rolled back.");
                        }
                    }
                    else
                    {
                        ErrorMessage.showErrorMessage(new Exception("Please, select the bonds."));
                    }
                }
                else
                {
                    ErrorMessage.showErrorMessage(new Exception("Account 540 not found."));
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsTFAMMainPayment.cmdPay_Click: " + _ex.Message);
                ErrorMessage.showErrorMessage(_ex);
            }

            this.bondsTFAMTableAdapter.FillByPayment(this.fundsDBDataSet.BondsTFAM, manager.Selected);
        }
    }
}
