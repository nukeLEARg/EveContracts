namespace NukeContracts.Business.Models.Universe
{
    public class Station
    {
        public int StationId { get; set; }
        public string Name { get; set; }
        public int Owner { get; set; }
        public int TypeId { get; set; }
        public int RaceId { get; set; }
        public Position Position { get; set; }
        public int SystemId { get; set; }
        public decimal ReprocessingEfficiency { get; set; }
        public decimal ReprocessingStationsTake { get; set; }
        public decimal MaxDockableShipVolume { get; set; }
        public decimal OfficeRentalCost { get; set; }
        public string[] Services { get; set; }
    }
}
