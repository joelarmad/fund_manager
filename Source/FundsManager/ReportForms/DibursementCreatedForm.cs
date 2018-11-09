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
    public partial class DibursementCreatedForm : Form
    {
        public int investmentId = 0;

        public DibursementCreatedForm()
        {
            InitializeComponent();
        }

        private void DibursementCreatedForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.InvestmentsView' Puede moverla o quitarla según sea necesario.
            this.investmentsViewTableAdapter.FillByInvestment(this.fundsDBDataSet.InvestmentsView, investmentId);

            ReportParameter language = new ReportParameter("Language", Thread.CurrentThread.CurrentCulture.Name);

            reportViewer1.LocalReport.SetParameters(language);

            this.reportViewer1.RefreshReport();
        }
    }
}
