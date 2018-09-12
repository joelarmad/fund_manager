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
    public partial class ClientsForm : Form
    {
        private MyFundsManager manager;

        private bool fEditMode = false;

        public ClientsForm()
        {
            manager = MyFundsManager.SingletonInstance;
            InitializeComponent();
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Countries' Puede moverla o quitarla según sea necesario.
            this.countriesTableAdapter.FillByFund(this.fundsDBDataSet.Countries, manager.Selected);

            loadClientsData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!fEditMode)
                {
                    Client _client = new Client();
                    _client.name = txtName.Text;
                    _client.FK_Clients_Funds = manager.Selected;
                    _client.CountryId = int.Parse(cbCountry.SelectedValue.ToString());
                    _client.number = txtNumber.Text;
                    manager.My_db.Clients.Add(_client);
                    manager.My_db.SaveChanges();
                }
                else
                {
                    Client _selectedItem = manager.My_db.Clients.FirstOrDefault(x => x.Id == (int)listBox1.SelectedValue);

                    if (_selectedItem != null)
                    {
                        _selectedItem.name = txtName.Text;
                        _selectedItem.number = txtNumber.Text;
                        _selectedItem.CountryId = int.Parse(cbCountry.SelectedValue.ToString());
                        manager.My_db.SaveChanges();
                    }
                }

                loadClientsData();

                cmdCancel_Click(null, null);
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult alert;
                alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (alert == DialogResult.OK)
                {

                    manager.DeleteClient(Convert.ToInt32(listBox1.SelectedValue));

                    loadClientsData();

                    cmdCancel_Click(null, null);
                }
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                fEditMode = true;
                cmdAddOrSave.Text = "Save";

                Client _selectedItem = manager.My_db.Clients.FirstOrDefault(x => x.Id == (int)listBox1.SelectedValue);

                if (_selectedItem != null)
                {
                    txtName.Text = _selectedItem.name;
                    txtNumber.Text = _selectedItem.number;
                }

                cmdCancel.Visible = true;
            }
            else
            {
                fEditMode = false;
                cmdAddOrSave.Text = "Add";
                txtName.Text = "";
                txtNumber.Text = "";

                cmdCancel.Visible = false;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
        }

        private void loadClientsData()
        {
            if (fundsDBDataSet != null && cbCountry.SelectedValue != null)
            {
                this.clientsTableAdapter.FillByCountryId(this.fundsDBDataSet.Clients, int.Parse(cbCountry.SelectedValue.ToString()), manager.Selected);
            }

            listBox1.SelectedIndex = -1;
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fEditMode)
            {
                loadClientsData();
            }
        }
    }
}
