using API_SGA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_SGA.Data.EFCore
{
    public class SignalDao : ISignalDao
    {
        private readonly AppDbContext _context;
        public SignalDao()
        {
            _context = new AppDbContext();
        }


        public async Task<IEnumerable<Signal>> GetAll()
        {
            return await _context.Signals.ToArrayAsync();
        }


        public async Task<Signal> GetById(int id)
        {
            return await _context.Signals.FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task Post(Signal signal)
        {
            await _context.Signals.AddAsync(signal);
            await _context.SaveChangesAsync();
        }


        public async Task Put(Signal signal)
        {
            _context.Signals.Update(signal);
            await _context.SaveChangesAsync();
        }


        public async Task Delete(Signal signal)
        {
            _context.Signals.Remove(signal);
            await _context.SaveChangesAsync();
        }
    }
}
