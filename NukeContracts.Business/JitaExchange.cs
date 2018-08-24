using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NukeESI;

namespace NukeContracts.Business
{
    public class JitaExchange
    {
        public string header { get; set; }
        public string content { get; set; }
        public List<Contract> Contracts { get; set; }

        public JitaExchange()
        {
        }

        public void Pull()
        {
            NukeESI.ESIClass esi = new ESIClass();
            List<ContractCall> call = esi.GetContracts("10000002");
            header += esi.header;
            for (int i = 0; i < 100; i++)
            {
                if (call.ElementAt(i).type.Equals("item_exchange"))
                    Contracts.Add(new Contract(call.ElementAt(i)));
                    content += call.ElementAt(i).ToString();
            }
        }        
    }
}
