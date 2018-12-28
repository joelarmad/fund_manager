using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FundsManager.ReportForms;
using FundsManager.Classes.Utilities;

namespace FundsManager
{
    public partial class DelayInterestToAccrueForm : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public DelayInterestToAccrueForm()
        {
            InitializeComponent();

            loadBookings();
        }

        private void loadBookings()
        {
            try
            {
                lvBookings.Items.Clear();

                DateTime _date = dtpDate.Value;

                List<DisbursementsBookingView> _delayedProfitShareToAccrueList = manager.My_db.DisbursementsBookingViews.Where(x => x.starting_date <= _date).OrderBy(x => x.contract).ToList();

                foreach (DisbursementsBookingView _delayedProfitShareToAccrue in _delayedProfitShareToAccrueList)
                {

                    BookingGeneratedInterestDetail interestDetail = manager.My_db.BookingGeneratedInterestDetails.FirstOrDefault(x => x.booking_id == _delayedProfitShareToAccrue.booking_id && x.generated_interest_date.Year == _date.Year && x.generated_interest_date.Month == _date.Month);

                    if (interestDetail == null)
                    {

                        string starting_date = _delayedProfitShareToAccrue.starting_date.ToLongDateString();

                        DateTime? fromDate = getLastGeneratedInterestDateFor(_delayedProfitShareToAccrue.booking_id);

                        if (fromDate == null)
                        {
                            fromDate = _delayedProfitShareToAccrue.starting_date;
                        }

                        DateTime toDate = dtpDate.Value <= _delayedProfitShareToAccrue.new_collection_date ? dtpDate.Value : _delayedProfitShareToAccrue.new_collection_date;

                        int financingDays = (toDate.Date - fromDate.Value.Date).Days;
                        
                        string[] row = {
                            _delayedProfitShareToAccrue.booking_id.ToString(),
                            _delayedProfitShareToAccrue.contract,
                            _delayedProfitShareToAccrue.booking_number,
                            String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _delayedProfitShareToAccrue.profit_share),
                            _delayedProfitShareToAccrue.new_collection_date.ToLongDateString(),
                            starting_date,
                            financingDays.ToString()
                        };

                        ListViewItem my_item = new ListViewItem(row);
                        lvBookings.Items.Add(my_item);
                    }
                    
                }
            }
            catch (Exception)
            {

            }
            

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private DateTime? getLastGeneratedInterestDateFor(int bookingId)
        {
            try
            {
                BookingGeneratedInterestDetail interest = manager.My_db.BookingGeneratedInterestDetails.OrderByDescending(x => x.generated_interest_date).FirstOrDefault(x => x.booking_id == bookingId);

                if (interest != null)
                {
                    return interest.generated_interest_date;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void generateInterest(bool forAll)
        {
            bool errorsDetected = false;
            string errorMessages = "";

            cmdGenerateInterest.Enabled = false;
            cmdGenerateAllInterest.Enabled = false;

            Account account128 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "128" && x.FK_Accounts_Funds == manager.Selected);

            Account account901 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "901" && x.FK_Accounts_Funds == manager.Selected);

            if (account128 != null && account901 != null)
            {
                try
                {
                    DateTime _date = Convert.ToDateTime(dtpDate.Text);

                    List<DisbursementsBookingView> _delayedProfitShareToAccrueList = new List<DisbursementsBookingView>();

                    if (!forAll)
                    {
                        foreach (ListViewItem _item in lvBookings.SelectedItems)
                        {
                            int bookingId = 0;

                            if (int.TryParse(_item.Text, out bookingId))
                            {
                                DisbursementsBookingView toAcrue = manager.My_db.DisbursementsBookingViews.FirstOrDefault(x => x.booking_id == bookingId);

                                if (toAcrue != null)
                                {
                                    _delayedProfitShareToAccrueList.Add(toAcrue);
                                }

                                if (toAcrue.new_collection_date <= toAcrue.starting_date)
                                {
                                    errorsDetected = true;
                                    errorMessages += "\rNumber " + toAcrue.booking_number + ": collection <= stating date.";
                                }

                                if (toAcrue.profit_share == 0)
                                {
                                    errorsDetected = true;
                                    errorMessages += "\rNumber " + toAcrue.booking_number + ": profit share = 0.";
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (ListViewItem _item in lvBookings.Items)
                        {
                            int bookingId = 0;

                            if (int.TryParse(_item.Text, out bookingId))
                            {
                                DisbursementsBookingView toAcrue = manager.My_db.DisbursementsBookingViews.FirstOrDefault(x => x.booking_id == bookingId);

                                if (toAcrue != null)
                                {
                                    _delayedProfitShareToAccrueList.Add(toAcrue);
                                }

                                if (toAcrue.new_collection_date <= toAcrue.starting_date)
                                {
                                    errorsDetected = true;
                                    errorMessages += "\rNumber " + toAcrue.booking_number + ": collection <= starting date.";
                                }

                                if (toAcrue.profit_share == 0)
                                {
                                    errorsDetected = true;
                                    errorMessages += "\rNumber " + toAcrue.booking_number + ": profit share = 0.";
                                }
                            }
                        }
                    }

                    if (errorsDetected)
                    {
                        if (MessageBox.Show("Do you want continue?\r\rThese bookings will be ignored in interest generation." + errorMessages, "Warning", MessageBoxButtons.OKCancel) != DialogResult.OK)
                        {
                            cmdGenerateInterest.Enabled = true;
                            cmdGenerateAllInterest.Enabled = true;
                            return;
                        }
                    }

                    if (_delayedProfitShareToAccrueList.Count > 0)
                    {
                        BookingGeneratedInterest _generatedInterest = new BookingGeneratedInterest();
                        _generatedInterest.GeneratedDate = Convert.ToDateTime(dtpDate.Text);

                        bool interestCreated = false;

                        decimal _totalInterest = 0;

                        bool someDataMissed = false;

                        foreach (DisbursementsBookingView _delayedProfitShareToAccrue in _delayedProfitShareToAccrueList)
                        {
                            Currency currency = manager.My_db.Currencies.FirstOrDefault(x => x.Id == _delayedProfitShareToAccrue.currency_id && x.FK_Currencies_Funds == manager.Selected);
                            Subaccount subacct128 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account128.Id && x.name == "INV " + currency.symbol);

                            if (currency != null && subacct128 != null)
                            {
                                BookingGeneratedInterestDetail interestDetail = manager.My_db.BookingGeneratedInterestDetails.FirstOrDefault(x => x.booking_id == _delayedProfitShareToAccrue.booking_id && x.generated_interest_date.Year == _date.Year && x.generated_interest_date.Month == _date.Month);

                                if (interestDetail == null)
                                {     
                                    DateTime? fromDate = getLastGeneratedInterestDateFor(_delayedProfitShareToAccrue.booking_id);

                                    if (fromDate == null)
                                    {
                                        fromDate = _delayedProfitShareToAccrue.starting_date;
                                    }
                                    
                                    bool canContinueGeneratingInterest = true;

                                    decimal _interest = 0;

                                    int totalFinancingDays = (_delayedProfitShareToAccrue.new_collection_date.Date - _delayedProfitShareToAccrue.starting_date.Date).Days;

                                    DateTime toDate = dtpDate.Value <= _delayedProfitShareToAccrue.new_collection_date ? dtpDate.Value : _delayedProfitShareToAccrue.new_collection_date;

                                    int financingDays = (toDate.Date - fromDate.Value.Date).Days;

                                    if (totalFinancingDays > 0 && financingDays > 0)
                                    {
                                        decimal profitSharePerDay = _delayedProfitShareToAccrue.profit_share / totalFinancingDays;
                                        _interest = Math.Round(financingDays * profitSharePerDay, 2);
                                    }

                                    canContinueGeneratingInterest = toDate < _delayedProfitShareToAccrue.new_collection_date;

                                    if (_interest > 0)
                                    {
                                        if (!interestCreated)
                                        {
                                            manager.My_db.BookingGeneratedInterests.Add(_generatedInterest);
                                            interestCreated = true;
                                        }

                                        if (!canContinueGeneratingInterest)
                                        {
                                            DisbursementBooking disbBooking = manager.My_db.DisbursementBookings.FirstOrDefault(x => x.id == _delayedProfitShareToAccrue.booking_id);

                                            if (disbBooking != null)
                                            {
                                                disbBooking.can_generate_interest = false;
                                            }
                                        }

                                        _totalInterest += _interest;

                                        BookingGeneratedInterestDetail _detail = new BookingGeneratedInterestDetail();

                                        _detail.BookingGeneratedInterest = _generatedInterest;
                                        _detail.booking_id = _delayedProfitShareToAccrue.booking_id;
                                        _detail.generated_interest = Math.Round(_interest, 2);
                                        _detail.generated_interest_date = toDate;

                                        manager.My_db.BookingGeneratedInterestDetails.Add(_detail);

                                        AccountingMovement _accountingMovement = new AccountingMovement();

                                        _accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                                        _accountingMovement.description = "";
                                        _accountingMovement.date = dtpDate.Value;
                                        _accountingMovement.reference = KeyDefinitions.NextAccountMovementReference;
                                        _accountingMovement.FK_AccountingMovements_Currencies = _delayedProfitShareToAccrue.currency_id;
                                        _accountingMovement.original_reference = _delayedProfitShareToAccrue.contract;
                                        _accountingMovement.contract = _delayedProfitShareToAccrue.contract;

                                        manager.My_db.AccountingMovements.Add(_accountingMovement);

                                        _detail.AccountingMovement = _accountingMovement;

                                        Movements_Accounts _maccount128 = new Movements_Accounts();

                                        _maccount128.AccountingMovement = _accountingMovement;
                                        _maccount128.FK_Movements_Accounts_Funds = manager.Selected;
                                        _maccount128.FK_Movements_Accounts_Accounts = account128.Id;
                                        if (subacct128 != null)
                                            _maccount128.FK_Movements_Accounts_Subaccounts = subacct128.Id;
                                        _maccount128.subaccount = _delayedProfitShareToAccrue.client_id;
                                        _maccount128.subaccount_type = 1;
                                        _maccount128.debit = Math.Round(_interest, 2);
                                        _maccount128.credit = 0;

                                        int _creditFactor = 1;
                                        int _debitFactor = -1;

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

                                        Movements_Accounts _maccount901 = new Movements_Accounts();

                                        _maccount901.AccountingMovement = _accountingMovement;
                                        _maccount901.FK_Movements_Accounts_Funds = manager.Selected;
                                        _maccount901.FK_Movements_Accounts_Accounts = account901.Id;

                                        _maccount901.subaccount = _delayedProfitShareToAccrue.client_id;
                                        _maccount901.subaccount_type = 1;
                                        _maccount901.debit = 0;
                                        _maccount901.credit = Math.Round(_interest, 2);

                                        _creditFactor = 1;
                                        _debitFactor = -1;

                                        if (Account.leftAccountingIncrement(account901.type))
                                        {
                                            _creditFactor = -1;
                                            _debitFactor = 1;
                                        }

                                        account901.amount += _debitFactor * _maccount901.debit;
                                        account901.amount += _creditFactor * _maccount901.credit;

                                        _maccount901.acc_amount = Math.Round(account901.amount, 2);

                                        manager.My_db.Movements_Accounts.Add(_maccount901);
                                        
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Attempt to duplicate booking interest generation.");
                                }
                            }
                            else
                            {
                                someDataMissed = true;
                            }
                        }

                        manager.My_db.SaveChanges();

                        if (someDataMissed)
                        {
                            ErrorMessage.showErrorMessage(new Exception("Some interests has not been generated dued missing related data. \rPlease, contact with your system administrator in order to find and fix missed data."));
                        }

                        if (interestCreated)
                        {
                            BookingGeneratedInterestForm disbursement_generated_interest_form = new BookingGeneratedInterestForm();
                            disbursement_generated_interest_form.generated_interest_id = _generatedInterest.Id;
                            disbursement_generated_interest_form.Show();
                        }
                        else
                        {
                            MessageBox.Show("No actions performed.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("No disbursement found for interest generation.");
                    }

                }
                catch (Exception _ex)
                {
                    ErrorMessage.showErrorMessage(_ex);
                }

                cmdGenerateInterest.Enabled = true;
                cmdGenerateAllInterest.Enabled = true;
            }
            else
            {
                ErrorMessage.showErrorMessage(new Exception("No account 128 or 901 were found."));
            }
        }

        private void cmdGenerateAllInterest_Click(object sender, EventArgs e)
        {
            generateInterest(true);

            loadBookings();
        }

        private void cmdGenerateInterest_Click(object sender, EventArgs e)
        {
            generateInterest(false);

            loadBookings();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            loadBookings();
        }

        private void ProfitShareToAccrueForm_Load(object sender, EventArgs e)
        {

        }
    }
}
