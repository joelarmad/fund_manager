using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FundsManager.Classes.Utilities
{
    public class ErrorMessage
    {

        public static void showErrorMessage(Exception ex)
        {
            MyFundsManager.SingletonInstance.Reset();

            string msg = ex.Message + "\r";

            Exception inner = ex.InnerException;

            while (inner != null)
            {
                msg += inner.Message;
                msg += "\r";
                inner = inner.InnerException;
            }

            MessageBox.Show("Error: " + msg);
        }

    }
}
