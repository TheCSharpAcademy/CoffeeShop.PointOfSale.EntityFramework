using CoffeeShop.PointOfSale.EntityFramework.Controllers;
using CoffeeShop.PointOfSale.EntityFramework.Models;
using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework.Services;

internal class OrderService
{
    internal static void InsertOrder()
    {
        var orderProducts = GetProductsForOrder();

        OrderController.AddOrder(orderProducts);
    }

    internal static void GetOrders()
    {
        var orders = OrderController.GetOrders();

        UserInterface.ShowOrderTable(orders);
    }

    private static List<OrderProduct> GetProductsForOrder()
    {
        var products = new List<OrderProduct>();
        var order = new Order
        {
            CreatedDate = DateTime.Now
        };

        bool isOrderFinished = false;
        while (!isOrderFinished)
        {
            var product = ProductService.GetProductOptionInput();
            var quantity = AnsiConsole.Ask<int>("How many?");

            order.TotalPrice = order.TotalPrice + (quantity * product.Price);

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
