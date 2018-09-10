using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeESI
{
    public class ContractCall
    {
        public double buyout { get; set; }
        public double collateral { get; set; }
        public int contract_id { get; set; }
        public string date_expired { get; set; }
        public string date_issued { get; set; }
        public int days_to_complete { get; set; }
        public long end_location_id { get; set; }
        public bool for_corporation { get; set; }
        public int issuer_corporation_id { get; set; }
        public int issuer_id { get; set; }
        public double price { get; set; }
        public double reward { get; set; }
        public long start_location_id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public double volume { get; set; }

        public ContractCall()
        {
        }
        
        public override string ToString()
        {
            return "buyout:" + buyout + " collateral:" + collateral + " contract_id:" + contract_id + " date_expired:" + date_expired + " date_issued:" + date_issued + " days_to_complete:" + 
                days_to_complete + " end_location_id:" + end_location_id + " for_corporation:" + for_corporation + " issuer_corporation_id:" + issuer_corporation_id + " issuer_id:" + issuer_id
                + " price:" + price + " reward:" + reward + " start_location_id:" + start_location_id + " title:" + title + " type:" + type + " volume:" + volume;
        }
    }
}
