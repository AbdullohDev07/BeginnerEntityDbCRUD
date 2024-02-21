using Microsoft.EntityFrameworkCore;
using One.Roots;

namespace One.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        {
        
        }

        public DbSet<Car> Cars { get; set; }
    }
}
