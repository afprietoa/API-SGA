using API_SGA.Models;

namespace API_SGA.Services
{
    public interface IEmergencyService
    {
        Task<IEnumerable<Emergency>> GetAll();
        Task<Emergency> GetById(int id);
        Task Post(Emergency emergency);
        Task Put(Emergency emergency);
        Task Delete(Emergency emergency);
    }
}
