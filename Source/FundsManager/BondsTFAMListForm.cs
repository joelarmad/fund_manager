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
    public partial class BondsTFAMListForm : Form
    {
        private MyFundsManager manager = MyFundsManager.SingletonInstance;

        public BondsTFAMListForm()
        {
            InitializeComponent();
        }

        private void BondsTFAMListForm_Load(object sender, EventArgs e)
        {
            this.bondsTFAMTableAdapter.FillByFundId(this.fundsDBDataSet.BondsTFAM, manager.Selected);
        }
    }
}
