using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundsManager
{
    public partial class Account
    {
        public static bool leftAccountingIncrement(int accountType)
        {
            return (accountType == 0 || accountType == 4 || accountType == 5 || accountType == 7 || accountType == 8 || accountType == 9);
        }
    }
}
