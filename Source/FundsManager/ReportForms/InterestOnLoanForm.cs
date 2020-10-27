using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FundsManager.ReportForms
{
    public partial class InterestOnLoanForm : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public InterestOnLoanForm()
        {
            InitializeComponent();
        }

        private void InterestOnLoanForm_Load(object sender, EventArgs e)
        {
            this.creditorsTableAdapter.FillWithEmpty(this.fundsDBDataSet.Creditors, "Any Lender", manager.Selected);

            updateReport();

        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            updateReport();
        }

        private void updateReport()
        {
            try
            {
                String lender = "Any Lender";
                int lenderId = 0;

                if (cbLender.SelectedValue != null)
                {
                    lenderId = int.Parse(cbLender.SelectedValue.ToString());
                    lender = ((FundsManager.FundsDBDataSet.CreditorsRow)((System.Data.DataRowView)cbLender.SelectedItem).Row).name;
                }

                this.loans1TableAdapter.Fill(this.fundsDBDataSet.Loans1, dtpTo.Value, manager.Selected, lenderId);

                var rds = new ReportDataSource("DataSet1", (DataTable)this.fundsDBDataSet.Loans1);

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                ReportParameter language = new ReportParameter("Language", Thread.CurrentThread.CurrentCulture.Name);
                ReportParameter pLender = new ReportParameter("Lender", lender);
                ReportParameter pTo = new ReportParameter("To", "To " + dtpTo.Value.ToShortDateString());

                reportViewer1.LocalReport.SetParameters(language);
                reportViewer1.LocalReport.SetParameters(pLender);
                reportViewer1.LocalReport.SetParameters(pTo);


                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at GeneralBalanceForm.updateReport: " + ex.Message);
            }

        }
    }
}
