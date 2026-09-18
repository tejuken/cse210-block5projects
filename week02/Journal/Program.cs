using System;

// The Program class controls the user interface and starts the journal application
class Program
{
    // This is the Main method and is the starting point of the journal application
    static void Main(string[] args)
    {
        // My additional creativity exceeding basic requirements is that I ensured each journal 
        // entry records the user's mood. I also added to the program a Search Journal 
        // feature that allows users to search their entries by keyword. These features 
        // provide additional information and make the journal more useful for reviewing 
        // past experiences

        // Create a Journal object to manage the collection of journal entries
        Journal journal = new Journal();

        // Create a PromptGenerator object to provide random journal prompts
        PromptGenerator promptGenerator = new PromptGenerator();

        // Control whether the journal menu will continue to be displayed
        bool running = true;

        // Continue displaying the menu until the user chooses the Quit option
        while (running)
        {
            // Display a heading showing journal menu
            Console.WriteLine();
            Console.WriteLine("========== JOURNAL MENU ==========");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Search journal");
            Console.WriteLine("6. Quit");
            Console.Write("Please select an option: ");

            // Read the user's menu selecction
            string choice = Console.ReadLine();

            Console.WriteLine();

            // Call the appropriate method based on the user's menu selction
            if (choice == "1")
            {
                WriteNewEntry(journal, promptGenerator);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                SaveJournal(journal);
            }
            else if (choice == "4")
            {
                LoadJournal(journal);
            }
            else if (choice == "5")
            {
                SearchJournal(journal);
            }
            else if (choice == "6")
            {
                // Display a goodbye message and stop the menu loop
                Console.WriteLine("Thank you for using My Daily Journal!");
                running = false;
            }
            else
            {
                // Inform the user when an option other than 1 - 6 is entered
                Console.WriteLine("Invalid option. Please choose 1-6.");
            }
        }
    }


    // This method creates a new journal entry by obtaining a prompt, collecting the user's response 
    // and mood; and adding the Entry to the Journal
    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        // Get a random prompt from the PromptGenerator class
        string prompt = promptGenerator.GetRandomPrompt();

        // Display a heading showing the new journal entry
        Console.WriteLine("========== NEW JOURNAL ENTRY ==========");
        Console.WriteLine($"Prompt: {prompt}");

        // Ask the user for their response to the selected prompt
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        // Ask the user to record their mood for the journal entry
        Console.Write("How are you feeling today? ");
        string mood = Console.ReadLine();

        // Automatically obtain and format the current date
        string date = DateTime.Now.ToString("MMMM dd, yyyy");

        // Create a new Entry object using the date, prompt, response and mood
        Entry entry = new Entry(date, prompt, response, mood);

        // Add the newly created Entry object to the journal
        journal.AddEntry(entry);

        // Inform the user the entry has been added successfully
        Console.WriteLine();
        Console.WriteLine("Your journal entry has been added successfully.");
    }


    // This method asks the user for a filename and saves the journal entries to the file
    static void SaveJournal(Journal journal)
    {
        // Prompt the user to enter the name of the file where the journal will be saved
        Console.Write("Enter the filename to save your journal: ");
        string filename = Console.ReadLine();

        // Try to save the journal and handle any file-related errors
        try
        {
            journal.SaveToFile(filename);
        }
        catch (Exception ex)
        {
            // Display the error message if the journal cannot be saved
            Console.WriteLine($"The journal could not be saved: {ex.Message}");
        }
    }


    // This method asks the user for a filename and loads the saved journal entries from the file to the Journal object
    static void LoadJournal(Journal journal)
    {
        // Prompt the user to enter the name of the file to load
        Console.Write("Enter the filename to load your journal: ");
        string filename = Console.ReadLine();

        // Try to load the journal and handle any file-related errors
        try
        {
            journal.LoadFromFile(filename);
        }
        catch (Exception ex)
        {
            // Display the error message if the journal cannot be loaded
            Console.WriteLine($"The journal could not be loaded: {ex.Message}");
        }
    }
    

    // This method asks the user for a keyword and searches the journal for entries containing the keyword
    static void SearchJournal(Journal journal)
    {
        // Prompt the user to enter the word or phrase they want to search for
        Console.Write("Enter a keyword to search for: ");
        string keyword = Console.ReadLine();

        // Perform the search only after the user has entered some text
        if (!string.IsNullOrWhiteSpace(keyword))
        {
            // Pass the keyword to the Journal class to perform the search
            journal.Search(keyword);
        }
        else
        {
            // Inform the user that a search word is required
            Console.WriteLine("Please enter a search word.");
        }
    }
}