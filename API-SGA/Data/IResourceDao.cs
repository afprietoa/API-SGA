using API_SGA.Models;

namespace API_SGA.Data
{
    public interface IResourceDao : ICommand<Resource>, IQuery<Resource>
    {
      // public Task<IEnumerable<Resource>> GetAll();
      // public Task<Resource> GetById(int id);
      // public Task Post(Resource resource);
      // public Task Put(Resource resource);
      // public Task Delete(Resource resource);
    }
}
