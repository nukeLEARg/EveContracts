using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeContracts.Business.Models.Items
{
    public class Type
    {
        public decimal Capacity { get; set; }
        public string Description { get; set; }
        public Dogma_attributes Dogma_Attributes { get; set; }
        public Dogma_effects Dogma_Effects { get; set; }
        public int Graphic_id { get; set; }
        public int Group_id { get; set; }
        public int Icon_id { get; set; }
        public int Market_group_id { get; set; }
        public decimal Mass { get; set; }
        public string Name { get; set; }
        public decimal Packaged_volume { get; set; }
        public int Portion_size { get; set; }
        public bool Published { get; set; }
        public decimal Radius { get; set; }
        public int Type_id {get; set;}
        public decimal Volume { get; set; }
    }
}
