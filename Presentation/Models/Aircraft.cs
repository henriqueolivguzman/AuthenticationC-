namespace Presentation.Models
{
    public class Aircraft
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Engine> Engines { get; set; }
    }
}
