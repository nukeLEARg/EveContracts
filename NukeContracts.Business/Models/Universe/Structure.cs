namespace NukeContracts.Business.Models.Universe
{
    public class Structure
    {
        public string Name { get; set; }
        public int SolarSystemId { get; set; }
        public int TypeId { get; set; }
        public Position Position { get; set; }
    }
}
