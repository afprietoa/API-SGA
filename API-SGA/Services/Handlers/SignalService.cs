using API_SGA.Data;
using API_SGA.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_SGA.Services.Handlers
{
    public class SignalService : ISignalService
    {

        ISignalDao _dao;

        public SignalService(ISignalDao dao)
        {
            _dao = dao;
        }

        async Task<IEnumerable<Signal>> ISignalService.GetAll()
        {
            return await _dao.GetAll();
        }

        async Task<Signal> ISignalService.GetById(int id)
        {
            return await _dao.GetById(id);
        }

        async Task ISignalService.Post(Signal signal)
        {
            await _dao.Post(signal);
        }

        async Task ISignalService.Put(Signal signal)
        {
            await _dao.Put(signal);
        }
        async Task ISignalService.Delete(Signal signal)
        {
            await _dao.Delete(signal);
        }
    }
}
