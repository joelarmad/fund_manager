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
    public partial class BookReportForm : Form
    {
        private MyFundsManager manager;

        public BookReportForm()
        {
            try
            {
                manager = MyFundsManager.SingletonInstance;
                InitializeComponent();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BookReportForm.BookReportForm: " + _ex.Message);
            }
        }

        private void BookReportForm_Load(object sender, EventArgs e)
        {
            this.clientsTableAdapter.FillByFund(this.fundsDBDataSet.Clients, manager.Selected);

            updateContractCombo();
        }

        private void updateContractCombo()
        {
            int clientId = 0;

            if (cbClient.SelectedValue != null && int.TryParse(cbClient.SelectedValue.ToString(), out clientId))
            {
                this.clientContractsTableAdapter.FillByClient(this.fundsDBDataSet.ClientContracts, manager.Selected, clientId);
            }
        }

        private void updateBookings()
        {
            int investmentId = 0;

            if (cbContract.SelectedValue != null && int.TryParse(cbContract.SelectedValue.ToString(), out investmentId))
            {
                this.disbursementsBookingViewTableAdapter.FillByInvestmentId(this.fundsDBDataSet.DisbursementsBookingView, manager.Selected, investmentId);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    AddendumsForm addendumsForm = new AddendumsForm();
                    addendumsForm.DisbursementId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    addendumsForm.EditingExistingBook = true;
                    int book_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    addendumsForm.BookToEdit = manager.My_db.DisbursementBooks.FirstOrDefault(x => x.Id == book_id);
                    addendumsForm.ShowDialog();

                    updateBookings();
                }
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateContractCombo();
            updateBookings();
        }

        private void cbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateBookings();
        }
    }
}
