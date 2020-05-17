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
    public partial class AccountReport : Form
    {
        public AccountReport()
        {
            InitializeComponent();
        }

        private void AccountReport_Load(object sender, EventArgs e)
        {
            this.accountReportTableAdapter.Fill(this.fundsDBDataSet.AccountReport, 0, 0, "", new DateTime(2017, 1, 1), new DateTime(2018, 1, 1), 1);

            var rds = new ReportDataSource("dsAccountReport", (DataTable)this.fundsDBDataSet.AccountReport);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);


            reportViewer1.RefreshReport();

        }
    }
}
