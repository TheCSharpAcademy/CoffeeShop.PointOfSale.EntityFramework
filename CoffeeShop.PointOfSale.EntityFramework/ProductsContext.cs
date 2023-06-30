using CoffeeShop.PointOfSale.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.PointOfSale.EntityFramework;

internal class ProductsContext: DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source = products.db");

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderProduct>()
            .HasKey(op => new { op.OrderId, op.ProductId });

        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Order)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(op => op.OrderId);

        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Product)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(op => op.ProductId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(o => o.Products)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Category>()
            .HasData(new List<Category>
            {
                new Category
                {
                    CategoryId = 1,
                    Name = "Coffee"
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Juice"
                }
            });

        modelBuilder.Entity<Product>()
           .HasData(new List<Product>
           {
                new Product
                {
                    ProductId = 1,
                    CategoryId = 1,
                    Name = "Cappuccino",
                    Price = 13.0m
                },
                new Product
                {
                    ProductId = 2,
                    CategoryId = 1,
                    Name = "Latte",
                    Price = 5.0m
                },
                new Product
                {
                    ProductId = 3,
                    CategoryId = 2,
                    Name = "Apple Juice",
                    Price = 13.0m
                },
                new Product
                {
                    ProductId = 4,
                    CategoryId = 2,
                    Name = "Orange Juice",
                    Price = 6.0m
                }
           });
    }
}
