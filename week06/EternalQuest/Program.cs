/*
My Creativity Exceeding Requirements

My player levels and achievement ranks provide additional motivation, the quest status displays the player's current score 
and progress, different goal types support one time, repeatable, and target based goals, my checklist goals award a bonus 
when the completion target is reached, input validation prevents empty names, invalid choices and numbers out of range, 
saving and loading allow the player to continue a quest that runs to new session, goal creation uses inheritance and 
polymorphism by storing different derived goal objects through the common Goal base class.
*/

using System;
// Import System so the program can use Console, StringComparison, and other basic features.

using System.IO;
// Import System.IO so the program can check file paths and handle saving and loading errors.

class Program
// Define the Program class that contains the entry point and menu methods.
{
    // Define the main method where execution of the program begins.
    static void Main(string[] args)
    {
        // Display a decorative line at the top of the application.
        Console.WriteLine("*************************************");

        // Display the name of the application.
        Console.WriteLine("             ETERNAL QUEST");

        // Display the application's motivational slogan.
        Console.WriteLine("       Small actions. Lasting progress.");

        // Display a decorative closing line for the heading.
        Console.WriteLine("======================================");

        // Ask the player to enter a name before starting the quest.
        string playerName = ReadNonEmptyText("Enter your name: ");

        // Create the manager that stores the player's goals and score.
        GoalManager manager = new GoalManager(playerName);

        // Keep the menu running until the player chooses to quit.
        bool keepRunning = true;

        // Start the main menu loop.
        while (keepRunning)
        {
            // Print a blank line to make the menu easier to read.
            Console.WriteLine();

            // Display the player's current score, level, and rank.
            manager.DisplayScore();

            // Display the menu heading.
            Console.WriteLine("\nMenu:");

            // Display the option for creating a goal.
            Console.WriteLine("1. Create a new goal");

            // Display the option for listing goals.
            Console.WriteLine("2. List goals");

            // Display the option for recording a goal event.
            Console.WriteLine("3. Record a goal event");

            // Display the option for saving the quest.
            Console.WriteLine("4. Save quest");

            // Display the option for loading a saved quest.
            Console.WriteLine("5. Load quest");

            // Display the option for viewing detailed quest progress.
            Console.WriteLine("6. View quest status");

            // Display the option for leaving the program.
            Console.WriteLine("7. Quit");

            // Ask the player to choose a menu option.
            Console.Write("Select an option: ");

            // Read the menu choice and safely handle an empty input.
            string choice = Console.ReadLine() ?? string.Empty;

            // Remove surrounding spaces from the player's choice.
            choice = choice.Trim();

            // Create a new goal when the player chooses option one.
            if (choice == "1")
            {
                // Call the method that creates and adds the selected goal.
                CreateGoal(manager);
            }
            // List the player goals when the player chooses option two.
            else if (choice == "2")
            {
                // Display the goals using the GoalManager class.
                manager.DisplayGoals();
            }
            // Record a goal event when the player chooses option three.
            else if (choice == "3")
            {
                // Record an event against one of the existing goals.
                RecordGoal(manager);
            }
            // Save the current quest when the player chooses option four.
            else if (choice == "4")
            {
                // Save the current quest to the default save file.
                SaveQuest(manager);
            }
            // Load a previously saved quest when the player chooses option five.
            else if (choice == "5")
            {
                // Load the quest data from the default save file.
                LoadQuest(manager);
            }
            // Display detailed progress when the player chooses option six.
            else if (choice == "6")
            {
                // Show the player's score, level, rank, and number of goals.
                DisplayQuestStatus(manager);
            }
            // Stop the menu loop when the player chooses option seven.
            else if (choice == "7")
            {
                // Set the loop condition to false so the program can exit.
                keepRunning = false;

                // Display a farewell message before exiting.
                Console.WriteLine("Thank you for playing Eternal Quest!");
            }
            // Handle choices that do not match any available menu option.
            else
            {
                // Inform the player that the menu choice is invalid.
                Console.WriteLine("Invalid choice. Please enter a number from 1 to 7.");
            }
        }
    }

    // Define a method that creates a goal and adds it to the manager.
    private static void CreateGoal(GoalManager manager)
    {
        // Display a blank line and the goal-type heading.
        Console.WriteLine("\nChoose a goal type:");

        // Explain that a simple goal is completed once.
        Console.WriteLine("1. Simple goal — complete once");

        // Explain that an eternal goal can be repeated.
        Console.WriteLine("2. Eternal goal — repeatable and never complete");

        // Explain that a checklist goal requires repeated completions.
        Console.WriteLine("3. Checklist goal — complete a required number of times");

        // Ask the player to choose the type of goal.
        Console.Write("Enter your choice: ");

        // Read the goal type and handle an empty input safely.
        string goalType = (Console.ReadLine() ?? string.Empty).Trim();

        // Check the choice before asking for any additional goal details.
        if (goalType != "1" && goalType != "2" && goalType != "3")
        {
            // Inform the player that the selected goal type is invalid.
            Console.WriteLine("Invalid goal type. Please choose 1, 2, or 3.");

            // Stop this method so an invalid goal is not created.
            return;
        }

        // Ask for a non-empty goal name.
        string name = ReadNonEmptyText("Enter the goal name: ");

        // Ask for a non-empty description of the goal.
        string description = ReadNonEmptyText("Enter the goal description: ");

        // Ask how many points should be awarded for each recording.
        int points = ReadInt("Enter points per recording: ", 1, 1000000);

        // Create a Simple Goal when the player chooses option one.
        if (goalType == "1")
        {
            // Create the correct derived class for a one-time goal.
            SimpleGoal goal = new SimpleGoal(name, description, points);

            // Add the new simple goal to the manager's goal collection.
            manager.AddGoal(goal);

            // Confirm that the simple goal was created.
            Console.WriteLine("Simple goal created successfully.");
        }
        // Create an Eternal Goal when the player chooses option two.
        else if (goalType == "2")
        {
            // Create the correct derived class for a repeatable goal.
            EternalGoal goal = new EternalGoal(name, description, points);

            // Add the new eternal goal to the manager's goal collection.
            manager.AddGoal(goal);

            // Confirm that the eternal goal was created.
            Console.WriteLine("Eternal goal created successfully.");
        }
        // Create a Checklist Goal when the player chooses option three.
        else if (goalType == "3")
        {
            // Ask how many successful recordings are required for completion.
            int targetCount = ReadInt("Enter the required number of completions: ", 1, 1000000);

            // Ask how many bonus points should be awarded when the target is reached.
            int bonus = ReadInt("Enter the completion bonus points: ", 0, 1000000);

            // Create the checklist goal with its target and completion bonus.
            ChecklistGoal goal = new ChecklistGoal(name, description, points, targetCount, bonus);

            // Add the checklist goal to the manager's goal collection.
            manager.AddGoal(goal);

            // Confirm that the checklist goal was created.
            Console.WriteLine("Checklist goal created successfully.");
        }
    }

    // Define a method that lets the player record progress on an existing goal.
    private static void RecordGoal(GoalManager manager)
    {
        // Check whether any goals have been created.
        if (manager.GetGoalCount() == 0)
        {
            // Explain why an event cannot be recorded.
            Console.WriteLine("You have not created any goals yet.");

            // Return to the menu without attempting to record an event.
            return;
        }

        // Display all goals so the player can choose one.
        manager.DisplayGoals();

        // Ask the player to select a goal by its displayed number.
        int goalNumber = ReadInt("Enter the number of the goal to record: ", 1, manager.GetGoalCount());

        // Record the selected goal event once and update the player's score.
        manager.RecordGoalEvent(goalNumber);
    }

    // Define a method that saves the quest to a text file.
    private static void SaveQuest(GoalManager manager)
    {
        // Set the default file name for saving quest data.
        string fileName = "eternal_quest_save.txt";

        // Attempt to save the quest and handle any file-related errors.
        try
        {
            // Call the existing Save method in GoalManager to save the player's information, goals, and score.
            manager.Save(fileName);
        }
        // Catch errors that occur while creating or writing the file.
        catch (Exception ex)
        {
            // Inform the player that saving was unsuccessful.
            Console.WriteLine($"Unable to save the quest: {ex.Message}");
        }
    }

    // Define a method that loads a saved quest from a text file.
    private static void LoadQuest(GoalManager manager)
    {
        // Set the default file name used for loading quest data.
        string fileName = "eternal_quest_save.txt";

        // Check whether the save file exists before loading it.
        if (!File.Exists(fileName))
        {
            // Inform the player that no saved quest file was found.
            Console.WriteLine("No saved quest file was found.");

            // Return to the menu without attempting to load a missing file.
            return;
        }

        // Attempt to load the saved quest and handle any file-related errors.
        try
        {
             // Call the existing Load method in GoalManager to load the player's information, goals, and score.
            manager.Load(fileName);

            // Confirm that the saved quest was loaded.
            Console.WriteLine("Quest loaded successfully.");
        }
        // Catch errors that occur while reading or interpreting the file.
        catch (Exception ex)
        {
            // Inform the player that loading was unsuccessful.
            Console.WriteLine($"Unable to load the quest: {ex.Message}");
        }
    }

    // Define a method that displays a summary of the player's quest.
    private static void DisplayQuestStatus(GoalManager manager)
    {
        // Display the player's current score, level, and rank.
        manager.DisplayScore();

        // Display the number of goals currently stored by the manager.
        Console.WriteLine($"Goals created: {manager.GetGoalCount()}");

        // Display the goal list and the progress shown by each goal type.
        manager.DisplayGoals();
    }

    // Define a method that reads a non-empty response from the player.
    private static string ReadNonEmptyText(string prompt)
    {
        // Declare a variable to hold the player's response.
        string response = string.Empty;

        // Continue asking until the player supplies non-empty text.
        while (string.IsNullOrWhiteSpace(response))
        {
            // Display the supplied prompt.
            Console.Write(prompt);

            // Read the response and safely handle an empty input.
            response = Console.ReadLine() ?? string.Empty;

            // Remove spaces at the beginning and end of the response.
            response = response.Trim();

            // Check whether the response is still empty.
            if (string.IsNullOrWhiteSpace(response))
            {
                // Ask the player to enter a value.
                Console.WriteLine("This field cannot be empty. Please try again.");
            }
        }

        // Return the validated response to the calling method.
        return response;
    }

    // Define a method that reads an integer within an allowed range.
    private static int ReadInt(string prompt, int minimum, int maximum)
    {
        // Declare a variable that will contain the validated number.
        int number;

        // Continue asking until the player enters a valid number.
        while (true)
        {
            // Display the supplied prompt.
            Console.Write(prompt);

            // Read the response and safely handle an empty input.
            string input = Console.ReadLine() ?? string.Empty;

            // Check whether the response is an integer within the permitted range.
            if (int.TryParse(input, out number) && number >= minimum && number <= maximum)
            {
                // Return the valid integer to the calling method.
                return number;
            }

            // Explain the acceptable numeric range.
            Console.WriteLine($"Please enter a whole number between {minimum} and {maximum}.");
        }
    }
}