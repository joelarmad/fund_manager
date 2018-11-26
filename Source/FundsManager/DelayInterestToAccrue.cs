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
    public partial class DelayInterestToAccrue : Form
    {
        

        public DelayInterestToAccrue()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void DelayInterestToAccrue_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.DelayInterestToAccrueSource' Puede moverla o quitarla según sea necesario.
            this.delayInterestToAccrueSourceTableAdapter.Fill(this.fundsDBDataSet.DelayInterestToAccrueSource);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddendumsForm addendumsForm = new AddendumsForm();
            addendumsForm.ShowDialog();
        }
    }
}
