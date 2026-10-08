using System;

namespace OnlineOrdering
{
    // This is the Main method for the OnlineOrdering application
    public class Program
    {
        // This is the entry point of the OnlineOrdering application
        public static void Main(string[] args)
        {
            // Order 1
            // Create an Address object for the first customer with their street, city, state and country
            Address address1 = new Address("Wellington St", "New York", "CA", "USA");

            // Create a Customer object for the first customer with their name and address
            Customer customer1 = new Customer("Kenny Olateju", address1);

            // Create products for the first order
            Product product1 = new Product("Laptop", "LT-1001", 1000, 1);
            Product product2 = new Product("Mouse", "MS-2002", 25, 2);
            Product product3 = new Product("Keyboard", "KB-3003", 75, 1);

            // Create the first order for the first customer
            Order order1 = new Order(customer1);
            
            // Add the three products to the first order
            order1.AddProduct(product1);
            order1.AddProduct(product2);
            order1.AddProduct(product3);

            // Order 2
            // Create the address for the second customer
            Address address2 = new Address("Queen St", "Toronto", "ON", "Canada");

            // Create the second customer with their name and address above
            Customer customer2 = new Customer("Eniola Oba", address2);

            // Create the products for the second order
            Product product4 = new Product("Monitor", "MN-4004", 200, 1);
            Product product5 = new Product("Headphones", "HP-5005", 150, 2);
            Product product6 = new Product("Webcam", "WC-6006", 100, 1);

            // Create the second order for the second customer
            Order order2 = new Order(customer2);

            // Add the three products to the second order
            order2.AddProduct(product4);
            order2.AddProduct(product5);
            order2.AddProduct(product6);

            // Display the Result of the First Order
            // Display a heading for Order 1
            Console.WriteLine();
            Console.WriteLine("*********************");
            Console.WriteLine("      ORDER 1:       ");
            Console.WriteLine("*********************");

            // Display the packaging label for the first order
            Console.WriteLine(order1.GetPackagingLabel());

            // Display the shipping label for the first order
            Console.WriteLine(order1.GetShippingLabel());

            // Display the total cost of the first order
            Console.WriteLine();
            Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");

            // Display the order 2 results
            Console.WriteLine();
            Console.WriteLine("*********************");
            Console.WriteLine("      ORDER 2:       ");
            Console.WriteLine("*********************");

            // Display the packaging label for the second order
            Console.WriteLine(order2.GetPackagingLabel());

            // Display the shipping label for the second order
            Console.WriteLine(order2.GetShippingLabel());

            // Display the total cost of the second order
            Console.WriteLine();
            Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
            Console.WriteLine();
        }
    }
}