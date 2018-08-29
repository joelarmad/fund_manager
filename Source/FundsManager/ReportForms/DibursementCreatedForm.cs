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

            this.reportViewer1.RefreshReport();
        }
    }
}
