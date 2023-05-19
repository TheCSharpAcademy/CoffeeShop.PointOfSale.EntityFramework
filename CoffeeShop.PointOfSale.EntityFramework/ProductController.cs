using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework;

internal class ProductController
{
    internal static void AddProduct()
    {
        var name = AnsiConsole.Ask<string>("Product's name:");

        using var db = new ProductsContext();
        db.Add(new Product { Name = name });

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
        var product = db.Products.FirstOrDefault(x => x.Id == id);

        return product;
    }

    internal static List<Product> GetProducts()
    {
        using var db = new ProductsContext();
        var products = db.Products.ToList();
        return products;
    }

    internal static void UpdateProduct()
    {
        throw new NotImplementedException();
    }
}
