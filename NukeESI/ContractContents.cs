using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeESI
{
    public class ContractContents
    {
        public bool is_blueprint_copy { get; set; }
        public bool is_included { get; set; }
        public int item_id { get; set; }
        public int material_efficiency { get; set; }
        public int quantity { get; set; }
        public int record_id { get; set; }
        public int runs { get; set; }
        public int time_efficiency { get; set; }
        public int type_id { get; set; }

        public ContractContents()
        {
        }

        public override string ToString()
        {
            return "is_blueprint_copy:" + is_blueprint_copy + " is_included:" + is_included + " item_id:" + item_id + " material_efficiency:" + material_efficiency + " quantity:" + quantity +
                " record_id:" + record_id + " runs:" + runs + " time_efficiency:" + time_efficiency + " type_id:" + type_id;
        }
    }
}
