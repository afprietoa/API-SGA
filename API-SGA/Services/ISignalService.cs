using API_SGA.Models;

namespace API_SGA.Services
{
    public interface ISignalService
    {
        Task<IEnumerable<Signal>> GetAll();
        Task<Signal> GetById(int id);
        Task Post(Signal signal);
        Task Put(Signal signal);
        Task Delete(Signal signal);
    }
}
