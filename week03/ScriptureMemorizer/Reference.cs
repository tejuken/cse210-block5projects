// Use the Reference class to store and display the scripture reference for scripture memorization practice
class Reference
{
    // Create private fields using the principles of encapsulation for the Reference class
    // Store the book for the scripture reference to display to the user
    private string _book;

    // Store the chapter for the scripture reference to display to the user
    private int _chapter;

    // Store the starting verse for the scripture reference to display to the user
    private int _startVerse;

    // Store the ending verse for the scripture reference to display to the user
    private int _endVerse;

    // Define constructor for a single verse to create a Reference object with a single verse
    public Reference(string book, int chapter, int verse)
    {
        // Store the book, chapter and verse in the private fields for the Reference class
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }
    // Define constructor for a verse range to create a Reference object with a verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        // Store the book, chapter, starting verse and ending verse in the private fields for the Reference class
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }
    // Create the Method to display the scripture reference as a formatted string to the user     
    public string GetDisplayText()
    {
        // Display a single verse if the beginning and ending verses are the same for the scripture reference
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
        // Display a non-single verse as a verse range if the beginning and ending verses are different for the scripture reference
        else
        {
        return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
    // Return the starting verse number for the Scripture class to display to the user
    public int GetStartVerse()
    {
        return _startVerse;
    }
}