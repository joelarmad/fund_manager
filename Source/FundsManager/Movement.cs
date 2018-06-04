using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundsManager
{
    public class Movement
    {
        private int account;
        private int subaccount;
        private int detail;
        private int detail_type;
        private Decimal debit;
        private Decimal credit;


        public int Account { get => account; set => account = value; }
        public int Subaccount { get => subaccount; set => subaccount = value; }
        public int Detail { get => detail; set => detail = value; }
        public int Detail_type { get => detail_type; set => detail_type = value; }
        public decimal Debit { get => debit; set => debit = value; }
        public decimal Credit { get => credit; set => credit = value; }
        

        public Movement() {
            account = -1;
            subaccount = -1;
            detail = -1;
            detail_type = -1;
            debit = 0;
            credit = 0;
        }
    }
}
