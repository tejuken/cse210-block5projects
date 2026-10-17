#nullable enable
using System;

// Use System.Diagnostics to access the Stopwatch class for accurate elapsed time measurement 
using System.Diagnostics;

// Use System.Threading to access the Thread.Sleep method for or animation delays
using System.Threading;

// Use abstract base class to manage the attributes and behaviors that will be shared by all activities
// It demonstrate abstraction, encapsulation, and inheritance by keeping common functionalities in one place
public abstract class Activity
{
    // Create private fields to store shared information for all activities
    // Store the activity name for the user to see when viewing the activity   
    private string _name;

    // Store the activity description for the user to see when viewing the activity
    private string _description;

    // Store the requested activity duration (secs) for the user to see when viewing the activity
    private int _duration;

    // Give the derived classes read-only access to the private fields for the Activity class
    // Provide read-only access to the activity name for derived classes to use
    protected string ActivityName => _name;
    
    // Provide read-only access to the activity description for derived classes to use
    protected string Description => _description;
    
    // Reveal the selected activity duration for derived classes without external modification   
    public int Duration => _duration;

    // Create an Activity object using constructor that receives the activity name and description
    public Activity(string name, string description)
    {
        // Store the activity name provided by the user in the private fields for the Activity class
        _name = name;

        // Store the activity description provided by the user in the private fields for the Activity class
        _description = description;

        // Create a default duration of 0 seconds for the activity in the private fields for the Activity class
        _duration = 0;
    }

    // Allow each derived activity to implement its own version of the RunActivity method to begin the activity     
    public abstract void Run();

    // Display the common introduction and collects the duration
    protected void DisplayStartingMessage()
    {
        // Clear the console to have a clean screen
        Console.Clear();

        // Display the activity name
        Console.WriteLine($"Welcome to the {_name}");

        // Explain the purpose of the acitivity
        Console.WriteLine();
        Console.WriteLine(_description);

        Console.WriteLine();

        // Loop through until the user enters a positive whole number duration
        while (true)
        {
            // Request for the desired activity duration
            Console.Write("How long (in seconds) would you like for your session? ");

            // Read the user's response
            string? input = Console.ReadLine();
            
            // Create the use of positive whole numbers only
            if (int.TryParse(input, out int duration) && duration > 0)
            {
                // Saves the valid duration
                _duration = duration;

                // Exit the vaidation loop
                break;
            }

            // Inform the user of an invalid input
            Console.WriteLine("Please enter a whole number greater than zero");
        }

        // Clean the screen for a new message
        Console.Clear();

        // Inform the user to prepare for the new message
        Console.WriteLine("Get ready....");

        // Create a 3-secs animated preparation period
        ShowSpinner(3);
    }

    // Display the common finishing message for every activity
    protected void DisplayEndingMessage()
    {
        // Write a message to encourage the User
        Console.WriteLine();
        Console.WriteLine("Well done! You have done a great job!");

        // Use animation delays before the final message
        ShowSpinner(2);

        // Display the selected activity duration
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds"); 

        // Provide a final animated pause
        ShowSpinner(3);
        Console.WriteLine();
    }

    // Display a rotating character animation for the specified duration and erase each 
    // character with backspaces
    protected void ShowSpinner(int seconds)
    {
       // Define the rotating spinner characters
       char[] spinner = { '|', '/', '-', '\\' }; 

       // Commence the pause duration measurement
       Stopwatch timer = Stopwatch.StartNew();

       // Track the current spinner character
       int index = 0;

       // Continue until the pause has elapsed
       while (timer.Elapsed.TotalSeconds < seconds)
        {
            // Display the next spinner character
            Console.Write(spinner[index % spinner.Length]);
        
            // Briefly pause to make the animation visible
            Thread.Sleep(150);
            
            // Erase the character using backspaces
            Console.Write("\b \b"); 

            //Advance the animation
            index++;
        }
    }
    // Display an animated countdown with a one-second pause between numbers, providing 
    // visible feedback while the user waits
    protected void ShowCountdown(int seconds, string message = "")
    {
        // Countdown one second at a time
        for (int remaining = seconds; remaining > 0; remaining--)
        {
            // Replace the current countdown line
            Console.Write($"\r{message}{remaining} ");

            // Wait one second before the next number
            Thread.Sleep(1000);

           // Erase the character using backspaces
            Console.Write("\b \b"); 
        }
        Console.WriteLine();
    }
}