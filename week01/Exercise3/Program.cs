using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine();
        // Create a Random object to generate the magic number as per Requirement 3
        Random randomGenerator = new Random();

        // Create a variable to determine if the user wants to play the game again        
        string playAgain = "yes";

        // Continue the game as long as the user enters "yes"
        while (playAgain.ToLower() == "yes")
        {
            // Generate a random magic number from 1 to 100
            int magicNumber = randomGenerator.Next(1, 101);

            // Keep track of the number of guesses
            int guessCount = 0;

            // Prompt the user for their first guess as per Requirement 1
            Console.Write("Guess the magic number between 1 and 100: ");
            int guess = int.Parse(Console.ReadLine());

            // Count the first guess
            guessCount++;

            // Continue the game while the guess is not the magic number using a while loop
            // as per Requirement 2
            while (guess != magicNumber)
            {
                // Inform the user to guess higher or lower
                if (guess < magicNumber)
                {
                    // For a smaller guess, the program says Higher
                    Console.WriteLine("Higher");
                }
                else
                {
                    // For a larger guess, the program says Lower 
                    Console.WriteLine("Lower");
                }

                // Ask the user for another guess
                Console.Write("Enter another guess: ");
                guess = int.Parse(Console.ReadLine());

                // Count each additional guess
                guessCount++;
            }

            // Tell the user they guessed the magic number correctly.
            Console.WriteLine("You guessed it!");
           
            // Display the number of guesses the user made
            Console.WriteLine($"It took you {guessCount} guesses.");

            // Ask the user if they want to play again
            Console.Write("Would you like to play again? ");
            playAgain = Console.ReadLine();
            Console.WriteLine();
        }

        // Display a message when the user decides to stop playing
        Console.WriteLine("Thanks for playing!");
        Console.WriteLine();
    }
}