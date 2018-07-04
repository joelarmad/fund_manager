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
    public partial class BondPayments : Form
    {
        public BondPayments()
        {
            InitializeComponent();
        }

        private void BondPayments_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Investors' Puede moverla o quitarla según sea necesario.
            this.investorsTableAdapter.Fill(this.fundsDBDataSet.Investors);

        }
    }
}
