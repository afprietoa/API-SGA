using API_SGA.Data;
using API_SGA.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_SGA.Services.Handlers
{
    public class EmergencyService : IEmergencyService
    {
        IEmergencyDao _dao;

        public EmergencyService(IEmergencyDao dao)
        {
            _dao = dao;
        }

        async Task<IEnumerable<Emergency>> IEmergencyService.GetAll()
        {
            return await _dao.GetAll();
        }

        async Task<Emergency> IEmergencyService.GetById(int id)
        {
            return await _dao.GetById(id);
        }


        async Task IEmergencyService.Post(Emergency emergency)
        {
            await _dao.Post(emergency);;
        }

        async Task IEmergencyService.Put(Emergency emergency)
        {
            await _dao.Put(emergency);
        }

        async Task IEmergencyService.Delete(Emergency emergency)
        {
            await _dao.Delete(emergency);
        }

    }
}
