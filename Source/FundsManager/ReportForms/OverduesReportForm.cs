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
    public partial class OverduesReportForm : Form
    {
        public int generated_overdue_id = 0;

        public OverduesReportForm()
        {
            InitializeComponent();
        }

        private void OverduesReportForm_Load(object sender, EventArgs e)
        {
            this.disbursementOverdueGeneratedViewTableAdapter.FillByGeneratedId(this.fundsDBDataSet.DisbursementOverdueGeneratedView, generated_overdue_id);

            var rds = new ReportDataSource("dsOverdue", (DataTable)this.fundsDBDataSet.DisbursementOverdueGeneratedView);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            ReportParameter language = new ReportParameter("Language", Thread.CurrentThread.CurrentCulture.Name);

            reportViewer1.LocalReport.SetParameters(language);


            reportViewer1.RefreshReport();
        }
    }
}
