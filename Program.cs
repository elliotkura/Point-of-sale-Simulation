using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
using System.Collections.Generic;

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

class POS
{
    private List<Product> products;
    private List<Product> cart;

    public POS()
    {
        products = new List<Product>();
        cart = new List<Product>();
    }

    public void AddProduct(string name, decimal price)
    {
        var product = new Product { Id = products.Count + 1, Name = name, Price = price };
        products.Add(product);
    }

    public void AddToCart(int productId)
    {
        var product = products.Find(p => p.Id == productId);
        if (product != null)
        {
            cart.Add(product);
            Console.WriteLine("Product added to cart: " + product.Name);
        }
        else
        {
            Console.WriteLine("Product not found");
        }
    }

    public void CalculateTotal()
    {
        decimal total = 0;
        foreach (var product in cart)
        {
            total += product.Price;
        }
        Console.WriteLine("Total: $" + total);
    }

    public void PrintReceipt()
    {
        Console.WriteLine("Receipt:");
        foreach (var product in cart)
        {
            Console.WriteLine(product.Name + " - $" + product.Price);
        }
        Console.WriteLine("Thank you for shopping with us!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        POS pos = new POS();

        // Prompt user to add products
        Console.WriteLine("Enter product details (name and price) or type 'done' to finish:");

        while (true)
        {
            Console.Write("Product name: ");
            string productName = Console.ReadLine();

            if (productName.ToLower() == "done")
                break;

            Console.Write("Product price: ");
            decimal productPrice;
            if (decimal.TryParse(Console.ReadLine(), out productPrice))
            {
                pos.AddProduct(productName, productPrice);
            }
            else
            {
                Console.WriteLine("Invalid price. Please enter a valid decimal value.");
            }
        }

        // Add products to the cart
        Console.WriteLine("Add products to the cart (enter product ID or type 'done' to finish):");
        while (true)
        {
            Console.Write("Product ID: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "done")
                break;

            int productId;
            if (int.TryParse(input, out productId))
            {
                pos.AddToCart(productId);
            }
            else
            {
                Console.WriteLine("Invalid product ID. Please enter a valid integer.");
            }
        }

        // Calculate and print the total amount
        pos.CalculateTotal();

        // Print the receipt
        pos.PrintReceipt();

        Console.ReadLine();
    }
}
