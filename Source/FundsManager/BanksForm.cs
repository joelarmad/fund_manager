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
    public partial class BanksForm : Form
    {
        private MyFundsManager manager;
        public BanksForm(MyFundsManager _manager)
        {
            manager = _manager;
            InitializeComponent();
        }

        private void BanksForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Banks' table. You can move, or remove it, as needed.
            this.banksTableAdapter.Fill(this.fundsDBDataSet.Banks);
            // TODO: This line of code loads data into the 'fundsDBDataSet.Countries' table. You can move, or remove it, as needed.
            this.countriesTableAdapter.Fill(this.fundsDBDataSet.Countries);            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bank _bank = new Bank();
            _bank.name = textBox1.Text;
            _bank.FK_Banks_Funds = manager.Selected;
            _bank.FK_Banks_Countries = Convert.ToInt32(comboBox1.SelectedValue);

            if (checkBox1.Checked)
                _bank.own = 1;
            else
                _bank.own = 0;


            manager.My_db.Banks.Add(_bank);
            manager.My_db.SaveChanges();

            textBox1.Clear();
            checkBox1.Checked = false;

            this.banksTableAdapter.Fill(this.fundsDBDataSet.Banks);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult alert;
            alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (alert == DialogResult.OK)
            {

                manager.DeleteBank(Convert.ToInt32(listBox1.SelectedValue));
                this.banksTableAdapter.Fill(this.fundsDBDataSet.Banks);

            }
        }
    }
}
