
//  Use the OnlineOrdering namespace to display an address for a customer placing an order
namespace OnlineOrdering
{
    // Use the Address class to display the address with its street, city, state and country; 
    // check if the address is in the USA or not and return the complete address 
    public class Address
    {
        // Create private fields to store the street, city, state and country of the address
        // Store the street for the user to see when viewing the address
        private string _street;
        
        // Store the city for the user to see when viewing the address
        private string _city;
        
        // Store the state for the user to see when viewing the address
        private string _state;
        
        // Store the country for the user to see when viewing the address
        private string _country;
        
        // Create Getter and Setter methods for the street of the address to show encapsulation
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        // Create Getter and Setter methods for the city of the address to show encapsulation
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        // Create Getter and Setter methods for the state of the address to show encapsulation
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        // Create Getter and Setter methods for the country of the address to show encapsulation
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        // Create an Address object using constructor that will receive address's member varaiables 
        // and assign values to them for the Address class
        public Address(string street, string city, string state, string country)
        {
            // Store the street provided by the user in the private fields for the Address class
            _street = street;
            
            // Store the city provided by the user in the private fields for the Address class
            _city = city;
            
            // Store the state provided by the user in the private fields for the Address class
            _state = state;
            
            // Store the country provided by the user in the private fields for the Address class
            _country = country;
        }
        
        // Check if the address is in the USA or not
        public bool IsInUSA()
        {
            return _country == "USA";
        }
        
        // Return a formatted string of a complete address's member variables for displaying to user
        // when viewing an address. Newline characters are used to separate the address's member 
        // variables on seperate lines
        public string GetAddressingString()
        {
            return $"{_street}\n{_city}\n{_state}\n{_country}";
        }
    }    
}