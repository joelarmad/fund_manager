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
    public partial class MovementReportForm : Form
    {
        private MyFundsManager manager;
        public MovementReportForm()
        {
            try
            {
                manager = MyFundsManager.SingletonInstance;
                InitializeComponent();

                dtpFrom.Value = DateTime.Now.AddMonths(-1).Date;
                dtpTo.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

                loadData();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error at MovementReportForm.MovementReportForm: " + _ex.Message);
            }
        }
        private void MovementReportForm_Load(object sender, EventArgs e)
        {
            this.accountsTableAdapter.FillWithEmpty(this.fundsDBDataSet.Accounts, manager.Selected);
            cbAccount.SelectedIndex = -1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            try
            {
                this.movementsViewTableAdapter.FillByFilters(this.fundsDBDataSet.MovementsView, manager.Selected, txtReference.Text.Trim(), cbAccount.SelectedValue != null ? int.Parse(cbAccount.SelectedValue.ToString()) : 0, dtpFrom.Value.Date, dtpTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            String reference = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            AccountingMovement accMov = manager.My_db.AccountingMovements.FirstOrDefault(x => x.reference == reference && x.FK_AccountingMovements_Funds == manager.Selected);

            if (accMov != null)
            {
                GeneralLedgerForm ledger = new GeneralLedgerForm();
                ledger.FormInEditAccountingMovement = true;
                ledger.IdOfAccountingMovementToEdit = accMov.Id;
                ledger.StartPosition = FormStartPosition.CenterScreen;
                ledger.ShowDialog();

                loadData();
            }
        }
    }
}
