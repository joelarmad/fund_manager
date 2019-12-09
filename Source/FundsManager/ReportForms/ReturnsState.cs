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
            dtpTo.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

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

                ReportParameter language = new ReportParameter("Language", Thread.CurrentThread.CurrentCulture.Name);
                ReportParameter current = new ReportParameter("Current", from.Year.ToString());
                ReportParameter last = new ReportParameter("Last", lastFrom.Year.ToString());

                reportViewer1.LocalReport.SetParameters(language);
                reportViewer1.LocalReport.SetParameters(current);
                reportViewer1.LocalReport.SetParameters(last);

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
