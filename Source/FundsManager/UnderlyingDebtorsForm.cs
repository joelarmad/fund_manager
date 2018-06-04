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
    public partial class UnderlyingDebtorsForm : Form
    {
        private MyFundsManager manager;

        public UnderlyingDebtorsForm(MyFundsManager _manager)
        {
            manager = _manager;
            InitializeComponent();
        }

        private void UnderlyingDebtorsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.UnderlyingDebtors' table. You can move, or remove it, as needed.
            this.underlyingDebtorsTableAdapter.Fill(this.fundsDBDataSet.UnderlyingDebtors);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UnderlyingDebtor _debtor = new UnderlyingDebtor();
            _debtor.name = textBox1.Text;
            _debtor.FK_UnderlyingDebtors_Funds = manager.Selected;
            manager.My_db.UnderlyingDebtors.Add(_debtor);
            manager.My_db.SaveChanges();
            textBox1.Clear();

            this.underlyingDebtorsTableAdapter.Fill(this.fundsDBDataSet.UnderlyingDebtors);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult alert;
            alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (alert == DialogResult.OK)
            {

                manager.deleteUnderlyingDebtors(Convert.ToInt32(listBox1.SelectedValue));
                this.underlyingDebtorsTableAdapter.Fill(this.fundsDBDataSet.UnderlyingDebtors);

            }
        }
    }
}
