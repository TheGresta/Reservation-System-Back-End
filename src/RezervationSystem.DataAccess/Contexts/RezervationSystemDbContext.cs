using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RezervationSystem.Entity.Concrete;

namespace RezervationSystem.DataAccess.Contexts
{
    public class RezervationSystemDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(getConnectionString("PostgreSql"));
        }

        public DbSet<Reser> Resers { get; set; }
        public DbSet<ReserRent> ReserRents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Reser[] reserEntitySeeds = {
                new() { Id = 1, Name="Halısaha",Address="Address line",Descripton="description",UserId=1,Price=1 },
                new() { Id = 2, Name="Halısaha 2",Address="Address line",Descripton="description",UserId=1,Price=1 },
                new() { Id = 3, Name="Halısaha 3",Address="Address line",Descripton="description",UserId=1,Price=1 },
            };

            modelBuilder.Entity<Reser>().HasData(reserEntitySeeds);

            ReserRent[] reserRentEntitySeeds =
            {
                new() {Id=1,ReserId=1,StartDate=DateTime.Now,EndDate=DateTime.Now.AddDays(3)},
                new() {Id=2,ReserId=2,StartDate=DateTime.Now,EndDate=DateTime.Now.AddDays(3)},
                new() {Id=3,ReserId=3,StartDate=DateTime.Now,EndDate=DateTime.Now.AddDays(3)}
            };

            modelBuilder.Entity<Reser>().HasData(reserRentEntitySeeds);
        }

        private string getConnectionString(string name)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot configurationManager = builder.Build();

            return configurationManager.GetConnectionString(name);
        }
    }
}
