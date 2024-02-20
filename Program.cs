using System;
using System.Collections.Generic;

class Program
{
    static List<(string itemName, double price)> orderList = new List<(string, double)>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nOrdering Application");
            Console.WriteLine("1. Add Item to Order");
            Console.WriteLine("2. View Order Summary");
            Console.WriteLine("3. Place Order");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    AddItemToOrder();
                    break;
                case "2":
                    ViewOrderSummary();
                    break;
                case "3":
                    PlaceOrder();
                    break;
                case "4":
                    Console.WriteLine("Exiting the application. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }

    static void AddItemToOrder()
    {
        Console.Write("Enter item name: ");
        string itemName = Console.ReadLine();

        double price;
        while (true)
        {
            Console.Write("Enter item price: ");
            if (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid price. Please enter a valid number.");
            }
            else
            {
                orderList.Add((itemName, price));
                Console.WriteLine($"Item '{itemName}' added to the order.");
                break;
            }
        }
    }

    static void ViewOrderSummary()
    {
        if (orderList.Count == 0)
        {
            Console.WriteLine("No items in the order.");
            return;
        }

        Console.WriteLine("Order Summary:");
        foreach (var (itemName, price) in orderList)
        {
            Console.WriteLine($"Item: {itemName}, Price: {price}");
        }
    }

    static void PlaceOrder()
    {
        if (orderList.Count == 0)
        {
            Console.WriteLine("No items in the order. Cannot place empty order.");
            return;
        }

        double totalPrice = 0;
        foreach (var (_, price) in orderList)
        {
            totalPrice += price;
        }

        Console.WriteLine($"Total price of the order: {totalPrice}");
        orderList.Clear();
        Console.WriteLine("Order placed successfully. Order list cleared.");
    }
}