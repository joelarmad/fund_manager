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
    public partial class InvestmentsForm : Form
    {
        private MyFundsManager manager;

        private Double disbursement;
        private Double profit;
        public InvestmentsForm(MyFundsManager _manager)
        {
            disbursement = 0;
            profit = 0;

            manager = _manager;
            InitializeComponent();

            textBox1.Text = manager.SelectedFund().contract_prefix;

            textBox2.Leave += textBox2_Leave;
            textBox2.Leave += calculate_total_collection;

            textBox3.Leave += textBox3_Leave;
            textBox3.Leave += calculate_total_collection;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisbursementsForm disbursements_form = new DisbursementsForm(manager);
            disbursements_form.Show();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(textBox2.Text, out value))
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

            if ((textBox3.Text != "" && textBox2.Text != "") && (profit > 0 && disbursement > 0)) {
                value = profit + disbursement;
                textBox4.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", value);
            }
        }
    }
}
