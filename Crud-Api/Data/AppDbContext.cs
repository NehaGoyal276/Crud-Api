using Microsoft.EntityFrameworkCore;

namespace Crud_Api.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Employee> employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
                
        }
    }
}
