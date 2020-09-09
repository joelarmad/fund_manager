using FundsManager.Classes;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FundsManager.ReportForms
{
    public partial class GeneralBalanceForm : Form
    {
        private MyFundsManager manager = MyFundsManager.SingletonInstance;

        public GeneralBalanceForm()
        {
            InitializeComponent();
        }

        private void GeneralBalanceForm_Load(object sender, EventArgs e)
        {
            dtpTo.Value = DateTime.Now;

            refreshData();
            refreshData();
        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void refreshData()
        {
            try
            {
                DateTime to = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);
                DateTime toLastPeriod = to.AddYears(-1);
                
                ReportParameter pLanguage = new ReportParameter("Language", Thread.CurrentThread.CurrentCulture.Name);
                ReportParameter pCurrent = new ReportParameter("Current", to.ToShortDateString());
                ReportParameter pLast = new ReportParameter("Last", toLastPeriod.ToShortDateString());
                ReportParameter pTitle = new ReportParameter("Title", manager.SelectedFund().name);
                ReportParameter pDate = new ReportParameter("Date", DateTime.Now.ToShortDateString());

                if (manager.My_db.ClosedPeriods.FirstOrDefault(x => x.year == dtpTo.Value.Year && x.fund_id == manager.Selected) == null)
                {
                    this.accountBalanceViewTableAdapter.Fill(this.fundsDBDataSet.AccountBalanceView, manager.Selected, to, toLastPeriod);
                    var rds = new ReportDataSource("DataSet1", (DataTable)this.fundsDBDataSet.AccountBalanceView);

                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rds);
                }
                else
                {
                    this.accountBalanceClosedPeriodTableAdapter.Fill(this.fundsDBDataSet.AccountBalanceClosedPeriodView, manager.Selected, to, toLastPeriod);
                    var rds = new ReportDataSource("DataSet1", (DataTable)this.fundsDBDataSet.AccountBalanceClosedPeriodView);

                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rds);
                }
                

                reportViewer1.LocalReport.SetParameters(pLanguage);
                reportViewer1.LocalReport.SetParameters(pCurrent);
                reportViewer1.LocalReport.SetParameters(pLast);
                reportViewer1.LocalReport.SetParameters(pTitle);
                reportViewer1.LocalReport.SetParameters(pDate);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at GeneralBalanceForm.refreshData: " + ex.Message);
            }
        }
    }
}
