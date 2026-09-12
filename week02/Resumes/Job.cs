using System;

// This Job class represents one job in a person's work history 
public class Job
{
    // Create member variables to store information about the job 
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    // Display the job information in the required format
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }

} 