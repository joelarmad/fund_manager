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
    public partial class LoanRenegotiation : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public LoanRenegotiation()
        {
            InitializeComponent();
            clear();
        }

        private void clear()
        {
            txtNewAmount.Text = "";
            txtNewInterest.Text = "";
            txtNewReference.Text = "";
            lblAmount.Text = "";
            lblInterest.Text = "";
            lblReference.Text = "";
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
            cmdRenegotiate.Enabled = false;
        }

        private void cbLender_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadLoans();
        }

        private void cbLoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadLoan();
        }

        private void loadLoans()
        {
            if (cbLender.SelectedValue != null)
            {
                int id = int.Parse(cbLender.SelectedValue.ToString());

                this.loansTableAdapter.FillByFund(this.fundsDBDataSet.Loans, manager.Selected, id, false);
            }

            loadLoan();
        }

        private void loadLoan()
        {
            if (cbLoan.SelectedValue != null)
            {
                int id = int.Parse(cbLoan.SelectedValue.ToString());

                LoansRepaymentsView loan = manager.My_db.LoansRepaymentsViews.FirstOrDefault(x => x.Id == id);

                if (loan != null)
                {
                    decimal amount = loan.amount - (loan.amount_repaid.HasValue ? loan.amount_repaid.Value : 0);
                    lblAmount.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", amount);
                    lblInterest.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:N2}", loan.interest) + " %";
                    txtNewAmount.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", amount);
                    txtNewInterest.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:N2}", loan.interest) + " %";
                    dtpStart.Value = loan.start;
                    dtpEnd.Value = loan.end;
                    lblStart.Text = loan.start.ToShortDateString();
                    lblEnd.Text = loan.end.ToShortDateString();
                    lblReference.Text = loan.reference;
                    cmdRenegotiate.Enabled = true;
                }
                else
                {
                    clear();
                }
            }
            else
            {
                clear();
            }
        }

        private void LoanRenegotiation_Load(object sender, EventArgs e)
        {
            this.creditorsTableAdapter.Fill(this.fundsDBDataSet.Creditors);
            loadLoans();
        }

        private void cmdRenegotiate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal amount = 0;
                decimal interest = 0;

                if (decimal.TryParse(txtNewAmount.Text.Trim(), out amount) && decimal.TryParse(txtNewInterest.Text.Trim(), out interest) && amount > 0 && interest > 0)
                {
                    if (manager.My_db.ClosedPeriods.FirstOrDefault(x => x.year == dtpStart.Value.Year) == null)
                    {
                        Loan _validation = manager.My_db.Loans.FirstOrDefault(x => x.reference == txtNewReference.Text && x.fund_id == manager.Selected);

                        if (_validation != null)
                        {
                            MessageBox.Show("Duplicated reference.");
                            return;
                        }

                        int id = int.Parse(cbLoan.SelectedValue.ToString());

                        Loan oldloan = manager.My_db.Loans.FirstOrDefault(x => x.Id == id);

                        oldloan.renegotiated = true;

                        Loan _loan = new Loan();
                        _loan.fund_id = manager.Selected;
                        _loan.lender_id = oldloan.lender_id;
                        _loan.reference = txtNewReference.Text;
                        _loan.interest = interest;
                        _loan.amount = amount;
                        _loan.start = dtpStart.Value;
                        _loan.end = dtpEnd.Value;
                        _loan.currency_id = oldloan.currency_id;
                        _loan.renegotiated = false;
                        _loan.loan_origin_id = oldloan.Id;
                        _loan.accounting_movement_id = oldloan.accounting_movement_id;
                        _loan.interest_base = oldloan.interest_base;
                        _loan.can_generate_interest = 1;
                        _loan.paid = oldloan.paid;

                        manager.My_db.Loans.Add(_loan);
                        manager.My_db.SaveChanges();

                        clear();
                        loadLoans();
                    }
                    else
                    {
                        ErrorMessage.showErrorMessage(new Exception("No movement allowed in closed period."));
                    }
                }
                else
                {
                    ErrorMessage.showErrorMessage(new Exception("Error in new amount or interest data."));
                }
                
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }
    }
}
