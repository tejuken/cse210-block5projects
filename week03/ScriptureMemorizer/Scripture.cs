using System;
using System.Collections.Generic;

// Use the Scripture class to display and hide words for scripture memorization practice
class Scripture
{
    // Create private fields using the principles of encapsulation for the Scripture class
    // Store the scripture reference for the user to see when practicing memorization
    private Reference _reference;

    // Store all the individual words in the scripture text as Word objects in a list to enable hiding of separate words
    private List<Word> _words;
    // Store the position where each verse ends to display each verse separately
    private List<int> _verseBreaks;

    // Select words randomly to hide them from the scripture text to enable scripture memorization practice 
    private Random _random;

    // Create a Scripture object using constructor that receives a Reference object and the scripture text as a string
    public Scripture(Reference reference, string text)
    {
        // Store the reference provided by the user in the private field for the Scripture class
        _reference = reference;

        // Create a list to hold the words in the scripture text as Word objects
        _words = new List<Word>();

        // Create a list to store the positions where each verse ends to display each verse separately
        _verseBreaks = new List<int>();

        // Create the random number generator to use for selecting words to hide from the scripture text
        _random = new Random();

        // Divide the scripture text into separate verses using the '|' symbol as a delimiter
        string[] verses = text.Split('|', StringSplitOptions.RemoveEmptyEntries);

        // Loop through each verse in the scripture text separately
        foreach (string verse in verses)
        {
           // Divide the current verse into separate words using spaces as delimiters
            string[] words = verse.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Create a Word object for each word in the current verse and add it to the list of words 
            // in the scripture text
            foreach (string word in words)
            {
                // Add the Word object to the list of words in the scripture text
                _words.Add(new Word(word));
            }
            // Store the position where the current verse ends to display each verse separately
            _verseBreaks.Add(_words.Count);                                         
        }
    }
    // Display the full scripture text to the user with unhidden reference and words
    public string GetDisplayText()
    {
        // Create a new list that will store the displayed verses for the scripture text
        List<string> displayedVerses = new List<string>();

        // Track the starting index for each verse in the scripture text to display each verse separately
        int startIndex = 0;

        // Get the starting verse number from the Reference object to display each verse separately in the scripture text
        int verseNumber = _reference.GetStartVerse();

        // Loop through every position a verse ends in the scripture text to display each verse separately
        foreach (int endIndex in _verseBreaks)
        {
            // Create a new list to store the displayed words for the current verse
            List<string> verseWords = new List<string>();

            // Loop through every word in the current verse to get its display text
            for (int i = startIndex; i < endIndex; i++)
            {
                // Get the appropriate displayed text for each word in the current verse
                verseWords.Add(_words[i].GetDisplayText());
            }
            // Join all the words together with spaces to create the current verse number before the text
            displayedVerses.Add($"Verse {verseNumber}: {string.Join(" ", verseWords)}");

            // Update the starting index for the next verse in the scripture text
            startIndex = endIndex;

            // Move to the next verse number in the scripture text
            verseNumber++;
        }
        // Join all the verses together with line breaks to create the scripture text to display to the user    
        string scriptureText = string.Join(Environment.NewLine, displayedVerses);
        
        // Return the reference and then the numbered verses on separate lines to display to the user
        return $"{_reference.GetDisplayText()}{Environment.NewLine}{scriptureText}";
    }
    // Hide a random number of words from the scripture text to enable memorization practice
    public void HideRandomWords(int numberToHide)
    {
        // Create a list containing only words that are still visible to the user
        List<Word> visibleWords = new List<Word>();

        // Loop through every Word object in the scripture text to check if it is hidden or not
        foreach (Word word in _words)
        {
            // Add the word to the list only if it is not hidden
            if (!word.IsHidden())
            {
                // Add the word to the list of visible words to enable random selection of words to hide
                visibleWords.Add(word);
            }
        }
        // Fix or control the number of words that can be hidden to prevent the program from hiding more 
        // words than are available
        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);

        // Hide the selected number of words currently visible in the scripture text
        for (int i = 0; i < wordsToHide; i++)
        {
            // Select a random index from the remaining visible words to hide a word from the scripture text
            int randomIndex = _random.Next(visibleWords.Count);

            // Get the word selected at random index from the list of visible words 
            Word selectedWord = visibleWords[randomIndex];

            // Hide the selected word to change its display text to underscores, which must match the number 
            // of letters in the original word
            selectedWord.Hide();

            // Remove the selected word from the temporary list to prevent same word from being hidden 
            // again in the same round of hiding words from the scripture text
            visibleWords.RemoveAt(randomIndex);
        }
    }
    // Determine if all words in the scripture text have been hidden to end the scripture memorization practice
    public bool IsCompletelyHidden()
    {
        // Loop through every word in the scripture to check if it is hidden
        foreach (Word word in _words)
        {
            // Return false if one word is visible to show that not all words are hidden
            if (!word.IsHidden())
            {
                // Return false to show that not all words are hidden for the scripture text
                return false;
            }
        }
        // Return true to show that all words are hidden for the scripture text
        return true;
    }
}