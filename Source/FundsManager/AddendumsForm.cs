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
    public partial class AddendumsForm : Form
    {
        private MyFundsManager manager;

        public List<Disbursement> disbursementForAddendumGroup = new List<Disbursement>();
        
        Investment investment;
        int currencyId = 0;
        int clientId = 0;
        int? underlayingDebtor = null;
        int? bankRiskId = null;
        int sectorId = 0;
        DateTime? payDate = null;
        int? shipmentId = null;

        private bool fEditMode;
        
        private decimal fAmountRemaining = 0;
        private decimal fProfitShareRemainig = 0;

        private List<Disbursement> bookings;

        public AddendumsForm()
        {
            try
            {
                manager = MyFundsManager.SingletonInstance;
                InitializeComponent();
                bookings = new List<Disbursement>();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.AddendumsForm: " + _ex.Message);
            }
        }

        private void AddendumsForm_Load(object sender, EventArgs e)
        {

            try
            {
                bool guiInitialized = false;

                txtProfitShare.Text = String.Format("{0:0.00}", 0);
                lblTotalToBeCollected.Text = String.Format("{0:0.00}", 0);

                this.currenciesTableAdapter.Fill(this.fundsDBDataSet.Currencies);

                foreach (Disbursement item in disbursementForAddendumGroup)
                {
                    int disbId = item.Id;

                    DisbursementsToBeCollected toBeCollected = manager.My_db.DisbursementsToBeCollecteds.FirstOrDefault(x => x.disbursement_id == disbId);

                    if (toBeCollected != null)
                    {
                        fProfitShareRemainig += toBeCollected.profit_share - toBeCollected.profit_share_collected.Value;

                        fAmountRemaining += toBeCollected.amount_remainig.Value;

                        if (!guiInitialized)
                        {
                            guiInitialized = true;

                            investment = item.Investment;
                            clientId = item.client_id;
                            currencyId = manager.My_db.Currencies.FirstOrDefault(x => x.symbol == "EUR").Id;
                            underlayingDebtor = item.underlying_debtor_id;
                            bankRiskId = item.bank_risk_id;
                            sectorId = item.sector_id;
                            payDate = item.pay_date;
                            shipmentId = item.shipment_id;
                            
                            txtNumber.Text = item.number.ToString();                            

                            lblContract.Text = item.Investment.contract;

                            lblClient.Text = clientId > 0 ? manager.My_db.Clients.FirstOrDefault(x => x.Id == clientId).name : "";

                            lblUnderLayingDebtor.Text = underlayingDebtor > 0 ? manager.My_db.UnderlyingDebtors.FirstOrDefault(x => x.Id == underlayingDebtor).name : "";

                            lblUnderlayingBank.Text = bankRiskId > 0 ? manager.My_db.Banks.FirstOrDefault(x => x.Id == bankRiskId).name : "";

                            lblLetterOfCredit.Text = shipmentId > 0 ? manager.My_db.Shipments.FirstOrDefault(x => x.Id == shipmentId).letter_of_credits.Reference : "";

                            lblShipment.Text = shipmentId > 0 ? manager.My_db.Shipments.FirstOrDefault(x => x.Id == shipmentId).Value.ToString() : "";

                            lblSector.Text = sectorId > 0 ? manager.My_db.Sectors.FirstOrDefault(x => x.Id == sectorId).name : "";

                            List<DisbursementItem> items = manager.My_db.DisbursementItems.Where(x => x.DisbursementId == item.Id).ToList();

                            foreach (DisbursementItem disbItem in items)
                            {
                                lbISelectedItems.Items.Add(disbItem.Item.name);
                            }

                            dtpStartingDate.Value = item.collection_date;
                            dtpBookingDate.Value = item.collection_date;
                        }
                    }
                }

                txtAmount.Text = String.Format("{0:0.00}", fAmountRemaining);

                txtProfitShare.Text = String.Format("{0:0.00}", fProfitShareRemainig);

                txtDelayInterest.Text = String.Format("{0:0.00}", 0);

                calculate_total_collection();

                checkEnablingAddBookingButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.AddendumsForm_Load: " + _ex.Message);
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void calculate_total_collection()
        {
            try
            {
                decimal _amount = 0;
                decimal _profit = 0;
                decimal _delayInterest = 0;

                if (decimal.TryParse(txtAmount.Text, out _amount)
                    && decimal.TryParse(txtProfitShare.Text, out _profit)
                    && decimal.TryParse(txtDelayInterest.Text, out _delayInterest))
                {
                    decimal toBeColected = Math.Round(_amount + _profit + _delayInterest, 2);
                    lblTotalToBeCollected.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", toBeColected);
                }
                else
                {
                    lblTotalToBeCollected.Text = String.Format("{0:0.00}", 0);
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.calculate_total_collection: " + _ex.Message);
            }
        }
        

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                calculate_total_collection();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.txtAmount_KeyUp: " + _ex.Message);
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal _result = 0;
                if (!decimal.TryParse(txtAmount.Text, out _result) || _result <= 0)
                {
                    txtAmount.Text = "0";
                }
                else
                {
                    txtAmount.Text = String.Format("{0:0.00}", _result);
                }

                checkEnablingAddBookingButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.txtAmount_Leave: " + _ex.Message);
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddBookingButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.txtAmount_TextChanged: " + _ex.Message);
            }
        }

        private void txtAmount_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void txtExchangeRate_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                calculate_total_collection();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.txtExchangeRate_KeyUp: " + _ex.Message);
            }
        }

        private void txtExchangeRate_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void txtProfitShare_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void txtProfitShare_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal _result = 0;
                if (!decimal.TryParse(txtProfitShare.Text, out _result) || _result < 0)
                {
                    txtProfitShare.Text = String.Format("{0:0.00}", 0);
                }
                else
                {
                    txtProfitShare.Text = String.Format("{0:0.00}", _result);
                }

                checkEnablingAddBookingButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.txtProfitShare_Leave: " + _ex.Message);
            }
        }

        private void txtProfitShare_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                calculate_total_collection();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.txtProfitShare_KeyUp: " + _ex.Message);
            }
        }

        private void txtProfitShare_TextChanged(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddBookingButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.txtProfitShare_TextChanged: " + _ex.Message);
            }
        }
        private void txtNumber_Leave(object sender, EventArgs e)
        {
            checkEnablingAddBookingButton();
        }
        private void checkEnablingAddBookingButton()
        {
            try
            {
                decimal _selectedAmount = decimal.Parse(txtAmount.Text);
                decimal _selectedProfitShare = decimal.Parse(txtProfitShare.Text);
                decimal _selectedDelayedInterest = decimal.Parse(txtDelayInterest.Text);

                if (!fEditMode)
                {
                    cmdAddBooking.Enabled = txtNumber.Text.Trim() != ""
                    && _selectedAmount >= 0 
                    && _selectedProfitShare >= 0
                    && _selectedDelayedInterest >= 0
                    && (_selectedAmount > 0 || _selectedProfitShare > 0 || _selectedDelayedInterest > 0);
                }
                else
                {
                    Disbursement toModify = bookings[lvBooking.SelectedIndices[0]];

                    decimal _amount = 0;
                    decimal _profitShare = 0;
                    decimal _delayedInterest = 0;

                    foreach (Disbursement booking in bookings)
                    {
                        _amount += booking.amount;
                        _profitShare += booking.profit_share;
                        _delayedInterest += booking.delay_interest ?? 0;
                    }

                    _amount -= toModify.amount - _selectedAmount;
                    _profitShare -= toModify.profit_share - _selectedProfitShare;
                    _delayedInterest -= (toModify.delay_interest ?? 0) - _selectedDelayedInterest;

                    cmdAddBooking.Enabled = txtNumber.Text.Trim() != ""
                    && _selectedAmount >= 0
                    && _selectedProfitShare >= 0
                    && _delayedInterest >= 0
                    && (_selectedAmount > 0 || _selectedProfitShare > 0 || _selectedDelayedInterest > 0)
                    && fAmountRemaining - _amount >= 0
                    && fProfitShareRemainig - _profitShare >= 0
                    ;
                }
                
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.checkEnablingAddDisbursementButton: " + _ex.Message);
                cmdAddBooking.Enabled = false;
            }
        }

        private void cmdAddBooking_Click(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddBookingButton();

                if (!cmdAddBooking.Enabled)
                {
                    return;
                }

                if (!duplicatedBookingNumber())
                {
                    Disbursement toAdd = getBookingFromGUI();

                    if (fEditMode)
                    {
                        bookings.RemoveAt(lvBooking.SelectedIndices[0]);
                    }

                    addBooking(toAdd);

                    loadBookings();

                    cmdCancel_Click(null, null);

                    checkEnablingBookButton();
                }
                else
                {
                    MessageBox.Show("Duplicated disbursement number.");
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.cmdAddBooking_Click: " + _ex.Message);
            }

            checkEnablingAddBookingButton();

            calculate_total_collection();
        }

        private bool duplicatedBookingNumber()
        {
            int i = 0;
            foreach (Disbursement disb in bookings)
            {
                if (disb.number == txtNumber.Text)
                {
                    if (!fEditMode)
                    {
                        return true;
                    }
                    else
                    {
                        if (i != lvBooking.SelectedIndices[0])
                        {
                            return true;
                        }
                    }
                }

                i++;
            }

            return false;
        }

        private Disbursement getBookingFromGUI()
        {
            try
            {
                Disbursement _booking = new Disbursement();

                _booking.fund_id = manager.Selected;
                _booking.investment_id = investment.Id;
                _booking.contract = investment.contract;
                _booking.is_booking = true;
                _booking.client_id = clientId;
                _booking.currency_id = currencyId;
                _booking.exchange_rate = 1;
                _booking.underlying_debtor_id = underlayingDebtor;
                _booking.bank_risk_id = bankRiskId;
                _booking.sector_id = sectorId;
                _booking.pay_date = payDate;
                _booking.shipment_id = shipmentId;

                if (fEditMode && lvBooking.SelectedIndices.Count > 0)
                {
                    _booking = bookings[lvBooking.SelectedIndices[0]];
                    fAmountRemaining += _booking.amount;
                    fProfitShareRemainig += _booking.profit_share;
                }

                decimal amountToDecrease = Convert.ToDecimal(txtAmount.Text);
                decimal profitShareToDecrease = Convert.ToDecimal(txtProfitShare.Text);
                decimal delayInterest = Convert.ToDecimal(txtDelayInterest.Text);

                _booking.amount = Math.Round(amountToDecrease, 2);
                _booking.profit_share = Math.Round(profitShareToDecrease, 2);
                _booking.date = Convert.ToDateTime(dtpStartingDate.Text);
                _booking.collection_date = Convert.ToDateTime(dtpCollectionDate.Text);
                _booking.number = txtNumber.Text;
                _booking.delay_interest = Math.Round(delayInterest, 2);

                fAmountRemaining -= amountToDecrease;
                fProfitShareRemainig -= profitShareToDecrease;

                _booking.collected = false;
                _booking.can_generate_interest = true;

                _booking.has_bookings = false;

                return _booking;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void addBooking(Disbursement toAdd)
        {
            if (toAdd != null)
            {
                int _index = -1;

                for (int i = 0; i < bookings.Count; i++)
                {
                    Disbursement _item = bookings[i];

                    if (_item.date > toAdd.date)
                    {
                        bookings.Insert(i, toAdd);
                        _index = i;
                        break;
                    }
                }

                if (_index == -1)
                {
                    bookings.Add(toAdd);
                }
            }
        }

        private void loadBookings()
        {
            try
            {
                lvBooking.Items.Clear();

                Decimal total_investment = 0;
                Decimal total_profit = 0;
                Decimal total_delay_interest = 0;
                Decimal total_to_be_collected = 0;

                foreach (Disbursement _booking in bookings)
                {
                    decimal _totalToBeCollected = _booking.amount + _booking.profit_share + _booking.delay_interest ?? 0;

                    
                    string[] row = { _booking.number,  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _booking.amount), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _booking.profit_share), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _booking.delay_interest), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _totalToBeCollected), _booking.collection_date.ToLongDateString() };
                    ListViewItem my_item = new ListViewItem(row);
                    lvBooking.Items.Add(my_item);

                    total_investment += _booking.amount;
                    total_profit += _booking.profit_share;
                    total_delay_interest += _booking.delay_interest ?? 0;
                    total_to_be_collected += _totalToBeCollected;
                }

                if (bookings.Count > 0)
                {
                    string[] totales = { "Total", String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_investment), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_profit), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_delay_interest), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_to_be_collected) };
                    ListViewItem listViewItemTotal = new ListViewItem(totales);
                    lvBooking.Items.Add(listViewItemTotal);
                }
            }
            catch (Exception)
            {

            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            lvBooking.SelectedIndices.Clear();
            lvBooking_SelectedIndexChanged(null, null);
            cmdAddBooking.Enabled = false;
            txtAmount.Text = String.Format("{0:0.00}", fAmountRemaining);
            txtProfitShare.Text = String.Format("{0:0.00}", fProfitShareRemainig);
            txtDelayInterest.Text = String.Format("{0:0.00}", 0);
            txtNumber.Text = "";
            lblTotalToBeCollected.Text = String.Format("{0:0.00}", 0);
            cmdDeleteBooking.Enabled = false;
        }

        private void lvBooking_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvBooking.SelectedIndices.Count > 0)
                {
                    if (lvBooking.SelectedIndices[0] == lvBooking.Items.Count - 1)
                    {
                        lvBooking.SelectedIndices.Clear();
                    }
                    else
                    {
                        Disbursement selected = bookings[lvBooking.SelectedIndices[0]];
                    }
                }

                if (lvBooking.SelectedIndices.Count > 0)
                {
                    fEditMode = true;
                    cmdDeleteBooking.Enabled = true;
                    cmdAddBooking.Enabled = false;
                    cmdCancel.Visible = true;

                    Disbursement selected = bookings[lvBooking.SelectedIndices[0]];

                    txtAmount.Text = String.Format("{0:0.00}", selected.amount);
                                        
                    txtProfitShare.Text = String.Format("{0:0.00}", selected.profit_share);
                    txtDelayInterest.Text = String.Format("{0:0.00}", selected.delay_interest);
                    txtNumber.Text = selected.number;

                    calculate_total_collection();

                    dtpStartingDate.Value = selected.date;
                    dtpCollectionDate.Value = selected.collection_date;
                }
                else
                {
                    fEditMode = false;
                    cmdDeleteBooking.Enabled = false;
                    cmdCancel.Visible = false;
                }

                checkEnablingAddBookingButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.lvBooking_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void checkEnablingBookButton()
        {
            cmdBook.Enabled = bookings.Count > 0 && Math.Round(fAmountRemaining, 2) == 0 && Math.Round(fProfitShareRemainig, 2) == 0;
        }

        private void cmdDeleteBooking_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvBooking.SelectedIndices.Count > 0)
                {
                    Disbursement booking = bookings[lvBooking.SelectedIndices[0]];
                    fAmountRemaining += booking.amount;
                    fProfitShareRemainig += booking.profit_share;                 
                    bookings.RemoveAt(lvBooking.SelectedIndices[0]);
                }

                loadBookings();

                checkEnablingBookButton();

                cmdCancel_Click(null, null);
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.cmdDeleteBooking_Click: " + _ex.Message);
            }
        }

        private void cmdBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (manager.My_db.ClosedPeriods.FirstOrDefault(x => x.year == dtpBookingDate.Value.Year) == null)
                {
                    decimal totalAmount = bookings.Sum(x => x.amount);
                    decimal totalProfitShare = bookings.Sum(x => x.profit_share);

                    AccountingMovement _accountingMovement = new AccountingMovement();
                    DisbursementBook _book = new DisbursementBook();
                    
                    Currency currency = manager.My_db.Currencies.FirstOrDefault(x => x.Id == currencyId && x.FK_Currencies_Funds == manager.Selected);
                    Account account125 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "125" && x.FK_Accounts_Funds == manager.Selected);
                    Subaccount subacct125 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account125.Id && x.name == "INV " + currency.symbol);
                    Account account128 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "128" && x.FK_Accounts_Funds == manager.Selected);
                    Subaccount subacct128 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account128.Id && x.name == "INV " + currency.symbol);

                    if (account125 == null || account128 == null || subacct125 == null || subacct128 == null)
                    {
                        //TODO: Error
                        return;
                    }

                    _accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                    _accountingMovement.description = "";
                    _accountingMovement.date = dtpBookingDate.Value.Date;
                    _accountingMovement.reference = KeyDefinitions.NextAccountMovementReference(dtpBookingDate.Value.Year);
                    _accountingMovement.FK_AccountingMovements_Currencies = currencyId;
                    _accountingMovement.original_reference = investment.contract;
                    _accountingMovement.contract = investment.contract;

                    manager.My_db.AccountingMovements.Add(_accountingMovement);

                    _book.date = DateTime.Now.Date;

                    _book.AccountingMovement = _accountingMovement;
                    manager.My_db.DisbursementBooks.Add(_book);

                    Movements_Accounts _maccount125_total = new Movements_Accounts();

                    _maccount125_total.AccountingMovement = _accountingMovement;
                    _maccount125_total.FK_Movements_Accounts_Funds = manager.Selected;
                    _maccount125_total.FK_Movements_Accounts_Accounts = account125.Id;
                    if (subacct125 != null)
                        _maccount125_total.FK_Movements_Accounts_Subaccounts = subacct125.Id;
                    _maccount125_total.subaccount = clientId;
                    _maccount125_total.subaccount_type = 1;
                    _maccount125_total.credit = totalAmount;
                    _maccount125_total.debit = 0;

                    manager.My_db.Movements_Accounts.Add(_maccount125_total);

                    Movements_Accounts _maccount128_total = new Movements_Accounts();

                    _maccount128_total.AccountingMovement = _accountingMovement;
                    _maccount128_total.FK_Movements_Accounts_Funds = manager.Selected;
                    _maccount128_total.FK_Movements_Accounts_Accounts = account128.Id;
                    if (subacct128 != null)
                        _maccount128_total.FK_Movements_Accounts_Subaccounts = subacct128.Id;
                    _maccount128_total.subaccount = clientId;
                    _maccount128_total.subaccount_type = 1;
                    _maccount128_total.credit = totalProfitShare;
                    _maccount128_total.debit = 0;

                    manager.My_db.Movements_Accounts.Add(_maccount128_total);

                    _book.Movements_Accounts = _maccount125_total;
                    _book.Movements_Accounts1 = _maccount128_total;

                    int plus = 1;

                    foreach (Disbursement _booking in bookings)
                    {
                        _booking.book_id = _book.Id;

                        Movements_Accounts _maccount125 = new Movements_Accounts();

                        _maccount125.AccountingMovement = _accountingMovement;
                        _maccount125.FK_Movements_Accounts_Funds = manager.Selected;
                        _maccount125.FK_Movements_Accounts_Accounts = account125.Id;
                        if (subacct125 != null)
                            _maccount125.FK_Movements_Accounts_Subaccounts = subacct125.Id;
                        _maccount125.subaccount = clientId;
                        _maccount125.subaccount_type = 1;
                        _maccount125.credit = 0;
                        _maccount125.debit = Math.Round(_booking.amount, 2);

                        manager.My_db.Movements_Accounts.Add(_maccount125);

                        Movements_Accounts _maccount128 = new Movements_Accounts();

                        _maccount128.AccountingMovement = _accountingMovement;
                        _maccount128.FK_Movements_Accounts_Funds = manager.Selected;
                        _maccount128.FK_Movements_Accounts_Accounts = account128.Id;
                        if (subacct128 != null)
                            _maccount128.FK_Movements_Accounts_Subaccounts = subacct128.Id;
                        _maccount128.subaccount = clientId;
                        _maccount128.subaccount_type = 1;
                        _maccount128.credit = 0;
                        _maccount128.debit = Math.Round(_booking.profit_share, 2);

                        manager.My_db.Movements_Accounts.Add(_maccount128);

                        _booking.Movements_Accounts = _maccount125;
                        _booking.Movements_Accounts1 = _maccount128;

                        int? groupId = manager.My_db.Disbursements.Max(x => x.group_id);

                        if (!groupId.HasValue)
                        {
                            groupId = 1;
                        }

                        groupId += plus;

                        plus++;

                        _booking.group_id = groupId;

                        manager.My_db.Disbursements.Add(_booking);
                    }

                    int groupParentId = 0;

                    if (disbursementForAddendumGroup.Count == 1)
                    {
                        groupParentId = disbursementForAddendumGroup.ElementAt(0).group_id.Value;
                    }
                    else
                    {
                        int? maxGroupId = manager.My_db.Disbursements.Max(x => x.group_id);

                        if (!maxGroupId.HasValue)
                        {
                            maxGroupId = 1;
                        }

                        groupParentId = maxGroupId.Value + bookings.Count + 1;
                    }

                    foreach (Disbursement item in disbursementForAddendumGroup)
                    {
                        item.has_bookings = true;
                        item.group_id = groupParentId;
                    }

                    foreach (Disbursement item in bookings)
                    {
                        item.DisbursementBook = _book;
                        item.group_parent_id = groupParentId;
                    }

                    manager.My_db.SaveChanges();

                    txtAmount.Text = "0";
                    txtNumber.Text = "";
                    txtProfitShare.Text = String.Format("{0:0.00}", 0);
                    lblTotalToBeCollected.Text = String.Format("{0:0.00}", 0);
                    lbISelectedItems.Items.Clear();
                    lvBooking.Items.Clear();

                    bookings.Clear();

                    cmdCancel_Click(null, null);

                    this.Close();
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

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            checkEnablingAddBookingButton();
        }

        private void txtDelayInterest_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void txtDelayInterest_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal _result = 0;
                if (!decimal.TryParse(txtDelayInterest.Text, out _result) || _result < 0)
                {
                    txtDelayInterest.Text = String.Format("{0:0.00}", 0);
                }
                else
                {
                    txtDelayInterest.Text = String.Format("{0:0.00}", _result);
                }

                checkEnablingAddBookingButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.txtDelayInterest_Leave: " + _ex.Message);
            }
        }

        private void txtDelayInterest_TextChanged(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddBookingButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.txtProfitShare_TextChanged: " + _ex.Message);
            }
        }

        private void txtDelayInterest_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                calculate_total_collection();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.txtDelayInterest_KeyUp: " + _ex.Message);
            }
        }
    }
}