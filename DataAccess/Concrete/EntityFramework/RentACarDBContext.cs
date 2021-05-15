using Entities.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Concrete.EntityFramework
{
    public class RentACarDBContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=RentACar; Trusted_Connection=true");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{   //Entity yi DB deki başka bir tabloya manual bağlamak istersen.

        //    //dbo vermek must değil(zaten defaultu dbo) ama farklı schema vereceksen bilgin olsun.
        //    //Farklı schema varsa tablo bazında böyle vermek istemiyorsan modelBuilder.HasDefaultSchema("MBOXWAP") şeklinde 1 kereye mahsus verebilirsin.
        //    modelBuilder.Entity<Brand>().ToTable("NewColors", "dbo");

        //    //Tablodaki bir column name benim entity classımda başka bir propertye map edilmek istenirse:
        //    modelBuilder.Entity<Brand>().Property(p => p.Id).HasColumnName("ProductId"); //veritabanındaki ProductId benim entity classımdaki Id ye map edildi.
        //}


    }
}
