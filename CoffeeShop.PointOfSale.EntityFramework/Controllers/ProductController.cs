using CoffeeShop.PointOfSale.EntityFramework.Models;
using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework.Controllers;

internal class ProductController
{
    internal static void AddProduct(Product product)
    {
        using var db = new ProductsContext();

        db.Add(product);

        db.SaveChanges();
    }

    internal static void DeleteProduct(Product product)
    {
        using var db = new ProductsContext();

        db.Remove(product);

        db.SaveChanges();

    }

    internal static Product GetProductById(int id)
    {
        using var db = new ProductsContext();

        var product = db.Products.SingleOrDefault(x => x.ProductId == id);

        return product;
    }

    internal static List<Product> GetProducts()
    {
        using var db = new ProductsContext();

        var products = db.Products.ToList();

        return products;
    }

    internal static void UpdateProduct(Product product)
    {
        using var db = new ProductsContext();

        db.Update(product);

        db.SaveChanges();
    }
}
