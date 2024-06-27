using API_SGA.Models.common;

namespace API_SGA.Models
{
    public class Signal
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public SignalLevel Level { get; set; }
        public string Message { get; set; }
        public int EmergencyId { get; set; }
        public Emergency Emergency { get; set; }
    }
}
