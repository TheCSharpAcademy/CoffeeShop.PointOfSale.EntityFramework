using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.PointOfSale.EntityFramework.Models;

[Index(nameof(Name), IsUnique = true)]
internal class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    public string Name { get; set; }

    public List<Product> Products { get; set; }
}
