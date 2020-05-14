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
    public partial class ServiceSupplierForm : Form
    {
        private MyFundsManager manager;

        private bool fEditMode = false;

        public ServiceSupplierForm()
        {
            manager = MyFundsManager.SingletonInstance;
            InitializeComponent();
        }

        private void ServiceSupplierForm_Load(object sender, EventArgs e)
        {
            this.serviceSuppliersTableAdapter.Fill(this.fundsDBDataSet.ServiceSuppliers, manager.Selected);

        }

        private void cmdAddOrSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!fEditMode)
                {
                    ServiceSupplier _serviceSupplier = new ServiceSupplier();
                    _serviceSupplier.name = txtName.Text;
                    _serviceSupplier.FK_ServiceSupplier_Funds = manager.Selected;
                    _serviceSupplier.number = txtNumber.Text;
                    manager.My_db.ServiceSuppliers.Add(_serviceSupplier);
                    manager.My_db.SaveChanges();
                }
                else
                {
                    ServiceSupplier _selectedItem = manager.My_db.ServiceSuppliers.FirstOrDefault(x => x.Id == (int)listBox1.SelectedValue);

                    if (_selectedItem != null)
                    {
                        _selectedItem.name = txtName.Text;
                        _selectedItem.number = txtNumber.Text;
                        manager.My_db.SaveChanges();
                    }
                }

                this.serviceSuppliersTableAdapter.Fill(this.fundsDBDataSet.ServiceSuppliers, manager.Selected);

                cmdCancel_Click(null, null);
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                fEditMode = true;
                cmdAddOrSave.Text = "Save";

                ServiceSupplier _selectedItem = manager.My_db.ServiceSuppliers.FirstOrDefault(x => x.Id == (int)listBox1.SelectedValue);

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

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult alert;
                alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (alert == DialogResult.OK)
                {

                    manager.DeleteServiceSupplier(Convert.ToInt32(listBox1.SelectedValue));
                    this.serviceSuppliersTableAdapter.Fill(this.fundsDBDataSet.ServiceSuppliers, manager.Selected);

                }
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }
    }
}
