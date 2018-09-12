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
    public partial class UnderlyingDebtorsForm : Form
    {
        private MyFundsManager manager;

        private bool fEditMode = false;

        public UnderlyingDebtorsForm()
        {
            manager = MyFundsManager.SingletonInstance;
            InitializeComponent();
        }

        private void UnderlyingDebtorsForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet1.Countries' Puede moverla o quitarla según sea necesario.
            this.countriesTableAdapter.FillByFund(this.fundsDBDataSet1.Countries, manager.Selected);
            loadUnderlyingDebtorsData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!fEditMode)
                {
                    UnderlyingDebtor _debtor = new UnderlyingDebtor();
                    _debtor.name = txtName.Text;
                    _debtor.FK_UnderlyingDebtors_Funds = manager.Selected;
                    _debtor.number = txtNumber.Text;
                    _debtor.CountryId = int.Parse(cbCountry.SelectedValue.ToString());
                    manager.My_db.UnderlyingDebtors.Add(_debtor);
                    manager.My_db.SaveChanges();
                }
                else
                {
                    UnderlyingDebtor _selectedItem = manager.My_db.UnderlyingDebtors.FirstOrDefault(x => x.Id == (int)listBox1.SelectedValue);

                    if (_selectedItem != null)
                    {
                        _selectedItem.name = txtName.Text;
                        _selectedItem.number = txtNumber.Text;
                        _selectedItem.CountryId = int.Parse(cbCountry.SelectedValue.ToString());
                        manager.My_db.SaveChanges();
                    }
                }

                loadUnderlyingDebtorsData();

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

                    manager.deleteUnderlyingDebtors(Convert.ToInt32(listBox1.SelectedValue));
                    loadUnderlyingDebtorsData();
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

                UnderlyingDebtor _selectedItem = manager.My_db.UnderlyingDebtors.FirstOrDefault(x => x.Id == (int)listBox1.SelectedValue);

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

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fEditMode)
            {
                loadUnderlyingDebtorsData();
            }
        }

        private void loadUnderlyingDebtorsData()
        {
            if (fundsDBDataSet != null && cbCountry.SelectedValue != null)
            {
                this.underlyingDebtorsTableAdapter.FillByCountryId(this.fundsDBDataSet.UnderlyingDebtors, int.Parse(cbCountry.SelectedValue.ToString()), manager.Selected);
            }

            listBox1.SelectedIndex = -1;
        }
    }
}
