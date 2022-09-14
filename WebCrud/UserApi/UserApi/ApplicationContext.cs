using Microsoft.EntityFrameworkCore;

namespace UserApi
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        { }

        public DbSet<User>? Users { get; set; }
    }
}