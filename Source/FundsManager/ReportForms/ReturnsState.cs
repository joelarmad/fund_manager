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
        public ReturnsState()
        {
            InitializeComponent();
        }

        private void ReturnsState_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.ProfitsResume' table. You can move, or remove it, as needed.
            this.profitsResumeTableAdapter.Fill(this.fundsDBDataSet.ProfitsResume);
            // TODO: This line of code loads data into the 'fundsDBDataSet.ProfitResults' table. You can move, or remove it, as needed.
            this.profitResultsTableAdapter.Fill(this.fundsDBDataSet.ProfitResults);

            this.reportViewer1.RefreshReport();
        }
    }
}
