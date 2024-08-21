using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApp.API.Domain;

namespace WebApp.Infrastracture
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {        
        }

        public DbSet<Post> Posts => Set<Post>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>();

            base.OnModelCreating(modelBuilder);
        }

    }
}
