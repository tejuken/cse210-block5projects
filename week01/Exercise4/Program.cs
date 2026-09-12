using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
       // Create a list to store the numbers entered by the user
        List<int> numbers = new List<int>();
        
        // Create a variable to store each number entered by the user
        int userNumber = -1;
        
        Console.WriteLine();
        // Ask the user to continue entering numbers until they enter 0
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        while (userNumber != 0)
        {
            // Ask the user to enter a number
            Console.Write("Enter a number: ");
            
            // Read the user's response and convert to an integer
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);
            
            // Only add the number to the list if it is not 0
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // To prevent output error when zero is the only number entered,
        // Check if the user entered at least one number
        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered");
            Console.WriteLine();
            return;
        }

        // Requirement 1: Compute the sum
        // Create a variable to store the total of all the numbers
        int sum = 0;
       
        // Go through each number in the list and add to the sum
        foreach (int number in numbers)
        {
            sum += number;
        }

        // Display the sum
        Console.WriteLine($"The sum is: {sum}");

        // Requirement 2: Compute the average
        // Convert the sum to double prior to dividing to allow the answer contain the 
        // desired decimal places
        double average = ((double)sum) / numbers.Count;
    
        // Display the average
        Console.WriteLine($"The average is: {average}");

        // Requirement 3: Find the largest number
        // There are several ways to do this; assume the first number is the largest
        int max = numbers[0];

        // Check every number in the list
        foreach (int number in numbers)
        {
            // If the current number on the list is greater than maximum, make it the new largest number
            if (number > max)
            {
                // if this number is greater than the max, we have found the new maximum
                max = number;
            }
        }

        // Display the largest number
        Console.WriteLine($"The largest number is: {max}");
    
        // Stretch Challenge 1: Find the smallest positive number
        // Create a variable to store the smallest positive number
        int smallestPositive = 0;

        // Check every number on the list
        foreach (int number in numbers)
        {
            // Consider numbers greater than 0 only
            if (number > 0)
            {
                // Store the number as the smallest positive number 
                // if this is the first positive number available    
                if (smallestPositive == 0)
                {
                    smallestPositive = number;
                }
            
                // If the current positive number is smaller, then update smallestPositive
                else if (number < smallestPositive)
                {
                    smallestPositive = number;
                }
            }
        }   
        // Display the smallest positive number
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        
        // Stretch challenge 2: Sort the numbers and display the sorted list
        // Sort the numbers from smallest to largest
        numbers.Sort();

        // Display a heading for the sorted list
        Console.WriteLine("The sorted list is:");

        // Go through the sorted list and display each number
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine();
    }
}