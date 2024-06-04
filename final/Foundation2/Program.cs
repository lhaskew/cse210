using System;

class Program
{
    static void Main()
    {
        // Create addresses
        var address1 = new Address("123 Elm Street", "Springfield", "IL", "USA");
        var address2 = new Address("456 Maple Avenue", "Toronto", "ON", "Canada");

        // Create customers
        var customer1 = new Customer("John Doe", address1);
        var customer2 = new Customer("Jane Smith", address2);

        // Create products
        var product1 = new Product("Laptop", "LP1001", 999.99m, 1);
        var product2 = new Product("Mouse", "MS2001", 25.50m, 2);
        var product3 = new Product("Keyboard", "KB3001", 45.00m, 1);
        var product4 = new Product("Monitor", "MN4001", 250.00m, 1);
        var product5 = new Product("USB Cable", "US5001", 10.00m, 3);

        // Create orders
        var order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        var order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Display order details
        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GeneratePackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GenerateShippingLabel());
        Console.WriteLine("Total Cost: $" + order.CalculateTotalCost());
        Console.WriteLine();
    }
}
