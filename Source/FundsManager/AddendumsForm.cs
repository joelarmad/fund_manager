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

        public int DisbursementId = 0;

        private Disbursement disbursement;
        private bool fEditMode;

        private decimal fRemaining = 0;

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
               
                // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Currencies' Puede moverla o quitarla según sea necesario.
                this.currenciesTableAdapter.Fill(this.fundsDBDataSet.Currencies);

                if (!EditingExistingBook)
                {
                    disbursement = manager.My_db.Disbursements.FirstOrDefault(x => x.Id == DisbursementId);

                    if (disbursement != null)
                    {
                        //TODO: determinar cual campo es el monto del amount
                        fRemaining = disbursement.amount;
                        txtAmount.Text = String.Format("{0:0.00}", disbursement.amount);

                        if (disbursement.currency_id > 0)
                        {
                            for (int i = 0; i < cbCurrency.Items.Count; i++)
                            {
                                cbCurrency.SelectedIndex = i;

                                if (cbCurrency.SelectedValue.ToString() == disbursement.currency_id.ToString())
                                    break;
                            }
                        }

                        txtExchangeRate.Text = String.Format("{0:0.0000000}", disbursement.exchange_rate);

                        txtProfitShare.Text = String.Format("{0:0.00}", disbursement.profit_share);

                        txtDelayInterest.Text = "0.00";

                        txtNumber.Text = disbursement.number.ToString();

                        calculate_total_collection();

                        lblContract.Text = disbursement.Investment.contract;

                        lblClient.Text = disbursement.Client != null ? disbursement.Client.name : "";

                        lblUnderLayingDebtor.Text = disbursement.UnderlyingDebtor != null ? disbursement.UnderlyingDebtor.name : "";

                        lblUnderlayingBank.Text = disbursement.Bank != null ? disbursement.Bank.name : "";

                        lblLetterOfCredit.Text = disbursement.Shipment != null ? disbursement.Shipment.letter_of_credits.Reference : "";

                        lblShipment.Text = disbursement.Shipment != null ? disbursement.Shipment.Number : "";

                        lblSector.Text = disbursement.Sector != null ? disbursement.Sector.name : "";

                        List<DisbursementItem> items = manager.My_db.DisbursementItems.Where(x => x.DisbursementId == disbursement.Id).ToList();

                        foreach (DisbursementItem disbItem in items)
                        {
                            lbISelectedItems.Items.Add(disbItem.Item.name);
                        }

                        dtpStartingDate.Value = disbursement.collection_date;
                    }
                }
                else
                {
                    if (BookToEdit != null)
                    {
                        cmdBook.Text = "Save Book";
                        cmdBook.Enabled = true;

                        bookings = manager.My_db.DisbursementBookings.Where(x => x.book_id == BookToEdit.Id).ToList();

                        loadBookings();
                    }
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
                    txtTotalToBeCollected.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", toBeColected);
                }
                else
                {
                    txtTotalToBeCollected.Text = "0.00";
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
                    txtExchangeRate.Text = "1.0000000";
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
                    txtProfitShare.Text = "0.00";
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
                decimal _amount = 0;
                decimal _profitShare = 0;

                cmdAddBooking.Enabled = cbCurrency.SelectedIndex >= 0
                    && decimal.TryParse(txtAmount.Text, out _amount)
                    && decimal.TryParse(txtProfitShare.Text, out _profitShare)
                    && txtNumber.Text.Trim() != ""
                    && (_amount > 0 || _profitShare >= 0);
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsForm.checkEnablingAddDisbursementButton: " + _ex.Message);
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
                            DisbursementBooking toDelete = bookings[lvBooking.SelectedIndices[0]];
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
                        fRemaining += _booking.amount * (decimal)_booking.exchange_rate;
                    }

                    decimal toDecrease = Convert.ToDecimal(txtAmount.Text);

                    _booking.disbursement_id = DisbursementId;
                    _booking.exchange_rate = exchangeRate;
                    _booking.amount = Math.Round(toDecrease / (decimal)exchangeRate, 2);
                    _booking.profit_share = Math.Round(Convert.ToDecimal(txtProfitShare.Text) / (decimal)exchangeRate, 2);
                    _booking.currency_id = Convert.ToInt32(cbCurrency.SelectedValue);
                    _booking.starting_date = Convert.ToDateTime(dtpStartingDate.Text);
                    _booking.collection_date = Convert.ToDateTime(dtpCollectionDate.Text);
                    _booking.number = txtNumber.Text;
                    _booking.delay_interest = Math.Round(Convert.ToDecimal(txtDelayInterest.Text), 2);

                    fRemaining -= toDecrease;

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
                lvBooking.Items.Clear();

                Decimal total_investment = 0;
                Decimal total_profit = 0;
                Decimal total_delay_interest = 0;
                Decimal total_to_be_collected = 0;

                foreach (DisbursementBooking _booking in bookings)
                {
                    decimal _totalToBeCollected = _booking.amount + _booking.profit_share;

                    
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
            txtAmount.Text = String.Format("{0:0.00}", fRemaining);
            cbCurrency.SelectedIndex = 0;
            txtExchangeRate.Text = "1.0000000";
            txtProfitShare.Text = "0.00";
            txtNumber.Text = "";
            txtTotalToBeCollected.Text = "0.00";            
            dtpStartingDate.Value = DateTime.Now;
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

                    lbISelectedItems.Items.Clear();
                    lbISelectedItems.Text = "";

                    List<DisbursementItem> items = manager.My_db.DisbursementItems.Where(x => x.DisbursementId == selected.id).ToList();

                    foreach (DisbursementItem item in items)
                    {
                        lbISelectedItems.Items.Add(item.Item.name);
                    }

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
            cmdBook.Enabled = bookings.Count > 0 && fRemaining == 0;
        }

        private void cmdDeleteBooking_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvBooking.SelectedIndices.Count > 0)
                {
                    DisbursementBooking booking = bookings[lvBooking.SelectedIndices[0]];
                    fRemaining += booking.amount * (decimal)booking.exchange_rate;
                    toDelete.Add(booking);
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
            int created_book_id = 0;

            try
            {
                DisbursementBook _newBook = new DisbursementBook();

                if (EditingExistingBook && BookToEdit != null)
                {
                    _newBook = BookToEdit;
                }
                else
                {
                    _newBook.date = DateTime.Now.Date;

                    manager.My_db.DisbursementBooks.Add(_newBook);
                    manager.My_db.SaveChanges();

                    created_book_id = _newBook.Id;
                }

                foreach (DisbursementBooking bookingToDelete in toDelete)
                {
                    if (bookingToDelete.id > 0)
                    {
                        manager.My_db.DisbursementBookings.Remove(bookingToDelete);
                        manager.My_db.SaveChanges();
                    }
                }

                foreach (DisbursementBooking _booking in bookings)
                {
                    _booking.book_id = _newBook.Id;

                    if (_booking.id == 0)
                    {
                        manager.My_db.DisbursementBookings.Add(_booking);
                    }

                    manager.My_db.SaveChanges();
                }

                manager.My_db.SaveChanges();

                txtAmount.Text = "0";
                txtNumber.Text = "";
                txtProfitShare.Text = "0.00";
                txtExchangeRate.Text = "1.0000000";
                txtTotalToBeCollected.Text = "0.00";
                lbISelectedItems.Items.Clear();
                lvBooking.Items.Clear();

                bookings.Clear();

                cmdCancel_Click(null, null);

                //TODO: mostrar reporte
                this.Close();
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);

                //rollback
                
            }
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            checkEnablingAddBookingButton();
        }
    }
}