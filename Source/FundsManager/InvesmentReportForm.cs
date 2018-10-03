using FundsManager.Classes.Utilities;
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
    public partial class InvesmentReportForm : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public InvesmentReportForm()
        {
            InitializeComponent();
        }

        private void InvesmentReportForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Banks' Puede moverla o quitarla según sea necesario.
            this.banksTableAdapter.FillExcludingOwnBanks(this.fundsDBDataSet.Banks, manager.Selected);
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.UnderlyingDebtors' Puede moverla o quitarla según sea necesario.
            this.underlyingDebtorsTableAdapter.FillAddingEmptyRow(this.fundsDBDataSet.UnderlyingDebtors, manager.Selected);
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Clients' Puede moverla o quitarla según sea necesario.
            this.clientsTableAdapter.FillWithEmpty(this.fundsDBDataSet.Clients, manager.Selected);
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Currencies' Puede moverla o quitarla según sea necesario.
            this.currenciesTableAdapter.FillWithEmpty(this.fundsDBDataSet.Currencies, manager.Selected);

            loadInvestments();

        }

        private void loadInvestments()
        {
            try
            {
                int clientId = 0;
                int bankId = 0;

                if (cbClient.SelectedValue != null && int.TryParse(cbClient.SelectedValue.ToString(), out clientId) &&
                    cbBank.SelectedValue != null && int.TryParse(cbBank.SelectedValue.ToString(), out bankId))
                {
                    this.investmentsViewTableAdapter.FillByFilters(this.fundsDBDataSet.InvestmentsView, clientId, bankId, manager.Selected);
                }

                
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            loadInvestments();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.RowCount)
                {
                    int disbursementId = 0;

                    if (int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), out disbursementId))
                    {

                        Disbursement disbToEdit = manager.My_db.Disbursements.FirstOrDefault(x => x.Id == disbursementId);

                        if (disbToEdit != null)
                        {
                            Investment invToEdit = disbToEdit.Investment;

                            if (invToEdit != null)
                            {
                                InvestmentsForm invForm = new InvestmentsForm();

                                invForm.EditingExistingInvestment = true;
                                invForm.InvestmenToEdit = invToEdit;
                                invForm.StartPosition = FormStartPosition.CenterScreen;

                                invForm.ShowDialog();

                                loadInvestments();
                            }
                        }
                    }
                }
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }
    }
}
