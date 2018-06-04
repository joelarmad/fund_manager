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
    public partial class CreditorsForm : Form
    {
        private MyFundsManager manager;
        public CreditorsForm(MyFundsManager _manager)
        {
            manager = _manager;
            InitializeComponent();
        }

        private void CreditorsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Creditors' table. You can move, or remove it, as needed.
            this.creditorsTableAdapter.Fill(this.fundsDBDataSet.Creditors);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Creditor _creditor = new Creditor();
            _creditor.name = textBox1.Text;
            _creditor.FK_Creditors_Funds = manager.Selected;
            manager.My_db.Creditors.Add(_creditor);
            manager.My_db.SaveChanges();
            textBox1.Clear();
            this.creditorsTableAdapter.Fill(this.fundsDBDataSet.Creditors);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult alert;
            alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (alert == DialogResult.OK)
            {

                manager.DeleteCreditor(Convert.ToInt32(listBox1.SelectedValue));
                this.creditorsTableAdapter.Fill(this.fundsDBDataSet.Creditors);

            }
        }
    }
}
