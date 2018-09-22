using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NukeESI;

namespace NukeContracts.Business
{
    public class ContractExchange
    {
        public List<Contract>[] Contracts;
        private int region;
        public int pages = 0;
        public int contracttotal = 0;
        public ContractExchange(int region_id)
        {
            Contracts = new List<Contract>[67];
            for(int i = 0; i < 67; i++)
            {
                Contracts[i] = new List<Contract>();
            }
            region = region_id;
        }

        public void Pull()
        {
            NukeESI.ESIClass esi = new ESIClass();
            List<ContractCall> call = esi.GetContracts($"{region}");
            pages = esi.XPages;
            contracttotal = call.Count;
            for (int i = 0; i < call.Count; i++)
            {
                Contract hold = new Contract(call.ElementAt(i));
                if (hold.contents != null)
                    Contracts[region - 10000000].Add(hold);
            }
        }
    }
}
