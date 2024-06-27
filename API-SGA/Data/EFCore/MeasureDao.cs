using API_SGA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_SGA.Data.EFCore
{
    public class MeasureDao : IMeasureDao
    {
        private readonly AppDbContext _context;

        public MeasureDao(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Measure>> GetAll()
        {
            return await _context.Measures.ToArrayAsync();
        }

        public async Task<Measure> GetById(int id)
        {
            return await _context.Measures.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Post(Measure measure)
        {
            await _context.Measures.AddAsync(measure);
            await _context.SaveChangesAsync();
        }

        public async Task Put(Measure measure)
        {
            _context.Measures.Update(measure);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Measure measure)
        {
            _context.Measures.Remove(measure);
            await _context.SaveChangesAsync();
        }


    }
}
