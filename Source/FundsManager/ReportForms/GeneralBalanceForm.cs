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
            dtpTo.Value = DateTime.Now;

            refreshData();
        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void refreshData()
        {
            try
            {
                DateTime to = Convert.ToDateTime(dtpTo.Text);

                this.accountBalanceViewTableAdapter.FillByDateInterval(this.fundsDBDataSet.AccountBalanceView, manager.Selected, to);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at GeneralBalanceForm.refreshData: " + ex.Message);
            }
        }
    }
}
