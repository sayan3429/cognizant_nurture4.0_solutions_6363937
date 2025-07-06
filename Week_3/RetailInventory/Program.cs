using Microsoft.EntityFrameworkCore;

using var context = new AppDbContext();

var electronics = new Category { Name = "Electronics" };
var groceries = new Category { Name = "Groceries" };

await context.Categories.AddRangeAsync(electronics, groceries);

var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

await context.Products.AddRangeAsync(product1, product2);
await context.SaveChangesAsync();

// Retrieving all products
Console.WriteLine("Retrieved all products:");
var products = await context.Products.ToListAsync();
foreach (var p in products)
    Console.WriteLine($"{p.Name} - {p.Price}");

// Find by ID 
Console.WriteLine("Product by ID:");
var productbyID = await context.Products.FindAsync(1);
Console.WriteLine($"Found: {productbyID?.Name}");

// FirstOrDefault with Condition:
Console.WriteLine("Product by Name:");
var productbyName = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
Console.WriteLine($"Found: {productbyName?.Name}");


