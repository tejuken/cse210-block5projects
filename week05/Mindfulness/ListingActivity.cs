using System;
// Provide the prompt list
using System.Collections.Generic; 
// Provide Stopwatch for timing
using System.Diagnostics; 
// Provide Thread.Sleep for short polling pauses
using System.Threading; 

// Use the ListingActivity class to implement the listing exercise and inherit shared activity features
public class ListingActivity : Activity 
{
    // Create private fields to store prompts and item count, while inheriting shared activity behavior 
    // from the Activity base class
    // Store the listing prompts privately
    private readonly List<string> _prompts; 

    // Select random prompts
    private readonly Random _random; 

    // Track the number of submitted items
    private int _itemCount; 

    // Create a ListingActivity object using constructor that will prompt collection and the random number generator
    public ListingActivity()
        // Supply shared activity information
        : base(
            // Set the activity name
            "Listing Activity",
            // Sets the description
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area")
    {
        // Initialize random selection
        _random = new Random(); 

        // Initialize the item counter
        _itemCount = 0; 

        // Creates a collection of positive-thinking prompts
        _prompts = new List<string> 
        {
            // Encourage grat itudefor other people
            "Who are people that you appreciate?", 
            // Encourage self-awareness
            "What are personal strengths of yours?", 
            // Encourage reflection on kindness
            "Who are people that you have helped this week?", 
            // Encourage reflection on meaningful experiences
            "When have you felt a sense of spiritual peace this month?", 
            // Encourage appreciation
            "Who are some of your personal heroes?" 
        };
    }

    // Run the listing exercise and report the number of submitted items
    public override void Run() 
    {
         // Display the shared introduction and obtains the duration
        DisplayStartingMessage();

        // Select one prompt for this session
        string prompt = GetRandomPrompt();

        // Introduce the listing task
        Console.WriteLine();

        // Explain what the user should do
        Console.WriteLine("List as many responses as you can to this prompt:");

        // Add spacing before the selected prompt
        Console.WriteLine();

        // Displays the selected prompt exactly once
        Console.WriteLine(prompt);

        // Add spacing before the preparation message
        Console.WriteLine();

        // Give the user a short opportunity to think
        Console.WriteLine("Take a moment to think about your answers");

        // Display a five second preparation countdown
        ShowCountDown(5, "Starting in: ");

        // Explain how to enter responses
        Console.WriteLine("Enter one item per line and press Enter after each item");

        // Explain how blank responses are handled
        Console.WriteLine("Empty entries are skipped");

        // Announce the beginning of the timed exercise
        Console.WriteLine("Your timed listing session starts now");

        // Reset the count and collects entries until time expires
        Console.WriteLine();
        GetListFromUser();

        // Display the number of entries collected
        Console.WriteLine();

        // Display the number of items entered by the user
        Console.WriteLine($"You listed {_itemCount} item(s).");

        // Display the common ending message inherited from Activity
         DisplayEndingMessage();
    }

    // Show a countdown timer before the activity begins
    private void ShowCountDown(int seconds, string message)
    {
        // Start the countdown at the specified number of seconds and decrease by one each time
        for (int i = seconds; i > 0; i--)
        {
            // Display the message followed by the current countdown number on the console
            Console.Write($"{message}{i}");
            
            // Pause the program for one second before displaying the next number
            Thread.Sleep(1000);
            
            // Return the cursor to the beginning of the current line for the next countdown number
            Console.Write("\r");
        }
        
        // Move the cursor to the next line after the countdown finishes
        Console.WriteLine();
    }

    // Return one randomly selected prompt from the collection
    private string GetRandomPrompt()
    {
        // Generate a valid index within the prompt collection
        int index = _random.Next(_prompts.Count);

        // Return the selected prompt
        return _prompts[index];
    }

    // Collect typed responses until the activity duration expires
    private void GetListFromUser()
    {
        // Reset the number of responses for the current session
        _itemCount = 0;

        // Store the response currently being typed
        string currentItem = "";

        // Start measuring the timed entry period
        Stopwatch timer = Stopwatch.StartNew();

        // Continue accepting input until the requested time expires
        while (timer.Elapsed.TotalSeconds < Duration)
        {
            // Calculate the remaining entry time
            double remaining = Math.Max(
                0,
                Duration - timer.Elapsed.TotalSeconds);

            // Create a status line showing the timer, count, and current entry
            string status =
                $"Time left: {Math.Ceiling(remaining),3:0}s | " +
                $"Items: {_itemCount,3} | Type: {currentItem}";

            // Refreshe the status line without continually scrolling
            Console.Write("\r" + status.PadRight(110));

            // Check whether a key is waiting in the interactive terminal
            if (Console.KeyAvailable)
            {
                // Read a key without displaying it twice
                ConsoleKeyInfo key = Console.ReadKey(true);

                // Submit the current entry when Enter is pressed
                if (key.Key == ConsoleKey.Enter)
                {
                    // Count only entries that contain non-whitespace text
                    if (!string.IsNullOrWhiteSpace(currentItem))
                    {
                        // Increase the submitted entry counter
                        _itemCount++;
                    }

                    // Clear the entry buffer for the next response
                    currentItem = "";
                }
                // Handle deletion of the previous character
                else if (key.Key == ConsoleKey.Backspace)
                {
                    // Remove the final character when the entry is not empty
                    if (currentItem.Length > 0)
                    {
                        // Keeps every character except the last one
                        currentItem = currentItem[..^1];
                    }
                }
                // Accept ordinary printable characters
                else if (!char.IsControl(key.KeyChar))
                {
                    // Append the typed character to the current entry
                    currentItem += key.KeyChar;
                }
            }
            // Avoid continuously polling the keyboard at full speed
            else
            {
                // Pauses briefly before checking for input again
                Thread.Sleep(40);
            }
        }

        // Count a non-empty entry still being typed when time expires
        if (!string.IsNullOrWhiteSpace(currentItem))
        {
            // Include the unfinished entry in the final count
            _itemCount++;
        }

        // Moves to a new line after the timed input session
        Console.WriteLine();
    }

    // Return the number of entries without exposing the private field
    public int GetItemCount()
    {
        // Provide the count to the activity history feature
        return _itemCount;
    }
}
        

    
