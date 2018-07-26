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
    public partial class CurrenciesForm : Form
    {
        private MyFundsManager manager;

        private bool fEditMode = false;
        private int fEditIndex = -1;

        public CurrenciesForm()
        {
            manager = MyFundsManager.SingletonInstance;
            InitializeComponent();
        }

        private void CurrenciesForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Currencies' table. You can move, or remove it, as needed.
            this.currenciesTableAdapter.FillByFund(this.fundsDBDataSet.Currencies, manager.Selected);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!fEditMode)
            {
                Currency _currency = new Currency();
                _currency.name = txtName.Text;
                _currency.code = txtCode.Text;
                _currency.symbol = txtSymbol.Text;
                _currency.exchange = Convert.ToSingle(txtExchange.Text);
                _currency.FK_Currencies_Funds = manager.Selected;

                manager.My_db.Currencies.Add(_currency);
                manager.My_db.SaveChanges();
            }
            else
            {
                int _id = (int)dataGridView1.Rows[fEditIndex].Cells[0].Value;

                Currency _selectedItem = manager.My_db.Currencies.FirstOrDefault(x => x.Id == _id);

                if (_selectedItem != null)
                {
                    _selectedItem.name = txtName.Text;
                    _selectedItem.code = txtCode.Text;
                    _selectedItem.symbol = txtSymbol.Text;
                    _selectedItem.exchange = Convert.ToSingle(txtExchange.Text);

                    manager.My_db.SaveChanges();
                }
            }


            this.currenciesTableAdapter.FillByFund(this.fundsDBDataSet.Currencies, manager.Selected);

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
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                    int _Id = Convert.ToInt32(selectedRow.Cells[0].Value);

                    if (_Id != 1)
                    {
                        manager.DeleteCurrency(Convert.ToInt32(selectedRow.Cells[0].Value));
                        this.currenciesTableAdapter.FillByFund(this.fundsDBDataSet.Currencies, manager.Selected);
                    }
                    else
                    {
                        alert = MessageBox.Show("This currency can't be deleted.", "Illegal operation");
                    }

                    cmdCancel_Click(null, null);
                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show("Error: " + _ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fEditIndex = e.RowIndex;
            int _id = (int)dataGridView1.Rows[fEditIndex].Cells[0].Value;

            Currency _selectedItem = manager.My_db.Currencies.FirstOrDefault(x => x.Id == _id);

            if (_selectedItem != null)
            {
                fEditMode = true;
                cmdAddOrSave.Text = "Save";

                txtName.Text = _selectedItem.name;
                txtCode.Text = _selectedItem.code.Trim();
                txtSymbol.Text = _selectedItem.symbol;
                txtExchange.Text = _selectedItem.exchange.ToString();

                txtName.Enabled = _id != 1;
                txtCode.Enabled = _id != 1;
                txtSymbol.Enabled = _id != 1;

                cmdCancel.Visible = true;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            fEditMode = false;
            cmdAddOrSave.Text = "Add";

            txtName.Text = "";
            txtCode.Text = "";
            txtSymbol.Text = "";
            txtExchange.Text = "";

            txtName.Enabled = true;
            txtCode.Enabled = true;
            txtSymbol.Enabled = true;

            cmdCancel.Visible = false;
        }
    }
}
