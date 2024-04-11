using Microsoft.EntityFrameworkCore;

namespace ChemicalElementsDictionaryMVC.Model
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<ChemicalElement> Chemicals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            string? connectionSring = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionSring);
        }
    }
}
