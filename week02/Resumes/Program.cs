using System;

// This Program class contains the Main method where the program starts
class Program
{
    static void Main(string[] args)
    {
        // Create the first Job object
        Job job1 = new Job();

        // Set the information for the first job
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        // Create the second Job object
        Job job2 = new Job();

        // Set the information for the second job
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        // Create a Resume object
        Resume myResume = new Resume();

        Console.WriteLine();
        // Set the person's name
        myResume._name = "Allison Rose";

        // Add the two Job objects to the resume's job list
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Display the complete resume
        myResume.Display();
        Console.WriteLine();
    }
}