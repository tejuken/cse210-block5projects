using System;

// The Program class contains the Main method where the program starts running
class Program
{
    static void Main(string[] args)
    {
        // To test constructor 1 - Create a Fraction object using the default constructor that does not have any parameters
        Fraction f1 = new Fraction();

        Console.WriteLine();
        // Display the fraction as a string
        Console.WriteLine(f1.GetFractionString());

        // Display the decimal value of the fraction
        Console.WriteLine(f1.GetDecimalValue());

        // To test constructor 2 - Create a Fraction object using the one-parameter constructor that accepts only the top number
        Fraction f2 = new Fraction(5);

        // Display the fraction as a string
        Console.WriteLine(f2.GetFractionString());

        // Display the decimal value of the fraction
        Console.WriteLine(f2.GetDecimalValue());

        // To test constructor 3 - Create a Fraction object using the two-parameter constructor that accepts both the top and bottom numbers
        Fraction f3 = new Fraction(3, 4);

        // Display the fraction as a string
        Console.WriteLine(f3.GetFractionString());

        // Display the decimal value of the fraction
        Console.WriteLine(f3.GetDecimalValue());

        // Create another fraction using the two-parameter constructor
        Fraction f4 = new Fraction(1, 3);

        // Display the fraction as a string
        Console.WriteLine(f4.GetFractionString());

        // Display the decimal value of the fraction
        Console.WriteLine(f4.GetDecimalValue());

        // Test the setters and getters by creating a new fraction using the default constructor
        Fraction f5 = new Fraction();

        // Use the setter to change the top number from 1 to 6
        f5.SetTop(6);

        // Use the setter to change the bottom number from 1 to 7
        f5.SetBottom(7);

        // Use the getter to retrieve and display the new top value
        Console.WriteLine("Top: " + f5.GetTop());

        // Use the getter to retrieve and display the new bottom value
        Console.WriteLine("Bottom: " + f5.GetBottom());

        // Display the complete fraction
        Console.WriteLine(f5.GetFractionString());

        // Display the decimal value of the fraction
        Console.WriteLine(f5.GetDecimalValue());
        Console.WriteLine();
    }
}