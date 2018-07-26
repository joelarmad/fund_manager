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
    public partial class SectorsForm : Form
    {
        private MyFundsManager manager;

        private bool fEditMode = false;

        public SectorsForm()
        {
            manager = MyFundsManager.SingletonInstance;
            InitializeComponent();
        }

        private void SectorsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Sectors' table. You can move, or remove it, as needed.
            this.sectorsTableAdapter.FillByFund(this.fundsDBDataSet.Sectors, manager.Selected);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!fEditMode)
            {
                Sector _sector = new Sector();
                _sector.name = txtName.Text;
                _sector.FK_Sectors_Funds = manager.Selected;
                manager.My_db.Sectors.Add(_sector);
                manager.My_db.SaveChanges();
            }
            else
            {
                Sector _selectedItem = manager.My_db.Sectors.FirstOrDefault(x => x.Id == (int)listBox1.SelectedValue);

                if (_selectedItem != null)
                {
                    _selectedItem.name = txtName.Text;
                    manager.My_db.SaveChanges();
                }
            }

            this.sectorsTableAdapter.FillByFund(this.fundsDBDataSet.Sectors, manager.Selected);

            cmdCancel_Click(null, null);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult alert;
                alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (alert == DialogResult.OK)
                {

                    manager.DeleteSector(Convert.ToInt32(listBox1.SelectedValue));
                    this.sectorsTableAdapter.FillByFund(this.fundsDBDataSet.Sectors, manager.Selected);
                    cmdCancel_Click(null, null);
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

                Sector _selectedItem = manager.My_db.Sectors.FirstOrDefault(x => x.Id == (int)listBox1.SelectedValue);

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
