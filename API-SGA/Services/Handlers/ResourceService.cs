using API_SGA.Data;
using API_SGA.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_SGA.Services.Handlers
{
    public class ResourceService : IResourceService
    {
        IResourceDao _dao;

        public ResourceService(IResourceDao dao)
        {
            _dao = dao;
        }

        async Task<IEnumerable<Resource>> IResourceService.GetAll()
        {
            return await _dao.GetAll();
        }

        async Task<Resource> IResourceService.GetById(int id)
        {
            return await _dao.GetById(id);
        }

        async Task IResourceService.Post(Resource resource)
        {
            await _dao.Post(resource);
        }

        async Task IResourceService.Put(Resource resource)
        {
            await _dao.Put(resource);
        }

        async Task IResourceService.Delete(Resource resource)
        {
            await _dao.Delete(resource);
        }
    }
}
