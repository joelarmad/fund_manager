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
        private MyFundsManager manager;
        private List<Movement> movements;
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
            InitializeComponent();
            textBox1.Text = 0.ToString();
            textBox2.Text = 0.ToString();
            _color = new Color();
            listView1.FullRowSelect = true;
            comboBox1.SelectedIndexChanged += OnAccountChanged;
            comboBox2.SelectedIndexChanged += OnSubAccountChanged;
        }

        private void GeneralLedgerForm_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'fundsDBDataSet.Currencies' table. You can move, or remove it, as needed.
                this.currenciesTableAdapter.Fill(this.fundsDBDataSet.Currencies);
                // TODO: This line of code loads data into the 'fundsDBDataSet.Accounts' table. You can move, or remove it, as needed.
                this.accountsTableAdapter.Fill(this.fundsDBDataSet.Accounts);
                comboBox1.SelectedItem = null;
                comboBox1.SelectedText = "Select account";
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedItem = null;
                comboBox3.SelectedIndex = -1;
                comboBox3.SelectedText = "Select detail";
                textBox3.Text = KeyDefinitions.NextAccountMovementReference;

                fFloatingAccounts = manager.My_db.Accounts.ToList();
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
                Dictionary<int, string> comboSource = new Dictionary<int, string>();

                foreach (Subaccount _subaccount in manager.My_db.Subaccounts)
                {
                    if (_subaccount.FK_Subaccounts_Accounts == Convert.ToInt32(comboBox1.SelectedValue))
                    {
                        comboSource.Add(_subaccount.Id, _subaccount.name);
                    }
                }

                if (comboSource.Count > 0)
                {
                    comboBox2.DataSource = new BindingSource(comboSource, null);
                    comboBox2.DisplayMember = "Value";
                    comboBox2.ValueMember = "Key";
                    comboBox2.Enabled = true;
                }
                else
                {
                    comboBox2.DataSource = null;
                    comboBox2.Items.Clear();
                    comboBox2.Text = "";
                    comboBox2.SelectedItem = null;
                    comboBox2.SelectedText = "Select subaccount";
                    comboBox2.Enabled = false;

                    comboBox3.DataSource = null;
                    comboBox3.Items.Clear();
                    comboBox3.Text = "";
                    comboBox3.SelectedItem = null;
                    comboBox3.SelectedText = "Select detail";
                    comboBox3.Enabled = false;
                }
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
                Dictionary<int, string> comboSource = new Dictionary<int, string>();

                //subaccount_type  1 -> Client, 2 -> Banking Account, 3 -> Employee, 4 -> Lender, 5 -> OtherDetail

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


                foreach (OtherDetail _detail in manager.My_db.OtherDetails)
                {
                    int custom_id = int.Parse(5.ToString() + _detail.Id.ToString());
                    comboSource.Add(custom_id, _detail.name);
                }

                if (comboSource.Count > 0)
                {
                    comboBox3.DataSource = new BindingSource(comboSource, null);
                    comboBox3.DisplayMember = "Value";
                    comboBox3.ValueMember = "Key";
                    comboBox3.Enabled = true;
                }
                else
                {
                    comboBox3.DataSource = null;
                    comboBox3.Enabled = false;
                }
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
                Movement movement = new Movement();

                movement.Id = fMovementIdReference++;

                movement.Account = Convert.ToInt32(comboBox1.SelectedValue);

                if (comboBox2.SelectedIndex != -1)
                    movement.Subaccount = Convert.ToInt32(comboBox2.SelectedValue);
                else
                    movement.Subaccount = -1;

                if (comboBox3.SelectedIndex != -1)
                {
                    string temp_id = Convert.ToString(comboBox3.SelectedValue);
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

                if (_account.type == 0 || _account.type == 4 || _account.type == 5)
                {
                    _creditFactor = -1;
                    _debitFactor = 1;
                }

                decimal _amountShift = _debitFactor * movement.Debit + _creditFactor * movement.Credit;

                movement.AccountBalance = calculateAccountBalance(movement.Account, _amountShift);
                movement.SubAccountBalance = calculateSubAccountBalance(movement.Subaccount, _amountShift);

                movements.Add(movement);

                if (listView1.Items.Count > 0)
                    listView1.Items.RemoveAt(listView1.Items.Count - 1);

                string[] row = { comboBox1.Text, comboBox2.Text, comboBox3.Text, String.Format("{0:0.00}", movement.Debit), String.Format("{0:0.00}", movement.Credit), String.Format("{0:0.00}", movement.AccountBalance) };
                ListViewItem my_item = new ListViewItem(row);

                if (movement.AccountBalance < 0)
                {
                    my_item.ForeColor = Color.FromName("Red");
                }

                listView1.Items.Add(my_item);


                string[] totales = { "Total", "", "", Convert.ToString(total_debit), Convert.ToString(total_credit), "" };
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

                ArrayList _subAccountIds = new ArrayList();
                ArrayList _accountBalances = new ArrayList();
                ArrayList _subAccountBalances = new ArrayList();

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
                    OtherDetail _detail = manager.My_db.OtherDetails.FirstOrDefault(x => x.Id == _movement.Detail);

                    int _creditFactor = 1;
                    int _debitFactor = -1;

                    if (_account.type == 0 || _account.type == 4 || _account.type == 5)
                    {
                        _creditFactor = -1;
                        _debitFactor = 1;
                    }

                    decimal _amountShift = _debitFactor * _movement.Debit + _creditFactor * _movement.Credit;

                    if (!_subAccountIds.Contains(_movement.Subaccount))
                    {
                        _movement.AccountBalance = _account.amount + _amountShift;
                        _movement.SubAccountBalance = _subAccount.amount + _amountShift;

                        _subAccountIds.Add(_movement.Subaccount);
                        _accountBalances.Add(_movement.AccountBalance);
                        _subAccountBalances.Add(_movement.SubAccountBalance);
                    }
                    else
                    {
                        int _index = _subAccountIds.IndexOf(_movement.Subaccount);

                        _movement.AccountBalance = decimal.Parse(_accountBalances[_index].ToString()) + _amountShift;
                        _movement.SubAccountBalance = decimal.Parse(_subAccountBalances[_index].ToString()) + _amountShift;

                        _accountBalances[_index] = _movement.AccountBalance;
                        _subAccountBalances[_index] = _movement.SubAccountBalance;
                    }

                    string[] row = { _account.name, _subAccount.name, _detail.name, String.Format("{0:0.00}", _movement.Debit), String.Format("{0:0.00}", _movement.Credit), String.Format("{0:0.00}", _movement.AccountBalance) };
                    ListViewItem my_item = new ListViewItem(row);

                    if (_movement.AccountBalance < 0)
                    {
                        my_item.ForeColor = Color.FromName("Red");
                    }

                    listView1.Items.Add(my_item);
                }

                if (total_credit > 0 || total_debit > 0)
                {
                    string[] totales = { "Total", "", "", Convert.ToString(total_debit), Convert.ToString(total_credit), "" };
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
                if (canMakeMovement())
                {
                    AccountingMovement _movement = new AccountingMovement();
                    _movement.FK_AccountingMovements_Funds = manager.Selected;
                    _movement.description = textBox4.Text;
                    _movement.date = Convert.ToDateTime(dateTimePicker1.Text);
                    _movement.reference = textBox3.Text;
                    _movement.FK_AccountingMovements_Currencies = Convert.ToInt32(comboBox4.SelectedValue);
                    _movement.original_reference = textBox5.Text;
                    manager.My_db.AccountingMovements.Add(_movement);
                    manager.My_db.SaveChanges();

                    textBox3.Text = KeyDefinitions.NextAccountMovementReference;
                    textBox4.Clear();
                    textBox5.Clear();
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

                        if (_account.type == 0 || _account.type == 4 || _account.type == 5)
                        {
                            _creditFactor = -1;
                            _debitFactor = 1;
                        }

                        _account.amount += _debitFactor * my_movement.Debit;
                        _account.amount += _creditFactor * my_movement.Credit;

                        _subAccount.amount += _debitFactor * my_movement.Debit;
                        _subAccount.amount += _creditFactor * my_movement.Credit;

                        _maccount.acc_amount = _account.amount;
                        _maccount.subacc_amount = _subAccount.amount;

                        manager.My_db.Movements_Accounts.Add(_maccount);

                        manager.My_db.SaveChanges();
                    }
                    movements.Clear();
                }
                else
                {
                    MessageBox.Show("Please, check the operations");
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.button2_Click: " + _ex.Message);
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

                button1.Enabled = comboBox3.SelectedIndex > 0
                    && decimal.TryParse(textBox1.Text, out _debit)
                    && decimal.TryParse(textBox2.Text, out _credit)
                    && (_debit > 0 || _credit > 0);
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.checkEnablingAddButton: " + _ex.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.comboBox3_SelectedIndexChanged: " + _ex.Message);
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

                button3.Enabled = listView1.SelectedIndices.Count > 0;
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.listView1_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private bool canMakeMovement()
        {
            try
            {
                decimal _leftAccount = 0;   //Asset + Expense
                decimal _rigthAccount = 0;  //Liability + Equity + Income

                foreach (Movement _movement in movements)
                {
                    Account _account = manager.My_db.Accounts.First(x => x.Id == _movement.Account);

                    if (_account.type == 0 || _account.type == 4 || _account.type == 5)
                    {
                        _leftAccount += _movement.AccountBalance;
                    }
                    else
                    {
                        _rigthAccount += _movement.AccountBalance;
                    }
                }

                return _leftAccount == _rigthAccount;
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.canMakeMovement: " + _ex.Message);
                return false;
            }
        }
    }
}
