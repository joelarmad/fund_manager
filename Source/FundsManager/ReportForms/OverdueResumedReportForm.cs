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
    public partial class OverdueResumedReportForm : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public OverdueResumedReportForm()
        {
            InitializeComponent();
        }

        private void OverdueResumedReportForm_Load(object sender, EventArgs e)
        {
            this.clientsTableAdapter.FillWithEmpty(this.fundsDBDataSet.Clients, "Any client", manager.Selected);

            updateReport();

        }

        private void updateContractCombo()
        {
            int clientId = 0;

            if (cbClient.SelectedValue != null && int.TryParse(cbClient.SelectedValue.ToString(), out clientId))
            {
                this.clientContractsTableAdapter.FillByClient(this.fundsDBDataSet.ClientContracts, manager.Selected, clientId);
            }
        }

        private void updateReport()
        {
            try
            {
                String client = "Any client";
                int clientId = 0;

                if (cbClient.SelectedValue != null)
                {
                    clientId = int.Parse(cbClient.SelectedValue.ToString());
                    client = ((FundsManager.FundsDBDataSet.ClientsRow)((System.Data.DataRowView)cbClient.SelectedItem).Row).name;
                }

                String contract = "Any contract";
                int investmentId = 0;

                if (cbContract.SelectedValue != null)
                {
                    investmentId = int.Parse(cbContract.SelectedValue.ToString());

                    if (cbContract.SelectedIndex > 0)
                    {
                        contract = ((FundsManager.FundsDBDataSet.ClientContractsRow)((System.Data.DataRowView)cbContract.SelectedItem).Row).contract;
                    }
                }

                this.overdueResumedReportViewTableAdapter.FillByFilters(this.fundsDBDataSet.OverdueResumedReportView, clientId, investmentId, manager.Selected);

                var rds = new ReportDataSource("dsOverdueResumed", (DataTable)this.fundsDBDataSet.OverdueResumedReportView);

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                ReportParameter language = new ReportParameter("Language", Thread.CurrentThread.CurrentCulture.Name);
                ReportParameter pClient = new ReportParameter("Client", client);
                ReportParameter pContract = new ReportParameter("Contract", contract);

                reportViewer1.LocalReport.SetParameters(language);
                reportViewer1.LocalReport.SetParameters(pClient);
                reportViewer1.LocalReport.SetParameters(pContract);


                reportViewer1.RefreshReport();
            }
            catch
            {

            }
            
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateContractCombo();

            updateReport();
        }

        private void cbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateReport();
        }
    }
}
