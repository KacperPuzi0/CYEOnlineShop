using CYEOnlineShop.Models;
using Microsoft.EntityFrameworkCore;


namespace CYEOnlineShop.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Sex> Sexes { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
