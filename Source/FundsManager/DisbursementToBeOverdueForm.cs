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
    public partial class DisbursementToBeOverdueForm : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public DisbursementToBeOverdueForm()
        {
            InitializeComponent();
        }

        private void DisbursementToBeOverdueForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.clientsTableAdapter.FillWithEmpty(this.fundsDBDataSet.Clients, "Select client", manager.Selected);

                updateContractCombo();

                loadOverdues();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementToBeOverdueForm.DisbursementToBeOverdueForm_Load: " + _ex.Message);
            }
        }

        private void updateContractCombo()
        {
            try
            {
                int clientId = 0;

                if (cbClient.SelectedValue != null && int.TryParse(cbClient.SelectedValue.ToString(), out clientId) && clientId > 0)
                {
                    this.clientContractsTableAdapter.FillByClient(this.fundsDBDataSet.ClientContracts, manager.Selected, clientId);
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementToBeOverdueForm.updateContractCombo: " + _ex.Message);
            }
        }

        private void loadOverdues()
        {
            try
            {
                int clientId = 0;
                if (cbClient.SelectedValue != null)
                {
                    int.TryParse(cbClient.SelectedValue.ToString(), out clientId);
                }

                int investmentId = 0;
                if (cbContract.SelectedValue != null)
                {
                    int.TryParse(cbContract.SelectedValue.ToString(), out investmentId);
                }

                decimal x = decimal.One;

                this.disbursementToBeOverduedTableAdapter.Fill(this.fundsDBDataSet.DisbursementToBeOverdued, clientId, investmentId, dtpDate.Value.Date, x, manager.Selected);
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementToBeOverdueForm.loadOverdues: " + _ex.Message);
            }
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                updateContractCombo();

                loadOverdues();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementToBeOverdueForm.cbClient_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void cbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadOverdues();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementToBeOverdueForm.cbContract_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                loadOverdues();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementToBeOverdueForm.dtpDate_ValueChanged: " + _ex.Message);
            }
        }
    }
}
