using Microsoft.EntityFrameworkCore;
using WebApp.API.Domain;

namespace WebApp.Infrastracture
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Post> Posts => Set<Post>();

    }
}
