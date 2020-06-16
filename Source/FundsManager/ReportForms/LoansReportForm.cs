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
    public partial class LoansReportForm : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public LoansReportForm()
        {
            InitializeComponent();
        }

        private void LoansReportForm_Load(object sender, EventArgs e)
        {
            this.creditorsTableAdapter.FillWithEmpty(this.fundsDBDataSet.Creditors, "Any Lender", manager.Selected);

            updateReport();
        }

        private void updateReport()
        {
            try
            {
                String lender = "Any Lender";
                int lenderId = 0;

                if (cbLender.SelectedValue != null)
                {
                    lenderId = int.Parse(cbLender.SelectedValue.ToString());
                    lender = ((FundsManager.FundsDBDataSet.CreditorsRow)((System.Data.DataRowView)cbLender.SelectedItem).Row).name;
                }

                this.loansReportViewTableAdapter.FillByFilters(this.fundsDBDataSet.LoansReportView, lenderId, manager.Selected);

                var rds = new ReportDataSource("dsLoansReport", (DataTable)this.fundsDBDataSet.LoansReportView);

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                ReportParameter language = new ReportParameter("Language", Thread.CurrentThread.CurrentCulture.Name);
                ReportParameter pLender = new ReportParameter("Lender", lender);

                reportViewer1.LocalReport.SetParameters(language);
                reportViewer1.LocalReport.SetParameters(pLender);


                reportViewer1.RefreshReport();
            }
            catch
            {

            }

        }

        private void cbLender_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateReport();
        }
    }
}
