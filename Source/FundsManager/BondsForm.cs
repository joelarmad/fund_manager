using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FundsManager.Classes.Utilities;
using System.Collections;

namespace FundsManager
{
    public partial class BondsForm : Form
    {
        private MyFundsManager manager;
        private List<InvestorForBond> investors;
        private Decimal check_pieces;
        private Color _color;

        private int fBondConsecutive = 0;

        public BondsForm(MyFundsManager _manager)
        {
            manager = _manager;
            investors = new List<InvestorForBond>();
            InitializeComponent();
            listView1.FullRowSelect = true;
            check_pieces = 0;
            _color = new Color();
            
        }

        private void BondsForm_Load(object sender, EventArgs e)
        {
            fBondConsecutive = 0;

            // TODO: This line of code loads data into the 'fundsDBDataSet.Investors' table. You can move, or remove it, as needed.
            this.investorsTableAdapter.Fill(this.fundsDBDataSet.Investors);
            comboBox1.SelectedItem = null;
            comboBox1.SelectedText = "Select investor";

            Resource _resource = manager.My_db.Resources.FirstOrDefault(x => x.Name == KeyDefinitions.BOND_CONSECUTIVE_KEY);

            if (_resource != null && _resource.Value != null && int.TryParse(_resource.Value, out fBondConsecutive))
            {
                textBox1.Text = "Bond " + Conversions.toRomanNumeral(fBondConsecutive);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
                listView1.Items.RemoveAt(listView1.Items.Count - 1);
            InvestorForBond investor = new InvestorForBond();

            investor.Pieces = (float)Convert.ToDouble(textBox5.Text);
            investor.Id = Convert.ToInt32(comboBox1.SelectedValue);

            investors.Add(investor);
            Decimal pieces_price = Convert.ToDecimal(textBox2.Text);

            float investor_amount = (float)pieces_price * investor.Pieces;


            string[] row = { comboBox1.Text, textBox5.Text, string.Format("€{0:N2}", investor_amount) };
            ListViewItem my_item = new ListViewItem(row);
            listView1.Items.Add(my_item);

            check_pieces += Convert.ToDecimal(textBox5.Text);
            Decimal amount = (pieces_price * Convert.ToDecimal(textBox6.Text));

            string[] totales = { "Total", textBox6.Text , string.Format("€{0:N2}", amount) };
            ListViewItem totales_item = new ListViewItem(totales);
            

            if (check_pieces == Convert.ToDecimal(textBox6.Text))
            {
                _color = Color.FromName("Green");
                button2.Enabled = true;
            }
            else
            {
                _color = Color.FromName("Red");
                button2.Enabled = false;
            }

            totales_item.ForeColor = _color;
            listView1.Items.Add(totales_item);
            textBox5.Text = "";
            comboBox1.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ArrayList _investorsToDelete = new ArrayList();

            foreach (int _index in listView1.SelectedIndices)
            {
                _investorsToDelete.Add(investors[_index]);
            }

            foreach (InvestorForBond _investor in _investorsToDelete)
            {
                investors.Remove(_investor);
            }

            listView1.Items.Clear();

            check_pieces = 0;
            Decimal pieces_price = Convert.ToDecimal(textBox2.Text);

            foreach (InvestorForBond _investorForBond in investors)
            {
                float investor_amount = (float)pieces_price * _investorForBond.Pieces;

                Investor _investor = manager.My_db.Investors.FirstOrDefault(x => x.Id == _investorForBond.Id);

                string[] row = { _investor.name, _investorForBond.Pieces.ToString(), string.Format("€{0:N2}", investor_amount) };
                ListViewItem my_item = new ListViewItem(row);
                listView1.Items.Add(my_item);

                check_pieces += (decimal)_investorForBond.Pieces;
                
                
                textBox5.Text = "";
                comboBox1.ResetText();
            }
            
            Decimal amount = (pieces_price * Convert.ToDecimal(textBox6.Text));

            string[] totales = { "Total", textBox6.Text, string.Format("€{0:N2}", amount) };

            if (check_pieces == Convert.ToDecimal(textBox6.Text))
            {
                _color = Color.FromName("Green");
                button2.Enabled = true;
            }
            else
            {
                _color = Color.FromName("Red");
                button2.Enabled = false;
            }

            ListViewItem totales_item = new ListViewItem(totales);

            totales_item.ForeColor = _color;
            listView1.Items.Add(totales_item);

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bond bond = new Bond();
            bond.number = textBox1.Text;
            bond.issued = Convert.ToDateTime(dateTimePicker1.Text);
            bond.FK_Bonds_Funds = manager.Selected;
            bond.price = Convert.ToDecimal(textBox2.Text);
            bond.pieces = (float)Convert.ToDecimal(textBox6.Text);
            bond.interest_on_bond = Convert.ToInt32(textBox3.Text);
            bond.interest_tff_contribution = Convert.ToInt32(textBox4.Text);
            manager.My_db.Bonds.Add(bond);
            manager.My_db.SaveChanges();

            foreach (InvestorForBond _investor in investors) {

                BondsInvestor bond_investor = new BondsInvestor();
                bond_investor.FK_BondsInvestors_Bonds = bond.Id;
                bond_investor.FK_BondsInvestors_Investors = _investor.Id;
                bond_investor.quantity = _investor.Pieces;
                manager.My_db.BondsInvestors.Add(bond_investor);
                manager.My_db.SaveChanges();

            }

            Resource _resource = manager.My_db.Resources.FirstOrDefault(x => x.Name == KeyDefinitions.BOND_CONSECUTIVE_KEY);

            fBondConsecutive++;

            _resource.Value = fBondConsecutive.ToString();

            manager.My_db.SaveChanges();

            textBox1.Text = "Bond " + Conversions.toRomanNumeral(fBondConsecutive);
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.ResetText();
            listView1.Items.Clear();

        }
    }
}
