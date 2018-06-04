using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundsManager
{
    public partial class Account
    {

    public Decimal CalculateBalance(Decimal _debit = 0, Decimal _credit = 0) {

            if (type == 0 || type == 4 || type == 5)
                return amount + _debit - _credit;

            else if (type == 1 || type == 2 || type == 3 || type == 6)
                return amount - _debit + _credit;

            return amount;
        }
    }
}
