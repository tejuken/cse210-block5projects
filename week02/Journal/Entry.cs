using System;

// This represents one journal entry containing information like date, prompt, response and mood that belongs 
// specifically to a single entry
public class Entry
{
    // Create private member variables using _underscoreCamelCase as required by the standard coding system
    private string _date;
    private string _prompt;
    private string _response;
    private string _mood;

    //  Use constructor to create a new Entry object and stores the information supplied by the user in the 
    // member variables
    public Entry(string date, string prompt, string response, string mood)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
    }

    // Displays the information for this journal entry
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine("----------------------------------------");
    }

    // Converts the entry into a line that can be saved to a file
    public string ToFileString()
    {
        // Use the special separator ~|~ to separate the four pieces of information to enable the reconstruction 
        // of entries when loaded from a file
        return $"{_date}~|~{_prompt}~|~{_response}~|~{_mood}";
    }

    // Creates an Entry object from a line loaded from a file 
    public static Entry FromFileString(string line)
    {
        // Split the saved line into separate pieces using the same separator ~|~ used above
        string[] parts = line.Split("~|~");

        // Ensure the saved line contains all the required four pieces of information before attempting to create 
        // the Entry object
        if (parts.Length >= 4)
        {
            return new Entry(
                parts[0],
                parts[1],
                parts[2],
                parts[3]
            );
        }

        // Return null when the line does not contain enough information to create a valid Entry object
        return null;
    }

    // Returns true when the search word or keyword is found in the date, prompt, response or mood
    public bool ContainsKeyword(string keyword)
    {
        // The OrdinalIgnoreCase allows the search to work regardless of letter cases
        return _date.Contains(keyword, StringComparison.OrdinalIgnoreCase)
            || _prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase)
            || _response.Contains(keyword, StringComparison.OrdinalIgnoreCase)
            || _mood.Contains(keyword, StringComparison.OrdinalIgnoreCase);
    }
}