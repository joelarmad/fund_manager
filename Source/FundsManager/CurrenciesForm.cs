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
        public CurrenciesForm(MyFundsManager _manager)
        {
            manager = _manager;
            InitializeComponent();
        }

        private void CurrenciesForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Currencies' table. You can move, or remove it, as needed.
            this.currenciesTableAdapter.Fill(this.fundsDBDataSet.Currencies);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Currency _currency = new Currency();
            _currency.name = textBox1.Text;
            _currency.code = textBox2.Text;
            _currency.symbol = textBox3.Text;
            _currency.exchange = Convert.ToSingle(textBox4.Text);
            _currency.FK_Currencies_Funds = manager.Selected;
           
            manager.My_db.Currencies.Add(_currency);
            manager.My_db.SaveChanges();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            this.currenciesTableAdapter.Fill(this.fundsDBDataSet.Currencies);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult alert;
            alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (alert == DialogResult.OK)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                manager.DeleteCurrency(Convert.ToInt32(selectedRow.Cells[0].Value));
                this.currenciesTableAdapter.Fill(this.fundsDBDataSet.Currencies);

            }
        }
    }
}
