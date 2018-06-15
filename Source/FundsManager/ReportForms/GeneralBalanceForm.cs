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
    public partial class GeneralBalanceForm : Form
    {
        public GeneralBalanceForm()
        {
            InitializeComponent();
        }

        private void GeneralBalanceForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.BalanceResume' Puede moverla o quitarla según sea necesario.
            this.balanceResumeTableAdapter.Fill(this.fundsDBDataSet.BalanceResume);
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.AccountBalance' Puede moverla o quitarla según sea necesario.
            this.accountBalanceTableAdapter.Fill(this.fundsDBDataSet.AccountBalance);

            this.reportViewer1.RefreshReport();
        }
    }
}
