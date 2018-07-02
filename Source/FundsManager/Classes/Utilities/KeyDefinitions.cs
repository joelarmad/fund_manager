using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundsManager.Classes.Utilities
{
    public static class KeyDefinitions
    {
        public static string BOND_CONSECUTIVE_KEY
        {
            get
            {
                return "BOND_CONSECUTIVE";
            }
        }

        public static string NextAccountMovementReference
        {
            get
            {
                try
                {
                    MyFundsManager _manager = MyFundsManager.SingletonInstance;

                    DateTime moment = DateTime.Today;
                    String last_reference = "";

                    try
                    {
                        last_reference = _manager.My_db.AccountingMovements.OrderByDescending(ac => ac.Id).First().reference;
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
                catch (Exception _ex)
                {
                    Console.WriteLine("Error in GeneralLedgerForm.MyNewReference: " + _ex.Message);
                    return "";
                }
            }
        }
    }
}
