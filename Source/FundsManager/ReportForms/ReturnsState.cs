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
            dtpFrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpTo.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            refreshData();
        }

        private void refreshData()
        {
            try
            {
                DateTime from = dtpFrom.Value.Date;
                DateTime to = dtpTo.Value;

                this.profitResultsViewTableAdapter.FillByFund(this.fundsDBDataSet.ProfitResultsView, manager.Selected, from, to);

                ReportParameter language = new ReportParameter("Language", Thread.CurrentThread.CurrentCulture.Name);

                reportViewer1.LocalReport.SetParameters(language);

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
