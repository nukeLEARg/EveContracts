﻿using System;
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
        
        public Contract(ContractCall call)
        {
            info = call;
            buildContract(call);
        }

        private async void buildContract(ContractCall call)
        {
            NukeESI.ESIClass esi = new ESIClass();
            List<ContractContents> contents = await esi.pullContract(call.contract_id);
            this.contents = contents;
        }
    }
}
