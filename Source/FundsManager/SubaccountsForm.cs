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
    public partial class SubaccountsForm : Form
    {
        private MyFundsManager manager;

        private bool fEditMode = false;
        private int fEditIndex = -1;

        public SubaccountsForm(MyFundsManager _manager)
        {
            manager = _manager;
            InitializeComponent();
            
        }

        private void SubaccountsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Subaccounts' table. You can move, or remove it, as needed.
            this.subaccountsTableAdapter.Fill(this.fundsDBDataSet.Subaccounts);
            // TODO: This line of code loads data into the 'fundsDBDataSet.Accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter.Fill(this.fundsDBDataSet.Accounts);

            foreach (DataGridViewRow _row in dataGridView1.Rows)
            {
                Account _account = new Account();
                _account = manager.My_db.Accounts.Find(Convert.ToInt32(_row.Cells[2].Value));
                _row.Cells[3].Value = _account.name;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addSubAccount();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult alert;
            alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (alert == DialogResult.OK)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                manager.DeleteSubaccount(Convert.ToInt32(selectedRow.Cells[0].Value));
                this.subaccountsTableAdapter.Fill(this.fundsDBDataSet.Subaccounts);

                cmdCancel_Click(null, null);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b' || e.KeyChar == '\r')
            {
                addSubAccount();
            }
        }

        private void addSubAccount()
        {
            if (!fEditMode)
            {
                Subaccount _subaccount = new Subaccount();
                _subaccount.name = txtName.Text;
                _subaccount.FK_Subaccounts_Accounts = Convert.ToInt32(cbAccount.SelectedValue);
                _subaccount.FK_Accounts_Funds = manager.Selected;
                manager.My_db.Subaccounts.Add(_subaccount);
                manager.My_db.SaveChanges();
            }
            else
            {
                int _id = (int)dataGridView1.Rows[fEditIndex].Cells[0].Value;

                Subaccount _selectedSubAccount = manager.My_db.Subaccounts.FirstOrDefault(x => x.Id == _id);

                if (_selectedSubAccount != null)
                {
                    _selectedSubAccount.name = txtName.Text;
                    _selectedSubAccount.FK_Subaccounts_Accounts = Convert.ToInt32(cbAccount.SelectedValue);

                    manager.My_db.SaveChanges();
                }
            }


            this.subaccountsTableAdapter.Fill(this.fundsDBDataSet.Subaccounts);

            foreach (DataGridViewRow _row in dataGridView1.Rows)
            {
                Account _account = new Account();
                _account = manager.My_db.Accounts.Find(Convert.ToInt32(_row.Cells[2].Value));
                _row.Cells[3].Value = _account.name;
            }

            cmdCancel_Click(null, null);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fEditIndex = e.RowIndex;
            int _id = (int)dataGridView1.Rows[fEditIndex].Cells[0].Value;

            Subaccount _selectedSubAccount = manager.My_db.Subaccounts.FirstOrDefault(x => x.Id == _id);

            if (_selectedSubAccount != null)
            {
                fEditMode = true;
                cmdAddOrSave.Text = "Save";

                txtName.Text = _selectedSubAccount.name;

                Account _acct = manager.My_db.Accounts.FirstOrDefault(x => x.Id == _selectedSubAccount.FK_Subaccounts_Accounts);

                foreach (DataRowView _item in cbAccount.Items)
                {
                    if (_item.Row[0].ToString() == _acct.Id.ToString())
                    {
                        cbAccount.SelectedItem = _item;
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
            cbAccount.SelectedIndex = 0;

            cmdCancel.Visible = false;
        }
    }
}
