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
            // TODO: This line of code loads data into the 'fundsDBDataSet.UnderlyingDebtors' table. You can move, or remove it, as needed.
            this.underlyingDebtorsTableAdapter.Fill(this.fundsDBDataSet.UnderlyingDebtors);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!fEditMode)
            {
                UnderlyingDebtor _debtor = new UnderlyingDebtor();
                _debtor.name = txtName.Text;
                _debtor.FK_UnderlyingDebtors_Funds = manager.Selected;
                manager.My_db.UnderlyingDebtors.Add(_debtor);
                manager.My_db.SaveChanges();
            }
            else
            {
                UnderlyingDebtor _selectedItem = manager.My_db.UnderlyingDebtors.FirstOrDefault(x => x.Id == (int)listBox1.SelectedValue);

                if (_selectedItem != null)
                {
                    _selectedItem.name = txtName.Text;
                    manager.My_db.SaveChanges();
                }
            }

            this.underlyingDebtorsTableAdapter.Fill(this.fundsDBDataSet.UnderlyingDebtors);

            cmdCancel_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult alert;
            alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (alert == DialogResult.OK)
            {

                manager.deleteUnderlyingDebtors(Convert.ToInt32(listBox1.SelectedValue));
                this.underlyingDebtorsTableAdapter.Fill(this.fundsDBDataSet.UnderlyingDebtors);
                cmdCancel_Click(null, null);
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
