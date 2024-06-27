using API_SGA.Models;

namespace API_SGA.Services
{
    public interface IResourceService
    {
        Task<IEnumerable<Resource>> GetAll();
        Task<Resource> GetById(int id);
        Task Post(Resource resource);
        Task Put(Resource resource);
        Task Delete(Resource resource);
    }
}
