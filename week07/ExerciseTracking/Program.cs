using System;
using System.Collections.Generic;

// Place the main program in the same namespace as the activity classes
namespace ExerciseTracking
{
    // Define the main program class
    class Program
    {
        // Define the entry point of the program
        static void Main(string[] args)
        {
            // Create a list that stores all activities through the base class
            List<Activity> activities = new List<Activity>();

            // Create a running activity dated 3 November 2022
            Running running = new Running(
                new DateTime(2022, 11, 3),
                30,
                4.8
            );

            // Create a cycling activity dated 3 November 2022
            Cycling cycling = new Cycling(
                new DateTime(2022, 11, 3),
                30,
                20.0
            );

            // Create a swimming activity dated 3 November 2022
            Swimming swimming = new Swimming(
                new DateTime(2022, 11, 3),
                30,
                20
            );

            // Add the running activity to the shared activity list
            activities.Add(running);

            // Add the cycling activity to the shared activity list
            activities.Add(cycling);

            // Add the swimming activity to the shared activity list
            activities.Add(swimming);

            // Loop through all activities using the common base class
            foreach (Activity activity in activities)
            {
                // Display the summary implemented through polymorphism
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}