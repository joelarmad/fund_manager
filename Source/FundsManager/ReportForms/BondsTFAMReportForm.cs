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
    public partial class BondsTFAMReportForm : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public BondsTFAMReportForm()
        {
            InitializeComponent();
        }

        private void BondsTFAMReportForm_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now.Date;
            dtpTo.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1);

            updateReport();
        }

        private void updateReport()
        {
            try
            {


                this.bondsTFAMViewTableAdapter.FillByFilters(this.fundsDBDataSet.BondsTFAMView, dtpFrom.Value.Date.ToLongDateString(), dtpTo.Value.Date.AddDays(1).AddSeconds(-1).ToLongDateString(), manager.Selected);

                var rds = new ReportDataSource("dsBondsReport", (DataTable)this.fundsDBDataSet.BondsTFAMView);

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                ReportParameter language = new ReportParameter("Language", Thread.CurrentThread.CurrentCulture.Name);
                ReportParameter from = new ReportParameter("From", dtpFrom.Value.Date.ToShortDateString());
                ReportParameter to = new ReportParameter("To", dtpTo.Value.Date.ToShortDateString());

                reportViewer1.LocalReport.SetParameters(language);
                reportViewer1.LocalReport.SetParameters(from);
                reportViewer1.LocalReport.SetParameters(to);


                reportViewer1.RefreshReport();
            }
            catch
            {
                
            }

        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            updateReport();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            updateReport();
        }
    }

    
}
