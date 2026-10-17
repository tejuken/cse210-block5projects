using System;
// Provide file operations
using System.IO; 
// Provide collection queries
using System.Linq; 

// Use ActivityLog class to manage persistent mindfulness records; for saving and reporting 
// activity history. it seperates file operations from the activity classes, which demonstrates 
// abstraction and keeps each class focused on its own responsibilities
public class ActivityLog 
{
    // Store the private location of the history file
    private readonly string _filePath;

    // Create an ActivityLog Object using constructor that assigns CSV file name so that 
    // activity history can be loaded again when the program is started in the same working directory
    public ActivityLog()
    {
        // Use a CSV file in the application's working directory
        _filePath = "mindfulness-history.csv"; 
    }
    
    // Save a completed session
    public void RecordSession(string activityName, int duration, int itemCount = 0) 
    {
        // Attempt to write the session without crashing the application
        try 
        {
            // Check whether the history file already exists
            bool fileExists = File.Exists(_filePath); 

            // Open (!fileExists) 
            // Write the file in append mode
            using StreamWriter writer = new StreamWriter(_filePath, true); 

            // Add headings when creating the file for the first time
            if (!fileExists || new FileInfo(_filePath).Length == 0)
            {
                // Write the CSV column headings
                writer.WriteLine("Date,Activity,DurationSeconds,ItemsListed"); 
            }
            // Escape quotes in the activity name
            string safeName = activityName.Replace("\"", "\"\""); 
            
            // Record the session
            writer.WriteLine($"\"{DateTime.Now:yyyy-MM-dd HH:mm:ss}\",\"{safeName}\",{duration},{itemCount}"); 
            
            // Confirm successful saving
            Console.WriteLine("Your session has been saved to the activity history");
        }
        // Handle file access or writing errors
        catch (IOException) 
        {
            // Report the problem
            Console.WriteLine("The session could not be saved because of a file access problem"); 
        }
        // Handle insufficient file permissions
        catch (UnauthorizedAccessException) 
        {
            // Inform the user that file access was denied
            Console.WriteLine("The session could not be saved because permission was denied"); 
        }
    }
// Read the saved CSV records and display saved session statistics without requiring the user to keep 
// track of completed sessions manually
    public void ShowStatistics() 
    {
        // Protect the menu from file reading errors
        try 
        {
            // Check whether any history file exists
            if (!File.Exists(_filePath)) 
            {
                // Explain the empty history
                Console.WriteLine("No saved activity history exists yet");
                
                // Return to the caller without attempting to read a missing file
                return; 
            }

            // Read all nonempty records,  while excluding the CSV header
            string[] records = File.ReadAllLines(_filePath).Skip(1).ToArray();

            // Display the statistics heading
            Console.WriteLine();
            Console.WriteLine("***** Mindfulness Statistics *****"); 
            
            // Display the total number of saved sessions
            Console.WriteLine($"Completed sessions: {records.Length}"); 

            // Initialize accumulated duration
            int totalSeconds = 0; 
            
            // Track the number of valid saved sessions
            int validSessions = 0;
            
            // Track breathing sessions
            int breathingSessions = 0; 
            
            // Track reflection sessions
            int reflectionSessions = 0; 
            
            // Track listing sessions
            int listingSessions = 0; 

            // Process each saved CSV record separately
            foreach (string record in records)
            {
                // Split the saved CSV row into columns
                string[] columns = record.Split(',');

                // Skip malformed records
                if (columns.Length < 4) 
                {
                    // Move to the next record
                    continue; 
                }

                // Checks whether the duration is a valid integer
                if (!int.TryParse(columns[2], out int duration))
                {
                    // Move to the next record
                    continue;
                }

                // Add the session duration to the total recorded time
                totalSeconds += duration;

                // Count the valid session
                validSessions++;

                
                // Retrieve the saved activity name  
                string activityName = columns[1];

                // Identify a breathing session
                if (activityName.Equals("Breathing Activity", StringComparison.OrdinalIgnoreCase)) 
                {
                    // Increase the breathing session counter
                    breathingSessions++; 
                }
                // Identify reflection sessions
                else if (activityName.Equals("Reflecting Activity", StringComparison.OrdinalIgnoreCase)) 
                {
                    // Increase the reflection session counter
                    reflectionSessions++; 
                }
                // Identify listing sessions
                else if (activityName.Equals("Listing", StringComparison.OrdinalIgnoreCase))
                {
                    // Increase the listing counter
                    listingSessions++; 
                }
            }

            // Display the statistics heading
            Console.Clear();
            Console.WriteLine("********************************"); 
            // Displays the application title
            Console.WriteLine("      MINDFULNESS STATISTICS    "); 
            // Displays a menu border
            Console.WriteLine("********************************");
            
            // Display the total number of saved sessions
            Console.WriteLine($"Completed sessions: {validSessions}"); 
            // Display the cumulative duration in minutes
            Console.WriteLine($"Total recorded activity time: {totalSeconds} seconds"); 
            Console.WriteLine($"Total recorded time: {totalSeconds / 60.0:F1} minutes");
            
            // Display breathing statistics
            Console.WriteLine($"Breathing sessions: {breathingSessions}"); 
            // Display reflection statistics
            Console.WriteLine($"Reflection sessions: {reflectionSessions}");
            // Display listing statistics
            Console.WriteLine($"Listing sessions: {listingSessions}");
            // Displays the closing border
            Console.WriteLine("**********************************");
        }
        // Handle file reading problems
        catch (IOException) 
        {
            // Report the failure to read the history file
            Console.WriteLine("The activity history could not be read");
        }
        // Handle file permission errors
        catch (UnauthorizedAccessException)
        {
            // Report the file permission issue
            Console.WriteLine("Permission was denied when reading the activity history");
        }
    }
     // Parse a CSV record while respecting quotation marks, so commas inside quoted fields 
     // do not accidentally split a column
    private List<string> ParseCsvRecord(string record)
    {
        // Create a collection to hold the parsed fields
        List<string> fields = new List<string>();
        
        // Build the current field character by character
        System.Text.StringBuilder currentField = new System.Text.StringBuilder();

         // Track whether the parser is currently inside quotation marks
        bool insideQuotes = false;

        // Examine each character in the CSV record
        for (int index = 0; index < record.Length; index++)
        {
            // Retrieve the current character
            char currentCharacter = record[index];

            // Check whether the current character is a quotation mark
            if (currentCharacter == '"')
            {
                // Detect an escaped quotation mark inside a quoted field
                if (insideQuotes &&
                    index + 1 < record.Length &&
                    record[index + 1] == '"')
                {
                    // Append the actual quotation mark to the field
                    currentField.Append('"');
                    
                    // Skip the second quotation mark of the escaped pair
                    index++;
                }
                else
                {
                    // Toggles the quoted field state
                    insideQuotes = !insideQuotes;
                }
            }

            // Treats a comma as a separator only outside quoted fields
            else if (currentCharacter == ',' && !insideQuotes)
            {
                // Saves the completed field
                fields.Add(currentField.ToString());

                // Clear the field builder for the next column
                currentField.Clear();
            }
            // Appends all ordinary characters to the current field
            else
            {
                // Preserve the current character
                currentField.Append(currentCharacter);
            }
        }

        // Adds the final field after the loop finishes
        fields.Add(currentField.ToString());

        // Returns all parsed CSV fields
        return fields;
    }
}