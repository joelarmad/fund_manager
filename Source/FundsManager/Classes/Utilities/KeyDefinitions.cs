using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundsManager.Classes.Utilities
{
    public static class KeyDefinitions
    {
        public static string BONDTFF_CONSECUTIVE_KEY
        {
            get
            {
                return "BONDTFF_CONSECUTIVE";
            }
        }
        public static string BONDTFAM_CONSECUTIVE_KEY
        {
            get
            {
                return "BONDTFAM_CONSECUTIVE";
            }
        }

        public static string NextAccountMovementReference(int forYear)
        {
            try
            {
                if (forYear.ToString().Length == 4)
                {
                    string reference = "GL" + forYear.ToString().Substring(2);

                    MyFundsManager _manager = MyFundsManager.SingletonInstance;
                    String last_reference = "";

                    try
                    {
                        last_reference = _manager.My_db.AccountingMovements.OrderByDescending(ac => ac.reference).Where(x => x.reference.Substring(0, 4) == reference).First().reference;
                    }
                    catch (Exception e)
                    {
                        e.Source = "First time reference";
                        last_reference = reference + "0000";
                    }

                    last_reference = last_reference.Substring(4);
                    int reference_number = Convert.ToInt32(last_reference) + 1;
                    String new_reference = reference + Convert.ToString(reference_number).PadLeft(4, '0'); ;
                    return new_reference;
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GeneralLedgerForm.MyNewReference: " + _ex.Message);
            }

            return "";
        }
    }
}
