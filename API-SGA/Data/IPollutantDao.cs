using API_SGA.Models;

namespace API_SGA.Data
{
    public interface IPollutantDao : ICommand<Pollutant>, IQuery<Pollutant>
    {
      // public Task<IEnumerable<Pollutant>> GetAll();
      // public Task<Pollutant> GetById(int id);
      // public Task Post(Pollutant pollutant);
      // public Task Put(Pollutant pollutant);
      // public Task Delete(Pollutant pollutant);
    }
}
