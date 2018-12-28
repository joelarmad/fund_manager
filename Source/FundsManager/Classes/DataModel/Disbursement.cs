using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundsManager
{
    public partial class Disbursement
    {
        public decimal Euro_collection;

        public string TextClient;

        public string TextUnderlyingDebtor;

        public List<int> ItemsIds = new List<int>();

        public void AddItemId(int itemId)
        {
            if (ItemsIds.Contains(itemId))
                return;

            ItemsIds.Add(itemId);
        }
    }


}
