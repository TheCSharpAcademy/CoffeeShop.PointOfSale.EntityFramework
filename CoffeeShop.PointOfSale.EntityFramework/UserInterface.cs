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
            Console.Clear();
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<MainMenuOptions>()
            .Title("What would you like to do?")
            .AddChoices(
                MainMenuOptions.ManageCategories,
                MainMenuOptions.ManageProducts,
                MainMenuOptions.ManageOrders,
                MainMenuOptions.Quit));

            switch (option)
            {
                case MainMenuOptions.ManageCategories:
                    CategoriesMenu();
                    break;
                case MainMenuOptions.ManageProducts:
                    ProductsMenu();
                    break;
                case MainMenuOptions.ManageOrders:
                    OrdersMenu();
                    break;
                case MainMenuOptions.Quit:
                    Console.WriteLine("Goodbye");
                    isAppRunning = false;
                    break;
            }
        }
    }

    static internal void CategoriesMenu()
    {
        var isCategoriesMenuRunning = true;
        while (isCategoriesMenuRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<CategoryMenu>()
            .Title("Categories Menu")
            .AddChoices(
                CategoryMenu.AddCategory,
                CategoryMenu.DeleteCategory,
                CategoryMenu.UpdateCategory,
                CategoryMenu.ViewAllCategories,
                CategoryMenu.ViewCategory,
                CategoryMenu.GoBack));

            switch (option)
            {
                case CategoryMenu.AddCategory:
                    CategoryService.InsertCategory();
                    break;
                case CategoryMenu.DeleteCategory:
                    CategoryService.DeleteCategory();
                    break;
                case CategoryMenu.UpdateCategory:
                    CategoryService.UpdateCategory();
                    break;
                case CategoryMenu.ViewAllCategories:
                    CategoryService.GetCategories();
                    break;
                case CategoryMenu.ViewCategory:
                    CategoryService.GetCategory();
                    break;
                case CategoryMenu.GoBack:
                    isCategoriesMenuRunning = false;
                    break;
            }
        }
    }

    static internal void ProductsMenu()
    {
        var isProductMenuRunning = true;
        while (isProductMenuRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<ProductMenu>()
            .Title("Products Menu")
            .AddChoices(
                ProductMenu.AddProduct,
                ProductMenu.DeleteProduct,
                ProductMenu.UpdateProduct,
                ProductMenu.ViewAllProducts,
                ProductMenu.ViewProduct,
                ProductMenu.GoBack));

            switch (option)
            {
                case ProductMenu.AddProduct:
                    ProductService.InsertProduct();
                    break;
                case ProductMenu.DeleteProduct:
                    ProductService.DeleteProduct();
                    break;
                case ProductMenu.UpdateProduct:
                    ProductService.UpdateProduct();
                    break;
                case ProductMenu.ViewProduct:
                    ProductService.GetProduct();
                    break;
                case ProductMenu.ViewAllProducts:
                    ProductService.GetProducts();
                    break;
                case ProductMenu.GoBack:
                    isProductMenuRunning = false;
                    break;
            }
        }
    }

    static internal void OrdersMenu()
    {
        var isOrderMenuRunning = true;
        while (isOrderMenuRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<OrderMenu>()
            .Title("Orders Menu")
            .AddChoices(
                OrderMenu.AddOrder,
                OrderMenu.GoBack));

            switch (option)
            {
                case OrderMenu.AddOrder:
                    OrderService.InsertOrder();
                    break;
                case OrderMenu.GoBack:
                    isOrderMenuRunning = false;
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

    static internal void ShowCategory(Category category)
    {
        var panel = new Panel($@"Id: {category.CategoryId}
Product Count: {category.Products.Count}");
        panel.Header = new PanelHeader($"{category.Name}");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        ShowProductTable(category.Products);

        Console.WriteLine("Press Any Key to Return to Menu");
        Console.ReadLine();
        Console.Clear();
    }
}
