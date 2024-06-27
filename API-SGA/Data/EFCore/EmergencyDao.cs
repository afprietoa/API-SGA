using API_SGA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_SGA.Data.EFCore
{
    public class EmergencyDao : IEmergencyDao
    {
        private readonly AppDbContext _context;

        public EmergencyDao(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Emergency>> GetAll()
        {
            return await _context.Emergencies.ToArrayAsync();
        }

        public async Task<Emergency> GetById(int id)
        {
            return await _context.Emergencies.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Post(Emergency emergency)
        {
            await _context.Emergencies.AddAsync(emergency);
            await _context.SaveChangesAsync();
        }

        public async Task Put(Emergency emergency)
        {
            _context.Emergencies.Update(emergency);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Emergency emergency)
        {
            _context.Emergencies.Remove(emergency);
            await _context.SaveChangesAsync();
        }

    }
}
