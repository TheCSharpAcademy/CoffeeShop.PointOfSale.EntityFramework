using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework;

static internal class UserInterface
{
    static internal void ShowProduct(Product product)
    {
        var panel = new Panel($@"Id: {product.Id}
Name: {product.Name}");
        panel.Header = new PanelHeader("Product Info");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        Console.WriteLine("Press Any Key to Return to Menu");
        Console.ReadLine();
        Console.Clear();
    }
    static internal void ShowProductTable(List<Product> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Price");

        foreach (Product product in products)
        {
            table.AddRow(
                product.Id.ToString(), 
                product.Name, 
                product.Price.ToString()
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press Any Key to Return to Menu");
        Console.ReadLine();
        Console.Clear();
    }
}
