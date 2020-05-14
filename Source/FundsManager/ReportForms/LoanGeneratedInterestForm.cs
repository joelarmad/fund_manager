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
    public partial class LoanGeneratedInterestForm : Form
    {
        public int generated_interest_id = 0;

        public LoanGeneratedInterestForm()
        {
            InitializeComponent();
        }

        private void LoanGeneratedInterestForm_Load(object sender, EventArgs e)
        {
            this.loanGeneratedInterestViewTableAdapter.FillByGeneratedId(this.fundsDBDataSet.LoanGeneratedInterestView, generated_interest_id);

            var rds = new ReportDataSource("dsGeneratedInterest", (DataTable)this.fundsDBDataSet.LoanGeneratedInterestView);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            ReportParameter language = new ReportParameter("Language", Thread.CurrentThread.CurrentCulture.Name);

            reportViewer1.LocalReport.SetParameters(language);


            reportViewer1.RefreshReport();
        }
    }
}
