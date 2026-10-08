

// Use the OnlineOrdering namespace to display a product being purchased 
namespace  OnlineOrdering
{
    // Use the Product class to display the product with its name, Id, price per unit, 
    // quantity and claculate the total cost for the product
    public class Product
    {
        // Create private fields to store the name, Id, price and quantity of the product
        // Store the product name for the user to see when viewing the product
        private string _name;
        
        // Store the product Id for the user to see when viewing the product
        private string _productId;
        
        // Store the product price for the user to see when viewing the product
        private double _price;
        
        // Store the product quantity for the user to see when viewing the product
        private int _quantity;

        // Create Getter and Setter methods for the product'name to show encapsulation
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Create Getter and Setter methods for the product's ID' to show encapsulation
        public string ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        // Create Getter and Setter methods for the price per unit of the product to show encapsulation
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        // Create Getter and Setter methods for the quantity of the product to show encapsulation
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        // Create a Product object using constructor that receives product's member 
        // varaiables and assign values to them for the Product class
        public Product(string name, string productId, double price, int quantity)
        {
            // Store the name provided by the user in the private fields for the Product class
            _name = name;
            
            // Store the productId provided by the user in the private fields for the Product class
            _productId = productId;
            
            // Store the price provided by the user in the private fields for the Product class
            _price = price;
            
            // Store the quantity provided by the user in the private fields for the Product class
            _quantity = quantity;
        }
        // Calculate and return the total cost for the product
        // Total cost = price per unit * quantity
        public double GetTotalCost()
        {
            return _price * _quantity;
        }
    }    
}