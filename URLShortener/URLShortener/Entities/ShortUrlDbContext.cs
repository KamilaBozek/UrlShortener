using Microsoft.EntityFrameworkCore;

namespace URLShortener.Entities
{
    public class ShortUrlDbContext : DbContext
    {
        private readonly string _connectionString =
          "Server=(localdb)\\mssqllocaldb;Database=URLsDb;Trusted_Connection=True;";

        public DbSet<ShortUrl> ShortUrls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
