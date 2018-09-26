using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeESI
{
    public class ESIStructure
    {
        public float max_dockable_ship_volume { get; set; }
        public string name { get; set; }
        public float office_rental_cost { get; set; }
        public int owner { get; set; }
       // public int position { get; set; }
        public int race_id { get; set; }
        public float reprocessing_efficiency { get; set; }
        public float reprocessing_stations_take { get; set; }
       // public string[] services { get; set; }
        public int station_id { get; set; }
        public int type_id { get; set; }

        public ESIStructure()
        {
        }
    }
}
