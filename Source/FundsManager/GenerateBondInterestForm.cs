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
    public partial class GenerateBondInterestForm : Form
    {
        private MyFundsManager manager;
        private Decimal total_tff_interest;
        private Decimal total_bond_interest;
        public GenerateBondInterestForm()
        {
            manager = MyFundsManager.SingletonInstance;
            InitializeComponent();
            total_bond_interest = 0;
            total_tff_interest = 0;
            foreach (Bond _bond in manager.My_db.Bonds)
            {
                DateTime now = DateTime.Now;
                var startDate = new DateTime(now.Year, now.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);
                int days = (int)(endDate - startDate).TotalDays;

                Decimal amount = (Decimal)_bond.pieces * _bond.price;
                Decimal interest_on_bond = amount * (decimal)_bond.interest_on_bond / 100 * days / 360;
                Decimal interest_tff = amount * (decimal)_bond.interest_tff_contribution / 100  * days / 360;

                total_bond_interest += interest_on_bond;
                total_tff_interest += interest_tff;

                string[] row = { _bond.number, string.Format("€{0:N2}", amount), string.Format("€{0:N2}", interest_on_bond), string.Format("€{0:N2}", interest_tff) };
                ListViewItem my_item = new ListViewItem(row);
                my_item.Font = new Font(listView1.Font, FontStyle.Bold);
                listView1.Items.Add(my_item);
                foreach (BondsInvestor _investor in _bond.BondsInvestors)
                {

                    String name = manager.My_db.Investors.Find(_investor.FK_BondsInvestors_Investors).name;
                    Decimal second_amount = (Decimal)_investor.quantity * _bond.price;
                    Decimal second_interest_on_bond = second_amount * (decimal)_bond.interest_on_bond / 100 * days / 360;
                    Decimal second_interest_tff = second_amount * (decimal)_bond.interest_tff_contribution / 100 * days / 360;

                    string[] second_row = { name, string.Format("€{0:N2}", second_amount), string.Format("€{0:N2}", second_interest_on_bond), string.Format("€{0:N2}", second_interest_tff) };
                    ListViewItem second_item = new ListViewItem(second_row);
                    listView1.Items.Add(second_item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InterestConfirmationForm interest_confirmation_form = new InterestConfirmationForm(total_bond_interest, total_tff_interest);
            interest_confirmation_form.ShowDialog();
        }
    }
}
