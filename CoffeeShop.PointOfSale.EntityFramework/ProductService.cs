using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework;

internal class ProductService
{
    internal static void InsertProduct()
    {
        var name = AnsiConsole.Ask<string>("Product's name:");
        ProductController.AddProduct(name);
    }

    internal static void DeleteProduct()
    {
        var product = GetProductOptionInput();
        ProductController.DeleteProduct(product);  
    }

    internal static void GetProducts()
    {
        var products = ProductController.GetProducts();
        UserInterface.ShowProductTable(products);
    }

    internal static void GetProduct()
    {
        var product = GetProductOptionInput();
        UserInterface.ShowProduct(product);
    }

    internal static void UpdateProduct() 
    { 
        var product = GetProductOptionInput();
        product.Name = AnsiConsole.Ask<string>("Product's new name:");
        ProductController.UpdateProduct(product);
    }

    static private Product GetProductOptionInput()
    {
        var products = ProductController.GetProducts();
        var productsArray = products.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Product")
            .AddChoices(productsArray));
        var id = products.Single(x => x.Name == option).Id;
        var product = ProductController.GetProductById(id);

        return product;
    }
}
