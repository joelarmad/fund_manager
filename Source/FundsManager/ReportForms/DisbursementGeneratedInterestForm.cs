using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FundsManager.ReportForms
{
    public partial class DisbursementGeneratedInterestForm : Form
    {
        public int generated_interest_id = 0;

        public DisbursementGeneratedInterestForm()
        {
            InitializeComponent();
        }

        private void DisbursementGeneratedInterestForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.DisbursementGeneratedInterestView' Puede moverla o quitarla según sea necesario.
            this.disbursementGeneratedInterestViewTableAdapter.FillByGeneratedId(this.fundsDBDataSet.DisbursementGeneratedInterestView, generated_interest_id);

            this.reportViewer1.RefreshReport();
        }
    }
}
