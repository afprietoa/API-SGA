using API_SGA.Models.common;

namespace API_SGA.Models
{
    public class Emergency
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public EmergencyMagnitude Magnitude { get; set; }
        public DateTime Date { get; set; }
        public int PollutantId { get; set; }
        public int ResourceId { get; set; }
    }
}
