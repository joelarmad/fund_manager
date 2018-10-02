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
    public partial class DisbursementCollection : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public DisbursementCollection()
        {
            InitializeComponent();
        }

        private void DisbursementCollection_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Clients' Puede moverla o quitarla según sea necesario.
            this.clientsTableAdapter.Fill(this.fundsDBDataSet.Clients);

            updateContractCombo();

            updateDisbursementList();
        }

        private void updateContractCombo()
        {
            int clientId = 0;

            if (cbClient.SelectedValue != null && int.TryParse(cbClient.SelectedValue.ToString(), out clientId))
            {
                // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.ClientContracts' Puede moverla o quitarla según sea necesario.
                this.clientContractsTableAdapter.FillByClient(this.fundsDBDataSet.ClientContracts, manager.Selected, clientId);
            }
        }

        private void updateDisbursementList()
        {
            try
            {
                //TODO: corregir exception cuando contract is empty
                string contract = cbContract.SelectedValue != null ? cbContract.SelectedValue.ToString() : "";

                if (contract != "")
                {
                    // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.DisbursementsToBeCollected' Puede moverla o quitarla según sea necesario.
                    this.disbursementsToBeCollectedTableAdapter.FillByContract(this.fundsDBDataSet.DisbursementsToBeCollected, contract, manager.Selected);
                }
            }
            catch (Exception)
            {
            }
            
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateContractCombo();

            updateDisbursementList();
        }

        private void cbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDisbursementList();
        }
    }
}
