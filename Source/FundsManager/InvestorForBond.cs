using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundsManager
{
    class InvestorForBond
    {
        private int id;
        private float pieces;

        public int Id { get => id; set => id = value; }
        public float Pieces { get => pieces; set => pieces = value; }

        public InvestorForBond()
        {
            id = -1;
            pieces = -1;
        }
    }
}
