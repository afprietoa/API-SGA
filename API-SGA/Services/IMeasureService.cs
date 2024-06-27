using API_SGA.Models;

namespace API_SGA.Services
{
    public interface IMeasureService
    {
        Task<IEnumerable<Measure>> GetAll();
        Task<Measure> GetById(int id);
        Task Post(Measure measure);
        Task Put(Measure measure);
        Task Delete(Measure measure);
    }
}
