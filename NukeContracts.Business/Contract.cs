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
        public List<TypeCall> typeInfo {get ; set;}
        public List<Task> genTasks { get; set; }
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
            resolveStructure(call);
            //typeGen(contents);
        }

        private async void resolveStructure(ContractCall call)
        {
            NukeESI.ESIClass esi = new ESIClass();
            ESIStructure stat = await esi.pullStructure(call.start_location_id).ConfigureAwait(false);
            station = stat;
        }

        private async void typeGen(List<ContractContents> items)
        {
            if (items != null)
            {
                ESIClass esi = new ESIClass();
                foreach (ContractContents item in items)
                    typeInfo.Add(await esi.pullTypeInfo(item.type_id));
            }
        }
    }
}
