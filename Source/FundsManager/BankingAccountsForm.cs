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
        public BankingAccountsForm(MyFundsManager _manager)
        {
            manager = _manager;
            InitializeComponent();

            comboBox2.DataSource = manager.OwnBanks();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
        }

        private void BankingAccountsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet1.BAccountsWithBanksCurrencies' table. You can move, or remove it, as needed.
            this.bAccountsWithBanksCurrenciesTableAdapter.Fill(this.fundsDBDataSet1.BAccountsWithBanksCurrencies);
            // TODO: This line of code loads data into the 'fundsDBDataSet.BAccountsWithBanksCurrencies' table. You can move, or remove it, as needed.
            this.bAccountsWithBanksCurrenciesTableAdapter.Fill(this.fundsDBDataSet.BAccountsWithBanksCurrencies);
            // TODO: This line of code loads data into the 'fundsDBDataSet.Currencies' table. You can move, or remove it, as needed.
            this.currenciesTableAdapter.Fill(this.fundsDBDataSet.Currencies);
            // TODO: This line of code loads data into the 'fundsDBDataSet.Banks' table. You can move, or remove it, as needed.
            this.banksTableAdapter.Fill(this.fundsDBDataSet.Banks);
            // TODO: This line of code loads data into the 'fundsDBDataSet.BankingAccounts' table. You can move, or remove it, as needed.
            this.bankingAccountsTableAdapter.Fill(this.fundsDBDataSet.BankingAccounts);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BankingAccount _banking = new BankingAccount();
                _banking.name = textBox1.Text;
                _banking.iban = textBox2.Text;
                _banking.amount = Convert.ToDecimal(textBox3.Text);
                _banking.FK_BankingAccounts_Funds = manager.Selected;
                _banking.FK_BankingAccounts_Banks = Convert.ToInt32(comboBox2.SelectedValue);
                _banking.FK_BankingAccounts_Currencies = Convert.ToInt32(comboBox1.SelectedValue);

                manager.My_db.BankingAccounts.Add(_banking);
                manager.My_db.SaveChanges();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                this.bAccountsWithBanksCurrenciesTableAdapter.Fill(this.fundsDBDataSet.BAccountsWithBanksCurrencies);
                this.bAccountsWithBanksCurrenciesTableAdapter.Fill(this.fundsDBDataSet1.BAccountsWithBanksCurrencies);
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);

                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
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

                manager.DeleteBankingAccount(Convert.ToInt32(selectedRow.Cells[0].Value));
                this.bAccountsWithBanksCurrenciesTableAdapter.Fill(this.fundsDBDataSet.BAccountsWithBanksCurrencies);
                this.bAccountsWithBanksCurrenciesTableAdapter.Fill(this.fundsDBDataSet1.BAccountsWithBanksCurrencies);
            }
        }
    }
}
