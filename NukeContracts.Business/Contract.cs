using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NukeESI;

namespace NukeContracts.Business
{
    public class Contract
    {
        public List<ContractContents> contents { get; set; }
        public ContractCall info { get; set; }
        public ESIStructure station { get; set; }
        public int index { get; set; }

        public Contract(ContractCall call,int i)
        {
            info = call;
            index = i;
        }

        public async Task buildContract(ContractCall call)
        {
            NukeESI.ESIClass esi = new ESIClass();
            List<ContractContents> contents = await esi.pullContract(call.contract_id).ConfigureAwait(false);
            this.contents = contents;
        }

        public async Task resolveStructure(ContractCall call)
        {
            NukeESI.ESIClass esi = new ESIClass();
            ESIStructure stat = await esi.pullStructure(call.start_location_id).ConfigureAwait(false);
            station = stat;
        }
    }
}
