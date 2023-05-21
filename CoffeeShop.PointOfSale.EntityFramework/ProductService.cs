using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework;

internal class ProductService
{
    static internal Product GetProductOptionInput()
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
