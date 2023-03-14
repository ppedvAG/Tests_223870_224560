using Microsoft.EntityFrameworkCore;
using ppedv.CarManager5000.Model;

namespace ppedv.CarManager5000.Data.Db
{
    public class CarManagerContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conString = "Server=(localdb)\\mssqllocaldb;Database=CarManager5000_Tests;Trusted_Connection=true";
            optionsBuilder.UseSqlServer(conString);
        }
    }
}