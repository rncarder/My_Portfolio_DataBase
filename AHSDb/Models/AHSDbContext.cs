using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AHSDb.Models
{
    public class AHSDbContext : DbContext
    {
        public AHSDbContext(DbContextOptions<AHSDbContext> options) : base(options) { }

        public AHSDbContext() { }

        public DbSet<Cast> Casts { get; set; }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Season> Seasons { get; set; }
    }
}
