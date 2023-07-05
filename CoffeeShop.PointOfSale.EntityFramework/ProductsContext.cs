using CoffeeShop.PointOfSale.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoffeeShop.PointOfSale.EntityFramework;

internal class ProductsContext: DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder
        .UseSqlite($"Data Source = products.db")
        .EnableSensitiveDataLogging()
        .UseLoggerFactory(GetLoggerFactory());

    private ILoggerFactory GetLoggerFactory()
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
            builder.AddFilter((category, level) =>
                category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information);
        });

        return loggerFactory;
    }

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
                },
                new Category
                {
                    CategoryId = 3,
                    Name = "Pastry"
                },
                new Category
                {
                    CategoryId = 4,
                    Name = "Loot"
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
                },
                new Product
                {
                    ProductId = 5,
                    CategoryId = 3,
                    Name = "Cheesecake",
                    Price = 7.0m
                },
                new Product
                {
                    ProductId = 6,
                    CategoryId = 3,
                    Name = "Beefcake",
                    Price = 9.0m
                },
                new Product
                {
                    ProductId = 7,
                    CategoryId = 4,
                    Name = "Super Mug",
                    Price = 13.0m
                },
                new Product
                {
                    ProductId = 8,
                    CategoryId = 4,
                    Name = "Super Keep Cup",
                    Price = 6.0m
                }
           });

        modelBuilder.Entity<Order>()
          .HasData(new List<Order>
          {
                new Order 
                {
                    OrderId = 1,
                    CreatedDate = DateTime.Now.AddMonths(-1),
                    TotalPrice = 70
                },
                new Order
                {
                    OrderId = 2,
                    CreatedDate = DateTime.Now.AddMonths(-1),
                    TotalPrice = 109
                },
                new Order
                {
                    OrderId = 3,
                    CreatedDate = DateTime.Now.AddMonths(-1),
                    TotalPrice = 189
                },
                new Order
                {
                    OrderId = 4,
                    CreatedDate = DateTime.Now.AddMonths(-1),
                    TotalPrice = 23
                },
                new Order
                {
                    OrderId = 5,
                    CreatedDate = DateTime.Now.AddMonths(-2),
                    TotalPrice = 27
                },
                new Order
                {
                    OrderId = 6,
                    CreatedDate = DateTime.Now.AddMonths(-2),
                    TotalPrice = 65
                },
                new Order
                {
                    OrderId = 7,
                    CreatedDate = DateTime.Now.AddMonths(-2),
                    TotalPrice = 5
                },
                new Order
                {
                    OrderId = 8,
                    CreatedDate = DateTime.Now.AddMonths(-2),
                    TotalPrice = 91
                },
                new Order
                {
                    OrderId = 9,
                    CreatedDate = DateTime.Now.AddMonths(-2),
                    TotalPrice = 88
                },
                new Order
                {
                    OrderId = 10,
                    CreatedDate = DateTime.Now.AddMonths(-3),
                    TotalPrice = 91
                },
                new Order
                {
                    OrderId = 11,
                    CreatedDate = DateTime.Now.AddMonths(-3),
                    TotalPrice = 18
                },
                new Order
                {
                    OrderId = 12,
                    CreatedDate = DateTime.Now.AddMonths(-3),
                    TotalPrice = 23
                },
                new Order
                {
                    OrderId = 13,
                    CreatedDate = DateTime.Now.AddMonths(-3),
                    TotalPrice = 27
                },
                new Order
                {
                    OrderId = 14,
                    CreatedDate = DateTime.Now.AddMonths(-3),
                    TotalPrice = 179
                },
                new Order
                {
                    OrderId = 15,
                    CreatedDate = DateTime.Now.AddMonths(-3),
                    TotalPrice = 202
                },
                new Order
                {
                    OrderId = 16,
                    CreatedDate = DateTime.Now.AddMonths(-3),
                    TotalPrice = 97
                },
                new Order
                {
                    OrderId = 17,
                    CreatedDate = DateTime.Now.AddYears(1),
                    TotalPrice = 70
                },
                new Order
                {
                    OrderId = 18,
                    CreatedDate = DateTime.Now.AddYears(1),
                    TotalPrice = 109
                },
                new Order
                {
                    OrderId = 19,
                    CreatedDate = DateTime.Now.AddYears(1),
                    TotalPrice = 189
                },
                new Order
                {
                    OrderId = 20,
                    CreatedDate = DateTime.Now.AddYears(-1),
                    TotalPrice = 23
                },
          });

        modelBuilder.Entity<OrderProduct>()
          .HasData(new List<OrderProduct>
          {
                new OrderProduct
                {
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 5
                },
                new OrderProduct
                {
                    OrderId = 1,
                    ProductId = 2,
                    Quantity = 1
                },
                new OrderProduct
                {
                    OrderId = 2,
                    ProductId = 3,
                    Quantity = 7
                },
                new OrderProduct
                {
                    OrderId = 2,
                    ProductId = 4,
                    Quantity = 3
                },
                new OrderProduct
                {
                    OrderId = 3,
                    ProductId = 1,
                    Quantity = 5
                },
                new OrderProduct
                {
                    OrderId = 3,
                    ProductId = 2,
                    Quantity = 1
                },
                new OrderProduct
                {
                    OrderId = 3,
                    ProductId = 3,
                    Quantity = 7
                },
                new OrderProduct
                {
                    OrderId = 3,
                    ProductId = 4,
                    Quantity = 3
                },
                new OrderProduct
                {
                    OrderId = 4,
                    ProductId = 5,
                    Quantity = 2
                },
                new OrderProduct
                {
                    OrderId = 4,
                    ProductId = 6,
                    Quantity = 1
                },
                new OrderProduct
                {
                    OrderId = 5,
                    ProductId = 6,
                    Quantity = 1
                },
                new OrderProduct
                {
                    OrderId = 5,
                    ProductId = 8,
                    Quantity = 3
                },
                new OrderProduct
                {
                    OrderId = 6,
                    ProductId = 1,
                    Quantity = 5
                },
                new OrderProduct
                {
                    OrderId = 7,
                    ProductId = 2,
                    Quantity = 1
                },
                new OrderProduct
                {
                    OrderId = 8,
                    ProductId = 3,
                    Quantity = 7
                },
                new OrderProduct
                {
                    OrderId = 9,
                    ProductId = 4,
                    Quantity = 3
                },
                new OrderProduct
                {
                    OrderId = 9,
                    ProductId = 1,
                    Quantity = 5
                },
                new OrderProduct
                {
                    OrderId = 9,
                    ProductId = 2,
                    Quantity = 1
                },
                new OrderProduct
                {
                    OrderId = 10,
                    ProductId = 3,
                    Quantity = 7
                },
                new OrderProduct
                {
                    OrderId = 11,
                    ProductId = 4,
                    Quantity = 3
                },
                new OrderProduct
                {
                    OrderId = 12,
                    ProductId = 5,
                    Quantity = 2
                },
                new OrderProduct
                {
                    OrderId = 12,
                    ProductId = 6,
                    Quantity = 1
                },
                new OrderProduct
                {
                    OrderId = 13,
                    ProductId = 6,
                    Quantity = 1
                },
                new OrderProduct
                {
                    OrderId = 13,
                    ProductId = 8,
                    Quantity = 3
                },
                new OrderProduct
                {
                    OrderId = 14,
                    ProductId = 1,
                    Quantity = 5
                },
                new OrderProduct
                {
                    OrderId = 14,
                    ProductId = 2,
                    Quantity = 1
                },
                new OrderProduct
                {
                    OrderId = 14,
                    ProductId = 3,
                    Quantity = 7
                },
                new OrderProduct
                {
                    OrderId = 14,
                    ProductId = 4,
                    Quantity = 3
                },
                new OrderProduct
                {
                    OrderId = 15,
                    ProductId = 1,
                    Quantity = 5
                },
                new OrderProduct
                {
                    OrderId = 15,
                    ProductId = 2,
                    Quantity = 1
                },
                new OrderProduct
                {
                    OrderId = 15,
                    ProductId = 3,
                    Quantity = 7
                },
                new OrderProduct
                {
                    OrderId = 15,
                    ProductId = 4,
                    Quantity = 3
                },
                new OrderProduct
                {
                    OrderId = 15,
                    ProductId = 5,
                    Quantity = 2
                },
                new OrderProduct
                {
                    OrderId = 15,
                    ProductId = 6,
                    Quantity = 1
                },
                new OrderProduct
                {
                    OrderId = 16,
                    ProductId = 6,
                    Quantity = 1
                },
                new OrderProduct
                {
                    OrderId = 16,
                    ProductId = 8,
                    Quantity = 3
                },
                new OrderProduct
                {
                    OrderId = 16,
                    ProductId = 1,
                    Quantity = 5
                },
                new OrderProduct
                {
                    OrderId = 16,
                    ProductId = 2,
                    Quantity = 1
                },
                new OrderProduct
                {
                    OrderId = 17,
                    ProductId = 1,
                    Quantity = 5
                },
                new OrderProduct
                {
                    OrderId = 17,
                    ProductId = 2,
                    Quantity = 1
                },
                new OrderProduct
                {
                    OrderId = 18,
                    ProductId = 3,
                    Quantity = 7
                },
                new OrderProduct
                {
                    OrderId = 18,
                    ProductId = 4,
                    Quantity = 3
                },
                new OrderProduct
                {
                    OrderId = 19,
                    ProductId = 1,
                    Quantity = 5
                },
                new OrderProduct
                {
                    OrderId = 19,
                    ProductId = 2,
                    Quantity = 1
                },
                new OrderProduct
                {
                    OrderId = 19,
                    ProductId = 3,
                    Quantity = 7
                },
                new OrderProduct
                {
                    OrderId = 19,
                    ProductId = 4,
                    Quantity = 3
                },
                new OrderProduct
                {
                    OrderId = 20,
                    ProductId = 5,
                    Quantity = 2
                },
                new OrderProduct
                {
                    OrderId = 20,
                    ProductId = 6,
                    Quantity = 1
                },
          });
    }
}
