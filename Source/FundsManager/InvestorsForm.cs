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
    public partial class InvestorsForm : Form
    {
        private MyFundsManager manager;
        public InvestorsForm(MyFundsManager _manager)
        {
            manager = _manager;
            InitializeComponent();
        }

        private void InvestorsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Investors' table. You can move, or remove it, as needed.
            this.investorsTableAdapter.Fill(this.fundsDBDataSet.Investors);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Investor _investor = new Investor();
            _investor.name = textBox1.Text;
            _investor.FK_Investors_Funds = manager.Selected;
            manager.My_db.Investors.Add(_investor);
            manager.My_db.SaveChanges();
            textBox1.Clear();
            this.investorsTableAdapter.Fill(this.fundsDBDataSet.Investors);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult alert;
            alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (alert == DialogResult.OK)
            {

                manager.DeleteInvestor(Convert.ToInt32(listBox1.SelectedValue));
                this.investorsTableAdapter.Fill(this.fundsDBDataSet.Investors);

            }
        }
    }
}
