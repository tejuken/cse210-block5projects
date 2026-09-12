using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user for their grade percentage
        Console.WriteLine();
        Console.Write("What is your grade percentage? ");
        string response = Console.ReadLine();
        int gradePercentage = int.Parse(response);

        // Create a variable to store the letter grade
        string letter = "";

        // Determine the letter grade using if statement
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign (+ or -)
        // Create a variable to store the sign
        string sign = "";

        // Find the last digit of the grade percentage
        int lastDigit = gradePercentage % 10;
        
        // Determine the plus or minus sign using if statement
        if (lastDigit >= 7)
        {
           sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        // Assuming there is no A+ grade
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }
        // Assuming there is no F+ or F- grade
        if (letter == "F")
        {
            sign = "";
        }
        // Display the letter grade and sign
        Console.WriteLine($"Your grade is {letter}{sign}");

        // Determine whether the student passed or failed
        if (gradePercentage >= 70)
        {
            // Congratulate the studen if gradepercent >= 70
            Console.WriteLine("Congratulations! You passed the course");
            Console.WriteLine();
        }
        else
        {
           // Encourage the student to try more if gradepercentage is not >= 70
            Console.WriteLine("Keep working hard. Better luck next time!");
            Console.WriteLine();
        }
    }
}