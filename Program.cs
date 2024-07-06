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
        StockDate = new DateTime(2022, 10, 20),
        ManufactureYear = 2010,
        Condition = 4.2
    },
    new Product()
    {
        Name = "Hockey Stick",
        Price = 12,
        Sold = false,
        StockDate = new DateTime(2022, 6, 27),
        ManufactureYear = 2014,
        Condition = 5.0
    },
    new Product()
    {
        Name = "Boomerang",
        Price = 8,
        Sold = false,
        StockDate = new DateTime(2022, 3, 27),
        ManufactureYear = 2019,
        Condition = 3.7
    },
    new Product()
    {
        Name = "Frisbee",
        Price = 8,
        Sold = false,
        StockDate = new DateTime(2022, 11, 4),
        ManufactureYear = 2010,
        Condition = 4.9
    },
    new Product()
    {
        Name = "Golf Putter",
        Price = 35,
        Sold = false,
        StockDate = new DateTime(2022, 8, 20),
        ManufactureYear = 2020,
        Condition = 5.0
    },
};

string greeting = @"Welcome to Thrown for a Loop
Your one-stop shop for used sporting Equipment";

Console.WriteLine(greeting);

Console.WriteLine(@"Products:");

for (int i = 0; i < products.Count; i++)
{
    Console.WriteLine($"{i + 1}. {products[i].Name}");
}

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
        Console.WriteLine("Do better!");
    }
}

DateTime now = DateTime.Now;

TimeSpan timeInStock = now - chosenProduct.StockDate;

Console.WriteLine(@$"You chose: 

{chosenProduct.Name}, which costs {chosenProduct.Price} dollars. The condion of the item is a {chosenProduct.Condition} out of 5.

It is {now.Year - chosenProduct.ManufactureYear} years old. 

It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}");

decimal totalValue = 0.0M;
foreach (Product product in products)
{
    if (!product.Sold)
    {
        totalValue += product.Price;
    }
}
Console.WriteLine($"Total inventory value: ${totalValue}");
Console.Read();

