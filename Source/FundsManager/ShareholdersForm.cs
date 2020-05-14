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
    public partial class ShareholdersForm : Form
    {
        private MyFundsManager manager;

        private bool fEditMode = false;

        public ShareholdersForm()
        {
            manager = MyFundsManager.SingletonInstance;
            InitializeComponent();
        }


        private void ShareholdersForm_Load(object sender, EventArgs e)
        {
            this.shareholdersTableAdapter.FillByFund(this.fundsDBDataSet.Shareholders, manager.Selected);

        }

        private void cmdAddOrSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!fEditMode)
                {
                    Shareholder _shareholder = new Shareholder();
                    _shareholder.name = txtName.Text;
                    _shareholder.FK_Creditors_Funds = manager.Selected;
                    _shareholder.number = txtNumber.Text;
                    manager.My_db.Shareholders.Add(_shareholder);
                    manager.My_db.SaveChanges();
                }
                else
                {
                    Shareholder _selectedItem = manager.My_db.Shareholders.FirstOrDefault(x => x.Id == (int)listBox1.SelectedValue);

                    if (_selectedItem != null)
                    {
                        _selectedItem.name = txtName.Text;
                        _selectedItem.number = txtNumber.Text;
                        manager.My_db.SaveChanges();
                    }
                }

                this.shareholdersTableAdapter.FillByFund(this.fundsDBDataSet.Shareholders, manager.Selected);

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

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult alert;
                alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (alert == DialogResult.OK)
                {

                    manager.DeleteShareholder(Convert.ToInt32(listBox1.SelectedValue));
                    this.shareholdersTableAdapter.FillByFund(this.fundsDBDataSet.Shareholders, manager.Selected);

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

                Shareholder _selectedItem = manager.My_db.Shareholders.FirstOrDefault(x => x.Id == (int)listBox1.SelectedValue);

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
    }
}
