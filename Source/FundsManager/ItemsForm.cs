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
    public partial class ItemsForm : Form
    {
        private MyFundsManager manager;

        private bool fEditMode = false;

        public ItemsForm()
        {
            manager = MyFundsManager.SingletonInstance;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!fEditMode)
            {
                Item _item = new Item();
                _item.name = txtName.Text;
                _item.FK_Items_Funds = manager.Selected;
                manager.My_db.Items.Add(_item);
                manager.My_db.SaveChanges();
            }
            else
            {
                Item _selectedItem = manager.My_db.Items.FirstOrDefault(x => x.Id == (int)listBox1.SelectedValue);

                if (_selectedItem != null)
                {
                    _selectedItem.name = txtName.Text;
                    manager.My_db.SaveChanges();
                }
            }

            this.itemsTableAdapter.FillByFund(this.fundsDBDataSet.Items, manager.Selected);

            cmdCancel_Click(null, null);
        }

        private void ItemsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.FillByFund(this.fundsDBDataSet.Items, manager.Selected);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult alert;
                alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (alert == DialogResult.OK)
                {

                    manager.DeleteItem(Convert.ToInt32(listBox1.SelectedValue));
                    this.itemsTableAdapter.FillByFund(this.fundsDBDataSet.Items, manager.Selected);

                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show("Error: " + _ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                fEditMode = true;
                cmdAddOrSave.Text = "Save";

                Item _selectedItem = manager.My_db.Items.FirstOrDefault(x => x.Id == (int)listBox1.SelectedValue);

                if (_selectedItem != null)
                {
                    txtName.Text = _selectedItem.name;
                }

                cmdCancel.Visible = true;
            }
            else
            {
                fEditMode = false;
                cmdAddOrSave.Text = "Add";
                txtName.Text = "";

                cmdCancel.Visible = false;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
        }
    }
}
