using FundsManager.Classes.Utilities;
using FundsManager.ReportForms;
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
    public partial class DisbursementToBeOverdueForm : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        int idIndex = 0;
        int disburdsementIdIndex = 1;
        int bookingIdIndex = 2;
        int referenceIndex = 3;
        int numberIndex = 4;
        int collectionDateIndex = 5;
        int investmentIndex = 6;
        int profitShareIndex = 7;
        int delayInterestIndex = 8;
        int toBeCollectedIndex = 9;
        int overdueIndex = 10;
        int fromIndex = 11;
        int toIndex = 12;
        int daysIndex = 13;

        public DisbursementToBeOverdueForm()
        {
            InitializeComponent();
        }

        private void DisbursementToBeOverdueForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.clientsTableAdapter.FillWithEmpty(this.fundsDBDataSet.Clients, "Select client", manager.Selected);

                updateContractCombo();

                loadOverdues();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementToBeOverdueForm.DisbursementToBeOverdueForm_Load: " + _ex.Message);
            }
        }

        private void updateContractCombo()
        {
            try
            {
                int clientId = 0;

                if (cbClient.SelectedValue != null && int.TryParse(cbClient.SelectedValue.ToString(), out clientId) && clientId > 0)
                {
                    this.clientContractsTableAdapter.FillByClient(this.fundsDBDataSet.ClientContracts, manager.Selected, clientId);
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementToBeOverdueForm.updateContractCombo: " + _ex.Message);
            }
        }

        private void loadOverdues()
        {
            try
            {
                int clientId = 0;
                if (cbClient.SelectedValue != null)
                {
                    int.TryParse(cbClient.SelectedValue.ToString(), out clientId);
                }

                int investmentId = 0;
                if (cbContract.SelectedValue != null)
                {
                    int.TryParse(cbContract.SelectedValue.ToString(), out investmentId);
                }

                decimal monthly_rate = 0;
                if (decimal.TryParse(txtMonthlyRate.Text.Trim(), out monthly_rate) && monthly_rate > 0)
                {
                    this.disbursementToBeOverduedTableAdapter.Fill(this.fundsDBDataSet.DisbursementToBeOverdued, clientId, investmentId, dtpDate.Value.Date, monthly_rate, manager.Selected);
                }
                else
                {
                    MessageBox.Show("Invalid monthly rate.");
                }
                
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementToBeOverdueForm.loadOverdues: " + _ex.Message);
            }
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                updateContractCombo();

                loadOverdues();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementToBeOverdueForm.cbClient_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void cbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadOverdues();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementToBeOverdueForm.cbContract_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                loadOverdues();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementToBeOverdueForm.dtpDate_ValueChanged: " + _ex.Message);
            }
        }

        private void cmdGenerateAll_Click(object sender, EventArgs e)
        {
            if (manager.My_db.ClosedPeriods.FirstOrDefault(x => x.year == dtpDate.Value.Year) == null)
            {
                generate(true);

                loadOverdues();
            }
            else
            {
                ErrorMessage.showErrorMessage(new Exception("No movement allowed in closed period."));
            }
        }

        private void cmdJustForSelection_Click(object sender, EventArgs e)
        {
            generate(false);

            loadOverdues();
        }

        private DisbursementOverdueDetail readFromRow(DataGridViewRow row, decimal monthlyRate)
        {
            DisbursementOverdueDetail detail = new DisbursementOverdueDetail();

            try
            {
                int days = int.Parse(row.Cells[daysIndex].Value.ToString());

                detail.disbursement_id = int.Parse(row.Cells[disburdsementIdIndex].Value.ToString());
                detail.booking_id = int.Parse(row.Cells[bookingIdIndex].Value.ToString());
                detail.generated_overdue = decimal.Parse(row.Cells[toBeCollectedIndex].Value.ToString()) * monthlyRate * daysIndex / 30 / 100;
                detail.monthly_rate = monthlyRate;
                detail.overdue_date_from = DateTime.Parse(row.Cells[fromIndex].Value.ToString());
                detail.overdue_date_to = DateTime.Parse(row.Cells[toIndex].Value.ToString());
                detail.collected = 0;

                return detail;
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementToBeOverdueForm.readFromRow: " + _ex.Message);
            }

            return null;
        }

        private void generate(bool forAll)
        {
            try
            {
                decimal monthly_rate = 0;

                if (decimal.TryParse(txtMonthlyRate.Text.Trim(), out monthly_rate) && monthly_rate > 0)
                {
                    if ((forAll && dataGridView1.Rows.Count > 0) || (!forAll && dataGridView1.SelectedRows.Count > 0))
                    {
                        Account account130 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "130" && x.FK_Accounts_Funds == manager.Selected);
                        Account account902 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "902" && x.FK_Accounts_Funds == manager.Selected);

                        if (account130 != null && account902 != null)
                        {
                            List<DisbursementOverdueDetail> details = new List<DisbursementOverdueDetail>();

                            if (forAll)
                            {

                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    DisbursementOverdueDetail detail = readFromRow(row, monthly_rate);

                                    if (detail != null)
                                    {
                                        details.Add(detail);
                                    }
                                    else
                                    {
                                        //TODO: error. El detail no se pudo generar
                                    }
                                }
                            }
                            else
                            {
                                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                                {
                                    DisbursementOverdueDetail detail = readFromRow(row, monthly_rate);

                                    if (detail != null)
                                    {
                                        details.Add(detail);
                                    }
                                    else
                                    {
                                        //TODO: error. El detail no se pudo generar
                                    }
                                }
                            }

                            if (details.Count > 0)
                            {
                                DisbursementOverdue overdue = new DisbursementOverdue();
                                overdue.OverdueDate = dtpDate.Value.Date;

                                manager.My_db.DisbursementOverdues.Add(overdue);

                                foreach (DisbursementOverdueDetail detail in details)
                                {
                                    detail.DisbursementOverdue = overdue;

                                    Disbursement disbursement = manager.My_db.Disbursements.FirstOrDefault(x => x.Id == detail.disbursement_id);

                                    if (disbursement != null)
                                    {
                                        Currency currency = manager.My_db.Currencies.FirstOrDefault(x => x.Id == disbursement.currency_id && x.FK_Currencies_Funds == manager.Selected);
                                        Subaccount subacct130 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account130.Id && x.name == "INV " + currency.symbol);

                                        AccountingMovement accountingMovement = new AccountingMovement();
                                        accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                                        accountingMovement.description = "Overdue";
                                        accountingMovement.date = dtpDate.Value.Date;
                                        accountingMovement.reference = KeyDefinitions.NextAccountMovementReference(dtpDate.Value.Year);
                                        accountingMovement.FK_AccountingMovements_Currencies = disbursement.currency_id;
                                        accountingMovement.original_reference = "";
                                        accountingMovement.contract = disbursement.Investment.contract;

                                        manager.My_db.AccountingMovements.Add(accountingMovement);

                                        detail.AccountingMovement = accountingMovement;

                                        Movements_Accounts _maccount130 = new Movements_Accounts();

                                        _maccount130.AccountingMovement = accountingMovement;
                                        _maccount130.FK_Movements_Accounts_Funds = manager.Selected;
                                        _maccount130.FK_Movements_Accounts_Accounts = account130.Id;
                                        if (subacct130 != null)
                                            _maccount130.FK_Movements_Accounts_Subaccounts = subacct130.Id;
                                        _maccount130.subaccount = disbursement.client_id;
                                        _maccount130.subaccount_type = 1;
                                        _maccount130.debit = Math.Round(detail.generated_overdue, 2);
                                        _maccount130.credit = 0;

                                        manager.My_db.Movements_Accounts.Add(_maccount130);

                                        Movements_Accounts _maccount902 = new Movements_Accounts();

                                        _maccount902.AccountingMovement = accountingMovement;
                                        _maccount902.FK_Movements_Accounts_Funds = manager.Selected;
                                        _maccount902.FK_Movements_Accounts_Accounts = account902.Id;

                                        _maccount902.subaccount = disbursement.client_id;
                                        _maccount902.subaccount_type = 1;
                                        _maccount902.debit = 0;
                                        _maccount902.credit = Math.Round(detail.generated_overdue, 2);

                                        manager.My_db.Movements_Accounts.Add(_maccount902);

                                        manager.My_db.DisbursementOverdueDetails.Add(detail);
                                    }
                                    else
                                    {
                                        //TODO: Originary disbursement doesn't exists.
                                    }
                                }

                                manager.My_db.SaveChanges();

                                OverduesReportForm disbursement_overdues_form = new OverduesReportForm();
                                disbursement_overdues_form.generated_overdue_id = overdue.Id;
                                disbursement_overdues_form.Show();
                            }
                            else
                            {
                                //TODO: error. No hay details que generar
                            }
                        }
                        else
                        {
                            //TODO: error some account is missing
                        }
                    }
                    else
                    {
                        MessageBox.Show("No selected data.");
                    }
                }
                else
                {
                    MessageBox.Show("Monthly rate must be greather than zero.");
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementToBeOverdueForm.generate: " + _ex.Message);
            }
        }

        private void txtMonthlyRate_Leave(object sender, EventArgs e)
        {
            loadOverdues();
        }

        private void txtMonthlyRate_KeyUp(object sender, KeyEventArgs e)
        {
            decimal monthly_rate = 0;
            if (decimal.TryParse(txtMonthlyRate.Text.Trim(), out monthly_rate) && monthly_rate > 0)
            {
                dataGridView1.Visible = true;
                loadOverdues();
            }
            else
            {
                dataGridView1.Visible = false;
            }
        }
    }
}
