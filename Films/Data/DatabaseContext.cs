using Microsoft.EntityFrameworkCore;

namespace Films.Data
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<Film> Films { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;" +
                "Database=FilmsDb;Username=postgres;Password=1111");
        }
    }
}
