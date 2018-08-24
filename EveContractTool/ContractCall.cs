using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveContractTool
{
    public class ContractCall
    {
        public string buyout { get; set; }
        public string collateral { get; set; }
        public string contract_id { get; set; }
        public string date_expired { get; set; }
        public string date_issued { get; set; }
        public string days_to_complete { get; set; }
        public string end_location_id { get; set; }
        public string for_corporation { get; set; }
        public string issuer_corporation_id { get; set; }
        public string issuer_id { get; set; }
        public string price { get; set; }
        public string reward { get; set; }
        public string start_location_id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string volume { get; set; }

        public void buildContract()
        {


        }

        public override string ToString()
        {
            return " buyout:" + buyout + " collateral:" + collateral + " contract_id:" + contract_id + " date_expired:" + date_expired + " date_issued:" + date_issued + " days_to_complete:" + 
                days_to_complete + " end_location_id:" + end_location_id + " for_corporation:" + for_corporation + " issuer_corporation_id:" + issuer_corporation_id + " issuer_id:" + issuer_id
                + " price:" + price + " reward:" + reward + " start_location_id:" + start_location_id + " title:" + title + " type:" + type + " volume:" + volume;
        }
    }
}
