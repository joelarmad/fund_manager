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

            int clientId = 0;
            int investmentId = 0;

            if (cbContract.SelectedValue != null && int.TryParse(cbContract.SelectedValue.ToString(), out investmentId)
                && cbClient.SelectedValue != null && int.TryParse(cbClient.SelectedValue.ToString(), out clientId))
            {
                this.disbursementsForAddendumsTableAdapter.FillByInvestmentId(this.fundsDBDataSet.DisbursementsForAddendums, investmentId, manager.Selected, clientId);
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

        private void cmdBook_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                List<Disbursement> disbursements = new List<Disbursement>();

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int id = int.Parse(row.Cells[0].Value.ToString());
                    Disbursement item = manager.My_db.Disbursements.FirstOrDefault(x => x.Id == id);
                    disbursements.Add(item);
                }

                AddendumsForm addendumsForm = new AddendumsForm();

                addendumsForm.disbursementForAddendumGroup = disbursements;

                addendumsForm.ShowDialog();

                updateDisbursements();
            }
            else
            {
                MessageBox.Show("Select the item(s)");
            }
        }
    }
}
