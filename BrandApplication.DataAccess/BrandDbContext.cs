using BrandApplication.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BrandApplication.DataAccess
{
    public class BrandDbContext : DbContext
    {
        public BrandDbContext(DbContextOptions<BrandDbContext> options) : base(options) { }

        public BrandDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=brand_db;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FluentConfiguration.Brand_FluentConfiguration());
            modelBuilder.Entity<Brand>().HasData(new Brand
            {
                BrandId = 1,
                BrandName = "Test brand 1",
            });
        }
    }
}
