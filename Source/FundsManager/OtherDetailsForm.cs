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
    public partial class OtherDetailsForm : Form
    {
        private MyFundsManager manager;

        private bool fEditMode = false;
        private int fEditIndex = -1;

        public OtherDetailsForm()
        {
            manager = MyFundsManager.SingletonInstance;
            InitializeComponent();
        }

        private void OtherDetailsForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.OtherDetails' Puede moverla o quitarla según sea necesario.
            this.otherDetailsTableAdapter.Fill(this.fundsDBDataSet.OtherDetails);
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.OtherDetails' Puede moverla o quitarla según sea necesario.
            this.otherDetailsTableAdapter.Fill(this.fundsDBDataSet.OtherDetails);
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Subaccounts' Puede moverla o quitarla según sea necesario.
            this.subaccountsTableAdapter.Fill(this.fundsDBDataSet.Subaccounts);

            foreach (DataGridViewRow _row in dataGridView1.Rows)
            {
                Subaccount _subaccount = new Subaccount();
                _subaccount = manager.My_db.Subaccounts.Find(Convert.ToInt32(_row.Cells[3].Value));
                _row.Cells[4].Value = _subaccount.name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addDetail();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult alert;
            alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (alert == DialogResult.OK)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                manager.DeleteOtherDetails(Convert.ToInt32(selectedRow.Cells[0].Value));
                this.otherDetailsTableAdapter.Fill(this.fundsDBDataSet.OtherDetails);

                cmdCancel_Click(null, null);
            }
        }

        private void addDetail()
        {
            if (!fEditMode)
            {
                OtherDetail _otherdetail = new OtherDetail();
                _otherdetail.name = txtName.Text;
                _otherdetail.subacct_id = Convert.ToInt32(cbSubAccount.SelectedValue);
                _otherdetail.FK_OtherDetails_Funds = manager.Selected;
                manager.My_db.OtherDetails.Add(_otherdetail);
                manager.My_db.SaveChanges();
            }
            else
            {
                int _id = (int)dataGridView1.Rows[fEditIndex].Cells[0].Value;

                OtherDetail _selectedDetail = manager.My_db.OtherDetails.FirstOrDefault(x => x.Id == _id);

                if (_selectedDetail != null)
                {
                    _selectedDetail.name = txtName.Text;
                    _selectedDetail.subacct_id = Convert.ToInt32(cbSubAccount.SelectedValue);


                    manager.My_db.SaveChanges();
                }

            }
            
            this.otherDetailsTableAdapter.Fill(this.fundsDBDataSet.OtherDetails);

            foreach (DataGridViewRow _row in dataGridView1.Rows)
            {
                Subaccount _subaccount = new Subaccount();
                _subaccount = manager.My_db.Subaccounts.Find(Convert.ToInt32(_row.Cells[3].Value));
                _row.Cells[4].Value = _subaccount.name;
            }

            cmdCancel_Click(null, null);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b' || e.KeyChar == '\r')
            {
                addDetail();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fEditIndex = e.RowIndex;
            int _id = (int)dataGridView1.Rows[fEditIndex].Cells[0].Value;

            OtherDetail _selectedDetail = manager.My_db.OtherDetails.FirstOrDefault(x => x.Id == _id);

            if (_selectedDetail != null)
            {
                fEditMode = true;
                cmdAddOrSave.Text = "Save";

                txtName.Text = _selectedDetail.name;

                Subaccount _subacct = manager.My_db.Subaccounts.FirstOrDefault(x => x.Id == _selectedDetail.subacct_id);

                foreach (DataRowView _item in cbSubAccount.Items)
                {
                    if (_item.Row[0].ToString() == _subacct.Id.ToString())
                    {
                        cbSubAccount.SelectedItem = _item;
                        break;
                    }
                }

                cmdCancel.Visible = true;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            fEditMode = false;
            cmdAddOrSave.Text = "Add";

            txtName.Text = "";
            cbSubAccount.SelectedIndex = 0;

            cmdCancel.Visible = false;
        }
    }
}
