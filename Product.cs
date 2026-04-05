using System;
using System.Collections.Generic;

class Product : IComparable<Product>
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public int CompareTo(Product other)
    {
        if (other == null) return 1;
        return Price.CompareTo(other.Price);
    }

    public override string ToString()
    {
        return $"Name: {Name}, Price: {Price}";
    }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product { Name = "Laptop", Price = 1000 },
            new Product { Name = "Phone", Price = 700 },
            new Product { Name = "Tablet", Price = 500 },
            new Product { Name = "Monitor", Price = 300 },
            new Product { Name = "Mouse", Price = 50 }
        };

        products.Sort();

        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
    }
}