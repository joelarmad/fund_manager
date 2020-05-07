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
    public partial class DisbursementCollectionForm : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        int IdIndex = 0;
        int NumberIndex = 1;
        int CollectionDateIndex = 2;
        int DisbursementIndex = 3;
        int AmountIndex = 4;
        int ProfitShareIndex = 5;
        int DelayInterestIndex = 6;
        int CollectTo125Index = 7;
        int CollectTo128Index = 8;
        int CollectTo130Index = 9;

        public DisbursementCollectionForm()
        {
            InitializeComponent();
        }

        private void DisbursementCollectionForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Clients' Puede moverla o quitarla según sea necesario.
            this.clientsTableAdapter.Fill(this.fundsDBDataSet.Clients);

            updateContractCombo();

            updateDisbursementList();
        }

        private void updateContractCombo()
        {
            int clientId = 0;

            if (cbClient.SelectedValue != null && int.TryParse(cbClient.SelectedValue.ToString(), out clientId))
            {
                // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.ClientContracts' Puede moverla o quitarla según sea necesario.
                this.clientContractsTableAdapter.FillByClient(this.fundsDBDataSet.ClientContracts, manager.Selected, clientId);
            }
        }

        private void updateDisbursementList()
        {
            try
            {
                if (cbContract.SelectedValue != null)
                {
                    string contract = ((FundsManager.FundsDBDataSet.ClientContractsRow)((System.Data.DataRowView)cbContract.SelectedItem).Row).contract;

                    if (contract != "")
                    {
                        // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.DisbursementsToBeCollected' Puede moverla o quitarla según sea necesario.
                        this.disbursementsToBeCollectedTableAdapter.FillByContract(this.fundsDBDataSet.DisbursementsToBeCollected, contract, manager.Selected);
                    }
                }
            }
            catch (Exception)
            {
            }
            
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateContractCombo();

            updateDisbursementList();
        }

        private void cbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDisbursementList();
        }

        private void cmdCollect_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> ids = new List<int>();
                List<decimal> amounts = new List<decimal>();
                List<decimal> profitShares = new List<decimal>();
                List<decimal> delayInterests = new List<decimal>();
                List<decimal> collect125 = new List<decimal>();
                List<decimal> collect128 = new List<decimal>();
                List<decimal> collect130 = new List<decimal>();

                String errors = "";

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int id = int.Parse(row.Cells[IdIndex].Value.ToString());
                    string number = row.Cells[NumberIndex].Value.ToString();
                    decimal amount = decimal.Parse(row.Cells[AmountIndex].Value.ToString());
                    decimal profitShare = decimal.Parse(row.Cells[ProfitShareIndex].Value.ToString());
                    decimal delayInterest = decimal.Parse(row.Cells[DelayInterestIndex].Value.ToString());
                    string amountToBeCollected125Str = row.Cells[CollectTo125Index].Value != null ? row.Cells[CollectTo125Index].Value.ToString() : "0";
                    string amountToBeCollected128Str = row.Cells[CollectTo128Index].Value != null ? row.Cells[CollectTo128Index].Value.ToString() : "0";
                    string amountToBeCollected130Str = row.Cells[CollectTo130Index].Value != null ? row.Cells[CollectTo130Index].Value.ToString() : "0";
                    
                    if (amountToBeCollected125Str != "0" || amountToBeCollected128Str != "0" || amountToBeCollected130Str != "0")
                    {
                        decimal amountToBeCollected125 = 0;
                        decimal amountToBeCollected128 = 0;
                        decimal amountToBeCollected130 = 0;

                        if (decimal.TryParse(amountToBeCollected125Str, out amountToBeCollected125) &&
                                decimal.TryParse(amountToBeCollected128Str, out amountToBeCollected128) &&
                                decimal.TryParse(amountToBeCollected130Str, out amountToBeCollected130))
                        {
                            if (amount - amountToBeCollected125 >= 0 && profitShare - amountToBeCollected128 >= 0 && delayInterest - amountToBeCollected130 >= 0)
                            {
                                ids.Add(id);
                                amounts.Add(amount);
                                profitShares.Add(profitShare);
                                delayInterests.Add(delayInterest);
                                collect125.Add(amountToBeCollected125);
                                collect128.Add(amountToBeCollected128);
                                collect130.Add(amountToBeCollected130);
                            }
                            else
                            {
                                errors += "\r\tDisbursement " + number + " has too much collection value.";
                            }
                        }
                        else
                        {
                            errors += "\r  Disbursement " + number + " has wrong collection value.";
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

                    if (ids.Count > 0)
                    {
                        DisbursementCollection collection = new DisbursementCollection();
                        collection.collection_date = dtpDate.Value;
                        collection.investment_id = cbContract.SelectedValue != null ? int.Parse(cbContract.SelectedValue.ToString()) : 0;

                        Account account125 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "125" && x.FK_Accounts_Funds == manager.Selected);
                        Account account128 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "128" && x.FK_Accounts_Funds == manager.Selected);
                        Account account130 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "130" && x.FK_Accounts_Funds == manager.Selected);

                        if (collection.investment_id > 0)
                        {
                            if (account125 != null && account128 != null && account130 != null)
                            {
                                manager.My_db.DisbursementCollections.Add(collection);

                                AccountingMovement accountingMovement = new AccountingMovement();

                                accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                                accountingMovement.description = "";
                                accountingMovement.date = dtpDate.Value;
                                accountingMovement.reference = KeyDefinitions.NextAccountMovementReference(dtpDate.Value.Year);
                                accountingMovement.original_reference = cbContract.Text;
                                accountingMovement.contract = cbContract.Text;
                                accountingMovement.FK_AccountingMovements_Currencies = 0;

                                bool showGL = false;
                                decimal totalPaid = 0;

                                for (int i = 0; i < ids.Count; i++)
                                {
                                    int disbId = ids[i];
                                    decimal amount = amounts[i];
                                    decimal profitShare = profitShares[i];
                                    decimal delayInterest = delayInterests[i];
                                    decimal toBeCollected125 = collect125[i];
                                    decimal toBeCollected128 = collect128[i];
                                    decimal toBeCollected130 = collect130[i];

                                    Disbursement disb = manager.My_db.Disbursements.FirstOrDefault(x => x.Id == disbId);

                                    if (disb != null)
                                    {
                                        Currency currency = manager.My_db.Currencies.FirstOrDefault(x => x.Id == disb.currency_id && x.FK_Currencies_Funds == manager.Selected);
                                        Subaccount subacct125 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account125.Id && x.name == "INV " + currency.symbol);
                                        Subaccount subacct128 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account128.Id && x.name == "INV " + currency.symbol);
                                        Subaccount subacct130 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account130.Id && x.name == "INV " + currency.symbol);

                                        if (currency != null)
                                        {   
                                            if (subacct125 != null && subacct128 != null && subacct130 != null)
                                            {
                                                if (accountingMovement.FK_AccountingMovements_Currencies == 0)
                                                {
                                                    accountingMovement.FK_AccountingMovements_Currencies = currency.Id;

                                                    manager.My_db.AccountingMovements.Add(accountingMovement);

                                                    collection.AccountingMovement = accountingMovement;
                                                }

                                                DisbursementCollectionsDetail collectionDetail = new DisbursementCollectionsDetail();

                                                collectionDetail.DisbursementCollection = collection;
                                                collectionDetail.disbursement_id = disbId;
                                                collectionDetail.amount_collected = Math.Round(toBeCollected125 + toBeCollected128 + toBeCollected130, 2);

                                                if (amount - toBeCollected125 <= 0 && profitShare - toBeCollected128 <= 0 && delayInterest - toBeCollected130 <= 0)
                                                {
                                                    disb.collected = true;
                                                }

                                                manager.My_db.DisbursementCollectionsDetails.Add(collectionDetail);

                                                Movements_Accounts _maccount125 = new Movements_Accounts();

                                                _maccount125.AccountingMovement = accountingMovement;
                                                _maccount125.FK_Movements_Accounts_Funds = manager.Selected;
                                                _maccount125.FK_Movements_Accounts_Accounts = account125.Id;
                                                if (subacct125 != null)
                                                    _maccount125.FK_Movements_Accounts_Subaccounts = subacct125.Id;
                                                _maccount125.subaccount = disb.client_id;
                                                _maccount125.subaccount_type = 1;
                                                _maccount125.debit = 0;
                                                _maccount125.credit = Math.Round(toBeCollected125, 2);

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

                                                subacct125.amount += _debitFactor * _maccount125.debit;
                                                subacct125.amount += _creditFactor * _maccount125.credit;
                                                _maccount125.subacc_amount = Math.Round(subacct125.amount, 2);

                                                manager.My_db.Movements_Accounts.Add(_maccount125);

                                                collectionDetail.Movements_Accounts = _maccount125;

                                                Movements_Accounts _maccount128 = new Movements_Accounts();

                                                _maccount128.AccountingMovement = accountingMovement;
                                                _maccount128.FK_Movements_Accounts_Funds = manager.Selected;
                                                _maccount128.FK_Movements_Accounts_Accounts = account128.Id;
                                                if (subacct128 != null)
                                                    _maccount128.FK_Movements_Accounts_Subaccounts = subacct128.Id;
                                                _maccount128.subaccount = disb.client_id;
                                                _maccount128.subaccount_type = 1;
                                                _maccount128.debit = 0;
                                                _maccount128.credit = Math.Round(toBeCollected128, 2);

                                                _creditFactor = 1;
                                                _debitFactor = -1;

                                                if (Account.leftAccountingIncrement(account128.type))
                                                {
                                                    _creditFactor = -1;
                                                    _debitFactor = 1;
                                                }

                                                account128.amount += _debitFactor * _maccount128.debit;
                                                account128.amount += _creditFactor * _maccount128.credit;

                                                _maccount128.acc_amount = Math.Round(account128.amount, 2);

                                                subacct128.amount += _debitFactor * _maccount128.debit;
                                                subacct128.amount += _creditFactor * _maccount128.credit;
                                                _maccount128.subacc_amount = Math.Round(subacct128.amount, 2);

                                                manager.My_db.Movements_Accounts.Add(_maccount128);

                                                collectionDetail.Movements_Accounts1 = _maccount128;

                                                Movements_Accounts _maccount130 = new Movements_Accounts();

                                                _maccount130.AccountingMovement = accountingMovement;
                                                _maccount130.FK_Movements_Accounts_Funds = manager.Selected;
                                                _maccount130.FK_Movements_Accounts_Accounts = account130.Id;
                                                if (subacct130 != null)
                                                    _maccount130.FK_Movements_Accounts_Subaccounts = subacct130.Id;
                                                _maccount130.subaccount = disb.client_id;
                                                _maccount130.subaccount_type = 1;
                                                _maccount130.debit = 0;
                                                _maccount130.credit = Math.Round(toBeCollected130, 2);

                                                _creditFactor = 1;
                                                _debitFactor = -1;

                                                if (Account.leftAccountingIncrement(account130.type))
                                                {
                                                    _creditFactor = -1;
                                                    _debitFactor = 1;
                                                }

                                                account130.amount += _debitFactor * _maccount130.debit;
                                                account130.amount += _creditFactor * _maccount130.credit;

                                                _maccount130.acc_amount = Math.Round(account130.amount, 2);

                                                subacct130.amount += _debitFactor * _maccount130.debit;
                                                subacct130.amount += _creditFactor * _maccount130.credit;
                                                _maccount130.subacc_amount = Math.Round(subacct130.amount, 2);

                                                manager.My_db.Movements_Accounts.Add(_maccount130);

                                                collectionDetail.Movements_Accounts2 = _maccount130;

                                                totalPaid += toBeCollected125 + toBeCollected128 + toBeCollected130;

                                                showGL = true;
                                            }
                                            else
                                            {
                                                msg += "\rSome sub account is missing. No collection has been generated for disbursement with Id=\"" + disbId + "\".";
                                            }
                                        }
                                        else
                                        {
                                            msg += "\rCurrency is missing. No collection has been generated for disbursement with Id=\"" + disbId + "\".";
                                        }
                                    }
                                    else
                                    {
                                        msg += "\rDisbursement with Id=\"" + disbId.ToString() + "\" not found.";
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
                                    gledger.ExternalDebit = totalPaid;
                                    gledger.ControlBox = false;
                                    gledger.ShowDialog();

                                    if (!gledger.OperationCompleted)
                                    {
                                        throw new Exception("Ledger operation has been failed. The disbursements collection has been rolled back.");
                                    }

                                    //TODO: mostrar reporte
                                }
                            }
                            else
                            {
                                ErrorMessage.showErrorMessage(new Exception("Account 125, 128 or 130 is missing."));
                            }
                        }
                        else
                        {
                            ErrorMessage.showErrorMessage(new Exception("No investment found for this contract."));
                        }
                    }
                    else
                    {
                        ErrorMessage.showErrorMessage(new Exception("No disbursement found."));
                    }
                }

                updateDisbursementList();
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }
    }
}
