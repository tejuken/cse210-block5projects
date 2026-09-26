using System;

// Use the Program class to run the scripture memorization practice program 
class Program
{
    static void Main(string[] args)
    {
        // The additional creativity exceeding requirements added to this program is a ScriptureLibrary class created, 
        // which contains five scriptures that allow the user to practice memorizing different scriptures. For verse range 
        // each verse iscriptures, each verse number with text is displayed separately on a new line. The program also uses 
        // the stretch challenge to randomly select only those words that are not already hidden. And for hidden words, 
        // punctuation does not add to their underscores, it remains visible. 

        // Create a ScriptureLibrary object 
        ScriptureLibrary library = new ScriptureLibrary();

        // Randomly select one scripture from the library
        Scripture scripture = library.GetRandomScripture();

        // Continue displaying and hiding words until all words have been hidden or the user chooses to quit
        while (!scripture.IsCompletelyHidden())
        {
            // Clear the console screen before displaying the scripture
            Console.Clear();

            // Display the current version of the scripture
            Console.WriteLine(scripture.GetDisplayText());

            // Prompt the user to press Enter to hide words or type quit to exit the program
            Console.WriteLine();
            Console.Write("Press Enter to hide words or type 'quit' to exit: ");

            // Get and read the response from the user to determine if they want to continue or quit the program
            string input = Console.ReadLine();

            // Check if the user wants to quit the program by typing "quit" and exit the program
            if (input != null && input.Trim().ToLower() == "quit")
            {
                // Display a thank you message to the user for practicing scripture memorization and exit the program
                Console.WriteLine();
                Console.WriteLine("Thank you for practicing scripture memorization. Goodbye!");
                Console.WriteLine();
                return;
            }
            // If the user presses Enter without typing "quit", hide two random words that have not already been hidden 
            // from the scripture text
            else if (input == "")
            {
                scripture.HideRandomWords(2);
            }
        }
        // Clear the console for the final display of the scripture with all words hidden
        Console.Clear();

        // Display the scripture with all words hidden to show the user that the scripture memorization practice is complete
        Console.WriteLine(scripture.GetDisplayText());

        // Display a message to the user that all words are hidden and a thank you message for practicing scripture memorization
        Console.WriteLine();
        Console.WriteLine("All words are hidden. Thank you for practicing!");
        Console.WriteLine();
    }
}