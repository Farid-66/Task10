using Microsoft.EntityFrameworkCore;
using SBootstrap.Models;

namespace SBootstrap.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
