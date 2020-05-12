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
    public partial class BondsList : Form
    {
        private MyFundsManager manager;
        public BondsList()
        {
            manager = MyFundsManager.SingletonInstance;
            InitializeComponent();
            listView1.FullRowSelect = true;

            foreach (BondsTFF _bond in manager.My_db.BondsTFFs)
            {
                Decimal amount = (decimal)_bond.pieces * _bond.price;
                string[] row = { _bond.number, Convert.ToString(_bond.pieces), string.Format("€{0:N2}", amount), Convert.ToString(_bond.issued) };
                ListViewItem my_item = new ListViewItem(row);
                listView1.Items.Add(my_item);
            }
        }
    }
}
