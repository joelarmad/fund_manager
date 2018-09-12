using FundsManager.Classes.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FundsManager
{
    public partial class BankingAccountsForm : Form
    {
        private MyFundsManager manager;

        private bool fEditMode = false;
        private int fEditIndex = -1;

        public BankingAccountsForm()
        {
            manager = MyFundsManager.SingletonInstance;
            InitializeComponent();

            cbBank.DataSource = manager.OwnBanks();
            cbBank.DisplayMember = "Name";
            cbBank.ValueMember = "Id";
        }

        private void BankingAccountsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet1.BAccountsWithBanksCurrencies' table. You can move, or remove it, as needed.
            this.bAccountsWithBanksCurrenciesTableAdapter.FillByFund(this.fundsDBDataSet1.BAccountsWithBanksCurrencies, manager.Selected);
            // TODO: This line of code loads data into the 'fundsDBDataSet.BAccountsWithBanksCurrencies' table. You can move, or remove it, as needed.
            this.bAccountsWithBanksCurrenciesTableAdapter.FillByFund(this.fundsDBDataSet.BAccountsWithBanksCurrencies, manager.Selected);
            // TODO: This line of code loads data into the 'fundsDBDataSet.Currencies' table. You can move, or remove it, as needed.
            this.currenciesTableAdapter.FillByFund(this.fundsDBDataSet.Currencies, manager.Selected);
            // TODO: This line of code loads data into the 'fundsDBDataSet.Banks' table. You can move, or remove it, as needed.
            this.banksTableAdapter.FillByFund(this.fundsDBDataSet.Banks, manager.Selected);
            // TODO: This line of code loads data into the 'fundsDBDataSet.BankingAccounts' table. You can move, or remove it, as needed.
            this.bankingAccountsTableAdapter.FillByFund(this.fundsDBDataSet.BankingAccounts, manager.Selected);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            try
            {
                if (!fEditMode)
                {
                    BankingAccount _banking = new BankingAccount();
                    _banking.name = txtName.Text;
                    _banking.iban = txtIBAN.Text;
                    _banking.amount = 0;
                    _banking.FK_BankingAccounts_Funds = manager.Selected;
                    _banking.FK_BankingAccounts_Banks = Convert.ToInt32(cbBank.SelectedValue);
                    _banking.FK_BankingAccounts_Currencies = Convert.ToInt32(cbCurrency.SelectedValue);
                    _banking.number = txtNumber.Text;

                    manager.My_db.BankingAccounts.Add(_banking);
                    manager.My_db.SaveChanges();
                    
                }
                else
                {
                    int _id = (int)dataGridView1.Rows[fEditIndex].Cells[0].Value;

                    BankingAccount _selecteItem = manager.My_db.BankingAccounts.FirstOrDefault(x => x.Id == _id);

                    if (_selecteItem != null)
                    {
                        _selecteItem.name = txtName.Text;
                        _selecteItem.iban = txtIBAN.Text;
                        _selecteItem.FK_BankingAccounts_Banks = Convert.ToInt32(cbBank.SelectedValue);
                        _selecteItem.FK_BankingAccounts_Currencies = Convert.ToInt32(cbCurrency.SelectedValue);
                        _selecteItem.number = txtNumber.Text;

                        manager.My_db.SaveChanges();
                    }
                }
                
                this.bAccountsWithBanksCurrenciesTableAdapter.FillByFund(this.fundsDBDataSet.BAccountsWithBanksCurrencies, manager.Selected);
                this.bAccountsWithBanksCurrenciesTableAdapter.FillByFund(this.fundsDBDataSet1.BAccountsWithBanksCurrencies, manager.Selected);

                cmdCancel_Click(null, null);

            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }            
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

                    manager.DeleteBankingAccount(Convert.ToInt32(selectedRow.Cells[0].Value));
                    this.bAccountsWithBanksCurrenciesTableAdapter.FillByFund(this.fundsDBDataSet.BAccountsWithBanksCurrencies, manager.Selected);
                    this.bAccountsWithBanksCurrenciesTableAdapter.FillByFund(this.fundsDBDataSet1.BAccountsWithBanksCurrencies, manager.Selected);

                    cmdCancel_Click(null, null);
                }
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fEditIndex = e.RowIndex;
            int _id = (int)dataGridView1.Rows[fEditIndex].Cells[0].Value;

            BankingAccount _selecteItem = manager.My_db.BankingAccounts.FirstOrDefault(x => x.Id == _id);

            if (_selecteItem != null)
            {
                fEditMode = true;
                cmdAddOrSave.Text = "Save";

                txtName.Text = _selecteItem.name;
                txtIBAN.Text = _selecteItem.iban;
                txtNumber.Text = _selecteItem.number;

                Currency _currency = manager.My_db.Currencies.FirstOrDefault(x => x.Id == _selecteItem.FK_BankingAccounts_Currencies);

                foreach (DataRowView _item in cbCurrency.Items)
                {
                    if (_item.Row[0].ToString() == _currency.Id.ToString())
                    {
                        cbCurrency.SelectedItem = _item;
                        break;
                    }
                }

                Bank _bank = manager.My_db.Banks.FirstOrDefault(x => x.Id == _selecteItem.FK_BankingAccounts_Banks);

                cbBank.SelectedItem = _bank;

                cmdCancel.Visible = true;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            fEditMode = false;
            cmdAddOrSave.Text = "Add";

            txtName.Text = "";
            txtIBAN.Text = "";
            cbBank.SelectedIndex = 0;
            cbCurrency.SelectedIndex = 0;
            txtNumber.Text = "";

            cmdCancel.Visible = false;
        }
    }
}
