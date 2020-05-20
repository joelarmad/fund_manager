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
    public partial class BondGeneratedInterestForm : Form
    {

        public int generated_interest_id = 0;

        public BondGeneratedInterestForm()
        {
            InitializeComponent();
        }

        private void BondGeneratedInterestForm_Load(object sender, EventArgs e)
        {
            this.bondGeneratedInterestViewTableAdapter.FillByGeneratedId(this.fundsDBDataSet.BondGeneratedInterestView, generated_interest_id);

            var rds = new ReportDataSource("dsGeneratedInterest", (DataTable)this.fundsDBDataSet.BondGeneratedInterestView);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            ReportParameter language = new ReportParameter("Language", Thread.CurrentThread.CurrentCulture.Name);

            reportViewer1.LocalReport.SetParameters(language);


            reportViewer1.RefreshReport();
        }
    }
}
