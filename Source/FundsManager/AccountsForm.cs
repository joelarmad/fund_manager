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
    public partial class AccountsForm : Form
    {
        private bool fEditMode = false;

        private MyFundsManager manager;

        public AccountsForm()
        {
            manager = MyFundsManager.SingletonInstance;
            InitializeComponent();
            
            //cbType.DataSource = tipos;
        }       

        private void AccountsForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.AccountType' Puede moverla o quitarla según sea necesario.
            this.accountTypeTableAdapter.Fill(this.fundsDBDataSet.AccountType);
            // TODO: This line of code loads data into the 'fundsDBDataSet.Accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter.FillByFund(this.fundsDBDataSet.Accounts, manager.Selected);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                int typeId = 0;

                if (int.TryParse(dataGridView1.Rows[i].Cells[3].Value.ToString(), out typeId))
                {
                    AccountType accttype = manager.My_db.AccountTypes.FirstOrDefault(x => x.Id == typeId);

                    if (accttype != null)
                    {
                        dataGridView1.Rows[i].Cells[4].Value = accttype.AccountType1;
                    }
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            addAccount();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult alert;
                alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (alert == DialogResult.OK)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                    manager.DeleteAccount(Convert.ToInt32(selectedRow.Cells[0].Value));
                    this.accountsTableAdapter.FillByFund(this.fundsDBDataSet.Accounts, manager.Selected);
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        int typeId = 0;

                        if (int.TryParse(dataGridView1.Rows[i].Cells[3].Value.ToString(), out typeId))
                        {
                            AccountType accttype = manager.My_db.AccountTypes.FirstOrDefault(x => x.Id == typeId);

                            if (accttype != null)
                            {
                                dataGridView1.Rows[i].Cells[4].Value = accttype.AccountType1;
                            }
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
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }            
        }

        private void addAccount()
        {
            try
            {
                int typeId = 0;

                if (cbType.SelectedValue != null && int.TryParse(cbType.SelectedValue.ToString(), out typeId))
                {
                    if (!fEditMode)
                    {
                        Account _validationAccount = manager.My_db.Accounts.FirstOrDefault(x => x.number == txtAccountNumber.Text && x.FK_Accounts_Funds == manager.Selected);

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
                        _account.type = typeId;
                        manager.My_db.Accounts.Add(_account);
                        manager.My_db.SaveChanges();
                    }
                    else
                    {
                        Account _selectedAccount = manager.My_db.Accounts.FirstOrDefault(x => x.number == txtAccountNumber.Text && x.FK_Accounts_Funds == manager.Selected);

                        if (_selectedAccount != null)
                        {
                            _selectedAccount.name = txtName.Text;
                            _selectedAccount.type = typeId;

                            manager.My_db.SaveChanges();
                        }
                    }

                    this.accountsTableAdapter.FillByFund(this.fundsDBDataSet.Accounts, manager.Selected);

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (int.TryParse(dataGridView1.Rows[i].Cells[3].Value.ToString(), out typeId))
                        {
                            AccountType accttype = manager.My_db.AccountTypes.FirstOrDefault(x => x.Id == typeId);

                            if (accttype != null)
                            {
                                dataGridView1.Rows[i].Cells[4].Value = accttype.AccountType1;
                            }
                        }
                    }

                    cmdCancel_Click(null, null);

                    txtName.Focus();
                }
                else
                {
                    MessageBox.Show("Error selecting account type.");
                    return;
                }
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow _row = dataGridView1.Rows[e.RowIndex];

            string _accountNumber = _row.Cells[1].Value.ToString();

            Account _selectedAccount = manager.My_db.Accounts.FirstOrDefault(x => x.number == _accountNumber && x.FK_Accounts_Funds == manager.Selected);

            if (_selectedAccount != null)
            {
                fEditMode = true;
                cmdAddOrSave.Text = "Save";

                txtName.Text = _selectedAccount.name;
                txtAccountNumber.Text = _selectedAccount.number;
                txtAccountNumber.Enabled = false;

                AccountType accType = manager.My_db.AccountTypes.FirstOrDefault(x => x.Id == _selectedAccount.type);

                for (int i = 0; i < cbType.Items.Count; i++)
                {
                    int id = ((FundsManager.FundsDBDataSet.AccountTypeRow)((System.Data.DataRowView)cbType.Items[i]).Row).Id;

                    if (id == _selectedAccount.type)
                    {
                        cbType.SelectedIndex = i;
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
            txtAccountNumber.Text = "";
            txtAccountNumber.Enabled = true;

            cbType.SelectedIndex = 0;

            cmdCancel.Visible = false;
        }
    }
}
