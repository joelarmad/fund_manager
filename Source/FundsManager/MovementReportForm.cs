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
    public partial class MovementReportForm : Form
    {
        private MyFundsManager manager;
        public MovementReportForm()
        {
            try
            {
                manager = MyFundsManager.SingletonInstance;
                InitializeComponent();

                dateTimePicker1.Value = new DateTime(DateTime.Now.Year, 1, 1);
                dateTimePicker2.Value = DateTime.Now;

                listView1.FullRowSelect = true;

                loadData();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error at MovementReportForm.MovementReportForm: " + _ex.Message);
            }
        }
        private void MovementReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter.FillWithEmpty(this.fundsDBDataSet.Accounts, manager.Selected);
            comboBox1.SelectedIndex = -1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            try
            {
                listView1.Items.Clear();

                int accountId = 0;

                if (comboBox1.SelectedValue != null && int.TryParse(comboBox1.SelectedValue.ToString(), out accountId))
                {

                }

                String[] row = new String[9];

                foreach (AccountingMovement _amove in manager.My_db.AccountingMovements.Where(x => (x.reference == textBox1.Text.Trim() || textBox1.Text.Trim() == "") && x.date >= dateTimePicker1.Value && x.date <= dateTimePicker2.Value).ToList())
                {

                    List<Movements_Accounts> movementsAccount = manager.My_db.Movements_Accounts.Where(x => x.FK_Movements_Accounts_AccountingMovements == _amove.Id && (x.FK_Movements_Accounts_Accounts == accountId || accountId == 0)).ToList();

                    foreach (Movements_Accounts my_account in movementsAccount)
                    {
                        row[0] = _amove.reference;
                        row[1] = _amove.date.ToString("dd/MM/yyyy");
                        row[2] = _amove.description;
                        row[3] = my_account.Account.name;

                        if (my_account.Subaccount1 != null)
                            row[4] = my_account.Subaccount1.name;
                        else
                            row[4] = "No Subaccount";

                        //subaccount_type  1 -> Client, 2 -> Banking Account, 3 -> Employee, 4 -> Lender, 5 -> OtherDetail, 6 -> Shareholder

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
                            case 6:
                                row[5] = manager.My_db.Shareholders.Find(my_account.subaccount).name;
                                break;
                        }

                        row[6] = String.Format("{0:c}", my_account.debit);
                        row[7] = String.Format("{0:c}", my_account.credit);
                        row[8] = my_account.AccountingMovement.Currency.name;


                        ListViewItem my_item = new ListViewItem(row);
                        listView1.Items.Add(my_item);
                    }
                }
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listView1.SelectedIndices.Count > 0 ? listView1.SelectedIndices[0] : -1;

            if (index >= 0)
            {
                String reference = listView1.Items[index].Text;

                AccountingMovement accMov = manager.My_db.AccountingMovements.FirstOrDefault(x => x.reference == reference && x.FK_AccountingMovements_Funds == manager.Selected);

                if (accMov != null)
                {
                    GeneralLedgerForm ledger = new GeneralLedgerForm();
                    ledger.EditMode = true;
                    ledger.EditAccountMovementId = accMov.Id;
                    ledger.StartPosition = FormStartPosition.CenterScreen;
                    ledger.ShowDialog();

                    loadData();
                }
            }
        }
    }
}
