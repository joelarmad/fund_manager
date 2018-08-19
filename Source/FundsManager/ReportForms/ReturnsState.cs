using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FundsManager.ReportForms
{
    public partial class ReturnsState : Form
    {
        private MyFundsManager manager = MyFundsManager.SingletonInstance;

        public ReturnsState()
        {
            InitializeComponent();
        }

        private void ReturnsState_Load(object sender, EventArgs e)
        { 
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.ProfitsResumeView' Puede moverla o quitarla según sea necesario.
            this.profitsResumeViewTableAdapter.FillByFund(this.fundsDBDataSet.ProfitsResumeView, manager.Selected);
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.ProfitResultsView' Puede moverla o quitarla según sea necesario.
            this.profitResultsViewTableAdapter.FillByFund(this.fundsDBDataSet.ProfitResultsView, manager.Selected);
            

            this.reportViewer1.RefreshReport();
        }

        
    }
}
