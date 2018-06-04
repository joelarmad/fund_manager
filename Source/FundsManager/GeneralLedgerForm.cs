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

            movements.Add(movement);

            if (listView1.Items.Count > 0)
                listView1.Items.RemoveAt(listView1.Items.Count - 1);

            string[] row = {comboBox1.Text, comboBox2.Text, comboBox3.Text, textBox1.Text, textBox2.Text };
            ListViewItem my_item = new ListViewItem(row);
            listView1.Items.Add(my_item);


            string[] totales = { "Total", "", "", Convert.ToString(total_debit), Convert.ToString(total_credit), "" };
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

            textBox1.Text = 0.ToString();
            textBox2.Text = 0.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (int index in listView1.SelectedIndices)
                movements.RemoveAt(index);

            foreach (ListViewItem _item in listView1.SelectedItems)
            {

                if (listView1.Items.Count > 0)
                    listView1.Items.RemoveAt(listView1.Items.Count - 1);

                total_debit -= Convert.ToDecimal(_item.SubItems[3].Text);
                total_credit -= Convert.ToDecimal(_item.SubItems[4].Text);

                listView1.Items.Remove(_item);

                string[] totales = { "Total", "", "", Convert.ToString(total_debit), Convert.ToString(total_credit), "" };
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
                manager.My_db.Movements_Accounts.Add(_maccount);

                // TODO: Hay que identificar como segun el tipo de cuenta se modifica el saldo de la cuenta.
                Account _account = manager.My_db.Accounts.First(x => x.Id == my_movement.Account);

                _account.amount += my_movement.Credit;
                _account.amount -= my_movement.Debit;

                manager.My_db.SaveChanges();
            }
            movements.Clear();
        }
    }
}
