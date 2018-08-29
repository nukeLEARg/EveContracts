﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeContracts.Business
{
    public class Item
    {
        public int type_id { get; set; }
        public string item_name { get; set; }

        public Item(string id, string name)
        {
            int x;
            bool parsed = Int32.TryParse(id, out x);
            type_id = x;
            item_name = name;
        }
    }
}
