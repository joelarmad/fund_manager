using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FundsManager.ReportForms
{
    public partial class ExpensesReportForm : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public ExpensesReportForm()
        {
            InitializeComponent();
        }

        private void ExpensesReportForm_Load(object sender, EventArgs e)
        {
            loadReport();
        }

        private void loadReport()
        {
            this.expensesReportTableAdapter.Fill(this.fundsDBDataSet.ExpensesReport, dtpFrom.Value.Date, dtpTo.Value.Date.AddDays(1).AddSeconds(-1), manager.Selected);

            var rds = new ReportDataSource("dsAccountReport", (DataTable)this.fundsDBDataSet.ExpensesReport);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            ReportParameter pFrom = new ReportParameter("From", "From " + dtpFrom.Value.ToShortDateString());
            ReportParameter pTo = new ReportParameter("To", "To " + dtpTo.Value.ToShortDateString());
            ReportParameter pTitle = new ReportParameter("Title", manager.SelectedFund().name);

            reportViewer1.LocalReport.SetParameters(pFrom);
            reportViewer1.LocalReport.SetParameters(pTo);
            reportViewer1.LocalReport.SetParameters(pTitle);


            reportViewer1.RefreshReport();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            loadReport();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            loadReport();
        }
    }
}
