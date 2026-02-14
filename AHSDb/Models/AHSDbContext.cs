using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AHSDb.Models
{
    public class AHSDbContext : DbContext
    {
        public AHSDbContext(DbContextOptions<AHSDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // This is the "Safety Valve" for your DLL
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=AHSDatabase;Integrated Security=True;TrustServerCertificate=True",
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        // The "Resilience" Plugin
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    });
                    
            }
        }
        public AHSDbContext() { }

        public DbSet<Cast> Casts { get; set; }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Season> Seasons { get; set; }


    }
}
