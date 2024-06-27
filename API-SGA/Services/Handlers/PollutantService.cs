using API_SGA.Data;
using API_SGA.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_SGA.Services.Handlers
{
    public class PollutantService : IPollutantService
    {
        IPollutantDao _dao;

        public PollutantService(IPollutantDao dao)
        {
            _dao = dao;
        }

        async Task<IEnumerable<Pollutant>> IPollutantService.GetAll()
        {
            return await _dao.GetAll();
        }

        async Task<Pollutant> IPollutantService.GetById(int id)
        {
            return await _dao.GetById(id);
        }

        async Task IPollutantService.Post(Pollutant pollutant)
        {
            await _dao.Post(pollutant);
        }

        async Task IPollutantService.Put(Pollutant pollutant)
        {
            await _dao.Put(pollutant);
        }

        async Task IPollutantService.Delete(Pollutant pollutant)
        {
            await _dao.Delete(pollutant);
        }
    }
}
