using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user for their first name
        Console.WriteLine();
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Prompt the user for their last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Display the name in the format: lastname, firstname lastname
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}");
        Console.WriteLine();
    }   
}