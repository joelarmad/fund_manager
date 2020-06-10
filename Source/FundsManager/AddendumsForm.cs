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

        public bool EditingExistingBook = false;
        public DisbursementBook BookToEdit = null;

        private DisbursementPlusAddendumsView disbPlusAddendum;
        private Disbursement disb;
        private DisbursementBooking booking;
        public String DisbursementForAddendumId = "";

        private bool fEditMode;

        private decimal fAmount = 0;
        private decimal fProfitShare = 0;
        private decimal fDelayedInterest = 0;
        private decimal fAmountRemaining = 0;
        private decimal fProfitShareRemainig = 0;
        
        private List<DisbursementBooking> bookings;
        private List<DisbursementBooking> toDelete;

        public AddendumsForm()
        {
            try
            {
                manager = MyFundsManager.SingletonInstance;
                InitializeComponent();
                bookings = new List<DisbursementBooking>();
                toDelete = new List<DisbursementBooking>();
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
                txtExchangeRate.Text = String.Format("{0:0.0000000}", 1);
                txtProfitShare.Text = String.Format("{0:0.00}", 0);
                lblTotalToBeCollected.Text = String.Format("{0:0.00}", 0);

                this.currenciesTableAdapter.Fill(this.fundsDBDataSet.Currencies);

                disbPlusAddendum = manager.My_db.DisbursementPlusAddendumsViews.FirstOrDefault(x => x.row_id == DisbursementForAddendumId);
                
                if (disbPlusAddendum != null)
                {
                    disb = manager.My_db.Disbursements.FirstOrDefault(x => x.Id == disbPlusAddendum.Id);

                    if(disbPlusAddendum.is_booking == 1)
                    {
                        booking = manager.My_db.DisbursementBookings.FirstOrDefault(x => x.id == disbPlusAddendum.booking_id);
                    }
                                        
                    if (!EditingExistingBook)
                    {
                        DisbursementsToBeCollected toBeCollected = manager.My_db.DisbursementsToBeCollecteds.FirstOrDefault(x => x.row_key == DisbursementForAddendumId);

                        if (toBeCollected != null)
                        {
                            fProfitShareRemainig = toBeCollected.profit_share - toBeCollected.profit_share_collected.Value;

                            fProfitShare = fProfitShareRemainig;

                            fAmountRemaining = toBeCollected.amount_remainig.Value;

                            fAmount = fAmountRemaining;

                            txtAmount.Text = String.Format("{0:0.00}", fAmountRemaining);

                            txtProfitShare.Text = String.Format("{0:0.00}", fProfitShareRemainig);

                            txtDelayInterest.Text = String.Format("{0:0.00}", 0);


                        }
                    }
                    //else
                    //{
                    //    if (BookToEdit != null)
                    //    {
                    //        cmdBook.Text = "Save Book";
                    //        cmdBook.Enabled = true;

                    //        bookings = manager.My_db.DisbursementBookings.Where(x => x.book_id == BookToEdit.Id).ToList();

                    //        foreach (DisbursementBooking booking in bookings)
                    //        {
                    //            fAmount += booking.amount;
                    //            fProfitShare += booking.profit_share;
                    //        }

                    //        loadBookings();
                    //    }
                    //}
                    
                    if (disbPlusAddendum.currency_id > 0)
                    {
                        for (int i = 0; i < cbCurrency.Items.Count; i++)
                        {
                            cbCurrency.SelectedIndex = i;

                            if (cbCurrency.SelectedValue.ToString() == disbPlusAddendum.currency_id.ToString())
                                break;
                        }
                    }

                    txtExchangeRate.Text = String.Format("{0:0.0000000}", disbPlusAddendum.exchange_rate);

                    txtNumber.Text = disbPlusAddendum.number.ToString();

                    calculate_total_collection();

                    lblContract.Text = disb.Investment.contract;

                    lblClient.Text = disb.Client != null ? disb.Client.name : "";

                    lblUnderLayingDebtor.Text = disb.UnderlyingDebtor != null ? disb.UnderlyingDebtor.name : "";

                    lblUnderlayingBank.Text = disb.Bank != null ? disb.Bank.name : "";

                    lblLetterOfCredit.Text = disb.Shipment != null ? disb.Shipment.letter_of_credits.Reference : "";

                    lblShipment.Text = disb.Shipment != null ? disb.Shipment.Number : "";

                    lblSector.Text = disb.Sector != null ? disb.Sector.name : "";

                    List<DisbursementItem> items = manager.My_db.DisbursementItems.Where(x => x.DisbursementId == disb.Id).ToList();

                    foreach (DisbursementItem disbItem in items)
                    {
                        lbISelectedItems.Items.Add(disbItem.Item.name);
                    }

                    dtpStartingDate.Value = disbPlusAddendum.collection_date;
                    dtpBookingDate.Value = disbPlusAddendum.collection_date;
                }
                else
                {
                    //TODO: error
                }

                checkEnablingAddBookingButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.AddendumsForm_Load: " + _ex.Message);
            }
        }

        private void calculate_total_collection()
        {
            try
            {
                decimal _amount = 0;
                decimal _profit = 0;
                decimal _exchange = 0;

                if (decimal.TryParse(txtAmount.Text, out _amount)
                    && decimal.TryParse(txtProfitShare.Text, out _profit)
                    && decimal.TryParse(txtExchangeRate.Text, out _exchange) && _exchange > 0)
                {
                    decimal toBeColected = Math.Round((_amount + _profit) / _exchange, 2);
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

        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddBookingButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.cbCurrency_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void cbCurrency_Leave(object sender, EventArgs e)
        {
            checkEnablingAddBookingButton();
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

        private void txtExchangeRate_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal _result = 0;
                if (!decimal.TryParse(txtExchangeRate.Text, out _result) || _result <= 0)
                {
                    txtExchangeRate.Text = String.Format("{0:0.0000000}", 1);
                }
                else
                {
                    txtExchangeRate.Text = String.Format("{0:0.0000000}", _result);
                }

                checkEnablingAddBookingButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.txtExchangeRate_Leave: " + _ex.Message);
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
                    cmdAddBooking.Enabled = cbCurrency.SelectedIndex >= 0
                    && txtNumber.Text.Trim() != ""
                    && _selectedAmount > 0 
                    && _selectedProfitShare >= 0
                    && _selectedDelayedInterest >= 0
                    && fAmountRemaining > 0;
                }
                else
                {
                    DisbursementBooking toModify = bookings[lvBooking.SelectedIndices[0]];

                    decimal _amount = 0;
                    decimal _profitShare = 0;
                    decimal _delayedInterest = 0;

                    foreach (DisbursementBooking booking in bookings)
                    {
                        _amount += booking.amount;
                        _profitShare += booking.profit_share;
                        _delayedInterest += booking.delay_interest;
                    }

                    _amount -= toModify.amount - _selectedAmount;
                    _profitShare -= toModify.profit_share - _selectedProfitShare;
                    _delayedInterest -= toModify.delay_interest - _selectedDelayedInterest;

                    cmdAddBooking.Enabled = cbCurrency.SelectedIndex >= 0
                    && txtNumber.Text.Trim() != ""
                    && _selectedAmount > 0
                    && _selectedProfitShare >= 0
                    && _delayedInterest >= 0
                    && fAmount - _amount >= 0
                    && fProfitShare - _profitShare >= 0;
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

                float exchangeRate = 0;

                if (float.TryParse(txtExchangeRate.Text, out exchangeRate) && exchangeRate > 0)
                {
                    if (!duplicatedBookingNumber())
                    {
                        DisbursementBooking toAdd = getBookingFromGUI();

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
                else
                {
                    MessageBox.Show("Error in exchage rate data.");
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
            foreach (DisbursementBooking disb in bookings)
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
        private DisbursementBooking getBookingFromGUI()
        {
            try
            {
                DisbursementBooking _booking = new DisbursementBooking();

                float exchangeRate = 0;

                if (float.TryParse(txtExchangeRate.Text, out exchangeRate) && exchangeRate > 0)
                {
                    if (fEditMode && lvBooking.SelectedIndices.Count > 0)
                    {
                        _booking = bookings[lvBooking.SelectedIndices[0]];
                        fAmountRemaining += _booking.amount * (decimal)_booking.exchange_rate;
                        fProfitShareRemainig += _booking.profit_share * (decimal)_booking.exchange_rate;
                    }

                    decimal amountToDecrease = Convert.ToDecimal(txtAmount.Text);
                    decimal profitShareToDecrease = Convert.ToDecimal(txtProfitShare.Text);

                    _booking.disbursement_id = disb.Id;
                    _booking.exchange_rate = exchangeRate;
                    _booking.amount = Math.Round(amountToDecrease / (decimal)exchangeRate, 2);
                    _booking.profit_share = Math.Round(Convert.ToDecimal(txtProfitShare.Text) / (decimal)exchangeRate, 2);
                    _booking.currency_id = Convert.ToInt32(cbCurrency.SelectedValue);
                    _booking.starting_date = Convert.ToDateTime(dtpStartingDate.Text);
                    _booking.collection_date = Convert.ToDateTime(dtpCollectionDate.Text);
                    _booking.number = txtNumber.Text;
                    _booking.delay_interest = Math.Round(Convert.ToDecimal(txtDelayInterest.Text), 2);

                    fAmountRemaining -= amountToDecrease;
                    fProfitShareRemainig -= profitShareToDecrease;

                    _booking.collected = false;
                    _booking.can_generate_interest = true;

                    _booking.has_booking = false;

                    if(disbPlusAddendum.is_booking == 1)
                    {
                        _booking.parent_book_id = disbPlusAddendum.booking_id;
                    }

                    return _booking;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void addBooking(DisbursementBooking toAdd)
        {
            if (toAdd != null)
            {
                int _index = -1;

                for (int i = 0; i < bookings.Count; i++)
                {
                    DisbursementBooking _item = bookings[i];

                    if (_item.starting_date > toAdd.starting_date)
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
                fDelayedInterest = 0;

                lvBooking.Items.Clear();

                Decimal total_investment = 0;
                Decimal total_profit = 0;
                Decimal total_delay_interest = 0;
                Decimal total_to_be_collected = 0;

                foreach (DisbursementBooking _booking in bookings)
                {
                    decimal _totalToBeCollected = _booking.amount + _booking.profit_share + _booking.delay_interest;

                    
                    string[] row = { _booking.number,  String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _booking.amount), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _booking.profit_share), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _booking.delay_interest), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _totalToBeCollected), _booking.collection_date.ToLongDateString() };
                    ListViewItem my_item = new ListViewItem(row);
                    lvBooking.Items.Add(my_item);

                    total_investment += _booking.amount;
                    total_profit += _booking.profit_share;
                    total_delay_interest += _booking.delay_interest;
                    total_to_be_collected += _totalToBeCollected;
                }

                if (bookings.Count > 0)
                {
                    string[] totales = { "Total", String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_investment), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_profit), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_delay_interest), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_to_be_collected) };
                    ListViewItem listViewItemTotal = new ListViewItem(totales);
                    lvBooking.Items.Add(listViewItemTotal);
                }

                fDelayedInterest = total_delay_interest;
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
            cbCurrency.SelectedIndex = 0;
            txtExchangeRate.Text = String.Format("{0:0.0000000}", 1);
            txtProfitShare.Text = String.Format("{0:0.00}", fProfitShareRemainig);
            txtDelayInterest.Text = String.Format("{0:0.00}", 0);
            txtNumber.Text = "";
            lblTotalToBeCollected.Text = String.Format("{0:0.00}", 0);
            dtpStartingDate.Value = DateTime.Now;
            dtpBookingDate.Value = DateTime.Now;
            dtpCollectionDate.Value = DateTime.Now;
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
                        DisbursementBooking selected = bookings[lvBooking.SelectedIndices[0]];
                        //TODO: validar si tiene algun cobro
                        //if (selected.pay_date.HasValue)
                        //{
                        //    lvDisbursements.SelectedIndices.Clear();
                        //    MessageBox.Show("This disbursement has been already paid.");
                        //}
                    }
                }

                if (lvBooking.SelectedIndices.Count > 0)
                {
                    fEditMode = true;
                    cmdDeleteBooking.Enabled = true;
                    cmdAddBooking.Enabled = true;
                    cmdAddBooking.Text = "Save Booking";
                    cmdCancel.Visible = true;

                    DisbursementBooking selected = bookings[lvBooking.SelectedIndices[0]];

                    txtAmount.Text = String.Format("{0:0.00}", selected.amount * (decimal)selected.exchange_rate);

                    if (selected.currency_id > 0)
                    {
                        for (int i = 0; i < cbCurrency.Items.Count; i++)
                        {
                            cbCurrency.SelectedIndex = i;

                            if (cbCurrency.SelectedValue.ToString() == selected.currency_id.ToString())
                                break;
                        }
                    }

                    txtExchangeRate.Text = String.Format("{0:0.0000000}", selected.exchange_rate);
                    txtProfitShare.Text = String.Format("{0:0.00}", selected.profit_share);
                    txtNumber.Text = selected.number;

                    calculate_total_collection();

                    dtpStartingDate.Value = selected.starting_date;
                    dtpCollectionDate.Value = selected.collection_date;
                }
                else
                {
                    fEditMode = false;
                    cmdDeleteBooking.Enabled = false;
                    cmdAddBooking.Text = "Add Booking";
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
            cmdBook.Enabled = bookings.Count > 0 && fAmountRemaining == 0 && fProfitShareRemainig == 0;
        }

        private void cmdDeleteBooking_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvBooking.SelectedIndices.Count > 0)
                {
                    DisbursementBooking booking = bookings[lvBooking.SelectedIndices[0]];
                    fAmountRemaining += booking.amount * (decimal)booking.exchange_rate;
                    fProfitShareRemainig += booking.profit_share * (decimal)booking.exchange_rate;
                    if(booking.id > 0)
                    {
                        toDelete.Add(booking);
                    }                    
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
                    AccountingMovement _accountingMovement = new AccountingMovement();
                    DisbursementBook _book = new DisbursementBook();


                    Currency currency = manager.My_db.Currencies.FirstOrDefault(x => x.Id == disbPlusAddendum.currency_id && x.FK_Currencies_Funds == manager.Selected);
                    Account account125 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "125" && x.FK_Accounts_Funds == manager.Selected);
                    Subaccount subacct125 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account125.Id && x.name == "INV " + currency.symbol);
                    Account account128 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "128" && x.FK_Accounts_Funds == manager.Selected);
                    Subaccount subacct128 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account128.Id && x.name == "INV " + currency.symbol);

                    if (account125 == null || account128 == null || subacct125 == null || subacct128 == null)
                    {
                        //TODO: Error
                        return;
                    }

                    if (EditingExistingBook)
                    {
                        if (BookToEdit == null)
                        {
                            //TODO: Error
                            return;
                        }

                        _book = BookToEdit;
                        _accountingMovement = manager.My_db.AccountingMovements.FirstOrDefault(x => x.Id == _book.accounting_movement_id);

                        if (_accountingMovement == null)
                        {
                            //TODO: error
                            return;
                        }

                        BookToEdit.Movements_Accounts.credit = fAmount;
                        //BookToEdit.Movements_Accounts128.credit = fDelayedInterest;
                        BookToEdit.Movements_Accounts1.credit = fProfitShare;

                    }
                    else
                    {
                        _accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                        _accountingMovement.description = "";
                        _accountingMovement.date = dtpBookingDate.Value.Date;
                        _accountingMovement.reference = KeyDefinitions.NextAccountMovementReference(dtpStartingDate.Value.Year);
                        _accountingMovement.FK_AccountingMovements_Currencies = disbPlusAddendum.currency_id;
                        _accountingMovement.original_reference = disb.Investment.contract;
                        _accountingMovement.contract = disb.Investment.contract;

                        manager.My_db.AccountingMovements.Add(_accountingMovement);

                        _book.date = DateTime.Now.Date;

                        _book.AccountingMovement = _accountingMovement;
                        manager.My_db.DisbursementBooks.Add(_book);

                        Movements_Accounts _maccount125 = new Movements_Accounts();

                        _maccount125.AccountingMovement = _accountingMovement;
                        _maccount125.FK_Movements_Accounts_Funds = manager.Selected;
                        _maccount125.FK_Movements_Accounts_Accounts = account125.Id;
                        if (subacct125 != null)
                            _maccount125.FK_Movements_Accounts_Subaccounts = subacct125.Id;
                        _maccount125.subaccount = disb.client_id;
                        _maccount125.subaccount_type = 1;
                        _maccount125.credit = Math.Round(fAmount, 2);
                        _maccount125.debit = 0;

                        manager.My_db.Movements_Accounts.Add(_maccount125);

                        Movements_Accounts _maccount128 = new Movements_Accounts();

                        _maccount128.AccountingMovement = _accountingMovement;
                        _maccount128.FK_Movements_Accounts_Funds = manager.Selected;
                        _maccount128.FK_Movements_Accounts_Accounts = account128.Id;
                        if (subacct128 != null)
                            _maccount128.FK_Movements_Accounts_Subaccounts = subacct128.Id;
                        _maccount128.subaccount = disb.client_id;
                        _maccount128.subaccount_type = 1;
                        _maccount128.credit = Math.Round(fDelayedInterest, 2);
                        //_maccount128.credit = Math.Round(fProfitShare, 2);
                        _maccount128.debit = 0;

                        manager.My_db.Movements_Accounts.Add(_maccount128);

                        _book.Movements_Accounts = _maccount125;
                        _book.Movements_Accounts1 = _maccount128;
                    }

                    foreach (DisbursementBooking bookingToDelete in toDelete)
                    {
                        manager.My_db.Movements_Accounts.Remove(bookingToDelete.Movements_Accounts);
                        manager.My_db.Movements_Accounts.Remove(bookingToDelete.Movements_Accounts1);

                        manager.My_db.DisbursementBookings.Remove(bookingToDelete);
                    }

                    foreach (DisbursementBooking _booking in bookings)
                    {
                        _booking.book_id = _book.Id;

                        if (_booking.id == 0)
                        {
                            Movements_Accounts _maccount125 = new Movements_Accounts();

                            _maccount125.AccountingMovement = _accountingMovement;
                            _maccount125.FK_Movements_Accounts_Funds = manager.Selected;
                            _maccount125.FK_Movements_Accounts_Accounts = account125.Id;
                            if (subacct125 != null)
                                _maccount125.FK_Movements_Accounts_Subaccounts = subacct125.Id;
                            _maccount125.subaccount = disb.client_id;
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
                            _maccount128.subaccount = disb.client_id;
                            _maccount128.subaccount_type = 1;
                            _maccount128.credit = 0;
                            _maccount128.debit = Math.Round(_booking.delay_interest, 2);
                            //_maccount128.debit = Math.Round(_booking.profit_share, 2);

                            manager.My_db.Movements_Accounts.Add(_maccount128);

                            _booking.Movements_Accounts = _maccount125;
                            _booking.Movements_Accounts1 = _maccount128;

                            manager.My_db.DisbursementBookings.Add(_booking);
                        }
                        else
                        {
                            _booking.Movements_Accounts.debit = _booking.amount;
                            _booking.Movements_Accounts1.debit = _booking.profit_share;
                        }
                    }

                    disb.has_bookings = true;

                    if (booking != null)
                    {
                        booking.has_booking = true;
                    }

                    manager.My_db.SaveChanges();

                    txtAmount.Text = "0";
                    txtNumber.Text = "";
                    txtProfitShare.Text = String.Format("{0:0.00}", 0);
                    txtExchangeRate.Text = String.Format("{0:0.0000000}", 1);
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
    }
}