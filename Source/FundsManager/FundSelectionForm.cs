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
    public partial class FundSelectionForm : Form
    {
        public FundSelectionForm()
        {
            InitializeComponent();
        }

        private void FundSelectionForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Funds' Puede moverla o quitarla según sea necesario.
            this.fundsTableAdapter.Fill(this.fundsDBDataSet.Funds);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int fundId = 0;

            if (cbFund.SelectedValue != null && int.TryParse(cbFund.SelectedValue.ToString(), out fundId))
            {
                MyFundsManager.SingletonInstance.Selected = fundId;

                this.Close();
            }
        }
    }
}
