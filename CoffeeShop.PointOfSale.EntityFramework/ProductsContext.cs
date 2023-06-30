using CoffeeShop.PointOfSale.EntityFramework.Models;
using CoffeeShop.PointOfSale.EntityFramework.Services;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.PointOfSale.EntityFramework;

internal class ProductsContext: DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
        .UseSqlite($"Data Source = products.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderProduct>()
            .HasKey(op => new { op.OrderId, op.ProductId });
        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Order)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(op => op.OrderId);
        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Product)
            .WithMany(p => p.OrderProducts)
            .HasForeignKey(op => op.ProductId);

        modelBuilder.Entity<Category>()
            .HasData(new List<Category>
            {
                new Category
                {
                    CategoryId = 1,
                    Name = "Donut"
                }
            });

        modelBuilder.Entity<Product>()
            .HasData(new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    Name = "Milk Donut",
                    Price = 1,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Chocolate Donut",
                    Price = 2,
                    CategoryId = 1
                }
            });
    }
}
