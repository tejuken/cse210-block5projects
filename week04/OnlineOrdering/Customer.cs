

// Use the OnlineOrdering namespace to display a customer placing an order
namespace OnlineOrdering
{
    // Use the Customer class to display the customer with their name and address
    public class Customer
    {
        // Create private fields for the order's member variables to demonstrate encapaulation
        // Store the customer's name for the user to see when viewing the customer
        private string _name;
        
        // Store the customer's address for the user to see when viewing the customer
        private Address _address;
        
        // Create Getter and Setter methods for the customer's name to show encapsulation
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        // Create Getter and Setter methods for the customer's address to show encapsulation
        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        // Create a Customer object using constructor that receives customer's member 
        // varaiables and assign values to them for the Customer class
        public Customer(string name, Address address)
        {
            // Store the name provided by the user in the private fields for the Customer class
            _name = name;
            
            // Store the address provided by the user in the private fields for the Customer class
            _address = address;
        }
        
        // Check if the customer lives in the USA or not
        public bool IsInUSA()
        {
            return _address.IsInUSA();
        }
    }    
}