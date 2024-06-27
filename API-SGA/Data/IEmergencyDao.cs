using API_SGA.Models;

namespace API_SGA.Data
{
    public interface IEmergencyDao : ICommand<Emergency>, IQuery<Emergency>
    {
      // public Task<IEnumerable<Emergency>> GetAll();
      // public Task<Emergency> GetById(int id);
      // public Task Post(Emergency emergency);
      // public Task Put(Emergency emergency);
      // public Task Delete(Emergency emergency);
    }
}
