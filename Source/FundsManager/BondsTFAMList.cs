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
    public partial class BondsTFAMList : Form
    {
        private MyFundsManager manager;

        private void BondsTFAMList_Load(object sender, EventArgs e)
        {
            manager = MyFundsManager.SingletonInstance;
           this.bondsTFAMTableAdapter.FillByFundId(this.fundsDBDataSet.BondsTFAM, manager.Selected);

        }
    }
}
