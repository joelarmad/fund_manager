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
    public partial class DisbursementCollectionReportForm : Form
    {
        public DisbursementCollectionReportForm()
        {
            InitializeComponent();
        }

        private void DisbursementCollectionReportForm_Load(object sender, EventArgs e)
        {
            ReportParameter language = new ReportParameter("Language", Thread.CurrentThread.CurrentCulture.Name);

            reportViewer1.LocalReport.SetParameters(language);

            this.reportViewer1.RefreshReport();
        }
    }
}
