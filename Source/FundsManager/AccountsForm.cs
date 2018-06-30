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
    public partial class AccountsForm : Form
    {
        private bool fEditMode = false;

        private MyFundsManager manager;
        private string[] tipos = new string[7] { "Asset", "Liability", "Equity", "Income", "Expense", "Contingency Asset","Contingency Liability" };
        public AccountsForm(MyFundsManager _manager)
        {
            manager = _manager;
            InitializeComponent();
            
            cbType.DataSource = tipos;
        }       

        private void AccountsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter.Fill(this.fundsDBDataSet.Accounts);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string temp = dataGridView1.Rows[i].Cells[3].Value.ToString();
                switch (temp)
                {

                    case "0":
                        dataGridView1.Rows[i].Cells[4].Value = "Asset";
                        break;
                    case "1":
                        dataGridView1.Rows[i].Cells[4].Value = "Liability";
                        break;
                    case "2":
                        dataGridView1.Rows[i].Cells[4].Value = "Equity";
                        break;
                    case "3":
                        dataGridView1.Rows[i].Cells[4].Value = "Income";
                        break;
                    case "4":
                        dataGridView1.Rows[i].Cells[4].Value = "Expense";
                        break;
                    case "5":
                        dataGridView1.Rows[i].Cells[4].Value = "Contingency Asset";
                        break;
                    case "6":
                        dataGridView1.Rows[i].Cells[4].Value = "Contingency Liability";
                        break;
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            addAccount();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult alert;
            alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (alert == DialogResult.OK)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                
                manager.DeleteAccount(Convert.ToInt32(selectedRow.Cells[0].Value));
                this.accountsTableAdapter.Fill(this.fundsDBDataSet.Accounts);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string temp = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    switch (temp)
                    {

                        case "0":
                            dataGridView1.Rows[i].Cells[4].Value = "Asset";
                            break;
                        case "1":
                            dataGridView1.Rows[i].Cells[4].Value = "Liability";
                            break;
                        case "2":
                            dataGridView1.Rows[i].Cells[4].Value = "Equity";
                            break;
                        case "3":
                            dataGridView1.Rows[i].Cells[4].Value = "Income";
                            break;
                        case "4":
                            dataGridView1.Rows[i].Cells[4].Value = "Expense";
                            break;
                        case "5":
                            dataGridView1.Rows[i].Cells[4].Value = "Contingency Asset";
                            break;
                        case "6":
                            dataGridView1.Rows[i].Cells[4].Value = "Contingency Liability";
                            break;
                    }
                }

                fEditMode = false;

                cmdAddOrSave.Text = "Add";

                txtName.Text = "";
                txtAccountNumber.Text = "";
                txtAccountNumber.Enabled = true;

                cbType.SelectedIndex = 0;

                cmdCancel.Visible = false;
            }
        }

        private void addAccount()
        {
            try
            {
                if (!fEditMode)
                {
                    Account _validationAccount = manager.My_db.Accounts.FirstOrDefault(x => x.number == txtAccountNumber.Text);

                    if (_validationAccount != null)
                    {
                        MessageBox.Show("Duplicated account number.");
                        return;
                    }

                    Account _account = new Account();
                    _account.name = txtName.Text;
                    _account.amount = 0;
                    _account.number = txtAccountNumber.Text;
                    _account.FK_Accounts_Funds = manager.Selected;
                    _account.type = cbType.SelectedIndex;
                    manager.My_db.Accounts.Add(_account);
                    manager.My_db.SaveChanges();
                    
                }
                else
                {
                    Account _selectedAccount = manager.My_db.Accounts.FirstOrDefault(x => x.number == txtAccountNumber.Text);

                    if (_selectedAccount != null)
                    {
                        _selectedAccount.name = txtName.Text;
                        _selectedAccount.type = cbType.SelectedIndex;

                        manager.My_db.SaveChanges();
                    }
                }

                this.accountsTableAdapter.Fill(this.fundsDBDataSet.Accounts);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string temp = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    switch (temp)
                    {

                        case "0":
                            dataGridView1.Rows[i].Cells[4].Value = "Asset";
                            break;
                        case "1":
                            dataGridView1.Rows[i].Cells[4].Value = "Liability";
                            break;
                        case "2":
                            dataGridView1.Rows[i].Cells[4].Value = "Equity";
                            break;
                        case "3":
                            dataGridView1.Rows[i].Cells[4].Value = "Income";
                            break;
                        case "4":
                            dataGridView1.Rows[i].Cells[4].Value = "Expense";
                            break;
                        case "5":
                            dataGridView1.Rows[i].Cells[4].Value = "Contingency Asset";
                            break;
                        case "6":
                            dataGridView1.Rows[i].Cells[4].Value = "Contingency Liability";
                            break;
                    }
                }

                cmdCancel_Click(null, null);

                txtName.Focus();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error at AccountsForm.addAccount: " + _ex.Message);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\r')
            {
                addAccount();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow _row = dataGridView1.Rows[e.RowIndex];

            string _accountNumber = _row.Cells[1].Value.ToString();

            Account _selectedAccount = manager.My_db.Accounts.FirstOrDefault(x => x.number == _accountNumber);

            if (_selectedAccount != null)
            {
                fEditMode = true;
                cmdAddOrSave.Text = "Save";

                txtName.Text = _selectedAccount.name;
                txtAccountNumber.Text = _selectedAccount.number;
                txtAccountNumber.Enabled = false;

                cbType.SelectedIndex = _selectedAccount.type;

                cmdCancel.Visible = true;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            fEditMode = false;

            cmdAddOrSave.Text = "Add";

            txtName.Text = "";
            txtAccountNumber.Text = "";
            txtAccountNumber.Enabled = true;

            cbType.SelectedIndex = 0;

            cmdCancel.Visible = false;
        }
    }
}
