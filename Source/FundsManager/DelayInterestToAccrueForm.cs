﻿using System;
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
                            String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _delayedProfitShareToAccrue.delay_interest),
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

            Account account130 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "130" && x.FK_Accounts_Funds == manager.Selected);

            Account account902 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "902" && x.FK_Accounts_Funds == manager.Selected);

            if (account130 != null && account902 != null)
            {
                try
                {
                    if (manager.My_db.ClosedPeriods.FirstOrDefault(x => x.year == dtpDate.Value.Year) == null)
                    {
                        DateTime _date = Convert.ToDateTime(dtpDate.Text);

                        List<DisbursementsBookingView> _delayedInterestToAccrueList = new List<DisbursementsBookingView>();

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
                                        _delayedInterestToAccrueList.Add(toAcrue);
                                    }

                                    if (toAcrue.new_collection_date <= toAcrue.starting_date)
                                    {
                                        errorsDetected = true;
                                        errorMessages += "\rNumber " + toAcrue.booking_number + ": collection <= stating date.";
                                    }

                                    if (toAcrue.delay_interest == 0)
                                    {
                                        errorsDetected = true;
                                        errorMessages += "\rNumber " + toAcrue.booking_number + ": delay interest = 0.";
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
                                        _delayedInterestToAccrueList.Add(toAcrue);
                                    }

                                    if (toAcrue.new_collection_date <= toAcrue.starting_date)
                                    {
                                        errorsDetected = true;
                                        errorMessages += "\rNumber " + toAcrue.booking_number + ": collection <= starting date.";
                                    }

                                    if (toAcrue.delay_interest == 0)
                                    {
                                        errorsDetected = true;
                                        errorMessages += "\rNumber " + toAcrue.booking_number + ": delay interest = 0.";
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

                        if (_delayedInterestToAccrueList.Count > 0)
                        {
                            BookingGeneratedInterest _generatedInterest = new BookingGeneratedInterest();
                            _generatedInterest.GeneratedDate = Convert.ToDateTime(dtpDate.Text);

                            bool interestCreated = false;

                            decimal _totalInterest = 0;

                            bool someDataMissed = false;

                            foreach (DisbursementsBookingView _delayedInterestToAccrue in _delayedInterestToAccrueList)
                            {
                                Currency currency = manager.My_db.Currencies.FirstOrDefault(x => x.Id == _delayedInterestToAccrue.currency_id && x.FK_Currencies_Funds == manager.Selected);
                                Subaccount subacct130 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account130.Id && x.name == "INV " + currency.symbol);

                                if (currency != null && subacct130 != null)
                                {
                                    BookingGeneratedInterestDetail interestDetail = manager.My_db.BookingGeneratedInterestDetails.FirstOrDefault(x => x.booking_id == _delayedInterestToAccrue.booking_id && x.generated_interest_date.Year == _date.Year && x.generated_interest_date.Month == _date.Month);

                                    if (interestDetail == null)
                                    {
                                        DateTime? fromDate = getLastGeneratedInterestDateFor(_delayedInterestToAccrue.booking_id);

                                        if (fromDate == null)
                                        {
                                            fromDate = _delayedInterestToAccrue.starting_date;
                                        }

                                        bool canContinueGeneratingInterest = true;

                                        decimal _interest = 0;

                                        int totalFinancingDays = (_delayedInterestToAccrue.new_collection_date.Date - _delayedInterestToAccrue.starting_date.Date).Days;

                                        DateTime toDate = dtpDate.Value <= _delayedInterestToAccrue.new_collection_date ? dtpDate.Value : _delayedInterestToAccrue.new_collection_date;

                                        int financingDays = (toDate.Date - fromDate.Value.Date).Days;

                                        if (totalFinancingDays > 0 && financingDays > 0)
                                        {
                                            decimal delayInterestPerDay = _delayedInterestToAccrue.delay_interest / totalFinancingDays;
                                            _interest = Math.Round(financingDays * delayInterestPerDay, 2);
                                        }

                                        canContinueGeneratingInterest = toDate < _delayedInterestToAccrue.new_collection_date;

                                        if (_interest > 0)
                                        {
                                            if (!interestCreated)
                                            {
                                                manager.My_db.BookingGeneratedInterests.Add(_generatedInterest);
                                                interestCreated = true;
                                            }

                                            if (!canContinueGeneratingInterest)
                                            {
                                                DisbursementBooking disbBooking = manager.My_db.DisbursementBookings.FirstOrDefault(x => x.id == _delayedInterestToAccrue.booking_id);

                                                if (disbBooking != null)
                                                {
                                                    disbBooking.can_generate_interest = false;
                                                }
                                            }

                                            _totalInterest += _interest;

                                            BookingGeneratedInterestDetail _detail = new BookingGeneratedInterestDetail();

                                            _detail.BookingGeneratedInterest = _generatedInterest;
                                            _detail.booking_id = _delayedInterestToAccrue.booking_id;
                                            _detail.generated_interest = Math.Round(_interest, 2);
                                            _detail.generated_interest_date = toDate;
                                            _detail.disbursement_id = _delayedInterestToAccrue.disbursement_id;

                                            manager.My_db.BookingGeneratedInterestDetails.Add(_detail);

                                            AccountingMovement _accountingMovement = new AccountingMovement();

                                            _accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                                            _accountingMovement.description = "";
                                            _accountingMovement.date = dtpDate.Value;
                                            _accountingMovement.reference = KeyDefinitions.NextAccountMovementReference(dtpDate.Value.Year);
                                            _accountingMovement.FK_AccountingMovements_Currencies = _delayedInterestToAccrue.currency_id;
                                            _accountingMovement.original_reference = _delayedInterestToAccrue.contract;
                                            _accountingMovement.contract = _delayedInterestToAccrue.contract;

                                            manager.My_db.AccountingMovements.Add(_accountingMovement);

                                            _detail.AccountingMovement = _accountingMovement;

                                            Movements_Accounts _maccount130 = new Movements_Accounts();

                                            _maccount130.AccountingMovement = _accountingMovement;
                                            _maccount130.FK_Movements_Accounts_Funds = manager.Selected;
                                            _maccount130.FK_Movements_Accounts_Accounts = account130.Id;
                                            if (subacct130 != null)
                                                _maccount130.FK_Movements_Accounts_Subaccounts = subacct130.Id;
                                            _maccount130.subaccount = _delayedInterestToAccrue.client_id;
                                            _maccount130.subaccount_type = 1;
                                            _maccount130.debit = Math.Round(_interest, 2);
                                            _maccount130.credit = 0;

                                            manager.My_db.Movements_Accounts.Add(_maccount130);

                                            Movements_Accounts _maccount902 = new Movements_Accounts();

                                            _maccount902.AccountingMovement = _accountingMovement;
                                            _maccount902.FK_Movements_Accounts_Funds = manager.Selected;
                                            _maccount902.FK_Movements_Accounts_Accounts = account902.Id;

                                            _maccount902.subaccount = _delayedInterestToAccrue.client_id;
                                            _maccount902.subaccount_type = 1;
                                            _maccount902.debit = 0;
                                            _maccount902.credit = Math.Round(_interest, 2);

                                            manager.My_db.Movements_Accounts.Add(_maccount902);

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
                    else
                    {
                        ErrorMessage.showErrorMessage(new Exception("No movement allowed in closed period."));
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
                ErrorMessage.showErrorMessage(new Exception("No account 130 or 902 were found."));
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
