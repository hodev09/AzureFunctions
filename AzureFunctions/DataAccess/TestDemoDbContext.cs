using TestFunction.Models;
using Microsoft.EntityFrameworkCore;

namespace TestFunction.DataAccess
{
    public class TestDemoDbContext : DbContext
    {
        public TestDemoDbContext(DbContextOptions<TestDemoDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
