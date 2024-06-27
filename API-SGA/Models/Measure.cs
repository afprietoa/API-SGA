namespace API_SGA.Models
{
    public class Measure
    {

        public int Id { get; set; }
        public DateTime date { get; set; }  
        public float Ph {  get; set; }
        public float Temperature { get; set; }
        public int PollutantId { get; set; }
        public int ResourceId { get; set; }

    }
}
