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
    public partial class AccountReport : Form
    {
        private MyFundsManager manager = MyFundsManager.SingletonInstance;

        public AccountReport()
        {
            InitializeComponent();
        }

        private void AccountReport_Load(object sender, EventArgs e)
        {
            this.accountsTableAdapter.FillByFund(this.fundsDBDataSet.Accounts, manager.Selected);

            cbAccount_SelectedIndexChanged(null, null);

            cmdFind_Click(null, null);

        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            int accountId = cbAccount.SelectedValue != null ? int.Parse(cbAccount.SelectedValue.ToString()) : 0;
            int subAccountId = cbSubAccount.SelectedValue != null ? int.Parse(cbSubAccount.SelectedValue.ToString()) : 0;

            this.accountReportTableAdapter.Fill(this.fundsDBDataSet.AccountReport, accountId, subAccountId, txtDetail.Text.Trim(), dtpFrom.Value.Date, dtpTo.Value.Date.AddDays(1).AddSeconds(-1), manager.Selected);

            var rds = new ReportDataSource("dsAccountReport", (DataTable)this.fundsDBDataSet.AccountReport);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);


            reportViewer1.RefreshReport();
        }

        private void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            int accountId = 0;
            if (cbAccount.SelectedIndex >= 0)
            {
                accountId = int.Parse(cbAccount.SelectedValue.ToString());
            }

            this.subaccountsTableAdapter.FillByAccount(this.fundsDBDataSet.Subaccounts,accountId, manager.Selected);
        }
    }
}
