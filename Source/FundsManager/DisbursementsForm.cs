using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace FundsManager
{
    public partial class DisbursementsForm : Form
    {
        private MyFundsManager manager;

        private Account cashAtBank;

        private string fUnpaidText = "waitting";

        public DisbursementsForm()
        {
            try
            {
                manager = MyFundsManager.SingletonInstance;
                InitializeComponent();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.DisbursementsForm: " + _ex.Message);
            }
        }

        private void DisbursementsForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.ClientContracts' Puede moverla o quitarla según sea necesario.
            this.clientContractsTableAdapter.Fill(this.fundsDBDataSet.ClientContracts);
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Clients' Puede moverla o quitarla según sea necesario.
            this.clientsTableAdapter.FillByFund(this.fundsDBDataSet.Clients, manager.Selected);
           
            updateContractCombo();

            loadDisbursements();

            try
            {
                cashAtBank = manager.My_db.Accounts.FirstOrDefault(x => x.number == "110");

                if (cashAtBank != null)
                {
                    lblAccount.Text = cashAtBank.name;
                    cbSubAccount.Enabled = true;
                    cbOtherDetails.Enabled = true;
                }

                // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Subaccounts' Puede moverla o quitarla según sea necesario.
                this.subaccountsTableAdapter.FillByAccount(this.fundsDBDataSet.Subaccounts, cashAtBank.Id, manager.Selected);

                updateOtherDetailsCombobox();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.DisbursementsForm_Load: " + _ex.Message);
            }
        }

        private void updateOtherDetailsCombobox()
        {
            int subAccountId = 0;

            if (cbSubAccount.SelectedValue != null && int.TryParse(cbSubAccount.SelectedValue.ToString(), out subAccountId))
            {
                // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.OtherDetails' Puede moverla o quitarla según sea necesario.
                this.otherDetailsTableAdapter.FillBySubaccount(this.fundsDBDataSet.OtherDetails, subAccountId, manager.Selected);
            }
        }

        private void updateContractCombo()
        {
            int clientId = 0;

            if (cbClient.SelectedValue != null && int.TryParse(cbClient.SelectedValue.ToString(), out clientId))
            {
                this.clientContractsTableAdapter.FillByClient(this.fundsDBDataSet.ClientContracts, manager.Selected, clientId);
            }
        }

        private void cbSubAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateOtherDetailsCombobox();
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvDisbursements.SelectedIndices.Clear();
            updateContractCombo();
        }

        private void loadDisbursements()
        {
            lvDisbursements.Items.Clear();

            int clientId = 0;
            int investmentId = 0;

            if (cbClient.SelectedValue != null && cbContract.SelectedValue != null
                && int.TryParse(cbClient.SelectedValue.ToString(), out clientId)
                && int.TryParse(cbContract.SelectedValue.ToString(), out investmentId))
            {

                List<Disbursement> disbursements = manager.My_db.Disbursements.Where(x => x.investment_id == investmentId && x.client_id == clientId).ToList();

                foreach (Disbursement disbursement in disbursements)
                {
                    string paid_date = disbursement.pay_date != null ? disbursement.pay_date.Value.ToLongDateString() : fUnpaidText;
                    
                    string[] row = {
                        disbursement.Id.ToString(),
                        disbursement.number,
                        String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", disbursement.amount),
                        disbursement.date.ToLongDateString(),
                        paid_date
                    };
                    ListViewItem my_item = new ListViewItem(row);
                    lvDisbursements.Items.Add(my_item);
                }

                
            }

        }

        private void cbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvDisbursements.SelectedIndices.Clear();
            loadDisbursements();
        }

        private void lvDisbursements_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem _item in lvDisbursements.SelectedItems)
                {
                    if (_item.SubItems[4].Text != fUnpaidText)
                    {
                        _item.Selected = false;
                    }
                }

                cmdPay.Enabled = lvDisbursements.SelectedItems.Count > 0;
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.lvDisbursements_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void cmdPay_Click(object sender, EventArgs e)
        {
            try
            {
                int investmentId = 0;

                if (cbContract.SelectedValue != null
                    && int.TryParse(cbContract.SelectedValue.ToString(), out investmentId))
                {
                    DisbursementPayment dPayment = new DisbursementPayment();
                    dPayment.investment_id = investmentId;
                    dPayment.payment_date = Convert.ToDateTime(dtpPayDate.Text);

                    manager.My_db.DisbursementPayments.Add(dPayment);
                    manager.My_db.SaveChanges();

                    foreach (ListViewItem _item in lvDisbursements.SelectedItems)
                    {
                        int disbursementId = 0;

                        if (int.TryParse(_item.Text, out disbursementId))
                        {
                            Disbursement toPay = manager.My_db.Disbursements.FirstOrDefault(x => x.Id == disbursementId);

                            if (toPay != null)
                            {
                                toPay.pay_date = dPayment.payment_date;

                                dPayment.Disbursements.Add(toPay);

                                manager.My_db.SaveChanges();

                                //TODO: Generar movimiento de cuenta si es uno por disbursemet
                            }
                        }
                    }

                    //TODO: Generar movimiento de cuenta si es uno x operacion

                    manager.My_db.SaveChanges();

                    //TODO: Generar y mostrar comprobante.

                    lvDisbursements.SelectedIndices.Clear();

                    loadDisbursements();
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.cmdPay_Click: " + _ex.Message);
            }
        }
    }
}
