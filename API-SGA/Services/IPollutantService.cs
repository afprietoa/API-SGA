using API_SGA.Models;

namespace API_SGA.Services
{
    public interface IPollutantService
    {
        Task<IEnumerable<Pollutant>> GetAll();
        Task<Pollutant> GetById(int id);
        Task Post(Pollutant pollutant);
        Task Put(Pollutant pollutant);
        Task Delete(Pollutant pollutant);
    }
}
