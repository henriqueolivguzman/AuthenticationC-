namespace Presentation.Models
{
    public class Engine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }
    }
}
