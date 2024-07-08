// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Football",
        Price = 15,
        Sold = false,
        StockDate = new DateTime(2024, 6, 20),
        ManufactureYear = 2010,
        Condition = 4.2
    },
    new Product()
    {
        Name = "Hockey Stick",
        Price = 12,
        Sold = false,
        StockDate = new DateTime(2024, 5, 17),
        ManufactureYear = 2014,
        Condition = 5.0
    },
    new Product()
    {
        Name = "Boomerang",
        Price = 8,
        Sold = true,
        StockDate = new DateTime(2024, 4, 24),
        ManufactureYear = 2019,
        Condition = 3.7
    },
    new Product()
    {
        Name = "Frisbee",
        Price = 8,
        Sold = false,
        StockDate = new DateTime(2024, 6, 4),
        ManufactureYear = 2010,
        Condition = 4.9
    },
    new Product()
    {
        Name = "Golf Putter",
        Price = 35,
        Sold = true,
        StockDate = new DateTime(2024, 5, 20),
        ManufactureYear = 2020,
        Condition = 5.0
    },
};

string greeting = @"Welcome to Thrown for a Loop
Your one-stop shop for used sporting Equipment";

Console.WriteLine(greeting);
//ViewProductDetails();
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Products
                        2. View Product Details
                        3. View Latest Products");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListProducts();
    }
    else if (choice == "2") 
    {
        ViewProductDetails();
    }
    else if  (choice == "3")
    {
        ViewLatestProducts();
    }
}


void ViewProductDetails()
{
    Console.WriteLine("Products:");
    ListProducts();

    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }

    }
    DateTime now = DateTime.Now;
    TimeSpan timeInStock = now - chosenProduct.StockDate;
    Console.WriteLine(@$"You chose: 
{chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
It is {now.Year - chosenProduct.ManufactureYear} years old. 
It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}");

}
void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}
void ViewLatestProducts()
{
    // create a new empty List to store the latest products
    List<Product> latestProducts = new List<Product>();
    // Calculate a DateTime 90 days in the past
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
    // Loop through the products
    foreach (Product product in products)
    {
        // Add a product to latestProducts if it fits the criteria
        if (product.StockDate > threeMonthsAgo && !product.Sold)
        {
            latestProducts.Add(product);
        }
    }
    // Print out the latest products to the console 
    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
    }
}
