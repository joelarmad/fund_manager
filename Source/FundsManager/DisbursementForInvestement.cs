using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundsManager
{
    class DisbursementForInvestement
    {
        DateTime date;
        Decimal amount;
        Decimal profit;
        Decimal exchange;
        Decimal euro_collection;
        int currency;
        int client;
        int underlying_debtor;
        int bank;
        int sector;
        List<int> items;

        public DisbursementForInvestement()
        {
            amount = 0;
            profit = 0;
            exchange = 0;
            euro_collection = 0;
            currency = -1;
            client = -1;
            underlying_debtor = -1;
            bank = -1;
            sector = -1;
            items = new List<int>();
            date = new DateTime();
        }

        public decimal Amount { get => amount; set => amount = value; }
        public decimal Profit { get => profit; set => profit = value; }
        public decimal Exchange { get => exchange; set => exchange = value; }
        public int Currency { get => currency; set => currency = value; }
        public int Client { get => client; set => client = value; }
        public int Underlying_debtor { get => underlying_debtor; set => underlying_debtor = value; }
        public int Bank { get => bank; set => bank = value; }
        public int Sector { get => sector; set => sector = value; }
        public List<int> Items { get => items; set => items = value; }
        public DateTime Date { get => date; set => date = value; }
        public decimal Euro_collection { get => euro_collection; set => euro_collection = value; }
    }
}
