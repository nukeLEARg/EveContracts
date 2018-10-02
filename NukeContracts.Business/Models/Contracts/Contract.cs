using NukeContracts.Business.Models.Universe;
using System;
using System.Collections.Generic;

namespace NukeContracts.Business.Models.Contracts
{
    public class Contract
    {
        public int ContractId { get; set; }
        public int IssuerId { get; set; }
        public int IssuerCorporationId { get; set; }
        public int AssigneeId { get; set; }
        public int AcceptorId { get; set; }
        public long StartLocationId { get; set; }
        public long EndLocationId { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
        public bool ForCorporation { get; set; }
        public string Availability { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DateExpired { get; set; }
        public DateTime DateAccepted { get; set; }
        public int DaysToComplete { get; set; }
        public DateTime DateCompleted { get; set; }
        public decimal Price { get; set; }
        public decimal Reward { get; set; }
        public decimal Collateral { get; set; }
        public decimal Buyout { get; set; }
        public decimal Volume { get; set; }
        public List<ContractItem> Items { get; set; } = new List<ContractItem>();
        public Structure Structure { get; set; } //temp?
        public Station Station { get; set; } //temp?
    }
}
