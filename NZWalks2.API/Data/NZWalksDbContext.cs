using Microsoft.EntityFrameworkCore;
using NZWalks2.API.Models.Domain;

namespace NZWalks2.API.Data
{
    public class NZWalksDbContext:DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContext) :base(dbContext) 
        {


            
        }


        #region DbSets
        public DbSet<Walk> Walk { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet <Region> regions { get; set; }
        #endregion

    }
}
