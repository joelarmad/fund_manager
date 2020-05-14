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
    public partial class UnknownRoutine : Form
    {

        private MyFundsManager manager;

        public UnknownRoutine()
        {
            manager = MyFundsManager.SingletonInstance;
            InitializeComponent();
        }

        private void UnknownRoutine_Load(object sender, EventArgs e)
        {
            loadData();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            this.unlinkedDisbursementsTableAdapter.FillByDate(this.fundsDBDataSet.UnlinkedDisbursements, manager.Selected, dateTimePicker1.Value.ToString("yyyy-MM-dd"));
        }
    }
}
