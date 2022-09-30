using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CodeFirst.Models
{
    public class ProductDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<cart> Cart { get; set; }
        public static string Connectionstring
        {
            get;
            set;
        }

        public void BuildConnectionstring(string dbstring) { Connectionstring = dbstring; }

        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(eb =>
            {
                eb.HasKey("product_id");
            });
            modelBuilder.Entity<cart>(eb =>
            {
                eb.HasKey("product_id");
            });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(Connectionstring))
            {
                optionsBuilder.UseSqlServer(Connectionstring);
            }
        }
    }
}
