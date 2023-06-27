using CoffeeShop.PointOfSale.EntityFramework.Models;
using CoffeeShop.PointOfSale.EntityFramework.Services;
using Spectre.Console;
using static CoffeeShop.PointOfSale.EntityFramework.Enums;

namespace CoffeeShop.PointOfSale.EntityFramework;

static internal class UserInterface
{

    static internal void MainMenu()
    {
        var isAppRunning = true;
        while (isAppRunning)
        {
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOptions>()
            .Title("What would you like to do?")
            .AddChoices(
                MenuOptions.AddCategory,
                MenuOptions.DeleteCategory,
                MenuOptions.UpdateCategory,
                MenuOptions.ViewAllCategories,
                MenuOptions.AddProduct,
                MenuOptions.DeleteProduct,
                MenuOptions.UpdateProduct,
                MenuOptions.ViewAllProducts,
                MenuOptions.ViewProduct));

            switch (option)
            {
                case MenuOptions.AddCategory:
                    CategoryService.InsertCategory();
                    break;
                case MenuOptions.DeleteCategory:
                    CategoryService.DeleteCategory();
                    break;
                case MenuOptions.UpdateCategory:
                    CategoryService.UpdateCategory();
                    break;
                case MenuOptions.ViewAllCategories:
                    CategoryService.GetCategories();
                    break;
                case MenuOptions.AddProduct:
                    ProductService.InsertProduct();
                    break;
                case MenuOptions.DeleteProduct:
                    ProductService.DeleteProduct();
                    break;
                case MenuOptions.UpdateProduct:
                    ProductService.UpdateProduct();
                    break;
                case MenuOptions.ViewProduct:
                    ProductService.GetProduct();
                    break;
                case MenuOptions.ViewAllProducts:
                    ProductService.GetProducts();
                    break;
            }
        }
    }
    static internal void ShowProduct(Product product)
    {
        var panel = new Panel($@"Id: {product.ProductId}
Name: {product.Name}
Category: {product.Category.Name}");
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
        table.AddColumn("Category");

        foreach (Product product in products)
        {
            table.AddRow(
                product.ProductId.ToString(), 
                product.Name, 
                product.Price.ToString(),
                product.Category.Name
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press Any Key to Return to Menu");
        Console.ReadLine();
        Console.Clear();
    }

    static internal void ShowCategoryTable(List<Category> categories)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");

        foreach (Category category in categories)
        {
            table.AddRow(
                category.CategoryId.ToString(),
                category.Name
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press Any Key to Return to Menu");
        Console.ReadLine();
        Console.Clear();
    }
}
