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
        public List<TypeCall> typeInfo { get; set; } = new List<TypeCall>();
        public int index { get; set; }

        public Contract(ContractCall call,int i)
        {
            info = call;
            index = i;
        }

        public async void buildContract()
        {
            await resolveContents(info);
            await resolveStructure(info);
        }
        

        private async Task resolveContents(ContractCall call)
        {
            NukeESI.ESIClass esi = new ESIClass();
            List<ContractContents> contents = await esi.pullContract(call.contract_id).ConfigureAwait(false);
            this.contents = contents;
            await resolveTypes(contents);
        }

        private async Task resolveStructure(ContractCall call)
        {
            NukeESI.ESIClass esi = new ESIClass();
            ESIStructure stat = await esi.pullStructure(call.start_location_id).ConfigureAwait(false);
            station = stat;
        }

        private async Task resolveTypes(List<ContractContents> items)
        {
            ESIClass esi = new ESIClass();
            await Task.Run(() =>
            {
                foreach (ContractContents item in items)
                {
                    TypeCall info = esi.pullTypeInfo(item.type_id);
                    typeInfo.Add(info);
                }
            });
        }
    }
}
