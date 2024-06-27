using API_SGA.Models;

namespace API_SGA.Data
{
    public interface IMeasureDao : ICommand<Measure>, IQuery<Measure>
    {
      // public Task<IEnumerable<Measure>> GetAll();
      // public Task<Measure> GetById(int id);
      // public Task Post(Measure measure);
      // public Task Put(Measure measure);
      // public Task Delete(Measure measure);
    }
}
