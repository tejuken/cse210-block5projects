
using System.Collections.Generic;

namespace OnlineOrdering
{
    // Use the Order class to display an order with its products and customer, calculate the total cost 
    // of the order; including shipping, and return the packaging and shipping labels
    public class Order
    {
        // Create a list to store the products in the order for the user to see when viewing the order
        private List<Product> _products;

        // Create a private field to store each customer's name for the user to see when viewing the order
        // Store the customer name for the user to see when viewing the order
        private Customer _customer;

        // Create Getter and Setter methods for the list of products to show encapsulation
        public List<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }
        
        // Create Getter and Setter methods for the customer to show encapsulation
        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        // Create an Order object using constructor that will receive the customer name 
        public Order(Customer customer)
        {
            // Create an empty list to store the products for the order
            _products = new List<Product>();

            // Store the customer provided by the user in the private field for the Order class
            _customer = customer;
        }

        // Add a Product object to the order
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        // Calculate the total cost of the order, including shipping
        public double GetTotalCost()
        {
            double totalCost = 0;

            // Loop through each product in the order and calculate its total cost
            foreach (Product product in _products)
            {
                totalCost += product.GetTotalCost();
            }

            // Add the correct shipping cost to the total cost of the order based on the customer's address
            // If the customer lives in the USA, the shipping cost is $5. If the customer lives outside of
            // the USA, the shipping cost is $35.
            if (_customer.IsInUSA())
            {
                // Customers in the USA will pay $5 for shipping
                totalCost += 5;
            }
            else
            {
                // Customers outside the USA will pay $35 for shipping
                totalCost += 35;
            }
            return totalCost;
        }

        // Create and return the packaging label for the order, which includes the product name and ID
        public string GetPackagingLabel()
        {
            // Create a heading for the packaging label
            string label = "PACKAGING LABEL\n";

            // Loop through each product in the order and add its information to the label
            foreach (Product product in _products)
            {
                label += $"Product: {product.Name} | ID: {product.ProductId}\n";
            }
            return label;
        }

        // Create and return the shipping label for the order, which includes the customer's name and address
        public string GetShippingLabel()
        {
            // Create a heading for the shipping label
            string label = "SHIPPING LABEL\n";

            // Add the customer's name
            label += $"Customer: {_customer.Name}\n";

            // Add the customer's complete address
            label += _customer.Address.GetAddressingString();
            
            return label;
        }
    }
}