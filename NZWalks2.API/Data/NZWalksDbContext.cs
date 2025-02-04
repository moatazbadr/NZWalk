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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Seeding Difficulties Data

            //seed Data for the Difficulties
            var difficulties = new List<Difficulty>() {
            new Difficulty()
            {
                Id=Guid.Parse ("a9d76f8b-8c1d-460f-bee2-15f66a01b935") ,
                Name="Easy"
            },
            new Difficulty()
            {
                Id=Guid.Parse("f58c0961-78ff-4409-98c1-78eebd6711af"),
                Name="Medium"
            },
            new Difficulty()
            {
                Id=Guid.Parse("6b2f0073-e323-4f68-a877-82df278f9d52"),
                Name="Hard"
            }
            };

            //seed Difficulties into the database 
            modelBuilder.Entity<Difficulty>().HasData(difficulties);
            #endregion

            #region Seeding Regions Data
            
            var Regions = new List<Region>() { 
            new Region()
            {
                Id= Guid.Parse("ef78a392-052f-4e97-8a91-749661fddfea"),
                Name="DownTown cairo",
                Code="DTC",
                RegionImgUrl="https://assets.nst.com.my/images/articles/cairo1_1554178412.jpg"
            },
            new Region()
            {
                Id=Guid.Parse("adcc7a33-c9af-4170-ae95-bdbe84997bed"),
                Name="Maadi",
                Code="MD",
                RegionImgUrl="https://i.pinimg.com/originals/5e/3e/52/5e3e523305335dcb1bbe62197aa9e992.jpg"
            },
            new Region()
            {
                Id=Guid.Parse("b9bd929c-ef15-4da9-8442-ff222663b976"),
                Name="Zamalek",
                Code="ZM",
                RegionImgUrl="https://2.bp.blogspot.com/-xsxTSZLgKag/UMGdtlTX5EI/AAAAAAAAACA/svGNjqTNEtQ/s1600/IMG_0629.JPG"
            },
            new Region()
            {
                Id=Guid.Parse("3dcff596-fc30-41b9-a41b-1f09be94609e"),
                Name="Fifth Settlement",
                Code="5TH",
                RegionImgUrl="https://realogy.co/images/upload/154046762.png"
            },
            new Region()
            {
                Id=Guid.Parse("c6877914-d178-4be0-9042-128d90ce58c1"),
                Name="Madinaty",
                Code="TMG",
                RegionImgUrl="https://th.bing.com/th/id/OIP.yf37VeOe1ka70Q5F0tLs-wHaEo?rs=1&pid=ImgDetMain"
            }

            };
            modelBuilder.Entity<Region>().HasData(Regions);

            #endregion

        }


    }
}
