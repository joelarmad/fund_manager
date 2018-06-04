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
            Subaccount _subaccount = new Subaccount();
            _subaccount.name = textBox1.Text;
            _subaccount.FK_Subaccounts_Accounts = Convert.ToInt32(comboBox1.SelectedValue);
            _subaccount.FK_Accounts_Funds = manager.Selected;
            manager.My_db.Subaccounts.Add(_subaccount);
            manager.My_db.SaveChanges();
            textBox1.Clear();
            comboBox1.ResetText();
            this.subaccountsTableAdapter.Fill(this.fundsDBDataSet.Subaccounts);
            foreach (DataGridViewRow _row in dataGridView1.Rows)
            {
                Account _account = new Account();
                _account = manager.My_db.Accounts.Find(Convert.ToInt32(_row.Cells[2].Value));
                _row.Cells[3].Value = _account.name;
            }
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
                
            }
        }
    }
}
