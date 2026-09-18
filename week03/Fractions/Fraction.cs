using System;

// The Fraction class represents a mathematical fraction, such as 3/4 or 5/1
class Fraction
{
    // Define the attributes (fields) of the Fraction class , which are private to demonstrate encapsulation
    
    // The top number is the numerator
    private int _top;

    // The bottom number is the denominator
    private int _bottom;

    // Create the default constructor that does not receive any parameters. This initializes the fraction to 1/1.
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Create a Fraction object using the one-parameter constructor that receives only the top number
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Create a Fraction object using the two-parameter constructor that receives both the top and bottom numbers
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Get getter and setter for the top number
    // Getter returns the current value of the top number
    public int GetTop()
    {
        return _top;
    }

    // Setter changes the value of the top number
    public void SetTop(int top)
    {
        _top = top;
    }

    // Get getter and setter for the bottom number
     // Getter returns the current value of the bottom number
    public int GetBottom()
    {
        return _bottom;
    }

    // Setter changes the value of the bottom number
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Return the fraction as a string
    public string GetFractionString()
    {
        // Return the fraction as a string
        return $"{_top}/{_bottom}";
    }

    // Get decimal value of the fraction
    public double GetDecimalValue()
    {
        // Return the decimal value of the fraction
        return (double)_top / _bottom;
    }
}