using API_SGA.Models;

namespace API_SGA.Data
{
    public interface ISignalDao : ICommand<Signal>, IQuery<Signal>
    {
      // public Task<IEnumerable<Signal>> GetAll();
      // public Task<Signal> GetById(int id);
      // public Task Post(Signal signal);
      // public Task Put(Signal signal);
      // public Task Delete(Signal signal);
    }
}
