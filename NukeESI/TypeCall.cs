using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeESI
{
    public class TypeCall
    {
        public float capacity { get; set; }
        public string description { get; set; }
        public int dogma_attributes { get; set; } // #Change type
        public int dogma_effects { get; set; } // #Change type
        public int graphic_id { get; set; }
        public int group_id { get; set; }
        public int icon_id { get; set; }
        public int market_group_id { get; set; }
        public float mass { get; set; }
        public string name { get; set; }
        public float packaged_volume { get; set; }
        public int portion_size { get; set; }
        public bool published { get; set; }
        public float radius { get; set; }
        public int type_id { get; set; }
        public float volume { get; set; }

        public TypeCall()
        {
        }
    }
}
