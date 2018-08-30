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
        public List<Contract> Contracts;

        public JitaExchange()
        {
            this.Contracts = new List<Contract>();
        }

        public void Pull()
        {
            NukeESI.ESIClass esi = new ESIClass();
            List<ContractCall> call = esi.GetContracts("10000009");
            for (int i = 0; i < call.Count; i++)
            {
                if (call.ElementAt(i).type.Equals("item_exchange"))
                {
                    Contract hold = new Contract(call.ElementAt(i));
                    Contracts.Add(hold);
                }
            }
        }
    }
}
