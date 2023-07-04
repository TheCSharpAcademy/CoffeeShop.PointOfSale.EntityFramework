using CoffeeShop.PointOfSale.EntityFramework.Models;

namespace CoffeeShop.PointOfSale.EntityFramework.Controllers;

internal class OrderController
{
    internal static void AddOrder(List<OrderProduct> orders)
    {
        using var db = new ProductsContext();

        db.OrderProducts.AddRange(orders);

        db.SaveChanges();
    }
}
