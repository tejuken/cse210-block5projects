using System;
using System.Collections.Generic;

// Use a library to store and manage a collection of scriptures, which is an additional 
// feature beyond the core requirements
class ScriptureLibrary
{
    // Create a private list to hold the available scriptures in the library
    // Store the scriptures in a list to enable their random selection for memorization practices
    private List<Scripture> _scriptures;

    // Store the random number generator to use for selecting a scripture at random from the library
    private Random _random;

    // Create a ScriptureLibrary object using the constructor to initialize the list of scriptures 
    // and the random number generator
    public ScriptureLibrary()
    {
        // Create a list of scriptures to hold the available scriptures in the library
        _scriptures = new List<Scripture>(); 
        // Create the random number generator for selecting a scripture at random from the library
        _random = new Random();

        // Add scriptures to the library
        // Scripture 1
        // Create a Scripture object for the scripture to add to the library using the reference text
        Reference reference1 = new Reference(
            "John",
            3,
            16
        );
        // Create a Scripture object for the scripture to add to the library using the scripture text
        Scripture scripture1 = new Scripture(
            reference1,
            "For God so loved the world that he gave his one and only Son that whoever believes in him shall not perish but have eternal life"
        );
        // Add the scripture to the library
        _scriptures.Add(scripture1);

        // Scripture 2
        // Create a Scripture object for the scripture to add to the library using the reference text
        Reference reference2 = new Reference(
            "Proverbs",
            3,
            5,
            6
        );
        // Store each verse of the scripture text separately
        string verse5 = "Trust in the Lord with all your heart and lean not on your own understanding; ";
        string verse6 = "In all your ways submit to him and he will make your paths straight; ";
     
        // Create a Scripture object for the scripture to add to the library using the scripture text
        Scripture scripture2 = new Scripture(
            reference2,
            verse5 + " | " + verse6
        );
        // Add the scripture to the library
        _scriptures.Add(scripture2);

        // Scripture 3
        // Create a Scripture object for the scripture to add to the library using the reference text
        Reference reference3 = new Reference(
            "2 Chronicles",
            20,
            20
        );
        // Create a Scripture object for the scripture to add to the library using the scripture text
        Scripture scripture3 = new Scripture(
            reference3,
            "Believe in the Lord your God and you shall be established; believe his prophets and you shall prosper"
        );
        // Add the scripture to the library
        _scriptures.Add(scripture3);

        // Scripture 4
        // Create a Scripture object for the scripture to add to the library using the reference text
        Reference reference4 = new Reference(
            "Isaiah",
            62,
            4
        );
        // Create a Scripture object for the scripture to add to the library using the scripture text
        Scripture scripture4 = new Scripture(
            reference4,
            "You shall no longer be termed Forsaken, and your land shall no longer be termed Desolate; " + "but you shall be called Hephzibah, and your land Beulah; " + "for the Lord delights in you, and your land shall be married"
        );
        // Add the scripture to the library
        _scriptures.Add(scripture4);

        // Scripture 5
        // Create a Scripture object for the scripture to add to the library using the reference text
        Reference reference5 = new Reference(
            "Matthew",
            7,
            7,
            8
        );
        // Store each verse of the scripture text separately
        string verse7 = "Ask and it shall be given to you; seek and you shall find; knock and it shall be opened to you. ";
        string verse8 = "For everyone who asks receives, the one who seeks finds, and to the one who knocks, the door will be opened. ";
        
        // Create a Scripture object for the scripture to add to the library using the scripture text
        Scripture scripture5 = new Scripture(
            reference5,
            verse7 + " | " + verse8
        );
        // Add the scripture to the library
        _scriptures.Add(scripture5);
    }
    // Select a scripture randomly from the library to enable memorization practice with different scriptures
    public Scripture GetRandomScripture()
    {
        // Generate a random position in the list of scriptures to select a scripture from the library
        int randomIndex = _random.Next(_scriptures.Count);

        // Return the scripture at the same random position in the list of scriptures
        return _scriptures[randomIndex];
    }
}