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
                DateTime to = Convert.ToDateTime(dtpTo.Text);
                DateTime from = new DateTime(to.Year, 1, 1);

                DateTime fromLastPeriod = new DateTime(to.Year - 1, 1, 1);
                DateTime toLastPeriod = new DateTime(fromLastPeriod.Year, to.Month, to.Day);

                this.accountBalanceViewTableAdapter.FillByDateInterval(this.fundsDBDataSet.AccountBalanceView, manager.Selected, from, to, fromLastPeriod, toLastPeriod);

                ReportParameter language = new ReportParameter("Language", Thread.CurrentThread.CurrentCulture.Name);

                reportViewer1.LocalReport.SetParameters(language);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at GeneralBalanceForm.refreshData: " + ex.Message);
            }
        }
    }
}
