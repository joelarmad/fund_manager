﻿using FundsManager.Classes.Utilities;
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

                Loans_View loan = manager.My_db.Loans_View.FirstOrDefault(x => x.Id == id);

                if (loan != null)
                {
                    lblAmount.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", loan.amount);
                    lblInterest.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", loan.interest);
                    dtpStart.Value = loan.start_date;
                    dtpEnd.Value = loan.end_date;
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
            // TODO: This line of code loads data into the 'fundsDBDataSet.Creditors' table. You can move, or remove it, as needed.
            this.creditorsTableAdapter.Fill(this.fundsDBDataSet.Creditors);

        }

        private void cmdRenegotiate_Click(object sender, EventArgs e)
        {
            try
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
                _loan.interest = oldloan.interest;
                _loan.amount = oldloan.amount;
                _loan.start = dtpStart.Value;
                _loan.end = dtpEnd.Value;
                _loan.currency_id = oldloan.currency_id;
                _loan.renegotiated = false;
                _loan.loan_origin_id = oldloan.Id;
                _loan.accounting_movement_id = oldloan.accounting_movement_id;

                manager.My_db.Loans.Add(_loan);
                manager.My_db.SaveChanges();

                clear();
                loadLoans();
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }
    }
}