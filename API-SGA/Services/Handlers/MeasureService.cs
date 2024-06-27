using API_SGA.Data;
using API_SGA.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_SGA.Services.Handlers
{
    public class MeasureService : IMeasureService
    {
        IMeasureDao _dao;

        public MeasureService(IMeasureDao dao)
        {
            _dao = dao;
        }

        async Task<IEnumerable<Measure>> IMeasureService.GetAll()
        {
            return await _dao.GetAll();
        }

        async Task<Measure> IMeasureService.GetById(int id)
        {
            return await _dao.GetById(id);
        }

        async Task IMeasureService.Post(Measure measure)
        {
            await _dao.Post(measure);
        }

        async Task IMeasureService.Put(Measure measure)
        {
            await _dao.Put(measure);
        }

        async Task IMeasureService.Delete(Measure measure)
        {
            await _dao.Delete(measure);
        }
    }
}
