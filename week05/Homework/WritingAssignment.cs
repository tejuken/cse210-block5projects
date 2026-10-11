public class WritingAssignment : Assignment
{
    // Create a private member variable for the title of the writing assignment
    private string _title;

    // Initialise the base class by passing the student name and topic using the 
    // base constructor
    public WritingAssignment(string studentName, string topic, string title)
    : base(studentName, topic)
    {
        // Set variables specific to the WritingAssignment class
        _title = title;
    }

    // Return the assignment title and student's name for the writing assignment
    public string GetWritingInformation()
    {
        // Call the getter for the student's name in the base class so that it 
        // can be accessed in the derived class
        string studentName = GetStudentName();

        return $"{_title} by {studentName}";
    }
}