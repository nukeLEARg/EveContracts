using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeContracts.Business
{
    public class Item
    {
        public long item_id { get; set; }
        public string item_name { get; set; }

        public Item(string id, string name)
        {
            long x;
            bool parsed = Int64.TryParse(id, out x);
            item_id = x;
            item_name = name;
        }
    }
}
