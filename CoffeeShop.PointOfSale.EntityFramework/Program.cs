// See https://aka.ms/new-console-template for more information
using CoffeeShop.PointOfSale.EntityFramework;
using Spectre.Console;

var isAppRunning = true;
while (isAppRunning)
{
    var option = AnsiConsole.Prompt(
    new SelectionPrompt<MenuOptions>()
    .Title("What would you like to do?")
    .AddChoices(
        MenuOptions.AddProduct,
        MenuOptions.DeleteProduct,
        MenuOptions.UpdateProduct,
        MenuOptions.ViewAllProducts,
        MenuOptions.ViewProduct));

    switch (option)
    {
        case MenuOptions.AddProduct:
            ProductController.AddProduct();
            break;
        case MenuOptions.DeleteProduct:
            var productsForDeleting = ProductController.GetProducts();
            var productNameForDeleting = UserInterface.GetProductOptionInput(productsForDeleting);
            var idForDeleting = productsForDeleting.Single(x => x.Name == productNameForDeleting).Id;
            var productForDeleting = ProductController.GetProductById(idForDeleting);
            ProductController.DeleteProduct(productForDeleting);
            break;
        case MenuOptions.UpdateProduct:
            ProductController.UpdateProduct();
            break;
        case MenuOptions.ViewProduct:
            var products = ProductController.GetProducts();
            var productName = UserInterface.GetProductOptionInput(products);
            var id = products.Single(x => x.Name == productName).Id;
            var product = ProductController.GetProductById(id);
            UserInterface.ShowProduct(product);
            break;
        case MenuOptions.ViewAllProducts:
            var allProducts = ProductController.GetProducts();
            UserInterface.ShowProductTable(allProducts);
            break;
    }
}

enum MenuOptions
{
    AddProduct,
    DeleteProduct,
    UpdateProduct, 
    ViewProduct,
    ViewAllProducts,
    Quit
}
