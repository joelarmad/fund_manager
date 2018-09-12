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

        public bool EditMode = false;
        public int EditAccountMovementId = 0;


        private MyFundsManager manager;
        private AccountingMovement AccountingMovementToEdit;
        private List<Movement> movements;
        private List<Movement> movementsToDelete;
        private List<Account> fFloatingAccounts;

        //subaccount_type  1 -> Client, 2 -> Banking Account, 3 -> Employee, 4 -> Lender, 5 -> OtherDetail

        private Decimal total_credit;
        private Decimal total_debit;
        private Color _color;

        private int fMovementIdReference = 0;

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
                textBox3.Text = KeyDefinitions.NextAccountMovementReference;

                fFloatingAccounts = manager.My_db.Accounts.Where(x => x.FK_Accounts_Funds == manager.Selected).ToList();

                txtContract.Text = "";

                OnAccountChanged(null, null);



                if (EditMode && EditAccountMovementId > 0)
                {
                    listView1.MultiSelect = false;

                    button1.Visible = false;
                    button3.Visible = false;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button1.Text = "Save";
                    button2.Text = "Save Movement";
                    
                    AccountingMovementToEdit = manager.My_db.AccountingMovements.FirstOrDefault(x => x.Id == EditAccountMovementId);

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

                        List<Movements_Accounts> movementsAccount = manager.My_db.Movements_Accounts.Where(x => x.FK_Movements_Accounts_AccountingMovements == EditAccountMovementId).ToList();

                        foreach (Movements_Accounts _mov in movementsAccount)
                        {
                            movements.Add(new Movement(_mov));
                        }

                        loadDataForEditMode();

                        checkForContractVisibility();
                    }
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
                if (!EditMode)
                {
                    Movement movement = new Movement();

                    movement.Id = fMovementIdReference++;

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

                    movement.Debit = decimal.Parse(textBox1.Text);
                    total_debit += movement.Debit;

                    movement.Credit = decimal.Parse(textBox2.Text);
                    total_credit += movement.Credit;

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

                    if (listView1.Items.Count > 0)
                        listView1.Items.RemoveAt(listView1.Items.Count - 1);

                    string[] row = { cbAccount.Text, movement.Subaccount > 0 ? cbSubaccount.Text : "", movement.Detail_type != -1 ? cbOtherDetail.Text : "", String.Format("{0:n}", movement.Debit), String.Format("{0:n}", movement.Credit) };
                    ListViewItem my_item = new ListViewItem(row);
                    
                    listView1.Items.Add(my_item);


                    string[] totales = { "", "", "Total", String.Format("{0:n}", total_debit), String.Format("{0:n}", total_credit) };
                    var listViewItemTotal = new ListViewItem(totales);

                    if (total_credit == total_debit)
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

                    textBox1.Text = 0.ToString();
                    textBox2.Text = 0.ToString();

                    checkForContractVisibility();
                }
                else
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

                        toEdit.Debit = decimal.Parse(textBox1.Text);

                        toEdit.Credit = decimal.Parse(textBox2.Text);

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
                        
                        loadDataForEditMode();

                        button1.Visible = false;
                        button3.Visible = false;
                        listView1.SelectedIndices.Clear();
                    }
                }
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
                if (!EditMode)
                {
                    ArrayList _movementsToDelete = new ArrayList();

                    foreach (int _index in listView1.SelectedIndices)
                    {
                        _movementsToDelete.Add(movements[_index]);
                    }

                    foreach (Movement _movement in _movementsToDelete)
                    {
                        movements.Remove(_movement);
                    }

                    listView1.Items.Clear();

                    //ArrayList _subAccountIds = new ArrayList();
                    //ArrayList _accountBalances = new ArrayList();
                    //ArrayList _subAccountBalances = new ArrayList();

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

                        //if (!_subAccountIds.Contains(_movement.Subaccount))
                        //{
                        //    _movement.AccountBalance = _account.amount + _amountShift;
                        //    _movement.SubAccountBalance = _subAccount.amount + _amountShift;

                        //    _subAccountIds.Add(_movement.Subaccount);
                        //    _accountBalances.Add(_movement.AccountBalance);
                        //    _subAccountBalances.Add(_movement.SubAccountBalance);
                        //}
                        //else
                        //{
                        //    int _index = _subAccountIds.IndexOf(_movement.Subaccount);

                        //    _movement.AccountBalance = decimal.Parse(_accountBalances[_index].ToString()) + _amountShift;
                        //    _movement.SubAccountBalance = decimal.Parse(_subAccountBalances[_index].ToString()) + _amountShift;

                        //    _accountBalances[_index] = _movement.AccountBalance;
                        //    _subAccountBalances[_index] = _movement.SubAccountBalance;
                        //}

                        string[] row = { _account.name, _subAccount != null ? _subAccount.name : "", detailText, String.Format("{0:n}", _movement.Debit), String.Format("{0:n}", _movement.Credit) };
                        ListViewItem my_item = new ListViewItem(row);

                        //if (_movement.AccountBalance < 0)
                        //{
                        //    my_item.ForeColor = Color.FromName("Red");
                        //}

                        listView1.Items.Add(my_item);
                    }

                    if (total_credit > 0 || total_debit > 0)
                    {
                        string[] totales = { "", "", "Total", String.Format("{0:n}", total_debit), String.Format("{0:n}", total_credit) };
                        var listViewItemTotal = new ListViewItem(totales);

                        if (total_credit == total_debit)
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

                    button3.Enabled = false;

                    checkForContractVisibility();
                }
                else
                {
                    int index = listView1.SelectedIndices.Count > 0 ? listView1.SelectedIndices[0] : -1;

                    if (index >= 0)
                    {
                        Movement toDelete = movements[index];

                        movementsToDelete.Add(toDelete);

                        movements.RemoveAt(index);

                        loadDataForEditMode();

                        button1.Visible = false;
                        button3.Visible = false;
                        listView1.SelectedIndices.Clear();
                    }
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
                if (!EditMode)
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
            }
            catch (Exception ex)
            {
                ErrorMessage.showErrorMessage(ex);
            }
        }

        private void makeMovement()
        {
            int created_movement_id = 0;

            try
            {
                if (!EditMode)
                {
                    AccountingMovement _movement = new AccountingMovement();
                    _movement.FK_AccountingMovements_Funds = manager.Selected;
                    _movement.description = textBox4.Text;
                    _movement.date = Convert.ToDateTime(dateTimePicker1.Text);
                    _movement.reference = textBox3.Text;
                    _movement.FK_AccountingMovements_Currencies = Convert.ToInt32(comboBox4.SelectedValue);
                    _movement.original_reference = textBox5.Text;

                    if (txtContract.Visible)
                    {
                        _movement.contract = txtContract.Text;
                    }

                    manager.My_db.AccountingMovements.Add(_movement);
                    manager.My_db.SaveChanges();

                    created_movement_id = _movement.Id;

                    textBox3.Text = KeyDefinitions.NextAccountMovementReference;
                    textBox4.Clear();
                    textBox5.Clear();
                    txtContract.Clear();
                    listView1.Items.Clear();
                    textBox1.Text = 0.ToString();
                    textBox2.Text = 0.ToString();
                    total_credit = 0;
                    total_debit = 0;

                    foreach (Movement my_movement in movements)
                    {
                        //subaccount_type  1 -> Client, 2 -> Banking Account, 3 -> Employee, 4 -> Lender, 5 -> OtherDetail
                        Movements_Accounts _maccount = new Movements_Accounts();

                        _maccount.FK_Movements_Accounts_AccountingMovements = _movement.Id;
                        _maccount.FK_Movements_Accounts_Funds = manager.Selected;
                        _maccount.FK_Movements_Accounts_Accounts = my_movement.Account;
                        if (my_movement.Subaccount != -1)
                            _maccount.FK_Movements_Accounts_Subaccounts = my_movement.Subaccount;
                        /*WARNING en la tabla Movements_Accounts los campos subaccount y subaccount_type se refieren a detail y detail_type respectivamente*/
                        _maccount.subaccount_type = my_movement.Detail_type;
                        if (my_movement.Detail != -1)
                            _maccount.subaccount = my_movement.Detail;
                        _maccount.debit = my_movement.Debit;
                        _maccount.credit = my_movement.Credit;

                        Account _account = manager.My_db.Accounts.FirstOrDefault(x => x.Id == my_movement.Account);
                        Subaccount _subAccount = manager.My_db.Subaccounts.FirstOrDefault(x => x.Id == my_movement.Subaccount);

                        int _creditFactor = 1;
                        int _debitFactor = -1;

                        if (Account.leftAccountingIncrement(_account.type))
                        {
                            _creditFactor = -1;
                            _debitFactor = 1;
                        }

                        _account.amount += _debitFactor * my_movement.Debit;
                        _account.amount += _creditFactor * my_movement.Credit;
                        _maccount.acc_amount = _account.amount;

                        if (_subAccount != null)
                        {
                            _subAccount.amount += _debitFactor * my_movement.Debit;
                            _subAccount.amount += _creditFactor * my_movement.Credit;
                            _maccount.subacc_amount = _subAccount.amount;
                        }
                        else
                        {
                            _maccount.subacc_amount = 0;
                        }

                        manager.My_db.Movements_Accounts.Add(_maccount);

                        manager.My_db.SaveChanges();
                    }
                    movements.Clear();

                    checkForContractVisibility();
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

                    manager.My_db.SaveChanges();

                    textBox3.Text = KeyDefinitions.NextAccountMovementReference;
                    textBox4.Clear();
                    textBox5.Clear();
                    txtContract.Clear();
                    listView1.Items.Clear();
                    textBox1.Text = 0.ToString();
                    textBox2.Text = 0.ToString();
                    total_credit = 0;
                    total_debit = 0;

                    foreach (Movement my_movement in movements)
                    {
                        Movements_Accounts _maccount = manager.My_db.Movements_Accounts.FirstOrDefault(x => x.Id == my_movement.Id);
                        
                        _maccount.FK_Movements_Accounts_Accounts = my_movement.Account;
                        if (my_movement.Subaccount != -1)
                            _maccount.FK_Movements_Accounts_Subaccounts = my_movement.Subaccount;
                        /*WARNING en la tabla Movements_Accounts los campos subaccount y subaccount_type se refieren a detail y detail_type respectivamente*/
                        _maccount.subaccount_type = my_movement.Detail_type;
                        if (my_movement.Detail != -1)
                            _maccount.subaccount = my_movement.Detail;
                        _maccount.debit = my_movement.Debit;
                        _maccount.credit = my_movement.Credit;

                        Account _account = manager.My_db.Accounts.FirstOrDefault(x => x.Id == my_movement.Account);
                        Subaccount _subAccount = manager.My_db.Subaccounts.FirstOrDefault(x => x.Id == my_movement.Subaccount);

                        int _creditFactor = 1;
                        int _debitFactor = -1;

                        if (Account.leftAccountingIncrement(_account.type))
                        {
                            _creditFactor = -1;
                            _debitFactor = 1;
                        }

                        _account.amount += _debitFactor * my_movement.Debit;
                        _account.amount += _creditFactor * my_movement.Credit;
                        _maccount.acc_amount = _account.amount;

                        if (_subAccount != null)
                        {
                            _subAccount.amount += _debitFactor * my_movement.Debit;
                            _subAccount.amount += _creditFactor * my_movement.Credit;
                            _maccount.subacc_amount = _subAccount.amount;
                        }
                        else
                        {
                            _maccount.subacc_amount = 0;
                        }

                        manager.My_db.SaveChanges();
                    }

                    foreach (Movement toDelete in movementsToDelete)
                    {
                        manager.DeleteMovementAccount(toDelete.Id);
                    }

                    movements.Clear();
                    movementsToDelete.Clear();

                    this.Close();
                }
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);

                //Try to rollback
                try
                {
                    if (!EditMode)
                    {
                        manager.Reset();

                        //TODO: analizar rollback
                    }
                }
                catch (Exception _ex2)
                {
                    ErrorMessage.showErrorMessage(_ex2);
                }
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

                if (!EditMode)
                {
                    button3.Enabled = listView1.SelectedIndices.Count > 0;
                }
                else
                {
                    if (listView1.SelectedIndices.Count > 0)
                    {
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
                            KeyValuePair<int, string> row = (KeyValuePair<int, string>) cbSubaccount.Items[i];

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

                        button1.Visible = true;
                        button3.Visible = true;
                    }
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
                if (!EditMode)                    
                    checkEnablingAddButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.cbOtherDetail_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void loadDataForEditMode()
        {
            if (EditMode)
            {
                listView1.Items.Clear();

                total_credit = 0;
                total_debit = 0;

                foreach (Movement mov in movements)
                {
                    total_debit += mov.Debit;
                    total_credit += mov.Credit;

                    Account _account = manager.My_db.Accounts.FirstOrDefault(x => x.Id == mov.Account);
                    Subaccount _subAccount = manager.My_db.Subaccounts.FirstOrDefault(x => x.Id == mov.Subaccount);

                    String detailText = "";

                    switch (mov.Detail_type)
                    {
                        case 1:
                            Client client = manager.My_db.Clients.FirstOrDefault(x => x.Id == mov.Detail);
                            if (client != null)
                            {
                                detailText = client.name;
                            }
                            break;
                        case 2:
                            BankingAccount baccount = manager.My_db.BankingAccounts.FirstOrDefault(x => x.Id == mov.Detail);
                            if (baccount != null)
                            {
                                detailText = baccount.name;
                            }
                            break;
                        case 3:
                            Employee employee = manager.My_db.Employees.FirstOrDefault(x => x.Id == mov.Detail);
                            if (employee != null)
                            {
                                detailText = employee.name;
                            }
                            break;
                        case 4:
                            Creditor creditor = manager.My_db.Creditors.FirstOrDefault(x => x.Id == mov.Detail);
                            if (creditor != null)
                            {
                                detailText = creditor.name;
                            }
                            break;
                        case 5:
                            OtherDetail detail = manager.My_db.OtherDetails.FirstOrDefault(x => x.Id == mov.Detail);
                            if (detail != null)
                            {
                                detailText = detail.name;
                            }
                            break;
                        case 6:
                            Shareholder holder = manager.My_db.Shareholders.FirstOrDefault(x => x.Id == mov.Detail);
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

                    decimal _amountShift = _debitFactor * mov.Debit + _creditFactor * mov.Credit;

                    string[] row = { _account.name, _subAccount != null ? _subAccount.name : "", detailText, String.Format("{0:n}", mov.Debit), String.Format("{0:n}", mov.Credit) };
                    ListViewItem my_item = new ListViewItem(row);
                    
                    listView1.Items.Add(my_item);
                }

                string[] totales = { "", "", "Total", String.Format("{0:n}", total_debit), String.Format("{0:n}", total_credit) };
                var listViewItemTotal = new ListViewItem(totales);

                if (total_credit == total_debit)
                {
                    _color = Color.FromName("Green");
                }
                else
                {
                    _color = Color.FromName("Red");
                }

                listViewItemTotal.ForeColor = _color;
                listView1.Items.Add(listViewItemTotal);
            }
        }

        private void cbSubaccount_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }
    }
}
