using CoffeeShop.PointOfSale.EntityFramework;

var context = new ProductsContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

UserInterface.MainMenu();