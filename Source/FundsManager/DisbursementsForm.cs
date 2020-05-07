using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using FundsManager.ReportForms;
using FundsManager.Classes.Utilities;

namespace FundsManager
{
    public partial class DisbursementsForm : Form
    {
        private MyFundsManager manager;

        private string fUnpaidText = "waitting";

        public DisbursementsForm()
        {
            try
            {
                manager = MyFundsManager.SingletonInstance;
                InitializeComponent();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.DisbursementsForm: " + _ex.Message);
            }
        }

        private void DisbursementsForm_Load(object sender, EventArgs e)
        {
            
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Clients' Puede moverla o quitarla según sea necesario.
            this.clientsTableAdapter.FillByFund(this.fundsDBDataSet.Clients, manager.Selected);
           
            updateContractCombo();

            loadDisbursements();

            try
            {
                //cashAtBank = manager.My_db.Accounts.FirstOrDefault(x => x.number == "110" && x.FK_Accounts_Funds == manager.Selected);

                //if (cashAtBank != null)
                //{
                //    lblAccount.Text = cashAtBank.name;
                //    cbSubAccount.Enabled = true;
                //    cbOtherDetails.Enabled = true;
                //}

                //// TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Subaccounts' Puede moverla o quitarla según sea necesario.
                //this.subaccountsTableAdapter.FillByAccount(this.fundsDBDataSet.Subaccounts, cashAtBank.Id, manager.Selected);

                //updateOtherDetailsCombobox();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.DisbursementsForm_Load: " + _ex.Message);
            }
        }

        //private void updateOtherDetailsCombobox()
        //{
        //    int subAccountId = 0;

        //    if (cbSubAccount.SelectedValue != null && int.TryParse(cbSubAccount.SelectedValue.ToString(), out subAccountId))
        //    {
        //        // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.OtherDetails' Puede moverla o quitarla según sea necesario.
        //        this.otherDetailsTableAdapter.FillBySubaccount(this.fundsDBDataSet.OtherDetails, subAccountId, manager.Selected);
        //    }
        //}

        private void updateContractCombo()
        {
            int clientId = 0;

            if (cbClient.SelectedValue != null && int.TryParse(cbClient.SelectedValue.ToString(), out clientId))
            {
                this.clientContractsTableAdapter.FillByClient(this.fundsDBDataSet.ClientContracts, manager.Selected, clientId);
            }
        }

        //private void cbSubAccount_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    updateOtherDetailsCombobox();
        //}

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvDisbursements.SelectedIndices.Clear();
            updateContractCombo();
        }

        private void loadDisbursements()
        {
            lvDisbursements.Items.Clear();

            int clientId = 0;
            int investmentId = 0;

            if (cbClient.SelectedValue != null && cbContract.SelectedValue != null
                && int.TryParse(cbClient.SelectedValue.ToString(), out clientId)
                && int.TryParse(cbContract.SelectedValue.ToString(), out investmentId))
            {

                List<Disbursement> disbursements = manager.My_db.Disbursements.Where(x => x.investment_id == investmentId && x.client_id == clientId).ToList();

                foreach (Disbursement disbursement in disbursements)
                {
                    string paid_date = disbursement.pay_date != null ? disbursement.pay_date.Value.ToLongDateString() : fUnpaidText;
                    
                    string[] row = {
                        disbursement.Id.ToString(),
                        disbursement.number,
                        String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", disbursement.amount),
                        disbursement.collection_date.ToLongDateString(),
                        disbursement.date.ToLongDateString(),
                        paid_date
                    };
                    ListViewItem my_item = new ListViewItem(row);
                    lvDisbursements.Items.Add(my_item);
                }

                
            }

        }

        private void cbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvDisbursements.SelectedIndices.Clear();
            loadDisbursements();
        }

        private void lvDisbursements_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem _item in lvDisbursements.SelectedItems)
                {
                    if (_item.SubItems[5].Text != fUnpaidText)
                    {
                        _item.Selected = false;
                    }
                }

                cmdPay.Enabled = lvDisbursements.SelectedItems.Count > 0;
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.lvDisbursements_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void cmdPay_Click(object sender, EventArgs e)
        {
            decimal totalPaid = 0;

            int investmentId = 0;

            Account account125 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "125" && x.FK_Accounts_Funds == manager.Selected);

            AccountingMovement _accountingMovement = new AccountingMovement();

            try
            {
                if (account125 != null)
                {
                    if (cbContract.SelectedValue != null
                        && int.TryParse(cbContract.SelectedValue.ToString(), out investmentId))
                    {
                        if (lvDisbursements.SelectedItems.Count > 0)
                        {
                            DisbursementPayment dPayment = new DisbursementPayment();
                            dPayment.investment_id = investmentId;
                            dPayment.payment_date = Convert.ToDateTime(dtpPayDate.Text);

                            manager.My_db.DisbursementPayments.Add(dPayment);

                            foreach (ListViewItem _item in lvDisbursements.SelectedItems)
                            {
                                int disbursementId = 0;

                                if (int.TryParse(_item.Text, out disbursementId))
                                {
                                    Disbursement toPay = manager.My_db.Disbursements.FirstOrDefault(x => x.Id == disbursementId);

                                    if (toPay != null)
                                    {
                                        toPay.pay_date = dPayment.payment_date;
                                        toPay.can_generate_interest = true;

                                        dPayment.Disbursements.Add(toPay);

                                        if (_accountingMovement.Id == 0)
                                        {
                                            _accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                                            _accountingMovement.description = "";
                                            _accountingMovement.date = dPayment.payment_date;
                                            _accountingMovement.reference = KeyDefinitions.NextAccountMovementReference(dtpPayDate.Value.Year);
                                            _accountingMovement.FK_AccountingMovements_Currencies = toPay.currency_id;
                                            _accountingMovement.original_reference = cbContract.Text;
                                            _accountingMovement.contract = cbContract.SelectedText;

                                            manager.My_db.AccountingMovements.Add(_accountingMovement);

                                            dPayment.AccountingMovement = _accountingMovement;
                                        }

                                        Currency currency = manager.My_db.Currencies.FirstOrDefault(x => x.Id == toPay.currency_id && x.FK_Currencies_Funds == manager.Selected);
                                        Subaccount subacct125 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account125.Id && x.name == "INV " + currency.symbol);

                                        Movements_Accounts _maccount125 = new Movements_Accounts();

                                        _maccount125.AccountingMovement = _accountingMovement;
                                        _maccount125.FK_Movements_Accounts_Funds = manager.Selected;
                                        _maccount125.FK_Movements_Accounts_Accounts = account125.Id;
                                        if (subacct125 != null)
                                            _maccount125.FK_Movements_Accounts_Subaccounts = subacct125.Id;
                                        _maccount125.subaccount = toPay.client_id;
                                        _maccount125.subaccount_type = 1;
                                        _maccount125.debit = Math.Round(toPay.amount, 2);
                                        _maccount125.credit = 0;

                                        totalPaid += toPay.amount;

                                        int _creditFactor = 1;
                                        int _debitFactor = -1;

                                        if (Account.leftAccountingIncrement(account125.type))
                                        {
                                            _creditFactor = -1;
                                            _debitFactor = 1;
                                        }

                                        account125.amount += _debitFactor * _maccount125.debit;
                                        account125.amount += _creditFactor * _maccount125.credit;

                                        _maccount125.acc_amount = Math.Round(account125.amount, 2);

                                        if (subacct125 != null)
                                        {
                                            subacct125.amount += _debitFactor * _maccount125.debit;
                                            subacct125.amount += _creditFactor * _maccount125.credit;
                                            _maccount125.subacc_amount = Math.Round(subacct125.amount, 2);
                                        }

                                        manager.My_db.Movements_Accounts.Add(_maccount125);
                                    }
                                }
                            }

                            lvDisbursements.SelectedIndices.Clear();

                            GeneralLedgerForm gledger = new GeneralLedgerForm();
                            gledger.StartPosition = FormStartPosition.CenterScreen;
                            gledger.FromExternalOperation = true;
                            gledger.ExternalAccountMovemet = _accountingMovement;
                            gledger.ExternalCredit = totalPaid;
                            gledger.ControlBox = false;
                            gledger.ShowDialog();

                            if (!gledger.OperationCompleted)
                            {
                                throw new Exception("Ledger operation has been failed. The disbursements payment has been rolled back.");
                            }

                            DisbursementPaymentForm disbursement_payments = new DisbursementPaymentForm();
                            disbursement_payments.paymentId = dPayment.id;
                            disbursement_payments.Show();
                        }
                        else
                        {
                            ErrorMessage.showErrorMessage(new Exception("No disbursement to pay was selected."));
                        }
                    }
                    else
                    {
                        ErrorMessage.showErrorMessage(new Exception("No contract selected."));
                    }
                }
                else
                {
                    ErrorMessage.showErrorMessage(new Exception("Account 125 not found."));
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.cmdPay_Click: " + _ex.Message);
                ErrorMessage.showErrorMessage(_ex);
            }

            loadDisbursements();
        }
    }
}
