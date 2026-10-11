using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a base "Assignment" object
        Console.WriteLine();
        Assignment a1 = new Assignment("Samuel Bennett", "Multiplication");
        // Call the GetSummary method to display the assignment summary
        Console.WriteLine(a1.GetSummary());

        // Create the derived class assignment objects (MathAssignment and WritingAssignment)
        // and call their methods to display their summary with required information
        MathAssignment a2 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        // Call the GetSummary method to display the mathassignment summary
        Console.WriteLine(a2.GetSummary());
        // Call the GetHomeworkList method to display the mathassignment homework list
        Console.WriteLine(a2.GetHomeworkList());

        // Create the derived class assignment objects (MathAssignment and WritingAssignment)
        WritingAssignment a3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        // Call the GetSummary method to display the writingassignment summary
        Console.WriteLine(a3.GetSummary());
       
        // Call the GetWritingInformation method to display the writingassignment information
        Console.WriteLine(a3.GetWritingInformation());
        Console.WriteLine();
    }   
}