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
    public partial class MovementReportForm : Form
    {
        private MyFundsManager manager;
        public MovementReportForm()
        {
            manager = MyFundsManager.SingletonInstance;
            InitializeComponent();
            listView1.FullRowSelect = true;
            String[] row = new String[9];
            
            foreach (AccountingMovement _amove in manager.My_db.AccountingMovements)
            {
                foreach (Movements_Accounts my_account in manager.My_db.Movements_Accounts)
                {
                    if (my_account.FK_Movements_Accounts_AccountingMovements == _amove.Id)
                    {
                        row[0] = _amove.reference;
                        row[1] = _amove.date.ToString("dd/MM/yyyy");
                        row[2] = _amove.description;
                        row[3] = my_account.Account.name;

                        if (my_account.Subaccount1 != null)
                            row[4] = my_account.Subaccount1.name;
                        else
                            row[4] = "No Subaccount";

                        //subaccount_type  1 -> Client, 2 -> Banking Account, 3 -> Employee, 4 -> Lender, 5 -> OtherDetail
                        
                        switch (my_account.subaccount_type)
                        {
                            case -1:
                                row[5] = "No Detail";
                                break;
                            case 1:
                                row[5] = manager.My_db.Clients.Find(my_account.subaccount).name;
                                break;
                            case 2:
                                row[5] = manager.My_db.BankingAccounts.Find(my_account.subaccount).name;
                                break;
                            case 3:
                                row[5] = manager.My_db.Employees.Find(my_account.subaccount).name;
                                break;
                            case 4:
                                row[5] = manager.My_db.Creditors.Find(my_account.subaccount).name;
                                break;
                            case 5:
                                row[5] = manager.My_db.OtherDetails.Find(my_account.subaccount).name;
                                break;
                        }

                        row[6] = String.Format("{0:c}", my_account.debit);
                        row[7] = String.Format("{0:c}", my_account.credit);
                        //TODO: pendiente a ajuste por eliminacion de currency.code
                        row[8] = "-"; // my_account.AccountingMovement.Currency.code;

                        
                        ListViewItem my_item = new ListViewItem(row);
                        listView1.Items.Add(my_item);

                    }             

                }
            }

        }
        private void MovementReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter.FillByFund(this.fundsDBDataSet.Accounts, manager.Selected);
            comboBox1.SelectedIndex = -1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (AccountingMovement _amove in manager.My_db.AccountingMovements)
            {
                if (((textBox1.Text == "") || (_amove.reference.Equals(textBox1.Text, StringComparison.OrdinalIgnoreCase))) && ((_amove.date > Convert.ToDateTime(dateTimePicker1.Text)) && (_amove.date < Convert.ToDateTime(dateTimePicker2.Text))))
                {
                    foreach (Movements_Accounts _maccount in manager.My_db.Movements_Accounts)
                    {
                        if ((_maccount.FK_Movements_Accounts_AccountingMovements == _amove.Id) && ((_maccount.Subaccount1.FK_Subaccounts_Accounts == Convert.ToInt32(comboBox1.SelectedValue)) || (comboBox1.SelectedIndex == -1)))
                        {

                            String _subaccount = "No Subaccount";
                            if (_maccount.Subaccount1 != null)
                               _subaccount = _maccount.Subaccount1.name;
                            
                            //subaccount_type  1 -> Client, 2 -> Banking Account, 3 -> Employee, 4 -> Lender, 5 -> OtherDetail
                            //TODO: pendiente a ajuste por eliminacion de Currency.code
                            string[] row = { _amove.reference, _amove.date.ToString("dd/MM/yyyy"), _amove.description, _maccount.Account.name, _subaccount, "subaccount", string.Format("{0:c}", _maccount.debit), string.Format("{0:c}", _maccount.credit), "-" /*_maccount.AccountingMovement.Currency.code*/ };
                        
                            switch (_maccount.subaccount_type)
                            {
                                case -1:
                                    row[5] = "No Detail";
                                    break;
                                case 1:
                                    row[5] = manager.My_db.Clients.Find(_maccount.subaccount).name;
                                    break;
                                case 2:
                                    row[5] = manager.My_db.BankingAccounts.Find(_maccount.subaccount).name;
                                    break;
                                case 3:
                                    row[5] = manager.My_db.Employees.Find(_maccount.subaccount).name;
                                    break;
                                case 4:
                                    row[5] = manager.My_db.Creditors.Find(_maccount.subaccount).name;
                                    break;
                                case 5:
                                    row[5] = manager.My_db.OtherDetails.Find(_maccount.subaccount).name;
                                    break;
                            }

                            ListViewItem my_item = new ListViewItem(row);
                            listView1.Items.Add(my_item);

                        }

                    }
                }

            }
            textBox1.Clear();
        }
    }
}
