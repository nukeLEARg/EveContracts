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
    }
}
