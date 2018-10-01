namespace NukeContracts.Business.Models.Contracts
{
    public class ContractItem
    {
        public long RecordId { get; set; }
        public int TypeId { get; set; }
        public int Quantity { get; set; }
        public int RawQuantity { get; set; }
        public bool IsSingleton { get; set; }
        public bool IsIncluded { get; set; }
        public bool IsBlueprintCopy { get; set; }
        public long ItemId { get; set; }
        public int MaterialEfficiency { get; set; }
        public int Runs { get; set; }
        public int TimeEfficiency { get; set; }
    }
}
