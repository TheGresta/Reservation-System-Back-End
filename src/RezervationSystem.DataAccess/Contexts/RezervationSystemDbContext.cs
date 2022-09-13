using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RezervationSystem.Entity.Concrete;
using System.Reflection;

namespace RezervationSystem.DataAccess.Contexts
{
    public class RezervationSystemDbContext : DbContext
    {
        public RezervationSystemDbContext()
        {
            #region PostgreSql EnableLegacyTimestampBehavior
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            #endregion
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(getConnectionString("PostgreSql"));
        }

        public DbSet<Reser> Resers { get; set; }
        public DbSet<ReserRent> ReserRents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private string getConnectionString(string name)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot configurationManager = builder.Build();

            return configurationManager.GetConnectionString(name);
        }
    }
}
