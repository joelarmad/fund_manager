using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FundsManager.ReportForms
{
    public partial class ReturnsState : Form
    {
        private MyFundsManager manager = MyFundsManager.SingletonInstance;

        public ReturnsState()
        {
            InitializeComponent();
        }

        private void ReturnsState_Load(object sender, EventArgs e)
        {
            //WARNING second 58 is a fix for excluding closing period
            dtpTo.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(58);

            refreshData();
        }

        private void refreshData()
        {
            try
            {

                DateTime to = dtpTo.Value;
                DateTime from = new DateTime(to.Year, 1, 1, 0, 0, 0);

                DateTime lastFrom = from.AddYears(-1);
                DateTime lastTo = to.AddYears(-1);

                this.profitResultsViewTableAdapter.Fill(this.fundsDBDataSet.ProfitResultsView, manager.Selected, from, to, lastFrom, lastTo);

                ReportParameter pLanguage = new ReportParameter("Language", Thread.CurrentThread.CurrentCulture.Name);
                ReportParameter pCurrent = new ReportParameter("Current", from.ToShortDateString());
                ReportParameter pLast = new ReportParameter("Last", lastFrom.ToShortDateString());
                ReportParameter pTitle = new ReportParameter("Title", manager.SelectedFund().name);

                reportViewer1.LocalReport.SetParameters(pLanguage);
                reportViewer1.LocalReport.SetParameters(pCurrent);
                reportViewer1.LocalReport.SetParameters(pLast);
                reportViewer1.LocalReport.SetParameters(pTitle);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at ReturnsState.refreshData: " + ex.Message);
            }
        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            refreshData();
        }
    }
}
