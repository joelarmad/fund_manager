using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundsManager.Classes.Utilities
{
    public static class DataUtils
    {
        public static Dictionary<int, String> getOtherDetailsSource(int subacctId)
        {
            try
            {
                MyFundsManager manager = MyFundsManager.SingletonInstance;

                Dictionary<int, string> comboSource = new Dictionary<int, string>();

                comboSource.Add(-1, "Select Detail");

                if (subacctId > 0)
                {
                    foreach (OtherDetail _detail in manager.My_db.OtherDetails.Where(x => x.subacct_id == subacctId).ToList())
                    {
                        int custom_id = int.Parse(5.ToString() + _detail.Id.ToString());
                        comboSource.Add(custom_id, _detail.name);
                    }
                }
                else
                {
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

                    foreach (Shareholder _shareholder in manager.My_db.Shareholders)
                    {
                        int custom_id = int.Parse(6.ToString() + _shareholder.Id.ToString());
                        comboSource.Add(custom_id, _shareholder.name);
                    }

                    foreach (ServiceSupplier _serviceSupplier in manager.My_db.ServiceSuppliers)
                    {
                        int custom_id = int.Parse(7.ToString() + _serviceSupplier.Id.ToString());
                        comboSource.Add(custom_id, _serviceSupplier.name);
                    }

                    foreach (BondsTFAM _bondsTFAM in manager.My_db.BondsTFAMs)
                    {
                        int custom_id = int.Parse(9.ToString() + _bondsTFAM.Id.ToString());
                        comboSource.Add(custom_id, _bondsTFAM.number);
                    }
                }

                return comboSource;
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DataUtils.getOtherDetailsSource: " + _ex.Message);
            }

            return new Dictionary<int, string>();
        }
    }
}
