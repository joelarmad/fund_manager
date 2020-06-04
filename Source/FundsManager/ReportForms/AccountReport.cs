using FundsManager.Classes.Utilities;
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

            cbSubAccount_SelectedIndexChanged(null, null);

            cmdFind_Click(null, null);

        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            int accountId = cbAccount.SelectedValue != null ? int.Parse(cbAccount.SelectedValue.ToString()) : 0;
            int subAccountId = cbSubAccount.SelectedValue != null ? int.Parse(cbSubAccount.SelectedValue.ToString()) : 0;
            int detailType = 0;
            int detailId = 0;
            String detail = "";

            if (cbOtherDetails.SelectedIndex > 0)
            {
                string temp_id = Convert.ToString(cbOtherDetails.SelectedValue);
                detailType = Convert.ToInt32(temp_id.Substring(0, 1));
                detailId = Convert.ToInt32(temp_id.Substring(1, temp_id.Length - 1));
                detail = ((KeyValuePair<int, string>)cbOtherDetails.SelectedItem).Value;
            }

            Account account = manager.My_db.Accounts.FirstOrDefault(x => x.Id == accountId);
            Subaccount subaccount = manager.My_db.Subaccounts.FirstOrDefault(x => x.Id == subAccountId);

            this.accountReportTableAdapter.Fill(this.fundsDBDataSet.AccountReport, accountId, subAccountId, detailType, detailId, dtpFrom.Value.Date, dtpTo.Value.Date.AddDays(1).AddSeconds(-1), manager.Selected);

            var rds = new ReportDataSource("dsAccountReport", (DataTable)this.fundsDBDataSet.AccountReport);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            ReportParameter pAccount = new ReportParameter("Account", "Account: " + (account != null ? account.name + " (" + account.number + ")" : ""));
            ReportParameter pSubbaccount = new ReportParameter("SubAccount", "SubAccount: " + (subaccount != null ? subaccount.name : ""));
            ReportParameter pDetails = new ReportParameter("Detail", "Other details: " + detail);
            ReportParameter pFrom = new ReportParameter("From", "From " + dtpFrom.Value.ToShortDateString());
            ReportParameter pTo = new ReportParameter("To", "To " + dtpTo.Value.ToShortDateString());



            reportViewer1.LocalReport.SetParameters(pAccount);
            reportViewer1.LocalReport.SetParameters(pSubbaccount);
            reportViewer1.LocalReport.SetParameters(pDetails);
            reportViewer1.LocalReport.SetParameters(pFrom);
            reportViewer1.LocalReport.SetParameters(pTo);


            reportViewer1.RefreshReport();
        }

        private void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            int accountId = 0;
            if (cbAccount.SelectedIndex >= 0)
            {
                accountId = int.Parse(cbAccount.SelectedValue.ToString());
            }

            this.subaccountsTableAdapter.FillWithEmpty(this.fundsDBDataSet.Subaccounts,accountId, manager.Selected);

            cbSubAccount_SelectedIndexChanged(null, null);
        }

        private void cbSubAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadOtherDetails();
        }

        private void cbOtherDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmdFind_Click(null, null);
        }

        private void loadOtherDetails()
        {
            try
            {
                cbOtherDetails.DataSource = null;
                cbOtherDetails.Items.Clear();
                cbOtherDetails.Text = "";
                cbOtherDetails.SelectedItem = null;
                cbOtherDetails.SelectedText = "Select detail";

                int subacctId = cbSubAccount.SelectedValue != null ? Convert.ToInt32(cbSubAccount.SelectedValue) : 0;

                Dictionary<int, string> comboSource = DataUtils.getOtherDetailsSource(subacctId, "");


                cbOtherDetails.DataSource = new BindingSource(comboSource, null);
                cbOtherDetails.DisplayMember = "Value";
                cbOtherDetails.ValueMember = "Key";
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AcctountReport.loadOtherDetails: " + _ex.Message);
            }
        }
    }
}
