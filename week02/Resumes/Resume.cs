using System;
using System.Collections.Generic;

// This Resume class represents a person's resume 
public class Resume
{
    // Create a member variable to store the person's name 
    public string _name;

    // Create a list to store all the Job objects belonging to the resume    
    public List<Job> _jobs = new List<Job>();

    // Display the person's name and all of their jobs with this method
    public void Display()
    {
        // Display the person's name
        Console.WriteLine($"Name: {_name}");
        
        // Display the Jobs heading
        Console.WriteLine("Jobs:");

        // Notice the use of the custom data type "Job" while looping through each job in the list
        foreach (Job job in _jobs)
        {
            // Call the Display method on each job
            job.Display();
        }
    }
}