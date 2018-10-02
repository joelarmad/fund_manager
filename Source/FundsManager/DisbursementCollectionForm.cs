using FundsManager.Classes.Utilities;
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
    public partial class DisbursementCollectionForm : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        int IdIndex = 0;
        int NumberIndex = 1;
        int AmountIndex = 2;
        int ProfitShareIndex = 3;
        int CollectedIndex = 4;
        int ToBeCollectedIndex = 5;

        public DisbursementCollectionForm()
        {
            InitializeComponent();
        }

        private void DisbursementCollectionForm_Load(object sender, EventArgs e)
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
                if (cbContract.SelectedValue != null)
                {
                    //TODO: corregir exception cuando contract is empty
                    string contract = ((FundsManager.FundsDBDataSet.ClientContractsRow)((System.Data.DataRowView)cbContract.SelectedItem).Row).contract;

                    if (contract != "")
                    {
                        // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.DisbursementsToBeCollected' Puede moverla o quitarla según sea necesario.
                        this.disbursementsToBeCollectedTableAdapter.FillByContract(this.fundsDBDataSet.DisbursementsToBeCollected, contract, manager.Selected);
                    }
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

        private void cmdCollect_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> ids = new List<int>();
                List<decimal> amounts = new List<decimal>();
                List<decimal> collecteds = new List<decimal>();
                List<decimal> toBeCollecteds = new List<decimal>();

                String errors = "";

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int id = int.Parse(row.Cells[IdIndex].Value.ToString());
                    string number = row.Cells[NumberIndex].Value.ToString();
                    decimal amount = decimal.Parse(row.Cells[AmountIndex].Value.ToString());
                    decimal profitShare = decimal.Parse(row.Cells[ProfitShareIndex].Value.ToString());
                    decimal collected = decimal.Parse(row.Cells[CollectedIndex].Value.ToString());
                    string amountToBeCollectedStr = row.Cells[ToBeCollectedIndex].Value != null ? row.Cells[ToBeCollectedIndex].Value.ToString() : "";

                    if (amountToBeCollectedStr != "")
                    {
                        decimal amountToBeCollected = 0;

                        if (decimal.TryParse(amountToBeCollectedStr, out amountToBeCollected) && amountToBeCollected > 0)
                        {
                            if (amount - collected - amountToBeCollected >= 0)
                            {
                                //TODO: consultar si se puede cobrar mas que el resto del collected
                                ids.Add(id);
                                amounts.Add(amount);
                                collecteds.Add(collected);
                                toBeCollecteds.Add(amountToBeCollected);
                            }
                            else
                            {
                                errors += "\r\tDisbursement " + number + " has too much collection value: " + amountToBeCollectedStr;
                            }
                        }
                        else
                        {
                            errors += "\r  Disbursement " + number + " has wrong collection value: " + amountToBeCollectedStr;
                        }
                    }
                }

                if (errors != "")
                {
                    string msg = "Please, fix these errors:" + errors;

                    ErrorMessage.showErrorMessage(new Exception(msg));
                    return;
                }
                else
                {
                    DisbursementCollection collection = new DisbursementCollection();
                    collection.collection_date = dtpDate.Value;
                    collection.investment_id = cbContract.SelectedValue != null ? int.Parse(cbContract.SelectedValue.ToString()) : 0;

                    if (collection.investment_id > 0)
                    {
                        manager.My_db.DisbursementCollections.Add(collection);
                        manager.My_db.SaveChanges();

                        for (int i = 0; i < ids.Count; i++)
                        {
                            int disbId = ids[i];
                            decimal amount = amounts[i];
                            decimal collected = collecteds[i];
                            decimal toBeCollected = toBeCollecteds[i];

                            Disbursement disb = manager.My_db.Disbursements.FirstOrDefault(x => x.Id == disbId);

                            if (disb != null)
                            {
                                //TODO: consultar cuando esta cobrado completo para marcar el disbursement.

                                if (amount - collected - toBeCollected <= 0)
                                {
                                    disb.can_generate_interest = false;
                                    manager.My_db.SaveChanges();
                                }

                                DisbursementCollectionsDetail collectionDetail = new DisbursementCollectionsDetail();
                                collectionDetail.disbursement_collection_id = collection.id;
                                collectionDetail.disbursement_id = disbId;
                                collectionDetail.amount_collected = toBeCollected;

                                manager.My_db.DisbursementCollectionsDetails.Add(collectionDetail);
                                manager.My_db.SaveChanges();
                            }
                        }
                    }
                }

                updateDisbursementList();
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }
    }
}
