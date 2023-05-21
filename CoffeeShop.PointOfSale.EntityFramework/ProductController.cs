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

    internal static void DeleteProduct()
    {
        throw new NotImplementedException();
    }

    internal static void GetProductById()
    {
        throw new NotImplementedException();
    }

    internal static void GetProducts()
    {
        throw new NotImplementedException();
    }

    internal static void UpdateProduct()
    {
        throw new NotImplementedException();
    }
}
