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

namespace FundsManager
{
    public partial class GeneralLedgerForm : Form
    {
        private MyFundsManager manager;
        private List<Movement> movements;

        //subaccount_type  1 -> Client, 2 -> Banking Account, 3 -> Employee, 4 -> Lender, 5 -> OtherDetail

        private Decimal total_credit;
        private Decimal total_debit;
        private Color _color;

        private int fMovementIdReference = 0;

        public GeneralLedgerForm(MyFundsManager _manager)
        {
            manager = _manager;
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
            // TODO: This line of code loads data into the 'fundsDBDataSet.Currencies' table. You can move, or remove it, as needed.
            this.currenciesTableAdapter.Fill(this.fundsDBDataSet.Currencies);
            // TODO: This line of code loads data into the 'fundsDBDataSet.Accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter.Fill(this.fundsDBDataSet.Accounts);
            comboBox1.SelectedItem = null;
            comboBox1.SelectedText = "Select account";
            comboBox2.SelectedItem = null;
            comboBox2.SelectedText = "Select subaccount";
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedItem = null;
            comboBox3.SelectedIndex = -1;
            comboBox3.SelectedText = "Select detail";
            textBox3.Text = MyNewReference();

        }

        private void OnAccountChanged(object sender, EventArgs e)
        {
            Dictionary<int,string> comboSource = new Dictionary<int, string>();

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
            

        }

        private void OnSubAccountChanged(object sender, EventArgs e)
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

        private String MyNewReference()
        {
            DateTime moment = DateTime.Today;
            String last_reference = "";

            try
            {
                last_reference = manager.My_db.AccountingMovements.OrderByDescending(ac => ac.Id).First().reference;
            }
            catch (Exception e)
            {
                e.Source = "First time reference";
                last_reference = "GL170000";
            }

            last_reference = last_reference.Substring(4);
            int reference_number = Convert.ToInt32(last_reference) + 1;
            String new_reference = "GL" + moment.ToString("yy") + Convert.ToString(reference_number).PadLeft(4, '0'); ;
            return new_reference;
        }

        private void button1_Click(object sender, EventArgs e)
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
                                    
            movement.Debit = Convert.ToDecimal(textBox1.Text);
            total_debit += movement.Debit;

            movement.Credit = Convert.ToDecimal(textBox2.Text);
            total_credit += movement.Credit;

            Account _account = manager.My_db.Accounts.First(x => x.Id == movement.Account);
            Subaccount _subaccount = manager.My_db.Subaccounts.First(x => x.Id == movement.Subaccount);

            int _credit_factor = 1;
            int _debit_factor = -1;

            if (_account.type == 0 || _account.type == 4 || _account.type == 5)
            {
                _credit_factor = -1;
                _debit_factor = 1;
            }

            decimal _amount_shift = _debit_factor * movement.Debit + _credit_factor * movement.Credit;
            movement.Account_balance = calculateAccountBalance(movement.Account, _amount_shift);
            movement.Sub_account_balance = calculateSubAccountBalance(movement.Subaccount, _amount_shift);

            movements.Add(movement);

            if (listView1.Items.Count > 0)
                listView1.Items.RemoveAt(listView1.Items.Count - 1);

            string[] row = {comboBox1.Text, comboBox2.Text, comboBox3.Text, textBox1.Text, textBox2.Text, movement.Sub_account_balance.ToString() };
            ListViewItem my_item = new ListViewItem(row);

            if (movement.Sub_account_balance < 0)
            {
                my_item.ForeColor = _color = Color.FromName("Red");
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

            listView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ArrayList _movementsToDelete = new ArrayList();

            foreach (int index in listView1.SelectedIndices)
                _movementsToDelete.Add(movements[index]);

            foreach (Movement _movementToDelete in _movementsToDelete)
            {
                movements.Remove(_movementToDelete);
            }

            listView1.Items.Clear();

            ArrayList _sub_accounts_ids = new ArrayList();
            ArrayList _accounts_balances = new ArrayList();
            ArrayList _sub_accounts_balances = new ArrayList();

            total_credit = 0;
            total_debit = 0;

            foreach (Movement _movement in movements)
            {
                _movement.Account_balance = 0;
                _movement.Sub_account_balance = 0;
            }

            foreach (Movement _movement in movements)
            {
                total_credit += _movement.Credit;
                total_debit += _movement.Debit;

                Account _account = manager.My_db.Accounts.FirstOrDefault(x => x.Id == _movement.Account);
                Subaccount _subaccount = manager.My_db.Subaccounts.FirstOrDefault(x => x.Id == _movement.Subaccount);
                OtherDetail _detail = manager.My_db.OtherDetails.FirstOrDefault(x => x.Id == _movement.Detail);

                int _credit_factor = 1;
                int _debit_factor = -1;

                if (_account.type == 0 || _account.type == 4 || _account.type == 5)
                {
                    _credit_factor = -1;
                    _debit_factor = 1;
                }

                decimal _amount_shift = _debit_factor * _movement.Debit + _credit_factor * _movement.Credit;

                if (!_sub_accounts_ids.Contains(_movement.Subaccount))
                {
                    _movement.Account_balance = _account.amount + _amount_shift;
                    _movement.Sub_account_balance = _subaccount.amount + _amount_shift;

                    _sub_accounts_ids.Add(_movement.Subaccount);
                    _accounts_balances.Add(_movement.Account_balance);
                    _sub_accounts_balances.Add(_movement.Sub_account_balance);
                }
                else
                {
                    int _index = _sub_accounts_ids.IndexOf(_movement.Subaccount);

                    _movement.Account_balance = decimal.Parse(_accounts_balances[_index].ToString()) + _amount_shift;
                    _movement.Sub_account_balance = decimal.Parse(_sub_accounts_balances[_index].ToString()) + _amount_shift;

                    _accounts_balances[_index] = _movement.Account_balance;
                    _sub_accounts_balances[_index] = _movement.Sub_account_balance;

                }

                string[] row = { _account.name, _subaccount.name, _detail.name, _movement.Debit.ToString(), _movement.Credit.ToString(), _movement.Sub_account_balance.ToString() };
                ListViewItem my_item = new ListViewItem(row);

                if (_movement.Sub_account_balance < 0)
                {
                    my_item.ForeColor = _color = Color.FromName("Red");
                }

                listView1.Items.Add(my_item);
            }

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

        private void button2_Click(object sender, EventArgs e)
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
            
            textBox3.Text = MyNewReference();
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
                if(my_movement.Subaccount != -1)
                    _maccount.FK_Movements_Accounts_Subaccounts = my_movement.Subaccount;
                /*WARNING en la tabla Movements_Accounts los campos subaccount y subaccount_type se refieren a detail y detail_type respectivamente*/
                _maccount.subaccount_type = my_movement.Detail_type;
                if (my_movement.Detail != -1)
                    _maccount.subaccount = my_movement.Detail;
                _maccount.debit = my_movement.Debit;
                _maccount.credit = my_movement.Credit;

                Account _account = manager.My_db.Accounts.First(x => x.Id == my_movement.Account);
                Subaccount _subaccount = manager.My_db.Subaccounts.First(x => x.Id == my_movement.Subaccount);
                
                int _credit_factor = 1;
                int _debit_factor = -1;
                
                if (_account.type == 0 || _account.type == 4 || _account.type == 5)
                {
                    _credit_factor = -1;
                    _debit_factor = 1;
                }

                _account.amount += _debit_factor * my_movement.Debit;
                _account.amount += _credit_factor * my_movement.Credit;

                _subaccount.amount += _debit_factor * my_movement.Debit;
                _subaccount.amount += _credit_factor * my_movement.Credit;

                _maccount.acc_amount = _account.amount;
                _maccount.subacc_amount = _subaccount.amount;
                
                manager.My_db.Movements_Accounts.Add(_maccount);

                manager.My_db.SaveChanges();
            }

            movements.Clear();
        }

        private decimal calculateAccountBalance(int aAccountId, decimal amountShift)
        {
            decimal _latestAmount = 0;
            bool _found = false;

            foreach (Movement _movement in movements)
            {
                if (_movement.Account == aAccountId)
                {
                    _latestAmount = _movement.Account_balance;
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

        private decimal calculateSubAccountBalance(int aSubAccountId, decimal amountShift)
        {
            decimal _latestAmount = 0;
            bool _found = false;

            foreach (Movement _movement in movements)
            {
                if (_movement.Subaccount == aSubAccountId)
                {
                    _latestAmount = _movement.Sub_account_balance;
                    _found = tr