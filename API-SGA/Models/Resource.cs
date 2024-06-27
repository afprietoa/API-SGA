using API_SGA.Models.common;

namespace API_SGA.Models
{
    public class Resource
    {
        public Resource()
        {
            Measures = new List<Measure>();
            Emergencies = new List<Emergency>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ResourceType Type { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Location { get; set;}
        public IList<Measure> Measures { get; set; }
        public IList<Emergency> Emergencies { get; set; }
    }
}
