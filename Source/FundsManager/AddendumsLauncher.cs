using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FundsManager
{
    public partial class AddendumsLauncher : Form
    {
        private MyFundsManager manager;

        public AddendumsLauncher()
        {
            try
            {
                manager = MyFundsManager.SingletonInstance;
                InitializeComponent();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in AddendumsLauncher.AddendumsLauncher: " + _ex.Message);
            }
        }

        private void AddendumsLauncher_Load(object sender, EventArgs e)
        {
            this.clientsTableAdapter.FillByFund(this.fundsDBDataSet.Clients, manager.Selected);

            updateContractCombo();
        }

        private void updateContractCombo()
        {
            int clientId = 0;

            if (cbClient.SelectedValue != null && int.TryParse(cbClient.SelectedValue.ToString(), out clientId))
            {
                this.clientContractsTableAdapter.FillByClient(this.fundsDBDataSet.ClientContracts, manager.Selected, clientId);
            }
        }

        private void updateDisbursements()
        {
            int investmentId = 0;

            if (cbContract.SelectedValue != null && int.TryParse(cbContract.SelectedValue.ToString(), out investmentId))
            {
                this.disbursementsForAddendumsTableAdapter.FillByInvestmentId(this.fundsDBDataSet.DisbursementsForAddendums, investmentId, manager.Selected);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                AddendumsForm addendumsForm = new AddendumsForm();
                addendumsForm.DisbursementId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                addendumsForm.ShowDialog();

                updateDisbursements();
            }
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateContractCombo();
            updateDisbursements();
        }

        private void cbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDisbursements();
        }
    }
}
