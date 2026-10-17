// Creativity Requirements
// I added creativity that exceeds requirements by making this program save completed sessions in a persistent
// CSV history file. I allowed users to view their total completed sessions and recorded activity time. I designed the 
// program statistics to separately track breathing, reflecting and listing sessions. I ensured the Reflection 
// questions are not repeated until the available question pool is used. And I added more prompts and timed animations 
// to make the exercises more engaging. 

using System;
// Use System.Threading to access the Thread.Sleep method for or animation delays
using System.Threading;

public class Program
{
    // Start the application and displays the menu until the user exits
    public static void Main(string[] args)
    {
        // Create the object responsible for recording activity history
        ActivityLog activityLog = new ActivityLog();

        // Control whether the application menu should continue running
        bool running = true;

        // Repeat the menu until the user selects the exit option
        while (running)
        {
            // Clear the console before drawing the menu
            Console.Clear();

            // Display the top border
            Console.WriteLine("**********************************");

            // Display the program title
            Console.WriteLine("       MINDFULNESS PROGRAM        ");

            // Display the bottom border
            Console.WriteLine("**********************************");

            // Offer the breathing exercise
            Console.WriteLine("1. Breathing Activity");

            // Offer the reflection exercise
            Console.WriteLine("2. Reflecting Activity");

            // Offer the listing exercise
            Console.WriteLine("3. Listing Activity");

            // Offer the activity statistics feature
            Console.WriteLine("4. View Activity Statistics");

            // Offer the exit option
            Console.WriteLine("5. Exit");

            // Add spacing before the user's choice.
            Console.WriteLine();

            // Request the menu selection
            Console.Write("Select an option: ");

            // Read the user's menu selection
            string choice = Console.ReadLine() ?? string.Empty;

            // Select the operation corresponding to the user's choice
            switch (choice)
            {
                // Handle the breathing activity option
                case "1":
                {
                    // Create the breathing activity through the base-class type.
                    Activity activity = new BreathingActivity();

                    // Run the breathing exercise
                    activity.Run();

                    // Save the completed breathing session
                    activityLog.RecordSession("Breathing Activity", activity.Duration);

                    // Wait before returning to the main menu
                    ReturnToMenu();

                    // End this switch case
                    break;
                }

                // Handle the reflecting activity option
                case "2":
                {
                    // Create the reflection activity using its correct class name
                    Activity activity = new ReflectionActivity();
                    
                    // Runs the reflection exercise
                    activity.Run();

                    // Save the completed reflecting session
                    activityLog.RecordSession("Reflecting Activity", activity.Duration);

                    // Wait before returning to the main menu
                    ReturnToMenu();

                    // End this switch case
                    break;
                }

                // Handle the listing activity option
                case "3":
                {
                    // Create the listing activity through the base class type
                    Activity activity = new ListingActivity();

                    // Run the listing exercise
                    activity.Run();

                    // Retrieve the count from the concrete listing activity
                    int itemCount = ((ListingActivity)activity).GetItemCount();

                    // Save the duration and the number of listed items
                    activityLog.RecordSession("Listing Activity", activity.Duration, itemCount);

                    // Wait before returning to the main menu
                    ReturnToMenu();

                    // End this switch case
                    break;
                }

                // Handle the statistics option
                case "4":
                {
                    // Display the saved activity statistics
                    activityLog.ShowStatistics();

                    // Wait before returning to the main menu
                    ReturnToMenu();

                    // End this switch case
                    break;
                }

                // Handle the exit option
                case "5":
                {
                    // Stop the menu loop
                    running = false;

                    // Thank the user for participating
                    Console.WriteLine("Thank you for practicing mindfulness");

                    // Provide a friendly closing message
                    Console.WriteLine(
                        "Take a peaceful moment with you into the rest of your day");

                    // End this switch case
                    break;
                }

                // Handle invalid or unrecognized menu selections
                default:
                {
                    // Explain the valid menu options
                    Console.WriteLine(
                        "Invalid choice. Please select a number from 1 to 5");

                    // Pause briefly before the menu is displayed again
                    Thread.Sleep(1200);

                    // End the default switch case
                    break;
                }
            }
        }
    }

    // Pause after an activity or statistics display before returning to the menu
    private static void ReturnToMenu()
    {
        // Add a blank line for readability
        Console.WriteLine();

        // Request confirmation before returning
        Console.Write("Press Enter to return to the main menu");

        // Wait for the user to press Enter
        Console.ReadLine();
    }
}