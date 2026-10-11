using System;

public class Assignment
{
    // Store the student's name as a private member variable
    private string _studentName;

    // Store the assignment topic as a private member variable
    private string _topic;

    //  Receives the student's name and topic using constructor
    public Assignment(string studentName, string topic)
    {
        // Initialize the private member variables
        _studentName = studentName;

        // Initialize the assignment topic
        _topic = topic;
    }

    // Return the student's name and the assignment topic for derived 
    // classes to have access
    public string GetStudentName()
    {
        return _studentName;
    }
      
    // Return the student's name and the assignment topic
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}