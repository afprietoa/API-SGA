using API_SGA.Models;
using Microsoft.EntityFrameworkCore;

namespace API_SGA.Data.EFCore
{
    public class PollutantDao : IPollutantDao
    {
        private readonly AppDbContext _context;
        public PollutantDao()
        {
            _context = new AppDbContext();
        }

        public async Task<IEnumerable<Pollutant>> GetAll()
        {
            return await _context.Pollutants
                                 .Include(r => r.Measures)
                                 .Include(r => r.Emergencies)
                                 .ToListAsync();
        }

        public async Task<Pollutant> GetById(int id)
        {
            return await _context.Pollutants
                                         .Include(r => r.Measures)
                                         .Include(r => r.Emergencies)
                                         .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Post(Pollutant pollutant)
        {
            await _context.Pollutants.AddAsync(pollutant);
            await _context.Measures.AddRangeAsync(pollutant.Measures);
            await _context.Emergencies.AddRangeAsync(pollutant.Emergencies);

            await _context.SaveChangesAsync();
        }

        public async Task Put(Pollutant pollutant)
        {


            var exisgingPollutant = await _context.Pollutants
                                         .Include(r => r.Measures)
                                         .Include(r => r.Emergencies)
                                         .FirstOrDefaultAsync(c => c.Id == pollutant.Id);


            exisgingPollutant.Name = pollutant.Name;
            exisgingPollutant.Load = pollutant.Load;

            _context.Measures.RemoveRange(exisgingPollutant.Measures);
            _context.Emergencies.RemoveRange(exisgingPollutant.Emergencies);

            _context.Pollutants.Update(exisgingPollutant);

            _context.Measures.AddRange(pollutant.Measures);
            _context.Emergencies.AddRange(pollutant.Emergencies);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Pollutant pollutant)
        {

            var exisgingPollutant = await _context.Resources
                             .Include(r => r.Measures)
                             .Include(r => r.Emergencies)
                             .FirstOrDefaultAsync(c => c.Id == pollutant.Id);

            _context.Measures.RemoveRange(exisgingPollutant.Measures);
            _context.Emergencies.RemoveRange(exisgingPollutant.Emergencies);


            _context.Resources.Remove(exisgingPollutant);
            await _context.SaveChangesAsync();
        }
    }


}
