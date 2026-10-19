using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// This class manages the user's goals, score, progress, and saved quest.
public class GoalManager
{
    // Store all goal types through the common Goal base class.
    private List<Goal> _goals;

    // Store the user's total accumulated points.
    private int _score;

    // Store the player's name for personalized messages.
    private string _playerName;

    // Initialize the goal list, score, and player name.
    public GoalManager(string playerName = "Quest Champion")
    {
        // Create an empty list that can contain any derived Goal type.
        _goals = new List<Goal>();

        // Start the score at zero.
        _score = 0;

        // Use the supplied name or a default when the name is blank.
        _playerName = string.IsNullOrWhiteSpace(playerName)
            ? "Quest Champion"
            : playerName.Trim();
    }

    // Return the current total score.
    public int GetScore()
    {
        // Provide the score without exposing the private field.
        return _score;
    }

    // Return the number of goals currently stored.
    public int GetGoalCount()
    {
        // Return the number of goals in the list.
        return _goals.Count;
    }

    // Calculate the player's level using the total score.
    public int GetLevel()
    {
        // Award one level for every 500 points, beginning at level one.
        return (_score / 500) + 1;
    }

    // Determine the player's achievement title from their level.
    public string GetRank()
    {
        // Give a beginner title to players at level one.
        if (GetLevel() == 1)
        {
            // Return the starting achievement title.
            return "Quest Beginner";
        }

        // Give a developing title to players below level five.
        if (GetLevel() < 5)
        {
            // Return the intermediate achievement title.
            return "Faithful Striver";
        }

        // Give an advanced title to players below level ten.
        if (GetLevel() < 10)
        {
            // Return the advanced achievement title.
            return "Quest Guardian";
        }

        // Return the highest title for level ten and above.
        return "Eternal Legend";
    }

    // Add a new goal to the user's collection.
    public void AddGoal(Goal goal)
    {
        // Reject a null reference to prevent invalid entries.
        if (goal == null)
        {
            // Exit without changing the collection.
            return;
        }

        // Add the supplied goal to the collection.
        _goals.Add(goal);
    }

    // Display the score, level, and achievement title.
    public void DisplayScore()
    {
        // Display the player's name and current score.
        Console.WriteLine($"\nPlayer: {_playerName}");

        // Display the current level and achievement title.
        Console.WriteLine($"Level {GetLevel()} — {GetRank()}");

        // Display the total points earned so far.
        Console.WriteLine($"Total score: {_score}");
    }

    // Display every goal and its current completion state or progress.
    public void DisplayGoals()
    {
        // Check whether the user has created any goals.
        if (_goals.Count == 0)
        {
            // Explain that the goal list is empty.
            Console.WriteLine("You have not created any goals yet.");

            // Exit because there is nothing to display.
            return;
        }

        // Display a heading before the list.
        Console.WriteLine("\nYour Goals:");

        // Visit each goal in the collection.
        for (int index = 0; index < _goals.Count; index++)
        {
            // Use polymorphism to display the correct details for each goal type.
            Console.WriteLine($"{index + 1}. {_goals[index].GetDetailsString()}");
        }
        // Add a blank line after the goal list for readability
        Console.WriteLine();
    }

    // Record an event for the selected goal and update the total score.
    public bool RecordGoalEvent(int goalNumber)
    {
        // Validate that the selected number identifies an existing goal.
        if (goalNumber < 1 || goalNumber > _goals.Count)
        {
            // Inform the user that the selected number is invalid.
            Console.WriteLine("That goal number is not valid.");

            // Report that no event was recorded.
            return false;
        }

        // Retrieve the selected goal using its one-based menu number.
        Goal selectedGoal = _goals[goalNumber - 1];

        // Let the actual goal type decide how many points the event earns.
        int pointsEarned = selectedGoal.RecordEvent();

        // Check whether the goal awarded no points.
        if (pointsEarned == 0)
        {
            // Explain that the goal may already be complete or award zero points.
            Console.WriteLine("No points were awarded for this recording.");

            // Report that no points were added.
            return false;
        }

        // Add the earned points to the total score.
        _score += pointsEarned;

        // Celebrate the user's progress.
        Console.WriteLine($"Well done, {_playerName}! You earned {pointsEarned} points.");

        // Display the updated score and achievement level.
        DisplayScore();

        // Confirm that the event was successfully recorded.
        return true;
    }

    // Save the player's name, score, goals, and progress to a text file.
    public void Save(string filename)
    {
        // Open the file for writing and ensure it closes automatically.
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // Write a format marker so the loader can recognize this save format.
            outputFile.WriteLine("EternalQuestSaveV1");

            // Encode the player's name to protect special characters.
            outputFile.WriteLine(EncodeForFile(_playerName));

            // Save the user's total score.
            outputFile.WriteLine(_score);

            // Save the number of goal records.
            outputFile.WriteLine(_goals.Count);

            // Visit every goal in the collection.
            foreach (Goal goal in _goals)
            {
                // Call the goal's overridden save method to serialize its specific data.
                outputFile.WriteLine(goal.GetSaveString());
            }
        }

        // Tell the user where the quest was saved.
        Console.WriteLine($"Quest saved to: {Path.GetFullPath(filename)}");
    }

    // Load the player's saved name, score, goals, and progress.
    public bool Load(string filename)
    {
        // Verify that the requested file exists.
        if (!File.Exists(filename))
        {
            // Explain why loading cannot proceed.
            Console.WriteLine("Save file not found.");

            // Report that loading failed.
            return false;
        }

        // Handle malformed data and file errors without terminating the application.
        try
        {
            // Read the saved file into an array of lines.
            string[] lines = File.ReadAllLines(filename);

            // Verify that the file has the expected header and basic structure.
            if (lines.Length < 4 || lines[0] != "EternalQuestSaveV1")
            {
                // Explain that the file is not in the expected format.
                Console.WriteLine("The save file is invalid or unsupported.");

                // Stop because the data cannot safely be loaded.
                return false;
            }

            // Decode the player's saved name.
            string loadedName = DecodeFromFile(lines[1]);

            // Convert the saved score into an integer.
            int loadedScore = int.Parse(lines[2]);

            // Convert the saved goal count into an integer.
            int goalCount = int.Parse(lines[3]);

            // Reject negative values and incomplete files.
            if (loadedScore < 0 || goalCount < 0 || lines.Length != 4 + goalCount)
            {
                // Explain that the saved data is inconsistent.
                Console.WriteLine("The save file contains invalid or incomplete data.");

                // Stop before replacing the current quest.
                return false;
            }

            // Create a temporary collection to hold reconstructed goals.
            List<Goal> loadedGoals = new List<Goal>();

            // Process each saved goal record.
            for (int index = 0; index < goalCount; index++)
            {
                // Split the record into fields using the pipe separator.
                string[] parts = lines[index + 4].Split('|');

                // Reconstruct a simple goal when its type marker is Simple.
                if (parts[0] == "Simple" && parts.Length == 5)
                {
                    // Decode the saved name and description.
                    string name = DecodeFromFile(parts[1]);
                    string description = DecodeFromFile(parts[2]);

                    // Parse the saved points and completion state.
                    int points = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);

                    // Add the reconstructed simple goal to the temporary collection.
                    loadedGoals.Add(new SimpleGoal(name, description, points, isComplete));
                }
                // Reconstruct an eternal goal when its type marker is Eternal.
                else if (parts[0] == "Eternal" && parts.Length == 4)
                {
                    // Decode the saved name and description.
                    string name = DecodeFromFile(parts[1]);
                    string description = DecodeFromFile(parts[2]);

                    // Parse the saved points per recording.
                    int points = int.Parse(parts[3]);

                    // Add the reconstructed eternal goal to the temporary collection.
                    loadedGoals.Add(new EternalGoal(name, description, points));
                }
                // Reconstruct a checklist goal when its type marker is Checklist.
                else if (parts[0] == "Checklist" && parts.Length == 7)
                {
                    // Decode the saved name and description.
                    string name = DecodeFromFile(parts[1]);
                    string description = DecodeFromFile(parts[2]);

                    // Parse the saved points, target, bonus, and current progress.
                    int points = int.Parse(parts[3]);
                    int targetCount = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    int amountCompleted = int.Parse(parts[6]);

                    // Reject invalid checklist values rather than silently changing saved data.
                    if (points < 0 || targetCount < 1 || bonus < 0 ||
                        amountCompleted < 0 || amountCompleted > targetCount)
                    {
                        // Report that the checklist record is invalid.
                        Console.WriteLine("The save file contains invalid checklist progress.");

                        // Stop before replacing the current quest.
                        return false;
                    }

                    // Add the reconstructed checklist goal to the temporary collection.
                    loadedGoals.Add(new ChecklistGoal(
                        name,
                        description,
                        points,
                        targetCount,
                        bonus,
                        amountCompleted));
                }
                // Handle an unknown goal type or incorrect field count.
                else
                {
                    // Identify the record that could not be reconstructed.
                    Console.WriteLine($"Invalid goal record at item {index + 1}.");

                    // Stop without replacing the current quest.
                    return false;
                }
            }

            // Replace the current collection only after all records load successfully.
            _goals = loadedGoals;

            // Restore the total score from the saved file.
            _score = loadedScore;

            // Restore the saved player name or use a default if it is blank.
            _playerName = string.IsNullOrWhiteSpace(loadedName)
                ? "Quest Champion"
                : loadedName;

            // Confirm that the saved quest has been restored.
            Console.WriteLine($"Welcome back, {_playerName}! Your quest has been loaded.");

            // Display the restored score and level.
            DisplayScore();

            // Report successful loading.
            return true;
        }
        // Catch errors caused by invalid data or file access problems.
        catch (Exception exception)
        {
            // Display the error message to help diagnose the problem.
            Console.WriteLine($"Unable to load the save file: {exception.Message}");

            // Report that loading did not succeed.
            return false;
        }
    }

    // Encode a text value for storage in the save file.
    private static string EncodeForFile(string value)
    {
        // Convert the text to Base64 using UTF-8 encoding.
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
    }

    // Decode a text value previously encoded for storage.
    private static string DecodeFromFile(string value)
    {
        // Convert Base64 data back into UTF-8 text.
        return Encoding.UTF8.GetString(Convert.FromBase64String(value));
    }
}