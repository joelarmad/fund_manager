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
            int investmentId = 0;
            int disbursementPaymentId = 0;
            int accountingMovementId = 0;
            decimal? account125Amount = null;
            List<int> subaccountsIds = new List<int>();
            List<decimal> subaccountAmounts = new List<decimal>();

            Account account125 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "125" && x.FK_Accounts_Funds == manager.Selected);

            try
            {
                if (account125 != null)
                {
                    account125Amount = account125.amount;

                    if (cbContract.SelectedValue != null
                        && int.TryParse(cbContract.SelectedValue.ToString(), out investmentId))
                    {
                        DisbursementPayment dPayment = new DisbursementPayment();
                        dPayment.investment_id = investmentId;
                        dPayment.payment_date = Convert.ToDateTime(dtpPayDate.Text);

                        manager.My_db.DisbursementPayments.Add(dPayment);
                        manager.My_db.SaveChanges();

                        disbursementPaymentId = dPayment.id;

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

                                    manager.My_db.SaveChanges();

                                    AccountingMovement _accountingMovement = new AccountingMovement();
                                    _accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                                    //TODO: buscar valor correcto
                                    _accountingMovement.description = "";
                                    _accountingMovement.date = dPayment.payment_date;
                                    _accountingMovement.reference = KeyDefinitions.NextAccountMovementReference;
                                    _accountingMovement.FK_AccountingMovements_Currencies = toPay.currency_id;
                                    //TODO: buscar valor correcto
                                    _accountingMovement.original_reference = "";
                                    _accountingMovement.contract = cbContract.SelectedText;

                                    manager.My_db.AccountingMovements.Add(_accountingMovement);
                                    manager.My_db.SaveChanges();

                                    accountingMovementId = _accountingMovement.Id;

                                    Currency currency = manager.My_db.Currencies.FirstOrDefault(x => x.Id == toPay.currency_id && x.FK_Currencies_Funds == manager.Selected);
                                    Subaccount subacct125 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account125.Id && x.name == "INV " + currency.symbol);

                                    Movements_Accounts _maccount125 = new Movements_Accounts();

                                    _maccount125.FK_Movements_Accounts_AccountingMovements = _accountingMovement.Id;
                                    _maccount125.FK_Movements_Accounts_Funds = manager.Selected;
                                    _maccount125.FK_Movements_Accounts_Accounts = account125.Id;
                                    if(subacct125 != null)
                                        _maccount125.FK_Movements_Accounts_Subaccounts = subacct125.Id;
                                    _maccount125.subaccount = toPay.client_id;
                                    _maccount125.subaccount_type = 1;
                                    _maccount125.debit = toPay.amount + toPay.profit_share;
                                    _maccount125.credit = 0;

                                    int _creditFactor = 1;
                                    int _debitFactor = -1;

                                    if (Account.leftAccountingIncrement(account125.type))
                                    {
                                        _creditFactor = -1;
                                        _debitFactor = 1;
                                    }

                                    account125.amount += _debitFactor * _maccount125.debit;
                                    account125.amount += _creditFactor * _maccount125.credit;

                                    _maccount125.acc_amount = account125.amount;

                                    if (subacct125 != null)
                                    {
                                        if (!subaccountsIds.Contains(subacct125.Id))
                                        {
                                            subaccountsIds.Add(subacct125.Id);
                                            subaccountAmounts.Add(subacct125.amount);
                                        }

                                        subacct125.amount += _debitFactor * _maccount125.debit;
                                        subacct125.amount += _creditFactor * _maccount125.credit;
                                        _maccount125.subacc_amount = subacct125.amount;
                                    }
                                    
                                    manager.My_db.Movements_Accounts.Add(_maccount125);

                                    manager.My_db.SaveChanges();
                                }
                            }
                        }

                        manager.My_db.SaveChanges();

                        lvDisbursements.SelectedIndices.Clear();

                        loadDisbursements();

                        GeneralLedgerForm gledger = new GeneralLedgerForm();
                        gledger.StartPosition = FormStartPosition.CenterScreen;
                        gledger.AvoidAccountBalanceValidation = true;
                        gledger.CustomReferenceInjected = cbContract.Text;
                        gledger.ShowDialog();

                        DisbursementPaymentForm disbursement_payments = new DisbursementPaymentForm();
                        disbursement_payments.paymentId = dPayment.id;
                        disbursement_payments.Show();
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

                //rollback
                try
                {
                    manager.Reset();

                    for (int i = 0; i < subaccountsIds.Count; i++)
                    {
                        int subacctId = subaccountsIds[i];

                        Subaccount subacct = manager.My_db.Subaccounts.FirstOrDefault(x => x.Id == subacctId);

                        if (subacct != null)
                        {
                            subacct.amount = subaccountAmounts[i];

                            manager.My_db.SaveChanges();
                        }
                    }

                    if (account125 != null && account125Amount.HasValue)
                    {
                        account125.amount = account125Amount.Value;

                        manager.My_db.SaveChanges();
                    }

                    DisbursementPayment disbPayment = manager.My_db.DisbursementPayments.FirstOrDefault(x => x.id == disbursementPaymentId);

                    if (disbPayment != null)
                    {
                        foreach (Disbursement disb in disbPayment.Disbursements)
                        {
                            disb.pay_date = null;
                            disb.can_generate_interest = false;

                            manager.My_db.SaveChanges();
                        }

                        disbPayment.Disbursements.Clear();

                        manager.My_db.SaveChanges();

                        manager.My_db.DisbursementPayments.Remove(disbPayment);

                        manager.My_db.SaveChanges();
                    }
                }
                catch (Exception _ex2)
                {
                    ErrorMessage.showErrorMessage(new Exception("Error rolling back operation.", _ex2));
                }
            }
        }
    }
}
