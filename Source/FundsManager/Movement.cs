using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundsManager
{
    public class Movement
    {
        private int id;
        private int account;
        private int subaccount;
        private int detail;
        private int detail_type;
        private Decimal debit;
        private Decimal credit;
        private Decimal accountBalance;
        private Decimal subAccountBalance;


        public int Id { get => id; set => id = value; }
        public int Account { get => account; set => account = value; }
        public int Subaccount { get => subaccount; set => subaccount = value; }
        public int Detail { get => detail; set => detail = value; }
        public int Detail_type { get => detail_type; set => detail_type = value; }
        public decimal Debit { get => debit; set => debit = value; }
        public decimal Credit { get => credit; set => credit = value; }
        public decimal AccountBalance { get => accountBalance; set => accountBalance = value; }
        public decimal SubAccountBalance { get => subAccountBalance; set => subAccountBalance = value; }


        public Movement() {
            id = -1;
            account = -1;
            subaccount = -1;
            detail = -1;
            detail_type = -1;
            debit = 0;
            credit = 0;
        }
    }
}
