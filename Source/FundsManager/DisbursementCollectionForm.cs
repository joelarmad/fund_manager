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
        int IsBookingIndex = 10;

        public DisbursementCollectionForm()
        {
            InitializeComponent();
        }

        private void DisbursementCollectionForm_Load(object sender, EventArgs e)
        {
            this.clientsTableAdapter.Fill(this.fundsDBDataSet.Clients);

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

        private void setCollected(DisbursementBooking booking)
        {
            if (!booking.can_generate_interest)
            {
                booking.collected = true;

                List<DisbursementBooking> bookings = manager.My_db.DisbursementBookings.Where(x => x.disbursement_id == booking.disbursement_id && x.id != booking.id).ToList();

                bool collected = true;

                foreach (DisbursementBooking item in bookings)
                {
                    if (item.collected == false)
                    {
                        collected = false;
                        break;
                    }
                }

                booking.Disbursement.collected = collected;
            }
        }

        private void setCollected(Disbursement disbursement)
        {
            if (!disbursement.can_generate_interest)
            {
                if (!disbursement.has_bookings.Value)
                {
                    disbursement.collected = true;
                }
                else
                {
                    bool collected = true;

                    List<DisbursementBooking> bookings = manager.My_db.DisbursementBookings.Where(x => x.disbursement_id == disbursement.Id).ToList();

                    foreach (DisbursementBooking booking in bookings)
                    {
                        if (!booking.collected)
                        {
                            collected = false;
                            break;
                        }
                    }

                    disbursement.collected = collected;
                }
            }
        }

        private void cmdCollect_Click(object sender, EventArgs e)
        {
            try
            {
                if (manager.My_db.ClosedPeriods.FirstOrDefault(x => x.year == dtpDate.Value.Year) == null)
                {
                    List<string> rowIds = new List<string>();
                    List<decimal> amounts = new List<decimal>();
                    List<decimal> profitShares = new List<decimal>();
                    List<decimal> delayInterests = new List<decimal>();
                    List<decimal> collect125 = new List<decimal>();
                    List<decimal> collect128 = new List<decimal>();
                    List<decimal> collect130 = new List<decimal>();
                    List<bool> isBookings = new List<bool>();

                    String errors = "";

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string rowId = row.Cells[IdIndex].Value.ToString();
                        string number = row.Cells[NumberIndex].Value.ToString();
                        decimal amount = decimal.Parse(row.Cells[AmountIndex].Value.ToString());
                        decimal profitShare = decimal.Parse(row.Cells[ProfitShareIndex].Value.ToString());
                        decimal delayInterest = decimal.Parse(row.Cells[DelayInterestIndex].Value.ToString());
                        string amountToBeCollected125Str = row.Cells[CollectTo125Index].Value != null ? row.Cells[CollectTo125Index].Value.ToString() : "0";
                        string amountToBeCollected128Str = row.Cells[CollectTo128Index].Value != null ? row.Cells[CollectTo128Index].Value.ToString() : "0";
                        string amountToBeCollected130Str = row.Cells[CollectTo130Index].Value != null ? row.Cells[CollectTo130Index].Value.ToString() : "0";
                        bool isBooking = row.Cells[IsBookingIndex].Value != null ? bool.Parse(row.Cells[IsBookingIndex].Value.ToString()) : false;

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
                                    rowIds.Add(rowId);
                                    amounts.Add(amount);
                                    profitShares.Add(profitShare);
                                    delayInterests.Add(delayInterest);
                                    collect125.Add(amountToBeCollected125);
                                    collect128.Add(amountToBeCollected128);
                                    collect130.Add(amountToBeCollected130);
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
                                    accountingMovement.original_reference = cbContract.Text;
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
                                        decimal toBeCollected125 = collect125[i];
                                        decimal toBeCollected128 = collect128[i];
                                        decimal toBeCollected130 = collect130[i];
                                        bool isBooking = isBookings[i];

                                        int disbursementId = int.Parse(rowId.Split('_')[0]);
                                        int bookingId = int.Parse(rowId.Split('_')[1]);

                                        Disbursement disbursement = manager.My_db.Disbursements.FirstOrDefault(x => x.Id == disbursementId);
                                        DisbursementBooking booking = manager.My_db.DisbursementBookings.FirstOrDefault(x => x.id == bookingId);

                                        if (disbursement != null && (booking != null || !isBooking))
                                        {
                                            int currencyId = booking != null ? booking.currency_id : disbursement.currency_id;

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
                                                    BookingCollectionsDetail bookingCollectionDetail = new BookingCollectionsDetail();

                                                    if (!isBooking)
                                                    {
                                                        disbursementCollectionDetail.DisbursementCollection = collection;
                                                        disbursementCollectionDetail.disbursement_id = disbursementId;
                                                        disbursementCollectionDetail.amount_collected = Math.Round(toBeCollected125 + toBeCollected128 + toBeCollected130, 2);

                                                        if (amount - toBeCollected125 <= 0 && profitShare - toBeCollected128 <= 0 && delayInterest - toBeCollected130 <= 0)
                                                        {
                                                            setCollected(disbursement);
                                                        }

                                                        manager.My_db.DisbursementCollectionsDetails.Add(disbursementCollectionDetail);
                                                    }
                                                    else
                                                    {
                                                        bookingCollectionDetail.DisbursementCollection = collection;
                                                        bookingCollectionDetail.booking_id = bookingId;
                                                        bookingCollectionDetail.amount_collected = Math.Round(toBeCollected125 + toBeCollected128 + toBeCollected130, 2);

                                                        if (amount - toBeCollected125 <= 0 && profitShare - toBeCollected128 <= 0 && delayInterest - toBeCollected130 <= 0)
                                                        {
                                                            setCollected(booking);
                                                        }

                                                        manager.My_db.BookingCollectionsDetails.Add(bookingCollectionDetail);
                                                    }

                                                    if (toBeCollected125 > 0)
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
                                                        _maccount125.credit = Math.Round(toBeCollected125, 2);

                                                        manager.My_db.Movements_Accounts.Add(_maccount125);

                                                        if (!isBooking)
                                                        {
                                                            disbursementCollectionDetail.Movements_Accounts = _maccount125;
                                                        }
                                                        else
                                                        {
                                                            bookingCollectionDetail.Movements_Accounts = _maccount125;
                                                        }
                                                    }

                                                    if (toBeCollected128 > 0)
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
                                                        _maccount128.credit = Math.Round(toBeCollected128, 2);

                                                        manager.My_db.Movements_Accounts.Add(_maccount128);
                                                        
                                                        if (!isBooking)
                                                        {
                                                            disbursementCollectionDetail.Movements_Accounts1 = _maccount128;
                                                        }
                                                        else
                                                        {
                                                            bookingCollectionDetail.Movements_Accounts1 = _maccount128;
                                                        }
                                                    }

                                                    if (toBeCollected130 > 0)
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
                                                        _maccount130.credit = Math.Round(toBeCollected130, 2);

                                                        manager.My_db.Movements_Accounts.Add(_maccount130);

                                                        if (!isBooking)
                                                        {
                                                            disbursementCollectionDetail.Movements_Accounts2 = _maccount130;
                                                        }
                                                        else
                                                        {
                                                            bookingCollectionDetail.Movements_Accounts2 = _maccount130;
                                                        }
                                                    }

                                                    totalPaid += toBeCollected125 + toBeCollected128 + toBeCollected130;

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
                                        gledger.ControlBox = false;
                                        gledger.ShowDialog();

                                        if (!gledger.OperationCompleted)
                                        {
                                            throw new Exception("Ledger operation has been failed. The disbursements collection has been rolled back.");
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
                ErrorMessage.showErrorMessage(_ex);
            }
        }
    }
}
