using EShopping.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopping.ProductApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //FluentAPI

        protected override void OnModelCreating(ModelBuilder mb) {
            //category
            mb.Entity<Category>().HasKey(c => c.CategoryId);
            mb.Entity<Category>().Property(c => c.Name)
                .HasMaxLength(100).
                IsRequired();
            //product
            mb.Entity<Category>().Property(c => c.Name)
                 .HasMaxLength(100).
                 IsRequired();

            mb.Entity<Product>().Property(c => c.Description)
            .HasMaxLength(255).
            IsRequired();

            mb.Entity<Product>().Property(c => c.ImageUrl)
               .HasMaxLength(255).
               IsRequired();

            mb.Entity<Product>().Property(c => c.Price)
            .HasPrecision(12, 2);

            mb.Entity<Category>().HasMany(g => g.Products).WithOne(c => c.Category)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Material Escolar"
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Acessorios"
                }
            );
        }
    }
}
