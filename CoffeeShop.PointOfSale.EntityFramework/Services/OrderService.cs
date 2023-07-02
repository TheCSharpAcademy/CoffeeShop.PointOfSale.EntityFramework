using CoffeeShop.PointOfSale.EntityFramework.Controllers;
using CoffeeShop.PointOfSale.EntityFramework.Models;
using CoffeeShop.PointOfSale.EntityFramework.Models.DTOs;
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

    internal static void GetOrder()
    {
        var order = GetOrderOptionInput();
        var products = order.OrderProducts
            .Select(x => new ProductForOrderViewDTO
            {
                Id = x.ProductId,
                Name = x.Product.Name,
                CategoryName = x.Product.Category.Name,
                Quantity = x.Quantity,
                Price = x.Product.Price,
                TotalPrice = x.Quantity * x.Product.Price
            })
            .ToList();

        UserInterface.ShowOrder(order);
        UserInterface.ShowProductForOrderTable(products);
    }

    private static Order GetOrderOptionInput()
    {
        var orders = OrderController.GetOrders();
        var orderArray = orders.Select(x => $"{x.OrderId}.{x.CreatedDate} - {x.TotalPrice}").ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Order")
            .AddChoices(orderArray));
        var idArray = option.Split('.');
        var order = orders.Single(x => x.OrderId == Int32.Parse(idArray[0]));

        return order;
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
