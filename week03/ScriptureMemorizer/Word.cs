// Use the Word class to store and manage separate words in a scripture for memorization practice
class Word
{
    // Create private fields using the principles of encapsulation for the Word class
    // Store the actual word text to show the user when practicing scripture memorization
    private string _text;

    // Store to show the user if the word is currently hidden or not using a Boolean value to enable hiding of separate words
    private bool _isHidden;

    // Create a Word object using the constructor that receives the word text as a string
    public Word(string text)
    {
       // Store the word text provided by the user in the private field for the Word class
        _text = text;

        // Set the _isHidden field to false to show that the word is not hidden when the Word object is newly created
        _isHidden = false;
    }
    // Create a method to hide the word from the scripture text
    public void Hide()
    {
        // Set the _isHidden field to true to hide the word from the scripture text
        _isHidden = true;
    }
    // Return a boolean value to show the user if the word is hidden or not for scripture memorization practice
    public bool IsHidden()
    {
        return _isHidden;
    }
    // Display the word text to show the user during scripture memorization practice
    public string GetDisplayText()
    {
        // Check if the word is hidden and return a string of underscores matching the same number of letters in the original word while keeping any punctuation visible
        if (_isHidden)
        {
            // Create a character array from the original word
            char[] hiddenText = _text.ToCharArray();

            // Replace only letters with underscores to hide the word while keeping punctuation visible
            for (int i = 0; i < hiddenText.Length; i++)
            {
                if (char.IsLetter(hiddenText[i]))
                {
                    hiddenText[i] = '_';
                }
            }
            // If the word is hidden, return a string of underscores matching the same number of letters in the original word
            // while keeping any punctuation visible
            return new string(hiddenText);
        }
        // Return the original word text if the word is not hidden
        return _text;
    }
}