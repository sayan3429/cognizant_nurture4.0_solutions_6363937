using System;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }
}

public class SearchOptimizer
{
    
    public static Product LinearSearch(Product[] products, int targetId)
    {
        foreach (var product in products)
        {
            if (product.ProductId == targetId)
                return product;
        }
        return null;
    }

    
    public static Product BinarySearch(Product[] sortedProducts, int targetId)
    {
        int left = 0;
        int right = sortedProducts.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            
            if (sortedProducts[mid].ProductId == targetId)
                return sortedProducts[mid];
                
            if (sortedProducts[mid].ProductId < targetId)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return null;
    }
}

class Program
{
    static void Main()
    {
        
        Product[] unsortedProducts = {
            new Product(105, "Wireless Mouse", "Electronics"),
            new Product(102, "Mechanical Keyboard", "Electronics"),
            new Product(101, "Gaming Headset", "Electronics"),
            new Product(104, "Desk Lamp", "Home"),
            new Product(103, "Water Bottle", "Kitchen")
        };

        
        Product[] sortedProducts = new Product[unsortedProducts.Length];
        Array.Copy(unsortedProducts, sortedProducts, unsortedProducts.Length);
        Array.Sort(sortedProducts, (p1, p2) => p1.ProductId.CompareTo(p2.ProductId));

        
        int searchId = 103;
        
        Console.WriteLine("=== Linear Search Test ===");
        Product linearResult = SearchOptimizer.LinearSearch(unsortedProducts, searchId);
        Console.WriteLine(linearResult != null 
            ? $"Found: {linearResult.ProductName} (ID: {linearResult.ProductId})" 
            : "Product not found");

        Console.WriteLine("\n=== Binary Search Test ===");
        Product binaryResult = SearchOptimizer.BinarySearch(sortedProducts, searchId);
        Console.WriteLine(binaryResult != null 
            ? $"Found: {binaryResult.ProductName} (ID: {binaryResult.ProductId})" 
            : "Product not found");
    }
}
