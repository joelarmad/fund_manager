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
    public partial class MovementsForm : Form
    {
        private MyFundsManager manager;
        private List<Movement> movements;

        //ATENCION en este código se trata a las Subcuentas como account y a los detalles como subcuentas
        
        //subaccount_type  0 -> Client, 1 -> Banking Account, 2 -> Employee, 3 -> Lender
        private int detalle_type;

        private string subaccount_text;
        private Decimal total_credit;
        private Decimal total_debit;
        private Color _color;
        public MovementsForm(MyFundsManager _manager)
        {
            manager = _manager;
            movements = new List<Movement>();
            InitializeComponent();
            textBox1.Text = 0.ToString();
            textBox2.Text = 0.ToString();
            _color = new Color();
            /*DateTime moment = DateTime.Today;
            String last_reference = "";

            try
            {
                last_reference = manager.My_db.AccountingMovements.OrderByDescending(ac => ac.Id).First().reference;
            }
            catch (Exception e)
            {
                last_reference = "GL170000";
            }
            
            last_reference = last_reference.Substring(4);
            int reference_number = Convert.ToInt32(last_reference) + 1;
            String new_reference = "GL" + moment.ToString("yy") + Convert.ToString(reference_number);
            textBox5.Text = new_reference;*/
            /*textBox1.TextChanged += OnDebitCreditChanged;
            textBox2.TextChanged += OnDebitCreditChanged;*/
            comboBox1.SelectedIndexChanged += OnSelectedIndexChanged;
            listView1.FullRowSelect = true;
        }

        private void MovementsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Subaccounts' table. You can move, or remove it, as needed.
            this.subaccountsTableAdapter.Fill(this.fundsDBDataSet.Subaccounts);
            // TODO: This line of code loads data into the 'fundsDBDataSet.Currencies' table. You can move, or remove it, as needed.
            this.currenciesTableAdapter.Fill(this.fundsDBDataSet.Currencies);
            // TODO: This line of code loads data into the 'fundsDBDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.fundsDBDataSet.Employees);
            // TODO: This line of code loads data into the 'fundsDBDataSet.Creditors' table. You can move, or remove it, as needed.
            this.creditorsTableAdapter.Fill(this.fundsDBDataSet.Creditors);
            // TODO: This line of code loads data into the 'fundsDBDataSet.BankingAccounts' table. You can move, or remove it, as needed.
            this.bankingAccountsTableAdapter.Fill(this.fundsDBDataSet.BankingAccounts);
            // TODO: This line of code loads data into the 'fundsDBDataSet.Clients' table. You can move, or remove it, as needed.
            this.clientsTableAdapter.Fill(this.fundsDBDataSet.Clients);
            // TODO: This line of code loads data into the 'fundsDBDataSet.Accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter.Fill(this.fundsDBDataSet.Accounts);

            Subaccount _subaccount = new Subaccount();
            _subaccount = manager.My_db.Subaccounts.Find(comboBox1.SelectedValue);

            /*if (_account != null)
            {
                String _amount = string.Format("{0:c}", _account.amount);
                textBox3.Text = _amount;
            }*/

        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            /* textBox1.Clear();
             textBox2.Clear();
             Account _account = new Account();
             _account = manager.My_db.Accounts.Find(comboBox1.SelectedValue);

             if (_account != null)
             {
                 String _amount = string.Format("{0:c}", _account.amount);
                 textBox3.Text = _amount;
             }*/
        }

        private void OnDebitCreditChanged(object sender, EventArgs e)
        {
            /*Account _account = new Account();
            _account = manager.My_db.Accounts.Find(comboBox1.SelectedValue);

            Decimal _debit = -1;
            Decimal _credit = -1;

            if (textBox1.Text == "")
                textBox1.Text = Convert.ToString(0);
            if (textBox2.Text == "")
                textBox2.Text = Convert.ToString(0);


            if ((decimal.TryParse(textBox1.Text, out _debit)) && (decimal.TryParse(textBox1.Text, out _credit)))
            {
                _debit = Convert.ToDecimal(textBox1.Text);
                _credit = Convert.ToDecimal(textBox2.Text);

                if (_account != null)
                {
                    String _amount = string.Format("{0:c}", _account.CalculateBalance(_debit, _credit));
                    textBox3.Text = _amount;
                }
                
            }*/
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
                last_reference = "GL170000";
            }

            last_reference = last_reference.Substring(4);
            int reference_number = Convert.ToInt32(last_reference) + 1;
            String new_reference = "GL" + moment.ToString("yy") + Convert.ToString(reference_number);
            return new_reference;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label7.Visible = true;
            comboBox2.Visible = true;

            label8.Visible = false;
            comboBox3.Visible = false;

            label10.Visible = false;
            comboBox5.Visible = false;

            label9.Visible = false;
            comboBox4.Visible = false;

            detalle_type = 0;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            label8.Visible = true;
            comboBox3.Visible = true;

            label10.Visible = false;
            comboBox5.Visible = false;

            label9.Visible = false;
            comboBox4.Visible = false;

            label7.Visible = false;
            comboBox2.Visible = false;

            detalle_type = 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label10.Visible = true;
            comboBox5.Visible = true;

            label8.Visible = false;
            comboBox3.Visible = false;

            label9.Visible = false;
            comboBox4.Visible = false;

            label7.Visible = false;
            comboBox2.Visible = false;

            detalle_type = 2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label9.Visible = true;
            comboBox4.Visible = true;

            label7.Visible = false;
            comboBox2.Visible = false;

            label8.Visible = false;
            comboBox3.Visible = false;

            label10.Visible = false;
            comboBox5.Visible = false;

            detalle_type = 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Movement movement = new Movement();

            movement.Subaccount = Convert.ToInt32(comboBox1.SelectedValue);
            movement.Detalle_type = detalle_type;

            movement.Debit = Convert.ToDecimal(textBox1.Text);
            total_debit += movement.Debit;

            movement.Credit = Convert.ToDecimal(textBox2.Text);
            total_credit += movement.Credit;

            //subaccount_type  0 -> Client, 1 -> Banking Account, 2 -> Employee, 3 -> Lender

            switch (detalle_type)
            {

                case 0:
                    movement.Detalle = Convert.ToInt32(comboBox2.SelectedValue);
                    subaccount_text = comboBox2.Text;
                    label7.Visible = false;
                    comboBox2.Visible = false;
                    
                    break;
                case 1:
                    movement.Detalle = Convert.ToInt32(comboBox3.SelectedValue);
                    subaccount_text = comboBox3.Text;
                    label8.Visible = false;
                    comboBox3.Visible = false;                    
                    break;
                case 2:
                    movement.Detalle = Convert.ToInt32(comboBox5.SelectedValue);
                    subaccount_text = comboBox5.Text;
                    label10.Visible = false;
                    comboBox5.Visible = false;                    
                    break;
                case 3:
                    movement.Detalle = Convert.ToInt32(comboBox4.SelectedValue);
                    subaccount_text = comboBox4.Text;
                    label9.Visible = false;
                    comboBox4.Visible = false;
                    break;
            }

            movements.Add(movement);

            if (listView1.Items.Count > 0)
                listView1.Items.RemoveAt(listView1.Items.Count - 1);

            string[] row = { comboBox1.Text, subaccount_text, textBox1.Text, textBox2.Text, textBox3.Text };
            var listViewItem = new ListViewItem(row);
            listView1.Items.Add(listViewItem);

            string[] totales = { "Total", "", Convert.ToString(total_debit), Convert.ToString(total_credit), "" };
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

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (int index in listView1.SelectedIndices)
                movements.RemoveAt(index);

            foreach (ListViewItem _item in listView1.SelectedItems)
            {

                if (listView1.Items.Count > 0)
                    listView1.Items.RemoveAt(listView1.Items.Count - 1);

                total_debit -= Convert.ToDecimal(_item.SubItems[2].Text);
                total_credit -= Convert.ToDecimal(_item.SubItems[3].Text);
                listView1.Items.Remove(_item);

                string[] totales = { "Total", "", Convert.ToString(total_debit), Convert.ToString(total_credit), "" };
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

        private void button3_Click(object sender, EventArgs e)
        {
            AccountingMovement _movement = new AccountingMovement();
            _movement.FK_AccountingMovements_Funds = manager.Selected;
            _movement.description = textBox4.Text;
            _movement.date = Convert.ToDateTime(dateTimePicker1.Text);
            _movement.reference = textBox5.Text;
            _movement.FK_AccountingMovements_Currencies = Convert.ToInt32(comboBox6.SelectedValue);
            manager.My_db.AccountingMovements.Add(_movement);
            manager.My_db.SaveChanges();
            textBox4.Clear();
            textBox5.Text = MyNewReference();
            listView1.Items.Clear();
            textBox1.Text = 0.ToString();
            textBox2.Text = 0.ToString();
            total_credit = 0;
            total_debit = 0;

            foreach (Movement my_movement in movements) {
                
                //subaccount_type  0 -> Client, 1 -> Banking Account, 2 -> Employee, 3 -> Lender
                Movements_Accounts _maccount = new Movements_Accounts();

                _maccount.FK_Movements_Accounts_AccountingMovements = _movement.Id;
                _maccount.FK_Movements_Accounts_Funds = manager.Selected;
                _maccount.FK_Movements_Accounts_Subaccounts = my_movement.Subaccount;
                _maccount.subaccount_type = my_movement.Detalle_type;
                _maccount.subaccount = my_movement.Detalle;
                _maccount.debit = my_movement.Debit;
                _maccount.credit = my_movement.Credit;
                manager.My_db.Movements_Accounts.Add(_maccount);
                manager.My_db.SaveChanges();

            }

        }
    }
}