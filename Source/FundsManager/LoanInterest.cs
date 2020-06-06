using FundsManager.Classes.Utilities;
using FundsManager.ReportForms;
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
    public partial class LoanInterest : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public LoanInterest()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                lvData.Items.Clear();

                DateTime _date = dtpDate.Value;

                List<Loans_View> _loansToAccrueList = manager.My_db.Loans_View.Where(x => (x.renegotiated == null || x.renegotiated == false) && x.generated_interest < x.interest && x.start_date <= _date).OrderBy(x => x.reference).ToList();

                foreach (Loans_View _loanToAccrue in _loansToAccrueList)
                {

                    LoanGeneratedInterestDetail interestDetail = manager.My_db.LoanGeneratedInterestDetails.FirstOrDefault(x => x.loan_id == _loanToAccrue.Id && x.generated_interest_date.Year == _date.Year && x.generated_interest_date.Month == _date.Month);

                    if (interestDetail == null)
                    {

                        string starting_date = _loanToAccrue.start_date.ToLongDateString();

                        DateTime? fromDate = getLastGeneratedInterestDateFor(_loanToAccrue.Id);

                        if (fromDate == null)
                        {
                            fromDate = _loanToAccrue.start_date;
                        }

                        DateTime toDate = dtpDate.Value <= _loanToAccrue.end_date ? dtpDate.Value : _loanToAccrue.end_date;

                        int financingDays = (toDate.Date - fromDate.Value.Date).Days;

                        string[] row = {
                            _loanToAccrue.Id.ToString(),
                            _loanToAccrue.reference,
                            String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _loanToAccrue.amount),
                            String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:N2}", _loanToAccrue.interest) + "%",
                            _loanToAccrue.start_date.ToLongDateString(),
                            _loanToAccrue.end_date.ToLongDateString(),
                            financingDays.ToString()
                        };

                        ListViewItem my_item = new ListViewItem(row);
                        lvData.Items.Add(my_item);
                    }

                }
            }
            catch (Exception)
            {

            }


        }

        private DateTime? getLastGeneratedInterestDateFor(int loanId)
        {
            try
            {
                LoanGeneratedInterestDetail interest = manager.My_db.LoanGeneratedInterestDetails.OrderByDescending(x => x.generated_interest_date).FirstOrDefault(x => x.loan_id == loanId);

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

            Account account840 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "840" && x.FK_Accounts_Funds == manager.Selected);

            Account account470 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "470" && x.FK_Accounts_Funds == manager.Selected);

            if (account840 != null && account470 != null)
            {
                try
                {
                    if (manager.My_db.ClosedPeriods.FirstOrDefault(x => x.year == dtpDate.Value.Year) == null)
                    {
                        DateTime _date = Convert.ToDateTime(dtpDate.Text);

                        List<Loans_View> _loansToAccrue = new List<Loans_View>();

                        if (!forAll)
                        {
                            foreach (ListViewItem _item in lvData.SelectedItems)
                            {
                                int loanID = 0;

                                if (int.TryParse(_item.Text, out loanID))
                                {
                                    Loans_View toAcrue = manager.My_db.Loans_View.FirstOrDefault(x => x.Id == loanID);

                                    if (toAcrue != null)
                                    {
                                        _loansToAccrue.Add(toAcrue);
                                    }

                                    if (toAcrue.end_date <= toAcrue.start_date)
                                    {
                                        errorsDetected = true;
                                        errorMessages += "\rReference " + toAcrue.reference + ": end <= start date.";
                                    }

                                    if (toAcrue.interest == 0)
                                    {
                                        errorsDetected = true;
                                        errorMessages += "\rReference " + toAcrue.reference + ": interest = 0.";
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (ListViewItem _item in lvData.Items)
                            {
                                int loanId = 0;

                                if (int.TryParse(_item.Text, out loanId))
                                {
                                    Loans_View toAcrue = manager.My_db.Loans_View.FirstOrDefault(x => x.Id == loanId);

                                    if (toAcrue != null)
                                    {
                                        _loansToAccrue.Add(toAcrue);
                                    }

                                    if (toAcrue.end_date <= toAcrue.start_date)
                                    {
                                        errorsDetected = true;
                                        errorMessages += "\rReference " + toAcrue.reference + ": end <= start date.";
                                    }

                                    if (toAcrue.interest == 0)
                                    {
                                        errorsDetected = true;
                                        errorMessages += "\rReference " + toAcrue.reference + ": interest = 0.";
                                    }
                                }
                            }
                        }

                        if (errorsDetected)
                        {
                            if (MessageBox.Show("Do you want continue?\r\rThese loans will be ignored in interest generation." + errorMessages, "Warning", MessageBoxButtons.OKCancel) != DialogResult.OK)
                            {
                                cmdGenerateInterest.Enabled = true;
                                cmdGenerateAllInterest.Enabled = true;
                                return;
                            }
                        }

                        if (_loansToAccrue.Count > 0)
                        {
                            LoanGeneratedInterest _generatedInterest = new LoanGeneratedInterest();
                            _generatedInterest.GeneratedDate = Convert.ToDateTime(dtpDate.Text);

                            bool interestCreated = false;

                            decimal _totalInterest = 0;

                            bool someDataMissed = false;

                            foreach (Loans_View _loanToAccrue in _loansToAccrue)
                            {
                                Subaccount subacct840 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account840.Id && x.name == "Interest on loan");
                                Subaccount subacct470 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account470.Id && x.name == "Interest Loan");

                                if (subacct840 != null && subacct470 != null)
                                {
                                    LoanGeneratedInterestDetail interestDetail = manager.My_db.LoanGeneratedInterestDetails.FirstOrDefault(x => x.loan_id == _loanToAccrue.Id && x.generated_interest_date.Year == _date.Year && x.generated_interest_date.Month == _date.Month);

                                    if (interestDetail == null)
                                    {
                                        DateTime? fromDate = getLastGeneratedInterestDateFor(_loanToAccrue.Id);

                                        if (fromDate == null)
                                        {
                                            fromDate = _loanToAccrue.start_date;
                                        }

                                        bool canContinueGeneratingInterest = true;

                                        decimal _interest = 0;

                                        DateTime toDate = dtpDate.Value <= _loanToAccrue.end_date ? dtpDate.Value : _loanToAccrue.end_date;

                                        int days = (toDate.Date - fromDate.Value.Date).Days;

                                        if (days > 0)
                                        {
                                            _interest = Math.Round(_loanToAccrue.amount * _loanToAccrue.interest * days / _loanToAccrue.interest_base / 100, 2);
                                        }

                                        canContinueGeneratingInterest = toDate < _loanToAccrue.end_date;

                                        if(!canContinueGeneratingInterest)
                                        {
                                            Loan loan = manager.My_db.Loans.FirstOrDefault(x => x.Id == _loanToAccrue.Id);
                                            loan.can_generate_interest = 0;
                                        }

                                        if (_interest > 0)
                                        {
                                            if (!interestCreated)
                                            {
                                                manager.My_db.LoanGeneratedInterests.Add(_generatedInterest);
                                                interestCreated = true;
                                            }

                                            _totalInterest += _interest;

                                            LoanGeneratedInterestDetail _detail = new LoanGeneratedInterestDetail();

                                            _detail.LoanGeneratedInterest = _generatedInterest;
                                            _detail.loan_id = _loanToAccrue.Id;
                                            _detail.generated_interest = Math.Round(_interest, 2);
                                            _detail.generated_interest_date = toDate;

                                            manager.My_db.LoanGeneratedInterestDetails.Add(_detail);

                                            AccountingMovement _accountingMovement = new AccountingMovement();

                                            _accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                                            _accountingMovement.description = "Loan Interest";
                                            _accountingMovement.date = dtpDate.Value;
                                            _accountingMovement.reference = KeyDefinitions.NextAccountMovementReference(dtpDate.Value.Year);
                                            _accountingMovement.FK_AccountingMovements_Currencies = _loanToAccrue.currency_id;
                                            _accountingMovement.original_reference = _loanToAccrue.reference;
                                            _accountingMovement.contract = _loanToAccrue.reference;

                                            manager.My_db.AccountingMovements.Add(_accountingMovement);

                                            _detail.AccountingMovement = _accountingMovement;

                                            Movements_Accounts _maccount840 = new Movements_Accounts();

                                            _maccount840.AccountingMovement = _accountingMovement;
                                            _maccount840.FK_Movements_Accounts_Funds = manager.Selected;
                                            _maccount840.FK_Movements_Accounts_Accounts = account840.Id;
                                            if (subacct840 != null)
                                                _maccount840.FK_Movements_Accounts_Subaccounts = subacct840.Id;
                                            _maccount840.subaccount_type = 4;
                                            _maccount840.subaccount = _loanToAccrue.lender_id;
                                            _maccount840.debit = Math.Round(_interest, 2);
                                            _maccount840.credit = 0;

                                            manager.My_db.Movements_Accounts.Add(_maccount840);

                                            Movements_Accounts _maccount470 = new Movements_Accounts();

                                            _maccount470.AccountingMovement = _accountingMovement;
                                            _maccount470.FK_Movements_Accounts_Funds = manager.Selected;
                                            _maccount470.FK_Movements_Accounts_Accounts = account470.Id;
                                            if (subacct470 != null)
                                                _maccount470.FK_Movements_Accounts_Subaccounts = subacct470.Id;
                                            _maccount470.subaccount_type = 4;
                                            _maccount470.subaccount = _loanToAccrue.lender_id;
                                            _maccount470.debit = 0;
                                            _maccount470.credit = Math.Round(_interest, 2);

                                            manager.My_db.Movements_Accounts.Add(_maccount470);

                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Attempt to duplicate loan interest generation.");
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
                                LoanGeneratedInterestForm generated_interest_form = new LoanGeneratedInterestForm();
                                generated_interest_form.generated_interest_id = _generatedInterest.Id;
                                generated_interest_form.Show();
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
                ErrorMessage.showErrorMessage(new Exception("No account 840 or 470 were found."));
            }
        }

        private void cmdGenerateAllInterest_Click(object sender, EventArgs e)
        {
            generateInterest(true);

            LoadData();
        }

        private void cmdGenerateInterest_Click(object sender, EventArgs e)
        {
            generateInterest(false);

            LoadData();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
