using CoffeeShop.PointOfSale.EntityFramework.Controllers;
using CoffeeShop.PointOfSale.EntityFramework.Models;
using CoffeeShop.PointOfSale.EntityFramework.Models.DTO;
using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework.Services;

internal class OrderService
{
    internal static void InsertOrder()
    {
        var products = GetProductsForOrder();

        OrderController.AddOrder(products);
    }

    internal static void GetOrders()
    {
        var orders = OrderController.GetOrders();

        UserInterface.ShowOrderTable(orders);
    }

    internal static void GetOrder()
    {
        var order = GetOrderOptionInput();
        var products = order.OrderProducts
            .Select(x => x.Product)
            .Select(x => new ProductForOrderViewDTO
            {
                Id = x.ProductId,
                Name = x.Name,
                CategoryName = x.Category.Name,
                Price = x.Price
            })
            .ToList();

        UserInterface.ShowOrder(order);
        UserInterface.ShowProductForOrderTable(products);
    }

    private static Order GetOrderOptionInput()
    {
        var orders = OrderController.GetOrders();
        var ordersArray = orders.Select(x => $"{x.OrderId}.{x.CreatedDate} - {x.TotalPrice}").ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Order")
            .AddChoices(ordersArray));
        var id = option.Split(('.'));
        var order = orders.Single(x => x.OrderId == Int32.Parse(id[0]));

        return order;
    }

    private static List<OrderProduct> GetProductsForOrder()
    {
        var products = new List<OrderProduct>();
        bool isOrderFinished = false;
        var order = new Order
        {
            CreatedDate = DateTime.Now
        };
        
        while(!isOrderFinished)
        {
            var product = ProductService.GetProductOptionInput();
            var quantity = AnsiConsole.Ask<int>("How many?");

            order.TotalPrice = order.TotalPrice + (quantity * product.Price) ;

            products.Add(
                new OrderProduct
                {
                    Order = order,
                    ProductId = product.ProductId,
                    Quantity = quantity
                }); 

            isOrderFinished = !AnsiConsole.Confirm("Would you like to add more products?");
        }

        return products;
    }
}
