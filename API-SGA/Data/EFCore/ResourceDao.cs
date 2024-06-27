using API_SGA.Models;
using Microsoft.EntityFrameworkCore;

namespace API_SGA.Data.EFCore
{
    public class ResourceDao: IResourceDao
    {
        private readonly AppDbContext _context;
        public ResourceDao()
        {
            _context = new AppDbContext();
        }

        public async Task<IEnumerable<Resource>> GetAll()
        {
            return await _context.Resources
                                 .Include(r => r.Measures)
                                 .Include(r => r.Emergencies)
                                 .ToListAsync();
        }


        public async Task<Resource> GetById(int id)
        {
            return await _context.Resources
                                         .Include(r => r.Measures)
                                         .Include(r => r.Emergencies)
                                         .FirstOrDefaultAsync(c => c.Id == id);

        }


        public async Task Post(Resource resource)
        {

            await _context.Resources.AddAsync(resource);
            await _context.Measures.AddRangeAsync(resource.Measures);
            await _context.Emergencies.AddRangeAsync(resource.Emergencies);

            await _context.SaveChangesAsync();
        }


        public async Task Put(Resource resource)
        {

            var exisgingResource = await _context.Resources
                                         .Include(r => r.Measures)
                                         .Include(r => r.Emergencies)
                                         .FirstOrDefaultAsync(c => c.Id == resource.Id);

            exisgingResource.Name = resource.Name;
            exisgingResource.Type = resource.Type;
            exisgingResource.Latitude = resource.Latitude;
            exisgingResource.Longitude = resource.Longitude;
            exisgingResource.Location = resource.Location;

            _context.Measures.RemoveRange(exisgingResource.Measures);
            _context.Emergencies.RemoveRange(exisgingResource.Emergencies);

            _context.Resources.Update(exisgingResource);

            _context.Measures.AddRange(resource.Measures);
            _context.Emergencies.AddRange(resource.Emergencies);

            await _context.SaveChangesAsync();
        }


        public async Task Delete(Resource resource)
        {

            var exisgingResource = await _context.Resources
                             .Include(r => r.Measures)
                             .Include(r => r.Emergencies)
                             .FirstOrDefaultAsync(c => c.Id == resource.Id);


            _context.Measures.RemoveRange(exisgingResource.Measures);
            _context.Emergencies.RemoveRange(exisgingResource.Emergencies);


            _context.Resources.Remove(exisgingResource);
            await _context.SaveChangesAsync();
        }
    }
}
