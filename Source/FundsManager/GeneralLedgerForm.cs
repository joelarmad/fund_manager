using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FundsManager.Classes.Utilities;

namespace FundsManager
{
    public partial class GeneralLedgerForm : Form
    {

        public bool FromDisbursementOperation = false;
        public AccountingMovement AcctMovFromDisbursement = null;
        public decimal CreditFromDisbursemet = 0;
        public decimal DebitFromDisbursemet = 0;
        public bool OperationCompleted = false;

        private bool AvoidAccountBalanceValidation = false;

        public bool FormInEditAccountingMovement = false;
        public int IdOfAccountingMovementToEdit = 0;

        private MyFundsManager manager;
        private AccountingMovement AccountingMovementToEdit;
        private List<Movement> movements;
        private List<Movement> movementsToDelete;
        private List<Account> fFloatingAccounts;

        //subaccount_type  1 -> Client, 2 -> Banking Account, 3 -> Employee, 4 -> Lender, 5 -> OtherDetail, 6 -> Shareholder

        private Decimal total_credit;
        private Decimal total_debit;
        private Color _color;

        private bool fEditMode = false;

        public GeneralLedgerForm()
        {
            manager = MyFundsManager.SingletonInstance;
            movements = new List<Movement>();
            movementsToDelete = new List<Movement>();
            InitializeComponent();
            textBox1.Text = 0.ToString();
            textBox2.Text = 0.ToString();
            _color = new Color();
            listView1.FullRowSelect = true;

            cbAccount.SelectedIndexChanged += OnAccountChanged;
            cbSubaccount.SelectedIndexChanged += OnSubAccountChanged;

        }

        private void GeneralLedgerForm_Load(object sender, EventArgs e)
        {
            try
            {

                // TODO: This line of code loads data into the 'fundsDBDataSet.Currencies' table. You can move, or remove it, as needed.
                this.currenciesTableAdapter.FillByFund(this.fundsDBDataSet.Currencies, manager.Selected);
                // TODO: This line of code loads data into the 'fundsDBDataSet.Accounts' table. You can move, or remove it, as needed.
                this.accountsTableAdapter.FillByFund(this.fundsDBDataSet.Accounts, manager.Selected);
                cbAccount.SelectedItem = null;
                cbAccount.SelectedText = "Select account";
                cbSubaccount.SelectedIndex = -1;
                cbOtherDetail.SelectedItem = null;
                cbOtherDetail.SelectedIndex = -1;
                textBox3.Text = KeyDefinitions.NextAccountMovementReference(dateTimePicker1.Value.Year);

                fFloatingAccounts = manager.My_db.Accounts.Where(x => x.FK_Accounts_Funds == manager.Selected).ToList();

                txtContract.Text = "";

                OnAccountChanged(null, null);



                if (FormInEditAccountingMovement && IdOfAccountingMovementToEdit > 0)
                {
                    listView1.MultiSelect = false;
                    
                    button2.Enabled = true;
                    button2.Text = "Save Movement";
                    
                    AccountingMovementToEdit = manager.My_db.AccountingMovements.FirstOrDefault(x => x.Id == IdOfAccountingMovementToEdit);

                    if (AccountingMovementToEdit != null)
                    {
                        for (int i = 0; i < comboBox4.Items.Count; i++)
                        {
                            FundsManager.FundsDBDataSet.CurrenciesRow row = (FundsManager.FundsDBDataSet.CurrenciesRow)((System.Data.DataRowView)comboBox4.Items[i]).Row;

                            if (row.Id == AccountingMovementToEdit.FK_AccountingMovements_Currencies)
                            {
                                comboBox4.SelectedIndex = i;
                                break;
                            }

                        }

                        dateTimePicker1.Value = AccountingMovementToEdit.date;

                        textBox3.Text = AccountingMovementToEdit.reference;

                        textBox4.Text = AccountingMovementToEdit.description;

                        textBox5.Text = AccountingMovementToEdit.original_reference;

                        txtContract.Text = AccountingMovementToEdit.contract != null ? AccountingMovementToEdit.contract : "";

                        List<Movements_Accounts> movementsAccount = manager.My_db.Movements_Accounts.Where(x => x.FK_Movements_Accounts_AccountingMovements == IdOfAccountingMovementToEdit).ToList();

                        foreach (Movements_Accounts _mov in movementsAccount)
                        {
                            movements.Add(new Movement(_mov));
                        }

                        loadMovementsInListView();

                        checkForContractVisibility();
                    }

                    if (movementCanBeDeleted())
                    {
                        cmdDeleteMovement.Visible = true;
                    }
                }

                if (FromDisbursementOperation && AcctMovFromDisbursement != null)
                {
                    AvoidAccountBalanceValidation = true;

                    textBox3.Text = AcctMovFromDisbursement.reference;

                    textBox5.Text = AcctMovFromDisbursement.original_reference;

                    dateTimePicker1.Value = AcctMovFromDisbursement.date;

                    textBox4.Text = AcctMovFromDisbursement.description;

                    for (int i = 0; i < comboBox4.Items.Count; i++)
                    {
                        int currency_id = ((FundsManager.FundsDBDataSet.CurrenciesRow)((System.Data.DataRowView)comboBox4.Items[i]).Row).Id;

                        if (currency_id == AcctMovFromDisbursement.FK_AccountingMovements_Currencies)
                        {
                            comboBox4.SelectedIndex = i;
                            break;
                        }
                    }

                    textBox3.Enabled = false;
                    textBox5.Enabled = false;

                    textBox1.Text = String.Format("{0:0.00}", DebitFromDisbursemet);
                    textBox2.Text = String.Format("{0:0.00}", CreditFromDisbursemet);
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.GeneralLedgerForm_Load: " + _ex.Message);
            }
        }

        private void OnAccountChanged(object sender, EventArgs e)
        {
            try
            {
                cbSubaccount.DataSource = null;
                cbSubaccount.Items.Clear();
                cbSubaccount.Text = "";

                Dictionary<int, string> comboSource = new Dictionary<int, string>();

                comboSource.Add(-1, "Select Subaccount");

                foreach (Subaccount _subaccount in manager.My_db.Subaccounts)
                {
                    if (_subaccount.FK_Subaccounts_Accounts == Convert.ToInt32(cbAccount.SelectedValue))
                    {
                        comboSource.Add(_subaccount.Id, _subaccount.name);
                    }
                }

                cbSubaccount.DataSource = new BindingSource(comboSource, null);
                cbSubaccount.DisplayMember = "Value";
                cbSubaccount.ValueMember = "Key";

                OnSubAccountChanged(null, null);

                checkForContractVisibility();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.OnAccountChanged: " + _ex.Message);
            }
        }

        private void OnSubAccountChanged(object sender, EventArgs e)
        {
            try
            {
                cbOtherDetail.DataSource = null;
                cbOtherDetail.Items.Clear();
                cbOtherDetail.Text = "";
                cbOtherDetail.SelectedItem = null;
                cbOtherDetail.SelectedText = "Select detail";

                Dictionary<int, string> comboSource = new Dictionary<int, string>();

                comboSource.Add(-1, "Select Detail");

                foreach (Client _client in manager.My_db.Clients)
                {
                    int custom_id = int.Parse(1.ToString() + _client.Id.ToString());
                    comboSource.Add(custom_id, _client.name);
                }

                foreach (BankingAccount _bankingaccount in manager.My_db.BankingAccounts)
                {
                    int custom_id = int.Parse(2.ToString() + _bankingaccount.Id.ToString());
                    comboSource.Add(custom_id, _bankingaccount.name);
                }

                foreach (Employee _employee in manager.My_db.Employees)
                {
                    int custom_id = int.Parse(3.ToString() + _employee.Id.ToString());
                    comboSource.Add(custom_id, _employee.name);
                }

                foreach (Creditor _creditor in manager.My_db.Creditors)
                {
                    int custom_id = int.Parse(4.ToString() + _creditor.Id.ToString());
                    comboSource.Add(custom_id, _creditor.name);
                }

                int subacctId = Convert.ToInt32(cbSubaccount.SelectedValue);

                foreach (OtherDetail _detail in manager.My_db.OtherDetails.Where(x => x.subacct_id == subacctId).ToList())
                {
                    int custom_id = int.Parse(5.ToString() + _detail.Id.ToString());
                    comboSource.Add(custom_id, _detail.name);
                }

                foreach (Shareholder _shareholder in manager.My_db.Shareholders)
                {
                    int custom_id = int.Parse(6.ToString() + _shareholder.Id.ToString());
                    comboSource.Add(custom_id, _shareholder.name);
                }

                cbOtherDetail.DataSource = new BindingSource(comboSource, null);
                cbOtherDetail.DisplayMember = "Value";
                cbOtherDetail.ValueMember = "Key";
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.OnSubAccountChanged: " + _ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!fEditMode)
                {
                    if (cbAccount.SelectedValue == null)
                        return;

                    Movement movement = new Movement();

                    movement.Id = 0;

                    movement.Account = Convert.ToInt32(cbAccount.SelectedValue);

                    movement.Subaccount = Convert.ToInt32(cbSubaccount.SelectedValue);

                    if (cbOtherDetail.SelectedIndex > 0)
                    {
                        string temp_id = Convert.ToString(cbOtherDetail.SelectedValue);
                        movement.Detail_type = Convert.ToInt32(temp_id.Substring(0, 1));
                        movement.Detail = Convert.ToInt32(temp_id.Substring(1, temp_id.Length - 1));
                    }
                    else
                    {
                        movement.Detail_type = -1;
                        movement.Detail = -1;
                    }

                    movement.Debit = Math.Round(decimal.Parse(textBox1.Text), 2);

                    movement.Credit = Math.Round(decimal.Parse(textBox2.Text), 2);

                    Account _account = manager.My_db.Accounts.FirstOrDefault(x => x.Id == movement.Account);
                    Subaccount _subAccount = manager.My_db.Subaccounts.FirstOrDefault(x => x.Id == movement.Subaccount);

                    int _creditFactor = 1;
                    int _debitFactor = -1;

                    if (Account.leftAccountingIncrement(_account.type))
                    {
                        _creditFactor = -1;
                        _debitFactor = 1;
                    }

                    decimal _amountShift = _debitFactor * movement.Debit + _creditFactor * movement.Credit;

                    movement.AccountBalance = calculateAccountBalance(movement.Account.Value, _amountShift);
                    movement.SubAccountBalance = calculateSubAccountBalance(movement.Subaccount.Value, _amountShift);

                    movements.Add(movement);
                }
                else
                {
                    putDataInSelectedMovement();
                }

                loadMovementsInListView();

                cmdCancel_Click(null, null);
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.button1_Click: " + _ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedIndices.Count > 0 && listView1.SelectedIndices[0] < movements.Count)
                {
                    int index = listView1.SelectedIndices[0];

                    Movement toDelete = movements[index];

                    movementsToDelete.Add(toDelete);

                    movements.RemoveAt(index);

                    loadMovementsInListView();

                    cmdCancel_Click(null, null);
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.button3_Click: " + _ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormInEditAccountingMovement)
                {
                    decimal leftAccount = 0;
                    decimal rightAccount = 0;
                    bool makeOperation = false;

                    if (canMakeMovement(out leftAccount, out rightAccount, out makeOperation))
                    {
                        if (makeOperation)
                        {
                            makeMovement();
                        }
                        else
                        {
                            String leftAccountStr = String.Format("{0:0.00}", leftAccount);
                            String rightAccountStr = String.Format("{0:0.00}", rightAccount);

                            String msg = "Account movement validation informs:\r" +
                                "This operation return an unbalanced accounting state.\r" +
                                "Asset + Expense (" + leftAccountStr + ") = Liability + Equity + Income (" + rightAccountStr + ")\r\r" +
                                "Do you want to execute operation anyway?";

                            if (MessageBox.Show(msg, "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                makeMovement();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("There was an error trying to validate the account movement.");
                    }
                }
                else
                {
                    makeMovement();
                }

                cmdCancel_Click(null, null);
            }
            catch (Exception ex)
            {
                ErrorMessage.showErrorMessage(ex);
            }
        }

        private void makeMovement()
        {
            if (listView1.Items.Count >= 0)
            {
                try
                {
                    if (!FormInEditAccountingMovement)
                    {
                        AccountingMovement newAccountingMovement = new AccountingMovement();

                        if (!FromDisbursementOperation)
                        {
                            newAccountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                            newAccountingMovement.reference = textBox3.Text;
                            newAccountingMovement.original_reference = textBox5.Text;
                        }
                        else
                        {
                            newAccountingMovement = AcctMovFromDisbursement;
                        }

                        newAccountingMovement.description = textBox4.Text;
                        newAccountingMovement.date = Convert.ToDateTime(dateTimePicker1.Text);
                        newAccountingMovement.FK_AccountingMovements_Currencies = Convert.ToInt32(comboBox4.SelectedValue);

                        if (txtContract.Visible)
                        {
                            newAccountingMovement.contract = txtContract.Text;
                        }

                        if (!FromDisbursementOperation)
                        {
                            manager.My_db.AccountingMovements.Add(newAccountingMovement);
                        }
                        
                        textBox3.Text = KeyDefinitions.NextAccountMovementReference(dateTimePicker1.Value.Year);
                        textBox4.Clear();
                        textBox5.Clear();
                        txtContract.Clear();
                        listView1.Items.Clear();
                        textBox1.Text = 0.ToString();
                        textBox2.Text = 0.ToString();
                        total_credit = 0;
                        total_debit = 0;

                        foreach (Movement newMovementAccount in movements)
                        {
                            addMovement(newMovementAccount, newAccountingMovement);
                        }

                        manager.My_db.SaveChanges();

                        movements.Clear();
                        movementsToDelete.Clear();

                        checkForContractVisibility();

                        button2.Enabled = false;

                        if (FromDisbursementOperation)
                        {
                            OperationCompleted = true;
                            this.Close();
                        }
                    }
                    else
                    {

                        AccountingMovementToEdit.FK_AccountingMovements_Funds = manager.Selected;
                        AccountingMovementToEdit.description = textBox4.Text;
                        AccountingMovementToEdit.date = Convert.ToDateTime(dateTimePicker1.Text);
                        AccountingMovementToEdit.reference = textBox3.Text;
                        AccountingMovementToEdit.FK_AccountingMovements_Currencies = Convert.ToInt32(comboBox4.SelectedValue);
                        AccountingMovementToEdit.original_reference = textBox5.Text;

                        if (txtContract.Visible)
                        {
                            AccountingMovementToEdit.contract = txtContract.Text;
                        }

                        textBox3.Text = KeyDefinitions.NextAccountMovementReference(dateTimePicker1.Value.Year);
                        textBox4.Clear();
                        textBox5.Clear();
                        txtContract.Clear();
                        listView1.Items.Clear();
                        textBox1.Text = 0.ToString();
                        textBox2.Text = 0.ToString();
                        total_credit = 0;
                        total_debit = 0;

                        foreach (Movement movementToSave in movements)
                        {
                            addMovement(movementToSave, AccountingMovementToEdit);
                        }

                        foreach (Movement toDelete in movementsToDelete)
                        {
                            if (toDelete.Id > 0)
                            {
                                manager.DeleteMovementAccount(toDelete.Id);
                            }
                        }

                        manager.My_db.SaveChanges();

                        movements.Clear();
                        movementsToDelete.Clear();

                        OperationCompleted = true;
                        this.Close();
                    }

                    OperationCompleted = true;
                }
                catch (Exception _ex)
                {
                    ErrorMessage.showErrorMessage(_ex);

                    OperationCompleted = false;
                }

                cmdDeleteMovement.Visible = false;
            }
            else
            {
                ErrorMessage.showErrorMessage(new Exception("Sorry, yo must add a movement account first."));
            }
        }

        private decimal calculateAccountBalance(int aAccountId, decimal amountShift)
        {
            try
            {
                decimal _latestAmount = 0;
                bool _found = false;

                foreach (Movement _movement in movements)
                {
                    if (_movement.Account == aAccountId)
                    {
                        _latestAmount = _movement.AccountBalance;
                        _found = true;
                    }
                }

                if (!_found)
                {
                    Account _account = manager.My_db.Accounts.FirstOrDefault(x => x.Id == aAccountId);

                    _latestAmount = _account.amount;
                }

                return _latestAmount + amountShift;
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.calculateAccountBalance: " + _ex.Message);
                return 0;
            }
        }

        private decimal calculateSubAccountBalance(int aSubAccountId, decimal amountShift)
        {
            try
            {
                decimal _latestAmount = 0;
                bool _found = false;

                foreach (Movement _movement in movements)
                {
                    if (_movement.Subaccount == aSubAccountId)
                    {
                        _latestAmount = _movement.SubAccountBalance;
                        _found = true;
                    }
                }

                if (!_found)
                {
                    Subaccount _subAccount = manager.My_db.Subaccounts.FirstOrDefault(x => x.Id == aSubAccountId);

                    _latestAmount = _subAccount.amount;
                }

                return _latestAmount + amountShift;
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.calculateSubAccountBalance: " + _ex.Message);
                return 0;
            }
        }

        private void checkEnablingAddButton()
        {
            try
            {
                decimal _debit = 0;
                decimal _credit = 0;

                button1.Enabled = decimal.TryParse(textBox1.Text, out _debit)
                    && decimal.TryParse(textBox2.Text, out _credit)
                    && (_debit > 0 || _credit > 0);
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.checkEnablingAddButton: " + _ex.Message);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "0")
                    textBox1.Text = "";
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.textBox1_Enter: " + _ex.Message);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal _result = 0;
                if (!decimal.TryParse(textBox1.Text, out _result) || _result <= 0)
                {
                    textBox1.Text = "0";
                }
                else
                {
                    textBox1.Text = String.Format("{0:0.00}", _result);
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.textBox1_Leave: " + _ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.textBox1_TextChanged: " + _ex.Message);
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "0")
                    textBox2.Text = "";
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.textBox2_Enter: " + _ex.Message);
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal _result = 0;
                if (!decimal.TryParse(textBox2.Text, out _result) || _result <= 0)
                {
                    textBox2.Text = "0";
                }
                else
                {
                    textBox2.Text = String.Format("{0:0.00}", _result);
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.textBox2_Leave: " + _ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.textBox2_TextChanged: " + _ex.Message);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (int _index in listView1.SelectedIndices)
                {
                    if (_index == listView1.Items.Count - 1)
                    {
                        listView1.SelectedIndices.Remove(_index);
                    }
                }

                if (listView1.SelectedIndices.Count > 0 && listView1.SelectedIndices[0] < movements.Count)
                {
                    fEditMode = true;

                    Movement toEdit = movements[listView1.SelectedIndices[0]];

                    this.accountsTableAdapter.FillByFund(this.fundsDBDataSet.Accounts, manager.Selected);

                    for (int i = 0; i < cbAccount.Items.Count; i++)
                    {
                        FundsManager.FundsDBDataSet.AccountsRow row = (FundsManager.FundsDBDataSet.AccountsRow)((System.Data.DataRowView)cbAccount.Items[i]).Row;

                        if (row.Id == toEdit.Account)
                        {
                            cbAccount.SelectedIndex = i;
                            break;
                        }

                    }

                    OnAccountChanged(null, null);

                    for (int i = 0; i < cbSubaccount.Items.Count; i++)
                    {
                        KeyValuePair<int, string> row = (KeyValuePair<int, string>)cbSubaccount.Items[i];

                        if (row.Key == toEdit.Subaccount)
                        {
                            cbSubaccount.SelectedIndex = i;
                            break;
                        }

                    }

                    OnSubAccountChanged(null, null);

                    for (int i = 0; i < cbOtherDetail.Items.Count; i++)
                    {
                        KeyValuePair<int, string> row = (KeyValuePair<int, string>)cbOtherDetail.Items[i];

                        string key1 = row.Key.ToString().Substring(0, 1);
                        string key2 = row.Key.ToString().Substring(1);

                        if (key1 == toEdit.Detail_type.ToString() && key2 == toEdit.Detail.ToString())
                        {
                            cbOtherDetail.SelectedIndex = i;
                            break;
                        }
                    }

                    textBox1.Text = String.Format("{0:n}", toEdit.Debit);
                    textBox2.Text = String.Format("{0:n}", toEdit.Credit);

                    button1.Text = "Save";
                    button3.Enabled = true;
                    cmdCancel.Visible = true;
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.listView1_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private bool canMakeMovement(out decimal leftAccount, out decimal rightAccount, out bool canMakeMovement)
        {
            try
            {
                if (AvoidAccountBalanceValidation)
                {
                    leftAccount = 0;
                    rightAccount = 0;
                    canMakeMovement = true;
                    return true;
                }

                decimal _leftAccount = 0;   //Asset + Expense
                decimal _rigthAccount = 0;  //Liability + Equity + Income

                foreach (Movement _movement in movements)
                {
                    Account _account = manager.My_db.Accounts.First(x => x.Id == _movement.Account);

                    //Asset, Expenses, Contingency Asset, Fixed Assets, Medium and Long Term Assets, Current Assets
                    if (Account.leftAccountingIncrement(_account.type))
                    {
                        _leftAccount += _movement.AccountBalance;
                    }
                    //Liability, Equity, Income, Contingency Liability, Medium and Long Term Liabilities, Current Liabilities
                    else
                    {
                        _rigthAccount += _movement.AccountBalance;
                    }
                }

                leftAccount = _leftAccount;
                rightAccount = _rigthAccount;
                canMakeMovement = _leftAccount == _rigthAccount;

                return true;
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.canMakeMovement: " + _ex.Message);

                leftAccount = 0;
                rightAccount = 0;
                canMakeMovement = false;

                return false;
            }
        }

        private void checkForContractVisibility()
        {

            int accountId = 0;

            if (cbAccount.SelectedValue != null && int.TryParse(cbAccount.SelectedValue.ToString(), out accountId))
            {
                Account acct = manager.My_db.Accounts.FirstOrDefault(x => x.Id == accountId);

                if (acct != null && (acct.number == "125" || acct.number == "128" || acct.number == "130"))
                {
                    lblContract.Visible = true;
                    txtContract.Visible = true;
                    return;
                }
            }

            foreach (Movement movement in movements)
            {
                Account account = manager.My_db.Accounts.FirstOrDefault(x => x.Id == movement.Account);

                if (account != null)
                {
                    if (account.number == "125" || account.number == "128" || account.number == "130")
                    {
                        lblContract.Visible = true;
                        txtContract.Visible = true;
                        return;
                    }
                }
            }
            
            lblContract.Visible = false;
            txtContract.Visible = false;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cbSubaccount_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbOtherDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!FormInEditAccountingMovement)                    
                    checkEnablingAddButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.cbOtherDetail_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void cbSubaccount_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            fEditMode = false;
            cbAccount.SelectedIndex = 0;
            cbSubaccount.SelectedIndex = 0;
            cbOtherDetail.SelectedIndex = 0;
            textBox1.Text = "0";
            textBox2.Text = "0";
            button1.Text = "Add";
            button1.Enabled = false;
            button3.Enabled = false;
            cmdCancel.Visible = false;
            listView1.SelectedIndices.Clear();
        }

        private void loadMovementsInListView()
        {    
            listView1.Items.Clear();

            total_credit = 0;
            total_debit = 0;

            foreach (Movement _movement in movements)
            {
                _movement.SubAccountBalance = 0;
                _movement.AccountBalance = 0;
            }

            foreach (Movement _movement in movements)
            {
                total_credit += _movement.Credit;
                total_debit += _movement.Debit;

                Account _account = manager.My_db.Accounts.FirstOrDefault(x => x.Id == _movement.Account);
                Subaccount _subAccount = manager.My_db.Subaccounts.FirstOrDefault(x => x.Id == _movement.Subaccount);

                String detailText = "";

                switch (_movement.Detail_type)
                {
                    case 1:
                        Client client = manager.My_db.Clients.FirstOrDefault(x => x.Id == _movement.Detail);
                        if (client != null)
                        {
                            detailText = client.name;
                        }
                        break;
                    case 2:
                        BankingAccount baccount = manager.My_db.BankingAccounts.FirstOrDefault(x => x.Id == _movement.Detail);
                        if (baccount != null)
                        {
                            detailText = baccount.name;
                        }
                        break;
                    case 3:
                        Employee employee = manager.My_db.Employees.FirstOrDefault(x => x.Id == _movement.Detail);
                        if (employee != null)
                        {
                            detailText = employee.name;
                        }
                        break;
                    case 4:
                        Creditor creditor = manager.My_db.Creditors.FirstOrDefault(x => x.Id == _movement.Detail);
                        if (creditor != null)
                        {
                            detailText = creditor.name;
                        }
                        break;
                    case 5:
                        OtherDetail detail = manager.My_db.OtherDetails.FirstOrDefault(x => x.Id == _movement.Detail);
                        if (detail != null)
                        {
                            detailText = detail.name;
                        }
                        break;
                    case 6:
                        Shareholder holder = manager.My_db.Shareholders.FirstOrDefault(x => x.Id == _movement.Detail);
                        if (holder != null)
                        {
                            detailText = holder.name;
                        }
                        break;
                }

                int _creditFactor = 1;
                int _debitFactor = -1;

                if (Account.leftAccountingIncrement(_account.type))
                {
                    _creditFactor = -1;
                    _debitFactor = 1;
                }

                decimal _amountShift = _debitFactor * _movement.Debit + _creditFactor * _movement.Credit;

                string[] row = { _account.name, _subAccount != null ? _subAccount.name : "", detailText, String.Format("{0:n}", _movement.Debit), String.Format("{0:n}", _movement.Credit) };
                ListViewItem my_item = new ListViewItem(row);

                listView1.Items.Add(my_item);
            }

            if (total_credit > 0 || total_debit > 0)
            {
                string[] totales = { "", "", "Total", String.Format("{0:n}", total_debit), String.Format("{0:n}", total_credit) };
                var listViewItemTotal = new ListViewItem(totales);

                if (total_credit == total_debit || AvoidAccountBalanceValidation)
                {
                    _color = Color.FromName("Green");
                    button2.Enabled = true;
                }
                else
                {
                    _color = Color.FromName("Red");
                    button2.Enabled = false;
                }

                listViewItemTotal.ForeColor = _color;
                listView1.Items.Add(listViewItemTotal);
            }

            checkForContractVisibility();
        }

        private void putDataInSelectedMovement()
        {
            int index = listView1.SelectedIndices.Count > 0 ? listView1.SelectedIndices[0] : -1;

            if (index >= 0)
            {
                Movement toEdit = movements[index];

                toEdit.Account = Convert.ToInt32(cbAccount.SelectedValue);

                toEdit.Subaccount = Convert.ToInt32(cbSubaccount.SelectedValue);

                if (cbOtherDetail.SelectedIndex > 0)
                {
                    string temp_id = Convert.ToString(cbOtherDetail.SelectedValue);
                    toEdit.Detail_type = Convert.ToInt32(temp_id.Substring(0, 1));
                    toEdit.Detail = Convert.ToInt32(temp_id.Substring(1, temp_id.Length - 1));
                }
                else
                {
                    toEdit.Detail_type = -1;
                    toEdit.Detail = -1;
                }

                toEdit.Debit = Math.Round(decimal.Parse(textBox1.Text), 2);

                toEdit.Credit = Math.Round(decimal.Parse(textBox2.Text), 2);

                Account _account = manager.My_db.Accounts.FirstOrDefault(x => x.Id == toEdit.Account);
                Subaccount _subAccount = manager.My_db.Subaccounts.FirstOrDefault(x => x.Id == toEdit.Subaccount);

                int _creditFactor = 1;
                int _debitFactor = -1;

                if (Account.leftAccountingIncrement(_account.type))
                {
                    _creditFactor = -1;
                    _debitFactor = 1;
                }

                decimal _amountShift = _debitFactor * toEdit.Debit + _creditFactor * toEdit.Credit;

                toEdit.AccountBalance = calculateAccountBalance(toEdit.Account.Value, _amountShift);
                toEdit.SubAccountBalance = calculateSubAccountBalance(toEdit.Subaccount.Value, _amountShift);

                listView1.SelectedIndices.Clear();
            }
        }

        private void addMovement(Movement toSave, AccountingMovement acctMov)
        {
            int? nullReference = null;

            //subaccount_type  1 -> Client, 2 -> Banking Account, 3 -> Employee, 4 -> Lender, 5 -> OtherDetail, 6 -> Shareholder
            Movements_Accounts movementAccountToSave = new Movements_Accounts();

            if (toSave.Id != 0)
            {
                movementAccountToSave = manager.My_db.Movements_Accounts.FirstOrDefault(x => x.Id == toSave.Id);

                if (movementAccountToSave == null)
                    throw new Exception("Attempt to edit non existing movement account.");
            }

            movementAccountToSave.AccountingMovement = acctMov;
            movementAccountToSave.FK_Movements_Accounts_Funds = manager.Selected;
            movementAccountToSave.FK_Movements_Accounts_Accounts = toSave.Account;

            if (toSave.Subaccount != -1)
                movementAccountToSave.FK_Movements_Accounts_Subaccounts = toSave.Subaccount;
            else
                movementAccountToSave.FK_Movements_Accounts_Subaccounts = nullReference;

            /*WARNING en la tabla Movements_Accounts los campos subaccount y subaccount_type se refieren a detail y detail_type respectivamente*/
            movementAccountToSave.subaccount_type = toSave.Detail_type;

            if (toSave.Detail != -1)
                movementAccountToSave.subaccount = toSave.Detail;
            else
                movementAccountToSave.subaccount = nullReference;

            movementAccountToSave.debit = Math.Round(toSave.Debit, 2);
            movementAccountToSave.credit = Math.Round(toSave.Credit, 2);

            Account _account = manager.My_db.Accounts.FirstOrDefault(x => x.Id == toSave.Account);
            Subaccount _subAccount = manager.My_db.Subaccounts.FirstOrDefault(x => x.Id == toSave.Subaccount);

            int _creditFactor = 1;
            int _debitFactor = -1;

            if (Account.leftAccountingIncrement(_account.type))
            {
                _creditFactor = -1;
                _debitFactor = 1;
            }

            _account.amount += _debitFactor * toSave.Debit;
            _account.amount += _creditFactor * toSave.Credit;
            movementAccountToSave.acc_amount = Math.Round(_account.amount, 2);

            if (_subAccount != null)
            {
                _subAccount.amount += _debitFactor * toSave.Debit;
                _subAccount.amount += _creditFactor * toSave.Credit;
                movementAccountToSave.subacc_amount = Math.Round(_subAccount.amount, 2);
            }
            else
            {
                movementAccountToSave.subacc_amount = 0;
            }

            if (toSave.Id == 0)
            {
                manager.My_db.Movements_Accounts.Add(movementAccountToSave);
            }
        }

        private void cmdDeleteMovement_Click(object sender, EventArgs e)
        {
            try
            {
                if (movementCanBeDeleted())
                {
                    if (MessageBox.Show("This operation can not be undone. Do you wish to proceed?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        AccountingMovement toAccountingMovementDelete = manager.My_db.AccountingMovements.FirstOrDefault(x => x.Id == IdOfAccountingMovementToEdit);

                        if (toAccountingMovementDelete != null)
                        {

                            List<Movements_Accounts> movementsToDelete = manager.My_db.Movements_Accounts.Where(x => x.FK_Movements_Accounts_AccountingMovements == IdOfAccountingMovementToEdit).ToList();

                            foreach (Movements_Accounts movToDelete in movementsToDelete)
                            {
                                manager.My_db.Movements_Accounts.Remove(movToDelete);
                            }

                            manager.My_db.AccountingMovements.Remove(toAccountingMovementDelete);

                            manager.My_db.SaveChanges();

                            this.Close();
                        }
                    }
                }
                else
                {
                    ErrorMessage.showErrorMessage(new Exception("This accounting movement can not be deleted."));
                }
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        public bool movementCanBeDeleted()
        {
            //TODO: implementar
            return true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = KeyDefinitions.NextAccountMovementReference(dateTimePicker1.Value.Year);
        }
    }
}
