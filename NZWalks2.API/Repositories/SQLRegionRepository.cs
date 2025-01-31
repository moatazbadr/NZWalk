using Microsoft.EntityFrameworkCore;
using NZWalks2.API.Data;
using NZWalks2.API.Models.Domain;

namespace NZWalks2.API.Repositories
{
    public class SQLRegionRepository : IRegionRepositry
    {
        private readonly NZWalksDbContext _context;

        public SQLRegionRepository(NZWalksDbContext context) { 
            _context = context;
        }


        public async Task<List<Region>> GetAllRegionsAsync()
        {
            return await _context.Set<Region>().ToListAsync();
        }

        public async Task<Region?> GetByidAsync(Guid id)
        {
            return await _context.Set<Region>().FirstOrDefaultAsync(x => x.Id == id);   
            
        }

       public async Task<Region> CreateRegionAsync(Region region)
        {
            await _context.Set<Region>().AddAsync(region);
            await _context.SaveChangesAsync();
            return region;

        }

        public async  Task<Region?> UpdateRegionAsync(Guid id, Region region)
        {
            var ExistingRegion = await _context.Set<Region>().FirstOrDefaultAsync(x => x.Id == id);
            if (ExistingRegion == null) { 
            return null;
            
            }
            ExistingRegion.Code = region.Code;
            ExistingRegion.Name = region.Name;
            ExistingRegion.RegionImgUrl = region.RegionImgUrl;

            await _context.SaveChangesAsync();

            return ExistingRegion;

        }

        public async Task<Region?> DeleteRegionAsync(Guid id)
        {
            var ExistingRegion= _context.Set<Region>().FirstOrDefault(x => x.Id == id);
            if (ExistingRegion == null) {
                return null;
            }

            _context.Remove(ExistingRegion);
            await _context.SaveChangesAsync();
            
             return ExistingRegion;


        }
    }
}
