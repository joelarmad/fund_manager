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
    public partial class InterestConfirmationForm : Form
    {
        public InterestConfirmationForm(Decimal _total_bond_interest, Decimal _total_tff_interest)
        {
            InitializeComponent();
            label2.Text = string.Format("€{0:N2}", _total_bond_interest);
            label6.Text = string.Format("€{0:N2}", _total_bond_interest);
            label4.Text = string.Format("€{0:N2}", _total_tff_interest);
            label8.Text = string.Format("€{0:N2}", _total_tff_interest);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
