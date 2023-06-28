using CoffeeShop.PointOfSale.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.PointOfSale.EntityFramework.Controllers;

internal class CategoryController
{
    internal static void AddCategory(Category category)
    {
        using var db = new ProductsContext();

        db.Add(category);

        db.SaveChanges();
    }

    internal static void DeleteCategory(Category category)
    {
        using var db = new ProductsContext();

        db.Remove(category);

        db.SaveChanges();
    }

    internal static List<Category> GetCategories()
    {
        using var db = new ProductsContext();

        var categories = db.Categories
            .Include(x => x.Products)
            .ToList();

        return categories;
    }

    internal static void UpdateCategory(Category category)
    {
        using var db = new ProductsContext();

        db.Update(category);

        db.SaveChanges();
    }
}
