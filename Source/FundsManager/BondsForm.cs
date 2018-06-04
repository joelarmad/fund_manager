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
    public partial class BondsForm : Form
    {
        private MyFundsManager manager;
        private List<InvestorForBond> investors;
        private Decimal check_pieces;
        private Color _color;

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
            // TODO: This line of code loads data into the 'fundsDBDataSet.Investors' table. You can move, or remove it, as needed.
            this.investorsTableAdapter.Fill(this.fundsDBDataSet.Investors);
            comboBox1.SelectedItem = null;
            comboBox1.SelectedText = "Select investor";

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
            }
            else
            {
                _color = Color.FromName("Red");
            }

            totales_item.ForeColor = _color;
            listView1.Items.Add(totales_item);
            textBox5.Text = "";
            comboBox1.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (int index in listView1.SelectedIndices)
               investors.RemoveAt(index);

            foreach (ListViewItem _item in listView1.SelectedItems)
            {
                check_pieces -= Convert.ToDecimal(_item.SubItems[1].Text);
                listView1.Items.Remove(_item);
            }
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

            textBox1.Text = "";
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
