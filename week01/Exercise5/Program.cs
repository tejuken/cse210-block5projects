using System;

class Program
{
    static void Main(string[] args)
    {
        // Show the welcome message by calling the DisplayWelcomeMessage function 
        DisplayWelcomeMessage();

        // Call the PromptUserName function and then save the returned name 
        // in the userName variable
        string userName = PromptUserName();
        
        // Call the PromptUserNumber function and then save the returned number 
        // in the userNumber variable
        int userNumber = PromptUserNumber();

        // Pass the user's number to SquareNumber function, then the squared number 
        // returned by the function will be saved in squareNumber variable
        int squaredNumber = SquareNumber(userNumber);

        // Pass the user's name and squared number to DisplayResult function
        // This is the function that displays the final result
        DisplayResult(userName, squaredNumber);
        Console.WriteLine();
    }
    // Display the welcome message
    static void DisplayWelcomeMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to the program!");
    }
    // Prompt the user for their name and return the name as a string
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        
        // Read the user's name from the keyboard
        string name = Console.ReadLine();

        // Return the name to the main function
        return name;
    }
    // Prompt the user for their favorite number and return the number as an integer
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        
        // Read the user's input and convert it from text to an integer
        int number = int.Parse(Console.ReadLine());

        // Return the number to the main function
        return number;
    }
    // Accept an integer as a parameter and calculate the square of that number
    static int SquareNumber(int number)
    {
        // Multiply the number by itself to find its square
        int square = number * number;
        
        // Return the squared number to the Main function 
        return square;
    }
    // Accept the user's name and squared number to display the final result
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}