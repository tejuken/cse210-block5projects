using System;
using System.Collections.Generic;
using System.IO;

// This manages the collection of journal entries by adding, displaying, saving, loading and 
// searching journal entries
public class Journal
{
    // Create private member variable that will store all journal entries
    // A List<Entry> will allow the journal to store multiple journal entries
    private List<Entry> _entries;

    // Use constructor to create an empty list of entries when a new Journal object is created
    public Journal()
    {
        // Prepares the journal for entries to be added to it 
        _entries = new List<Entry>();
    }

    // Adds a new entry to the journal
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // Display all entries currently stored in the journal
    public void DisplayAll()
    {
        // Check whether the journal contains any entries
        if (_entries.Count == 0)
        {
            // Display a message if the journal is empty
            Console.WriteLine("There are no journal entries to display.");
            return;
        }

        // Display a heading before showing the journal entries
        Console.WriteLine();
        Console.WriteLine("========== MY JOURNAL ==========");

        // Loop through each Entry in the list use Entry class's display method to display its information
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Saves all journal entries to the specified file
    public void SaveToFile(string filename)
    {
        // Use StreamWriter to create or overwrite the specified file to allo the program to write text into it
        using (StreamWriter writer = new StreamWriter(filename))
        {
            // Loop through every Entry in the jounal
            foreach (Entry entry in _entries)
            {
                // Convert the Entry into a file-ready string and write it to the file
                writer.WriteLine(entry.ToFileString());
            }
        }

        // Inform the user the journal has been saved successfully
        Console.WriteLine($"Journal successfully saved to {filename}");
    }

    // Loads journal entries from the specified file, which will replace the existing entries
    public void LoadFromFile(string filename)
    {
        // Check the specified file exists before attempting to read it
        if (!File.Exists(filename))
        {
            Console.WriteLine("The file could not be found.");
            return;
        }

        // Clear the existing entries so that loading does not create duplicates
        _entries.Clear();

        // Read all lines from the specified file into an array
        string[] lines = File.ReadAllLines(filename);

        // Loop through each line from the file
        foreach (string line in lines)
        {
            // Ignore blank lines or whitespace because they do not contain a journal entry
            if (!string.IsNullOrWhiteSpace(line))
            {
                // Convert the saved line back into an Entry object
                Entry entry = Entry.FromFileString(line);

                // Add the Entry only if the line contained vald entry information
                if (entry != null)
                {
                    _entries.Add(entry);
                }
            }
        }

        // Inform the user the journal has been loaded successfully
        Console.WriteLine($"Journal successfully loaded from {filename}");
    }

    // Additional requirement using Searc mehtod searches all journal entries for the supplied keyword
    // Determine whether the keyword appears in an entry
    public void Search(string keyword)
    {
        // Create a varaiable that keeps track of whether at least one matching entry was found
        bool found = false;

        // Display a heading showing the keyword being searched for
        Console.WriteLine();
        Console.WriteLine($"========== SEARCH RESULTS FOR: {keyword} ==========");

        // Loop through every Entry in the journal
        foreach (Entry entry in _entries)
        {
            // Display the entry if the keyword is found in the Entry
            if (entry.ContainsKeyword(keyword))
            {
                entry.Display();
                found = true;
            }
        }

        // Inform the user if no matching entries were found
        if (!found)
        {
            Console.WriteLine("No entries were found containing that keyword.");
        }
    }
}