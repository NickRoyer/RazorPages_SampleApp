using RazorPages_SampleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RazorPages_SampleApp.Data
{
    public class ProductContext : DbContext
    {
        
        private IContextSeeder Seeder { get; }
        public ProductContext(DbContextOptions<ProductContext> options, IContextSeeder seeder = default) : base(options)
        {
            Seeder = seeder;
            if (Seeder != null)
                Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
                
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                       
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory");

            Seeder?.SeedContext(modelBuilder);
        }
    }
}