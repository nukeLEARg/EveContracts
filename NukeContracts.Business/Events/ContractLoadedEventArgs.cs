using System;

namespace NukeContracts.Business.Events
{
    public class ContractLoadedEventArgs : EventArgs
    {
        public int ContractId { get; set; }
    }
}
