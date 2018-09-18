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

        private decimal AccrueInterest(ProfitShareToAccrue aProfitShareToAccrue)
        {
            try
            {
                int financingDays = (aProfitShareToAccrue.pay_date.Value - aProfitShareToAccrue.collection_date).Days;

                if (financingDays > 0)
                {
                    decimal profitSharePerDay = aProfitShareToAccrue.profit_share / financingDays;
                    return financingDays * profitSharePerDay;
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error at ProfitShareToAccrueForm.AccrueInterest: " + _ex.Message);
            }
            
            return 0;
        }

        private void loadDisbursements()
        {
            try
            {
                lvDisbursements.Items.Clear();

                DateTime _date = dtpDate.Value;

                List<ProfitShareToAccrue> _profitShareToAccrueList = manager.My_db.ProfitShareToAccrues.Where(x => x.pay_date <= _date).ToList();

                foreach (ProfitShareToAccrue _profitShareToAccrue in _profitShareToAccrueList)
                {

                    DisbursementGeneratedInterestDetail interestDetail = manager.My_db.DisbursementGeneratedInterestDetails.FirstOrDefault(x => x.disbursement_id == _profitShareToAccrue.Id && x.generated_interest_date.Year == _date.Year && x.generated_interest_date.Month == _date.Month);

                    if (interestDetail == null)
                    {
                        string paid_date = _profitShareToAccrue.pay_date != null ? _profitShareToAccrue.pay_date.Value.ToLongDateString() : "";

                        string[] row = {
                            _profitShareToAccrue.Id.ToString(),
                            _profitShareToAccrue.number,
                            String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _profitShareToAccrue.amount),
                            _profitShareToAccrue.collection_date.ToLongDateString(),
                            _profitShareToAccrue.date.ToLongDateString(),
                            paid_date
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
            loadDisbursements();
        }

        private void generateInterest(bool forAll)
        {
            cmdGenerateInterest.Enabled = false;
            cmdGenerateAllInterest.Enabled = false;

            try
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
                        }
                    }
                }


                if (_profitShareToAccrueList.Count > 0)
                {
                    DisbursementGeneratedInterest _generatedInterest = new DisbursementGeneratedInterest();
                    _generatedInterest.GeneratedDate = Convert.ToDateTime(dtpDate.Text);

                    bool interestCreated = false;

                    decimal _totalInterest = 0;

                    foreach (ProfitShareToAccrue _profitShareToAccrue in _profitShareToAccrueList)
                    {
                        DisbursementGeneratedInterestDetail interestDetail = manager.My_db.DisbursementGeneratedInterestDetails.FirstOrDefault(x => x.disbursement_id == _profitShareToAccrue.Id && x.generated_interest_date.Year == _date.Year && x.generated_interest_date.Month == _date.Month);

                        if (interestDetail == null)
                        {
                            if (!interestCreated)
                            {
                                manager.My_db.DisbursementGeneratedInterests.Add(_generatedInterest);
                                manager.My_db.SaveChanges();
                                interestCreated = true;
                            }

                            decimal _interest = AccrueInterest(_profitShareToAccrue);

                            _totalInterest += _interest;

                            DisbursementGeneratedInterestDetail _detail = new DisbursementGeneratedInterestDetail();
                            _detail.disbursement_generated_interest_id = _generatedInterest.Id;
                            _detail.disbursement_id = _profitShareToAccrue.Id;
                            _detail.generated_interest = _interest;
                            _detail.generated_interest_date = _date;

                            manager.My_db.DisbursementGeneratedInterestDetails.Add(_detail);
                            manager.My_db.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("Attempt to duplicate disbursement interest generation.");
                        }

                    }

                    if (interestCreated)
                    {
                        //TODO: Generar movimientos de cuenta

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
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }

            cmdGenerateInterest.Enabled = true;
            cmdGenerateAllInterest.Enabled = true;
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
    }
}
