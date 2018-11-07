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
    public partial class DateSelection : Form
    {

        public DateTime? selectedDate;

        public DateSelection()
        {
            InitializeComponent();
        }

        private void DateSelection_Load(object sender, EventArgs e)
        {

        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            selectedDate = e.Start.Date;
            this.Close();
        }
    }
}
