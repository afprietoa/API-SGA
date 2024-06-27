namespace API_SGA.Models
{
    public class Pollutant
    {
        public Pollutant()
        {
            Measures = new List<Measure>();
            Emergencies = new List<Emergency>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public float Load { get; set; }
        public IList<Measure> Measures { get; set; }
        public IList<Emergency> Emergencies { get; set; }
    }
}
