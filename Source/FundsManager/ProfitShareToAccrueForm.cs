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
    public partial class ProfitShareToAccrueForm : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public ProfitShareToAccrueForm()
        {
            InitializeComponent();

            loadDisbursements();
        }

        private void loadDisbursements()
        {
            try
            {
                lvDisbursements.Items.Clear();

                DateTime _date = dtpDate.Value;

                List<ProfitShareToAccrue> _profitShareToAccrueList = manager.My_db.ProfitShareToAccrues.Where(x => x.pay_date <= _date && x.fund_id == manager.Selected).OrderBy(x => x.contract).ToList();

                foreach (ProfitShareToAccrue _profitShareToAccrue in _profitShareToAccrueList)
                {

                    DisbursementGeneratedInterestDetail interestDetail = manager.My_db.DisbursementGeneratedInterestDetails.FirstOrDefault(x => x.disbursement_id == _profitShareToAccrue.Id && x.generated_interest_date.Year == _date.Year && x.generated_interest_date.Month == _date.Month);

                    if (interestDetail == null)
                    {

                        string paid_date = _profitShareToAccrue.pay_date != null ? _profitShareToAccrue.pay_date.Value.ToLongDateString() : "";
                        
                        DateTime? fromDate = getLastGeneratedInterestDateFor(_profitShareToAccrue.Id);

                        if (fromDate == null)
                        {
                            fromDate = _profitShareToAccrue.pay_date;
                        }

                        DateTime toDate = dtpDate.Value <= _profitShareToAccrue.collection_date ? dtpDate.Value : _profitShareToAccrue.collection_date;

                        int financingDays = (toDate.Date - fromDate.Value.Date).Days;
                        
                        string[] row = {
                            _profitShareToAccrue.Id.ToString(),
                            _profitShareToAccrue.contract,
                            _profitShareToAccrue.number,
                            String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _profitShareToAccrue.profit_share),
                            _profitShareToAccrue.collection_date.ToLongDateString(),
                            paid_date,
                            financingDays.ToString()
                        };

                        ListViewItem my_item = new ListViewItem(row);
                        lvDisbursements.Items.Add(my_item);
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

        private DateTime? getLastGeneratedInterestDateFor(int disbursementId)
        {
            try
            {
                DisbursementGeneratedInterestDetail interest = manager.My_db.DisbursementGeneratedInterestDetails.OrderByDescending(x => x.generated_interest_date).FirstOrDefault(x => x.disbursement_id == disbursementId);

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
                    if (manager.My_db.ClosedPeriods.FirstOrDefault(x => x.year == dtpDate.Value.Year && x.fund_id == manager.Selected) == null)
                    {
                        DateTime _date = Convert.ToDateTime(dtpDate.Text);

                        List<ProfitShareToAccrue> _profitShareToAccrueList = new List<ProfitShareToAccrue>();

                        if (!forAll)
                        {
                            foreach (ListViewItem _item in lvDisbursements.SelectedItems)
                            {
                                int disbursementId = 0;

                                if (int.TryParse(_item.Text, out disbursementId))
                                {
                                    ProfitShareToAccrue toAcrue = manager.My_db.ProfitShareToAccrues.FirstOrDefault(x => x.Id == disbursementId);

                                    if (toAcrue != null)
                                    {
                                        _profitShareToAccrueList.Add(toAcrue);
                                    }

                                    if (toAcrue.collection_date <= toAcrue.pay_date)
                                    {
                                        errorsDetected = true;
                                        errorMessages += "\rNumber " + toAcrue.number + ": collection <= payment.";
                                    }

                                    if (toAcrue.profit_share == 0)
                                    {
                                        errorsDetected = true;
                                        errorMessages += "\rNumber " + toAcrue.number + ": profit share = 0.";
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (ListViewItem _item in lvDisbursements.Items)
                            {
                                int disbursementId = 0;

                                if (int.TryParse(_item.Text, out disbursementId))
                                {
                                    ProfitShareToAccrue toAcrue = manager.My_db.ProfitShareToAccrues.FirstOrDefault(x => x.Id == disbursementId);

                                    if (toAcrue != null)
                                    {
                                        _profitShareToAccrueList.Add(toAcrue);
                                    }

                                    if (toAcrue.collection_date <= toAcrue.pay_date)
                                    {
                                        errorsDetected = true;
                                        errorMessages += "\rNumber " + toAcrue.number + ": collection <= payment.";
                                    }

                                    if (toAcrue.profit_share == 0)
                                    {
                                        errorsDetected = true;
                                        errorMessages += "\rNumber " + toAcrue.number + ": profit share = 0.";
                                    }
                                }
                            }
                        }

                        if (errorsDetected)
                        {
                            if (MessageBox.Show("Do you want continue?\r\rThese disbursements will be ignored in interest generation." + errorMessages, "Warning", MessageBoxButtons.OKCancel) != DialogResult.OK)
                            {
                                cmdGenerateInterest.Enabled = true;
                                cmdGenerateAllInterest.Enabled = true;
                                return;
                            }
                        }

                        if (_profitShareToAccrueList.Count > 0)
                        {
                            DisbursementGeneratedInterest _generatedInterest = new DisbursementGeneratedInterest();
                            _generatedInterest.GeneratedDate = Convert.ToDateTime(dtpDate.Text);

                            bool interestCreated = false;

                            decimal _totalInterest = 0;

                            bool someDataMissed = false;

                            foreach (ProfitShareToAccrue _profitShareToAccrue in _profitShareToAccrueList)
                            {
                                Currency currency = manager.My_db.Currencies.FirstOrDefault(x => x.Id == _profitShareToAccrue.currency_id && x.FK_Currencies_Funds == manager.Selected);
                                Subaccount subacct128 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account128.Id && x.name == "INV " + currency.symbol);
                                Investment investment = manager.My_db.Investments.FirstOrDefault(x => x.Id == _profitShareToAccrue.investment_id);

                                if (currency != null && subacct128 != null && investment != null)
                                {
                                    DisbursementGeneratedInterestDetail interestDetail = manager.My_db.DisbursementGeneratedInterestDetails.FirstOrDefault(x => x.disbursement_id == _profitShareToAccrue.Id && x.generated_interest_date.Year == _date.Year && x.generated_interest_date.Month == _date.Month);

                                    if (interestDetail == null)
                                    {
                                        DateTime? fromDate = getLastGeneratedInterestDateFor(_profitShareToAccrue.Id);

                                        if (fromDate == null)
                                        {
                                            fromDate = _profitShareToAccrue.pay_date;
                                        }

                                        bool canContinueGeneratingInterest = true;

                                        decimal _interest = 0;

                                        int totalFinancingDays = (_profitShareToAccrue.collection_date.Date - _profitShareToAccrue.pay_date.Value.Date).Days;

                                        DateTime toDate = dtpDate.Value <= _profitShareToAccrue.collection_date ? dtpDate.Value : _profitShareToAccrue.collection_date;

                                        int financingDays = (toDate.Date - fromDate.Value.Date).Days;

                                        if (totalFinancingDays > 0 && financingDays > 0)
                                        {
                                            decimal profitSharePerDay = _profitShareToAccrue.profit_share / totalFinancingDays;
                                            _interest = Math.Round(financingDays * profitSharePerDay, 2);
                                        }

                                        canContinueGeneratingInterest = toDate < _profitShareToAccrue.collection_date;

                                        if (_interest > 0)
                                        {
                                            if (!interestCreated)
                                            {
                                                manager.My_db.DisbursementGeneratedInterests.Add(_generatedInterest);
                                                interestCreated = true;
                                            }

                                            if (!canContinueGeneratingInterest)
                                            {
                                                Disbursement disb = manager.My_db.Disbursements.FirstOrDefault(x => x.Id == _profitShareToAccrue.Id);

                                                if (disb != null)
                                                {
                                                    disb.can_generate_interest = false;
                                                }
                                            }

                                            _totalInterest += _interest;

                                            DisbursementGeneratedInterestDetail _detail = new DisbursementGeneratedInterestDetail();

                                            _detail.DisbursementGeneratedInterest = _generatedInterest;
                                            _detail.disbursement_id = _profitShareToAccrue.Id;
                                            _detail.generated_interest = Math.Round(_interest, 2);
                                            _detail.generated_interest_date = toDate;

                                            manager.My_db.DisbursementGeneratedInterestDetails.Add(_detail);

                                            AccountingMovement _accountingMovement = new AccountingMovement();

                                            _accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                                            _accountingMovement.description = "";
                                            _accountingMovement.date = _detail.generated_interest_date;
                                            _accountingMovement.reference = KeyDefinitions.NextAccountMovementReference(dtpDate.Value.Year);
                                            _accountingMovement.FK_AccountingMovements_Currencies = _profitShareToAccrue.currency_id;
                                            _accountingMovement.original_reference = investment.contract;
                                            _accountingMovement.contract = investment.contract;

                                            manager.My_db.AccountingMovements.Add(_accountingMovement);

                                            _detail.AccountingMovement = _accountingMovement;

                                            Movements_Accounts _maccount128 = new Movements_Accounts();

                                            _maccount128.AccountingMovement = _accountingMovement;
                                            _maccount128.FK_Movements_Accounts_Funds = manager.Selected;
                                            _maccount128.FK_Movements_Accounts_Accounts = account128.Id;
                                            if (subacct128 != null)
                                                _maccount128.FK_Movements_Accounts_Subaccounts = subacct128.Id;
                                            _maccount128.subaccount = _profitShareToAccrue.client_id;
                                            _maccount128.subaccount_type = 1;
                                            _maccount128.debit = Math.Round(_interest, 2);
                                            _maccount128.credit = 0;

                                            manager.My_db.Movements_Accounts.Add(_maccount128);

                                            Movements_Accounts _maccount901 = new Movements_Accounts();

                                            _maccount901.AccountingMovement = _accountingMovement;
                                            _maccount901.FK_Movements_Accounts_Funds = manager.Selected;
                                            _maccount901.FK_Movements_Accounts_Accounts = account901.Id;

                                            _maccount901.subaccount = _profitShareToAccrue.client_id;
                                            _maccount901.subaccount_type = 1;
                                            _maccount901.debit = 0;
                                            _maccount901.credit = Math.Round(_interest, 2);

                                            manager.My_db.Movements_Accounts.Add(_maccount901);

                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Attempt to duplicate disbursement interest generation.");
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
                                DisbursementGeneratedInterestForm disbursement_generated_interest_form = new DisbursementGeneratedInterestForm();
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
                ErrorMessage.showErrorMessage(new Exception("No account 128 or 901 were found."));
            }
        }

        private void cmdGenerateAllInterest_Click(object sender, EventArgs e)
        {
            generateInterest(true);

            loadDisbursements();
        }

        private void cmdGenerateInterest_Click(object sender, EventArgs e)
        {
            generateInterest(false);

            loadDisbursements();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            loadDisbursements();
        }
    }
}
