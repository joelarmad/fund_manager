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

        //private List<DisbursementForInvestement> disbursements;
        private List<Disbursement> disbursements;
        private List<int> fItemIds = new List<int>();

        public DisbursementsForm(MyFundsManager _manager)
        {
            disbursement = 0;
            profit = 0;

            //disbursements = new List<DisbursementForInvestement>();
            disbursements = new List<Disbursement>();

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
            if (comboBox6.SelectedIndex >= 0)
            {
                fItemIds.Add((int)comboBox6.SelectedValue);

                listBox1.Items.Add(comboBox6.Text);
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Decimal total_amount = 0;
            Decimal total_profit = 0;
            Decimal total_euro_collection = 0;
            TimeSpan day = new TimeSpan();
            
            Disbursement _disbursement = new Disbursement();

            _disbursement.fund_id = manager.Selected;

            _disbursement.amount = Convert.ToDecimal(textBox1.Text);
            _disbursement.exchange_rate = Convert.ToSingle(textBox2.Text);
            _disbursement.profit_share = Convert.ToDecimal(textBox3.Text);
            _disbursement.currency_id = Convert.ToInt32(comboBox1.SelectedValue);
            _disbursement.bank_risk_id = Convert.ToInt32(comboBox4.SelectedValue);
            _disbursement.client_id = Convert.ToInt32(comboBox2.SelectedValue);
            _disbursement.underlying_debtor_id = Convert.ToInt32(comboBox3.SelectedValue);
            _disbursement.date = Convert.ToDateTime(dateTimePicker1.Text);


            disbursements.Add(_disbursement);
            
            _disbursement.Euro_collection = Convert.ToDecimal((disbursement + profit) / Convert.ToDouble(textBox2.Text));

            if (disbursements.First<Disbursement>().date != _disbursement.date)
                day = _disbursement.date.Subtract(disbursements.First<Disbursement>().date);

            if (listView1.Items.Count > 0)
                listView1.Items.RemoveAt(listView1.Items.Count - 1);


            string[] row = { comboBox2.Text, comboBox3.Text, String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", textBox1.Text), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", textBox3.Text), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", textBox4.Text), dateTimePicker1.Text, Convert.ToString(day.Days) };
            ListViewItem my_item = new ListViewItem(row);
            listView1.Items.Add(my_item);


            foreach (Disbursement _dis in disbursements)
            {
                total_amount += _dis.amount;
                total_profit += _dis.profit_share;
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

        private void cmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal _totalDisbursement = 0;
                decimal _totalProfitShare = 0;

                Investment _newInvestment = new Investment();

                _newInvestment.contract = "";
                _newInvestment.date = DateTime.Now.Date;
                _newInvestment.fund_id = manager.Selected;
                _newInvestment.sector_id = Convert.ToInt32(comboBox5.SelectedValue);
                
                manager.My_db.Investments.Add(_newInvestment);
                manager.My_db.SaveChanges();

                foreach (int _itemId in fItemIds)
                {
                    Item _item = manager.My_db.Items.FirstOrDefault(x => x.Id == _itemId);

                    _newInvestment.Items.Add(_item);
                }

                foreach (Disbursement _disbursement in disbursements)
                {
                    _disbursement.investment_id = _newInvestment.Id;

                    _totalDisbursement += _disbursement.Euro_collection;
                    _totalProfitShare += _disbursement.profit_share;

                    manager.My_db.Disbursements.Add(_disbursement);
                }

                _newInvestment.total_disbursement = _totalDisbursement;
                _newInvestment.profit_share = _totalProfitShare;

                manager.My_db.SaveChanges();

                fItemIds.Clear();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                listBox1.Items.Clear();
                listView1.Items.Clear();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.cmdCreate_Click: " + _ex.Message);
            }
        }
    }
}
