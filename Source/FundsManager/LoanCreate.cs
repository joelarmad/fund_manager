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
    public partial class LoanCreate : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        private bool fEditMode = false;

        public LoanCreate()
        {
            InitializeComponent();
        }

        private void LoanCreate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Currencies' table. You can move, or remove it, as needed.
            this.currenciesTableAdapter.FillByFund(this.fundsDBDataSet.Currencies, manager.Selected);
            // TODO: This line of code loads data into the 'fundsDBDataSet.Loans' table. You can move, or remove it, as needed.
            this.creditorsTableAdapter.FillByFund(this.fundsDBDataSet.Creditors, manager.Selected);

            loadLoansData();
        }

        private bool validate()
        {
            bool result = false;

            double amount = 0;
            double interest = 0;

            if (cbLender.SelectedIndex >= 0 && 
                cbCurrency.SelectedIndex >= 0 && 
                txtReference.Text.Trim() != "" && 
                double.TryParse(txtAmount.Text, out amount) &&
                amount > 0 && 
                double.TryParse(txtInterest.Text, out interest) && 
                interest > 0)
            {
                result = true;
            }

            return result;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                addLoan();
            }
            else
            {
                MessageBox.Show("Please, verify data.");
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            fEditMode = false;
            cmdAdd.Text = "Add";

            txtAmount.Text = "";
            txtReference.Text = "";
            txtInterest.Text = "";

            cmdCancel.Visible = false;
            cmdDelete.Visible = false;

            dataGridView1.ClearSelection();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO: no esta claro como proceder en la eliminacion pues hay mov de cuentas involucrados
                DialogResult alert;
                alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (alert == DialogResult.OK)
                {
                    int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                    manager.DeleteLoan(id);

                    loadLoansData();

                    cmdCancel_Click(null, null);
                }
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void loadLoansData()
        {
            if (fundsDBDataSet != null && cbLender.SelectedValue != null)
            {
                // TODO: This line of code loads data into the 'fundsDBDataSet.Loans_View' table. You can move, or remove it, as needed.
                this.loans_ViewTableAdapter.FillByFund(this.fundsDBDataSet.Loans_View, manager.Selected, int.Parse(cbLender.SelectedValue.ToString()));
            }

            dataGridView1.ClearSelection();
        }

        private void addLoan()
        {
            try
            {
                int lenderId = Convert.ToInt32(cbLender.SelectedValue);
                int currencyId = Convert.ToInt32(cbCurrency.SelectedValue);

                if (!fEditMode)
                {
                    Loan _validation = manager.My_db.Loans.FirstOrDefault(x => x.reference == txtReference.Text && x.fund_id == manager.Selected);

                    if (_validation != null)
                    {
                        MessageBox.Show("Duplicated reference.");
                        return;
                    }

                    Loan _loan = new Loan();
                    _loan.fund_id = manager.Selected;
                    _loan.lender_id = lenderId;
                    _loan.reference = txtReference.Text;
                    _loan.interest = Math.Round(decimal.Parse(txtInterest.Text), 2);
                    _loan.amount = Math.Round(decimal.Parse(txtAmount.Text), 2);
                    _loan.start = dtpFrom.Value;
                    _loan.end = dtpTo.Value;
                    _loan.currency_id = currencyId;
                    _loan.renegotiated = false;
                    _loan.interest_base = rb360.Checked ? 360 : 365;

                    AccountingMovement acctMov = generateAccountingMovement(_loan);

                    if (acctMov != null)
                    {
                        _loan.AccountingMovement = acctMov;

                        manager.My_db.Loans.Add(_loan);

                        GeneralLedgerForm gledger = new GeneralLedgerForm();
                        gledger.StartPosition = FormStartPosition.CenterScreen;
                        gledger.FromExternalOperation = true;
                        gledger.ExternalAccountMovemet = acctMov;
                        gledger.ExternalDebit = _loan.amount;
                        gledger.ControlBox = false;
                        gledger.ShowDialog();

                        if (!gledger.OperationCompleted)
                        {
                            throw new Exception("Ledger operation has been failed.");
                        }

                    }
                }
                //else
                //{
                //    //TODO: no esta claro como proceder en la modificacion pues hay mov de cuentas involucrados
                //    int _id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                //    Loan _validation = manager.My_db.Loans.FirstOrDefault(x => x.Id != _id && x.reference == txtReference.Text && x.fund_id == manager.Selected);

                //    if (_validation != null)
                //    {
                //        MessageBox.Show("Duplicated reference.");
                //        return;
                //    }

                //    Loan _selected = manager.My_db.Loans.FirstOrDefault(x => x.Id == _id);

                //    if (_selected != null)
                //    {
                //        _selected.fund_id = manager.Selected;
                //        _selected.lender_id = lenderId;
                //        _selected.reference = txtReference.Text;
                //        _selected.interest = Math.Round(decimal.Parse(txtInterest.Text), 2);
                //        _selected.amount = Math.Round(decimal.Parse(txtAmount.Text), 2);
                //        _selected.start = dtpFrom.Value;
                //        _selected.end = dtpTo.Value;
                //        _selected.currency_id = currencyId;
                //        _selected.interest_base = rb360.Checked ? 360 : 365;

                //        manager.My_db.SaveChanges();
                //    }
                //}

                loadLoansData();

                cmdCancel_Click(null, null);
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void cbLender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fEditMode)
            {
                loadLoansData();

                cmdCancel_Click(null, null);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    try
            //    {
            //        int _id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            //        Loan _selected = manager.My_db.Loans.FirstOrDefault(x => x.Id == _id);

            //        if (_selected != null)
            //        {
            //            txtReference.Text = _selected.reference;
            //            txtAmount.Text = String.Format("{0:n}", _selected.amount);
            //            txtInterest.Text = String.Format("{0:n}", _selected.interest);
            //            dtpFrom.Value = _selected.start;
            //            dtpTo.Value = _selected.end;

            //            Creditor lender = manager.My_db.Creditors.FirstOrDefault(x => x.Id == _selected.lender_id);

            //            foreach (DataRowView _item in cbLender.Items)
            //            {
            //                if (_item.Row[0].ToString() == lender.Id.ToString())
            //                {
            //                    cbLender.SelectedItem = _item;
            //                    break;
            //                }
            //            }

            //            Currency currency = manager.My_db.Currencies.FirstOrDefault(x => x.Id == _selected.currency_id);

            //            foreach (DataRowView _item in cbCurrency.Items)
            //            {
            //                if (_item.Row[0].ToString() == currency.Id.ToString())
            //                {
            //                    cbCurrency.SelectedItem = _item;
            //                    break;
            //                }
            //            }

            //            cmdCancel.Visible = true;
            //            cmdDelete.Visible = true;
            //            fEditMode = true;
            //            cmdAdd.Text = "Save";
            //        }
            //    }
            //    catch (Exception _ex)
            //    {
            //        MessageBox.Show("Error: " + _ex.Message);
            //    }
            //}
            //else
            //{
            //    cmdCancel_Click(null, null);
            //}
            
        }

        private AccountingMovement generateAccountingMovement(Loan loan)
        {
            AccountingMovement _accountingMovement = new AccountingMovement();

            Account account110 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "110" && x.FK_Accounts_Funds == manager.Selected);
            Account account470 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "470" && x.FK_Accounts_Funds == manager.Selected);

            if (account110 != null && account470 != null)
            {
                Currency currency = manager.My_db.Currencies.FirstOrDefault(x => x.Id == loan.currency_id && x.FK_Currencies_Funds == manager.Selected);
                Subaccount subacct110 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account110.Id && x.name == "Bank " + currency.symbol);
                Subaccount subacct470 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account470.Id && x.name == "Principal Loan");

                if (currency != null && subacct110 != null && subacct470 != null)
                {
                    

                    _accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                    _accountingMovement.description = ((FundsDBDataSet.CreditorsRow)((DataRowView)cbLender.SelectedItem).Row).name;
                    _accountingMovement.date = loan.start;
                    _accountingMovement.reference = _accountingMovement.contract = KeyDefinitions.NextAccountMovementReference(loan.start.Year);
                    _accountingMovement.FK_AccountingMovements_Currencies = loan.currency_id;
                    _accountingMovement.original_reference = "";

                    manager.My_db.AccountingMovements.Add(_accountingMovement);

                    Movements_Accounts _maccount470 = new Movements_Accounts();

                    _maccount470.AccountingMovement = _accountingMovement;
                    _maccount470.FK_Movements_Accounts_Funds = manager.Selected;
                    _maccount470.FK_Movements_Accounts_Accounts = account470.Id;
                    if (subacct470 != null)
                        _maccount470.FK_Movements_Accounts_Subaccounts = subacct470.Id;
                    _maccount470.debit = 0;
                    _maccount470.credit = Math.Round(loan.amount, 2);
                    
                    manager.My_db.Movements_Accounts.Add(_maccount470);
                }

                return _accountingMovement;
            }

            return null;
        }
    }
}
