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

                this.accountBalanceViewTableAdapter.Fill(this.fundsDBDataSet.AccountBalanceView, manager.Selected, to, toLastPeriod);

                ReportParameter language = new ReportParameter("Language", Thread.CurrentThread.CurrentCulture.Name);
                ReportParameter current = new ReportParameter("Current", to.Year.ToString());
                ReportParameter last = new ReportParameter("Last", toLastPeriod.Year.ToString());

                reportViewer1.LocalReport.SetParameters(language);
                reportViewer1.LocalReport.SetParameters(current);
                reportViewer1.LocalReport.SetParameters(last);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at GeneralBalanceForm.refreshData: " + ex.Message);
            }
        }
    }
}
