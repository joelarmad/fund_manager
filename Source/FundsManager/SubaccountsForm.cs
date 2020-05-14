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
    public partial class SubaccountsForm : Form
    {
        private MyFundsManager manager;

        private bool fEditMode = false;
        private int fEditIndex = -1;

        public SubaccountsForm()
        {
            manager = MyFundsManager.SingletonInstance;
            InitializeComponent();
            
        }

        private void SubaccountsForm_Load(object sender, EventArgs e)
        {
            this.accountsTableAdapter.FillByFund(this.fundsDBDataSet.Accounts, manager.Selected);

            loadSubAccountData();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addSubAccount();
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

                    manager.DeleteSubaccount(Convert.ToInt32(selectedRow.Cells[0].Value));

                    loadSubAccountData();

                    cmdCancel_Click(null, null);
                }
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void addSubAccount()
        {
            try
            {
                int accountId = Convert.ToInt32(cbAccount.SelectedValue);

                if (!fEditMode)
                {
                    Subaccount _validationSubAccount = manager.My_db.Subaccounts.FirstOrDefault(x => x.number == txtNumber.Text && x.FK_Subaccounts_Accounts == accountId && x.FK_Accounts_Funds == manager.Selected);

                    if (_validationSubAccount != null)
                    {
                        MessageBox.Show("Duplicated Subaccount number.");
                        return;
                    }

                    Subaccount _subaccount = new Subaccount();
                    _subaccount.name = txtName.Text;
                    _subaccount.FK_Subaccounts_Accounts = accountId;
                    _subaccount.FK_Accounts_Funds = manager.Selected;
                    _subaccount.number = txtNumber.Text;
                    manager.My_db.Subaccounts.Add(_subaccount);
                    manager.My_db.SaveChanges();
                }
                else
                {
                    int _id = (int)dataGridView1.Rows[fEditIndex].Cells[0].Value;

                    Subaccount _validationSubAccount = manager.My_db.Subaccounts.FirstOrDefault(x => x.Id != _id && x.number == txtNumber.Text && x.FK_Subaccounts_Accounts == accountId && x.FK_Accounts_Funds == manager.Selected);

                    if (_validationSubAccount != null)
                    {
                        MessageBox.Show("Duplicated Subaccount number.");
                        return;
                    }

                    Subaccount _selectedSubAccount = manager.My_db.Subaccounts.FirstOrDefault(x => x.Id == _id);

                    if (_selectedSubAccount != null)
                    {
                        _selectedSubAccount.name = txtName.Text;
                        _selectedSubAccount.number = txtNumber.Text;
                        _selectedSubAccount.FK_Subaccounts_Accounts = Convert.ToInt32(cbAccount.SelectedValue);

                        manager.My_db.SaveChanges();
                    }
                }

                loadSubAccountData();

                cmdCancel_Click(null, null);
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                fEditIndex = e.RowIndex;
                int _id = (int)dataGridView1.Rows[fEditIndex].Cells[0].Value;

                Subaccount _selectedSubAccount = manager.My_db.Subaccounts.FirstOrDefault(x => x.Id == _id);

                if (_selectedSubAccount != null)
                {
                    fEditMode = true;
                    cmdAddOrSave.Text = "Save";

                    txtName.Text = _selectedSubAccount.name;
                    txtNumber.Text = _selectedSubAccount.number;

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
            catch (Exception _ex)
            {
                MessageBox.Show("Error: " + _ex.Message);
            }
            
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            fEditMode = false;
            cmdAddOrSave.Text = "Add";

            txtName.Text = "";
            txtNumber.Text = "";

            cmdCancel.Visible = false;
        }

        private void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadSubAccountData();

            cmdCancel_Click(null, null);
        }

        private void loadSubAccountData()
        {
            if (fundsDBDataSet != null && cbAccount.SelectedValue != null)
            {
                this.subaccountsTableAdapter.FillByAccount(this.fundsDBDataSet.Subaccounts, int.Parse(cbAccount.SelectedValue.ToString()), manager.Selected);

                foreach (DataGridViewRow _row in dataGridView1.Rows)
                {
                    int id = Convert.ToInt32(_row.Cells[3].Value);
                    Account _account = new Account();
                    _account = manager.My_db.Accounts.FirstOrDefault(x => x.Id == id);
                    _row.Cells[4].Value = _account.name;
                }
            }
        }
    }
}
