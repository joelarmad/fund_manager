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
    public partial class FundsForm : Form
    {
        private MyFundsManager manager;
        
        public FundsForm(MyFundsManager _manager)
        {
            manager = _manager;            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fund _fund = new Fund();
            _fund.name = textBox1.Text;
            _fund.contract_prefix = textBox2.Text;
            manager.My_db.Funds.Add(_fund);
            manager.My_db.SaveChanges();
            textBox1.Clear();
            textBox2.Clear();
            this.fundsTableAdapter.Fill(this.fundsDBDataSet.Funds);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult alert;
            alert = MessageBox.Show("Warning, this action would delete all the operations of this fund. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (alert == DialogResult.OK)
            {
                
                manager.DeleteFund(Convert.ToInt32(listBox1.SelectedValue));                
                this.fundsTableAdapter.Fill(this.fundsDBDataSet.Funds);

            }
        }

        private void FundsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Funds' table. You can move, or remove it, as needed.
            this.fundsTableAdapter.Fill(this.fundsDBDataSet.Funds);

        }
    }
}
