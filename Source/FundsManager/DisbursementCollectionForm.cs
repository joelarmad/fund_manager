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
        int AmountIndex = 3;
        int ProfitShareIndex = 4;
        int DelayInterestIndex = 5;
        int OverdueIndex = 6;
        int CollectToPrincipalIndex = 7;
        int CollectToProfitShareIndex = 8;
        int CollectToDelayInterestIndex = 9;
        int CollectToOverdueIndex = 10;
        int IsBookingIndex = 11;

        public DisbursementCollectionForm()
        {
            InitializeComponent();
        }

        private void DisbursementCollectionForm_Load(object sender, EventArgs e)
        {
            this.clientsTableAdapter.FillByFund(this.fundsDBDataSet.Clients, manager.Selected);

            updateContractCombo();

            updateDisbursementList();
        }

        private void updateContractCombo()
        {
            int clientId = 0;

            if (cbClient.SelectedValue != null && int.TryParse(cbClient.SelectedValue.ToString(), out clientId))
            {
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

        private void setCollected(Disbursement disbursement)
        {
            if (!disbursement.can_generate_interest)
            {
                disbursement.collected = true;
            }
        }

        private void cmdCollect_Click(object sender, EventArgs e)
        {
            try
            {
                if (manager.My_db.ClosedPeriods.FirstOrDefault(x => x.year == dtpDate.Value.Year && x.fund_id == manager.Selected) == null)
                {
                    List<string> rowIds = new List<string>();
                    List<decimal> amounts = new List<decimal>();
                    List<decimal> profitShares = new List<decimal>();
                    List<decimal> delayInterests = new List<decimal>();
                    List<decimal> overdues = new List<decimal>();
                    List<decimal> collectPrincipal = new List<decimal>();
                    List<decimal> collectProfitShare = new List<decimal>();
                    List<decimal> collectDelayInterest = new List<decimal>();
                    List<decimal> collectOverdues = new List<decimal>();
                    List<bool> isBookings = new List<bool>();

                    String errors = "";

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string rowId = row.Cells[IdIndex].Value.ToString();
                        string number = row.Cells[NumberIndex].Value.ToString();
                        decimal amount = decimal.Parse(row.Cells[AmountIndex].Value.ToString());
                        decimal profitShare = decimal.Parse(row.Cells[ProfitShareIndex].Value.ToString());
                        decimal delayInterest = decimal.Parse(row.Cells[DelayInterestIndex].Value.ToString());
                        decimal overdue = decimal.Parse(row.Cells[OverdueIndex].Value.ToString());
                        string amountToBeCollectedPrincipalStr = row.Cells[CollectToPrincipalIndex].Value != null ? row.Cells[CollectToPrincipalIndex].Value.ToString() : "0";
                        string amountToBeCollectedProfitShareStr = row.Cells[CollectToProfitShareIndex].Value != null ? row.Cells[CollectToProfitShareIndex].Value.ToString() : "0";
                        string amountToBeCollectedDelayInterestStr = row.Cells[CollectToDelayInterestIndex].Value != null ? row.Cells[CollectToDelayInterestIndex].Value.ToString() : "0";
                        string amountToBeCollectedOverdueStr = row.Cells[CollectToOverdueIndex].Value != null ? row.Cells[CollectToOverdueIndex].Value.ToString() : "0";
                        bool isBooking = row.Cells[IsBookingIndex].Value != null ? bool.Parse(row.Cells[IsBookingIndex].Value.ToString()) : false;

                        if (amountToBeCollectedPrincipalStr != "0" || 
                            amountToBeCollectedProfitShareStr != "0" || 
                            amountToBeCollectedDelayInterestStr != "0" || 
                            amountToBeCollectedOverdueStr != "0")
                        {
                            decimal amountToBeCollectedPrincipal = 0;
                            decimal amountToBeCollectedProfitShare = 0;
                            decimal amountToBeCollectedDelayInterest = 0;
                            decimal amountToBeCollectedOverdue = 0;

                            if (decimal.TryParse(amountToBeCollectedPrincipalStr, out amountToBeCollectedPrincipal) &&
                                    decimal.TryParse(amountToBeCollectedProfitShareStr, out amountToBeCollectedProfitShare) &&
                                    decimal.TryParse(amountToBeCollectedDelayInterestStr, out amountToBeCollectedDelayInterest) &&
                                    decimal.TryParse(amountToBeCollectedOverdueStr, out amountToBeCollectedOverdue))
                            {
                                if (amount - amountToBeCollectedPrincipal >= 0 && 
                                    profitShare - amountToBeCollectedProfitShare >= 0 && 
                                    delayInterest - amountToBeCollectedDelayInterest >= 0 && 
                                    overdue - amountToBeCollectedOverdue >= 0)
                                {
                                    rowIds.Add(rowId);
                                    amounts.Add(amount);
                                    profitShares.Add(profitShare);
                                    delayInterests.Add(delayInterest);
                                    overdues.Add(overdue);
                                    collectPrincipal.Add(amountToBeCollectedPrincipal);
                                    collectProfitShare.Add(amountToBeCollectedProfitShare);
                                    collectDelayInterest.Add(amountToBeCollectedDelayInterest);
                                    collectOverdues.Add(amountToBeCollectedOverdue);
                                    isBookings.Add(isBooking);
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

                        if (rowIds.Count > 0)
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
                                    accountingMovement.description = "Disbursement Collection";
                                    accountingMovement.date = dtpDate.Value;
                                    accountingMovement.reference = KeyDefinitions.NextAccountMovementReference(dtpDate.Value.Year);
                                    accountingMovement.original_reference = cbContract.SelectedIndex > 0 ? cbContract.Text : "";
                                    accountingMovement.contract = cbContract.Text;
                                    accountingMovement.FK_AccountingMovements_Currencies = 0;

                                    bool showGL = false;
                                    decimal totalPaid = 0;

                                    for (int i = 0; i < rowIds.Count; i++)
                                    {
                                        string rowId = rowIds[i];
                                        decimal amount = amounts[i];
                                        decimal profitShare = profitShares[i];
                                        decimal delayInterest = delayInterests[i];
                                        decimal overdue = overdues[i];
                                        decimal toBeCollectedPrincipal = collectPrincipal[i];
                                        decimal toBeCollectedProfitShare = collectProfitShare[i];
                                        decimal toBeCollectedDelayInterest = collectDelayInterest[i];
                                        decimal toBeCollectedOverdue = collectOverdues[i];
                                        bool isBooking = isBookings[i];

                                        int disbursementId = int.Parse(rowId);

                                        Disbursement disbursement = manager.My_db.Disbursements.FirstOrDefault(x => x.Id == disbursementId);

                                        if (disbursement != null)
                                        {
                                            int currencyId = disbursement.currency_id;

                                            Currency currency = manager.My_db.Currencies.FirstOrDefault(x => x.Id == currencyId && x.FK_Currencies_Funds == manager.Selected);
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

                                                    DisbursementCollectionsDetail disbursementCollectionDetail = new DisbursementCollectionsDetail();

                                                    disbursementCollectionDetail.DisbursementCollection = collection;
                                                    disbursementCollectionDetail.disbursement_id = disbursementId;
                                                    disbursementCollectionDetail.amount_to_be_collected = amount + profitShare + delayInterest + overdue;
                                                    disbursementCollectionDetail.amount_collected = Math.Round(toBeCollectedPrincipal + toBeCollectedProfitShare + toBeCollectedDelayInterest + toBeCollectedOverdue, 2);
                                                    disbursementCollectionDetail.principal_to_be_collected = amount;
                                                    disbursementCollectionDetail.principal_collected = Math.Round(toBeCollectedPrincipal, 2);
                                                    disbursementCollectionDetail.profit_share_to_be_collected = profitShare;
                                                    disbursementCollectionDetail.profit_share_collected = Math.Round(toBeCollectedProfitShare, 2);
                                                    disbursementCollectionDetail.delay_interest_be_collected = delayInterest;
                                                    disbursementCollectionDetail.delay_interest_collected = Math.Round(toBeCollectedDelayInterest, 2);
                                                    disbursementCollectionDetail.overdue_to_be_collected = overdue;
                                                    disbursementCollectionDetail.overdue_collected = Math.Round(toBeCollectedOverdue, 2);

                                                    if (amount - toBeCollectedPrincipal <= 0 && 
                                                        profitShare - toBeCollectedProfitShare <= 0 && 
                                                        delayInterest - toBeCollectedDelayInterest <= 0 &&
                                                        overdue - toBeCollectedOverdue <= 0 && 
                                                        !disbursement.can_generate_interest)
                                                    {
                                                        setCollected(disbursement);
                                                    }

                                                    manager.My_db.DisbursementCollectionsDetails.Add(disbursementCollectionDetail);

                                                    if (toBeCollectedPrincipal > 0)
                                                    {
                                                        Movements_Accounts _maccount125 = new Movements_Accounts();

                                                        _maccount125.AccountingMovement = accountingMovement;
                                                        _maccount125.FK_Movements_Accounts_Funds = manager.Selected;
                                                        _maccount125.FK_Movements_Accounts_Accounts = account125.Id;
                                                        if (subacct125 != null)
                                                            _maccount125.FK_Movements_Accounts_Subaccounts = subacct125.Id;
                                                        _maccount125.subaccount = disbursement.client_id;
                                                        _maccount125.subaccount_type = 1;
                                                        _maccount125.debit = 0;
                                                        _maccount125.credit = Math.Round(toBeCollectedPrincipal, 2);

                                                        manager.My_db.Movements_Accounts.Add(_maccount125);

                                                        disbursementCollectionDetail.Movements_Accounts = _maccount125;
                                                    }

                                                    if (toBeCollectedProfitShare > 0)
                                                    {
                                                        Movements_Accounts _maccount128 = new Movements_Accounts();

                                                        _maccount128.AccountingMovement = accountingMovement;
                                                        _maccount128.FK_Movements_Accounts_Funds = manager.Selected;
                                                        _maccount128.FK_Movements_Accounts_Accounts = account128.Id;
                                                        if (subacct128 != null)
                                                            _maccount128.FK_Movements_Accounts_Subaccounts = subacct128.Id;
                                                        _maccount128.subaccount = disbursement.client_id;
                                                        _maccount128.subaccount_type = 1;
                                                        _maccount128.debit = 0;
                                                        _maccount128.credit = Math.Round(toBeCollectedProfitShare, 2);

                                                        manager.My_db.Movements_Accounts.Add(_maccount128);

                                                        disbursementCollectionDetail.Movements_Accounts1 = _maccount128;
                                                    }

                                                    if (toBeCollectedDelayInterest > 0 | toBeCollectedOverdue > 0)
                                                    {
                                                        Movements_Accounts _maccount130 = new Movements_Accounts();

                                                        _maccount130.AccountingMovement = accountingMovement;
                                                        _maccount130.FK_Movements_Accounts_Funds = manager.Selected;
                                                        _maccount130.FK_Movements_Accounts_Accounts = account130.Id;
                                                        if (subacct130 != null)
                                                            _maccount130.FK_Movements_Accounts_Subaccounts = subacct130.Id;
                                                        _maccount130.subaccount = disbursement.client_id;
                                                        _maccount130.subaccount_type = 1;
                                                        _maccount130.debit = 0;
                                                        _maccount130.credit = Math.Round(toBeCollectedDelayInterest + toBeCollectedOverdue, 2);

                                                        manager.My_db.Movements_Accounts.Add(_maccount130);

                                                        disbursementCollectionDetail.Movements_Accounts2 = _maccount130;
                                                    }

                                                    totalPaid += toBeCollectedPrincipal + toBeCollectedProfitShare + toBeCollectedDelayInterest + toBeCollectedOverdue;

                                                    showGL = true;
                                                }
                                                else
                                                {
                                                    msg += "\rSome sub account is missing. No collection has been generated for disbursement with Id=\"" + disbursementId + "\".";
                                                }
                                            }
                                            else
                                            {
                                                msg += "\rCurrency is missing. No collection has been generated for disbursement with Id=\"" + disbursementId + "\".";
                                            }
                                        }
                                        else
                                        {
                                            msg += "\rDisbursement with Id=\"" + disbursementId.ToString() + "\" not found.";
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
                                        gledger.ShowDialog();

                                        if (!gledger.OperationCompleted)
                                        {
                                            throw new Exception("Ledger window has been closed. The operation has been rolled back.");
                                        }

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
                else
                {
                    ErrorMessage.showErrorMessage(new Exception("No movement allowed in closed period."));
                }
                
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex, false);
            }
        }
    }
}
