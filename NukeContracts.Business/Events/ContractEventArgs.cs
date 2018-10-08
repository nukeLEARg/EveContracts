using System;

namespace NukeContracts.Business.Events
{
    public class ContractEventArgs : EventArgs
    {
        public int ContractId { get; set; }
        public int LoadingContractsAmmount { get; set; }
    }
}
