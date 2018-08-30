﻿using System;
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
    public partial class DisbursementPaymentForm : Form
    {

        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public bool loadAllData = false;
        public int paymentId = 0; 

        public DisbursementPaymentForm()
        {
            InitializeComponent();
        }

        private void DisbursementPaymentForm_Load(object sender, EventArgs e)
        {
            if (loadAllData)
            {
                // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.InvestmentsView' Puede moverla o quitarla según sea necesario.
                this.investmentsViewTableAdapter.FillByFundId(this.fundsDBDataSet.InvestmentsView, manager.Selected);
            }

            if (paymentId > 0)
            {
                // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.InvestmentsView' Puede moverla o quitarla según sea necesario.
                this.investmentsViewTableAdapter.FillByPaymentId(this.fundsDBDataSet.InvestmentsView, paymentId, manager.Selected);
            }

            this.reportViewer1.RefreshReport();

        }
    }
}