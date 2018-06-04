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
        private MyFundsManager manager;
        private string[] tipos = new string[7] { "Asset", "Liability", "Equity", "Income", "Expense", "Contingency Asset","Contingency Liability" };
        public AccountsForm(MyFundsManager _manager)
        {
            manager = _manager;
            InitializeComponent();
            
            comboBox1.DataSource = tipos;
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
            
            Account _account = new Account();
            _account.name = textBox1.Text;
            _account.amount = 0;
            _account.number = textBox2.Text;
            _account.FK_Accounts_Funds = manager.Selected;
            _account.type = comboBox1.SelectedIndex;
            manager.My_db.Accounts.Add(_account);
            manager.My_db.SaveChanges();
            textBox1.Clear();
            textBox2.Clear();
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
            }
        }
    }
}
