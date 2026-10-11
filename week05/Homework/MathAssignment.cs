public class MathAssignment : Assignment
{
    // Create private member variables for the textbook section and problems for the math assignment
    private string _textbookSection;
    private string _problems;

    // Initialise the base class using the base constructor    
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        // Set variables specific to the MathAssignment class
        _textbookSection = textbookSection;
        _problems = problems;
    }

    // Return the textbook section and problems for the math assignment
    public string GetHomeworkList()
    {
        // Create a getter for the textbook section and problems in the MathAssignment class so that 
        // they can be accessed in the derived class
        return $"Section {_textbookSection} Problems {_problems}";
    }
}