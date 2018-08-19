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
        private MyFundsManager manager = MyFundsManager.SingletonInstance;

        public GeneralBalanceForm()
        {
            InitializeComponent();
        }

        private void GeneralBalanceForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.BalanceResumeView' Puede moverla o quitarla según sea necesario.
            this.balanceResumeViewTableAdapter.FillByFund(this.fundsDBDataSet.BalanceResumeView, manager.Selected);
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.AccountBalanceView' Puede moverla o quitarla según sea necesario.
            this.accountBalanceViewTableAdapter.FillByFund(this.fundsDBDataSet.AccountBalanceView, manager.Selected);
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.BalanceResume' Puede moverla o quitarla según sea necesario.
            
            this.reportViewer1.RefreshReport();
        }

        
    }
}
