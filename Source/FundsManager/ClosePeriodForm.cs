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
    public partial class ClosePeriodForm : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        int selectedYear = 0;
        decimal credit = 0;
        decimal debit = 0;

        public ClosePeriodForm()
        {
            InitializeComponent();
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            try
            {
                lblCredit.Text = "";
                lblDebit.Text = "";
                cmdClose.Enabled = false;

                selectedYear = 0;
                credit = 0;
                debit = 0;

                decimal shiftAmoutIncomes = 0;
                decimal shiftAmountExpenses = 0;

                int year = 0;

                if (int.TryParse(txtYear.Text.Trim(), out year) && year > 0)
                {
                    selectedYear = year;

                    ClosedPeriod closedPeriod = manager.My_db.ClosedPeriods.FirstOrDefault(x => x.year == year);

                    if (closedPeriod != null)
                    {
                        ErrorMessage.showErrorMessage(new Exception("This period has been already closed."));
                        return;
                    }

                    List<MovementsView> movements = manager.My_db.MovementsViews.Where(x => (x.TypeId == 3 || x.TypeId == 4) && x.Date.Year == year).ToList();

                    if (movements.Count == 0)
                    {
                        ErrorMessage.showErrorMessage(new Exception("No data in selected period."));
                        return;
                    }

                    foreach (MovementsView movement in movements)
                    {
                        if (movement.TypeId == 3)
                        {
                            shiftAmoutIncomes += movement.Shift_Amount.Value;
                        }
                        else
                        {
                            shiftAmountExpenses += movement.Shift_Amount.Value;
                        }
                    }

                    if (shiftAmoutIncomes > 0 || shiftAmoutIncomes > 0)
                    {
                        credit = shiftAmountExpenses;
                        debit = shiftAmoutIncomes;
                        lblCredit.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", shiftAmountExpenses);
                        lblDebit.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", shiftAmoutIncomes);

                        cmdClose.Enabled = true;
                    }
                }
                else
                {
                    ErrorMessage.showErrorMessage(new Exception("Data format error."));
                }
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want close selected period?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    ClosedPeriod closure = new ClosedPeriod();
                    closure.year = selectedYear;
                    closure.closing_date = DateTime.Now;

                    manager.My_db.ClosedPeriods.Add(closure);

                    AccountingMovement _accountingMovement = new AccountingMovement();

                    Account account999 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "999" && x.FK_Accounts_Funds == manager.Selected);

                    if (account999 != null)
                    {
                        _accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                        _accountingMovement.description = "Period Closure";
                        _accountingMovement.date = new DateTime(selectedYear, 12, 31, 23, 59, 59, 999);
                        _accountingMovement.reference = _accountingMovement.contract = KeyDefinitions.NextAccountMovementReference(selectedYear);
                        _accountingMovement.FK_AccountingMovements_Currencies = 1;
                        _accountingMovement.original_reference = "";

                        manager.My_db.AccountingMovements.Add(_accountingMovement);

                        Movements_Accounts _maccount999 = new Movements_Accounts();

                        _maccount999.AccountingMovement = _accountingMovement;
                        _maccount999.FK_Movements_Accounts_Funds = manager.Selected;
                        _maccount999.FK_Movements_Accounts_Accounts = account999.Id;
                        _maccount999.debit = Math.Round(debit, 2);
                        _maccount999.credit = Math.Round(credit, 2);

                        manager.My_db.Movements_Accounts.Add(_maccount999);

                        manager.My_db.SaveChanges();

                        txtYear.Text = "";
                        lblCredit.Text = "";
                        lblDebit.Text = "";
                        cmdClose.Enabled = false;

                        MessageBox.Show("Period has been closed.");
                    }
                    else
                    {
                        ErrorMessage.showErrorMessage(new Exception("Missing account 999."));
                    }
                }
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void txtYear_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                cmdFind_Click(null, null);
            }
        }
    }
}
