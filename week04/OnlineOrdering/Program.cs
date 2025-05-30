using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 - USA Customer
        Address address1 = new Address("123 Apple St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "LP1001", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "MS2001", 25.50, 2));

        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Order 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Order 1 Total Price: ${order1.GetTotalPrice():F2}");
        Console.WriteLine();

        // Order 2 - International Customer
        Address address2 = new Address("456 Banana Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Tablet", "TB3002", 499.99, 1));
        order2.AddProduct(new Product("Stylus Pen", "SP4003", 45.75, 1));
        order2.AddProduct(new Product("Keyboard Case", "KC5004", 79.99, 1));

        Console.WriteLine("Order 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Order 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Order 2 Total Price: ${order2.GetTotalPrice():F2}");
    }
}
