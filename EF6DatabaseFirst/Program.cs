// See https://aka.ms/new-console-template for more information
using EF6DatabaseFirst.Models;

Console.WriteLine("Hello, World!");

using (var db = new NorthwindContext())
{
    Console.WriteLine("Database Connected");
    Console.WriteLine();

    Console.WriteLine("Listing Category Sales For 1997s");
    db.CategorySalesFor1997s.ToList().ForEach(x => Console.WriteLine(x.CategoryName));
    Console.WriteLine();

    Console.WriteLine("Listing Products Above Average Prices");
    db.ProductsAboveAveragePrices.ToList().ForEach(x => Console.WriteLine(x.ProductName));
    Console.WriteLine();

    Console.WriteLine("Listing Territories");
    db.Territories.ToList().ForEach(x => Console.WriteLine(x.TerritoryDescription));
}
