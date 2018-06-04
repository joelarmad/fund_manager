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
    public partial class DisbursementsForm : Form
    {
        private MyFundsManager manager;

        private Double disbursement;
        private Double profit;

        private List<DisbursementForInvestement> disbursements;

        public DisbursementsForm(MyFundsManager _manager)
        {
            disbursement = 0;
            profit = 0;

            disbursements = new List<DisbursementForInvestement>();

            manager = _manager;
            InitializeComponent();
            
            textBox1.Leave += textBox1_Leave;
            textBox1.Leave += calculate_total_collection;

            textBox3.Leave += textBox3_Leave;
            textBox3.Leave += calculate_total_collection;

            comboBox1.SelectedValueChanged += getExchangeRate;
 
        }

        private void DisbursementsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.fundsDBDataSet.Items);
            // TODO: This line of code loads data into the 'fundsDBDataSet.Sectors' table. You can move, or remove it, as needed.
            this.sectorsTableAdapter.Fill(this.fundsDBDataSet.Sectors);
            // TODO: This line of code loads data into the 'fundsDBDataSet.Banks' table. You can move, or remove it, as needed.
            this.banksTableAdapter.Fill(this.fundsDBDataSet.Banks);
            // TODO: This line of code loads data into the 'fundsDBDataSet.UnderlyingDebtors' table. You can move, or remove it, as needed.
            this.underlyingDebtorsTableAdapter.Fill(this.fundsDBDataSet.UnderlyingDebtors);
            // TODO: This line of code loads data into the 'fundsDBDataSet.Clients' table. You can move, or remove it, as needed.
            this.clientsTableAdapter.Fill(this.fundsDBDataSet.Clients);
            // TODO: This line of code loads data into the 'fundsDBDataSet.Currencies' table. You can move, or remove it, as needed.
            this.currenciesTableAdapter.Fill(this.fundsDBDataSet.Currencies);

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(textBox1.Text, out value))
                disbursement = value;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(textBox3.Text, out value))
                profit = value;
        }

        private void calculate_total_collection(object sender, EventArgs e)
        {
            Double value;

            if ((textBox1.Text != "" && textBox3.Text != "") && (profit > 0 && disbursement > 0))
            {
                value = (disbursement + profit) / Convert.ToDouble(textBox2.Text);
                textBox4.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", value);
            }
        }

        private void getExchangeRate(object sender, EventArgs e)
        {
            Double value = 0;
            if (comboBox1.SelectedIndex != -1)
                textBox2.Text = manager.My_db.Currencies.Find(Convert.ToInt32(comboBox1.SelectedValue)).exchange.ToString();
            if (disbursement > 0 && profit > 0)
            {
                value = (disbursement + profit) / Convert.ToDouble(textBox2.Text);
                textBox4.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", value);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            listBox1.Items.Add(comboBox6.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisbursementForInvestement _disbursement = new DisbursementForInvestement();
            Decimal total_amount = 0;
            Decimal total_profit = 0;
            Decimal total_euro_collection = 0;
            TimeSpan day = new TimeSpan();

            _disbursement.Amount = Convert.ToDecimal(textBox1.Text);
            _disbursement.Exchange = Convert.ToDecimal(textBox2.Text);
            _disbursement.Profit = Convert.ToDecimal(textBox3.Text);
            _disbursement.Currency = Convert.ToInt32(comboBox1.SelectedValue);

            _disbursement.Bank = Convert.ToInt32(comboBox4.SelectedValue);
            _disbursement.Client = Convert.ToInt32(comboBox2.SelectedValue);
            _disbursement.Underlying_debtor = Convert.ToInt32(comboBox3.SelectedValue);

            _disbursement.Sector = Convert.ToInt32(comboBox5.SelectedValue);
            _disbursement.Date = Convert.ToDateTime(dateTimePicker1.Text);

            _disbursement.Euro_collection = Convert.ToDecimal((disbursement + profit) / Convert.ToDouble(textBox2.Text));

            foreach (String _item in listBox1.Items) 
                foreach (Item real_item in manager.My_db.Items) 
                    if (real_item.name == _item)
                        _disbursement.Items.Add(real_item.Id);

            disbursements.Add(_disbursement);
            if (disbursements.First<DisbursementForInvestement>().Date != _disbursement.Date)
                day = _disbursement.Date.Subtract(disbursements.First<DisbursementForInvestement>().Date);

            if (listView1.Items.Count > 0)
                listView1.Items.RemoveAt(listView1.Items.Count - 1);

            
            string[] row = { comboBox2.Text, comboBox3.Text, String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", textBox1.Text), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", textBox3.Text), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", textBox4.Text), dateTimePicker1.Text, Convert.ToString(day.Days)};
            ListViewItem my_item = new ListViewItem(row);
            listView1.Items.Add(my_item);


            foreach (DisbursementForInvestement _dis in disbursements) { 
                total_amount += _dis.Amount;
                total_profit += _dis.Profit;
                total_euro_collection += _dis.Euro_collection;
            }

            string[] totales = { "Total", "", String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_amount), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_profit), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_euro_collection) };
            ListViewItem listViewItemTotal = new ListViewItem(totales);
            listView1.Items.Add(listViewItemTotal);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            listBox1.Items.Clear();

        }
    }
}
