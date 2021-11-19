using TestFunction.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
