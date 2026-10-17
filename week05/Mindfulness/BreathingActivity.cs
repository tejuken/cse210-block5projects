 
 using System;
// Provide stopwatch for timing the session
using System.Diagnostics;
// Provide Thread.Sleep for breathing countdown delays
using System.Threading;
   
// Use the BreathingActivity to implement a timed breathing exercise that reuses the shared activity messages 
// and animations while adding breathing-specific instructions and a more expressive countdown
public class BreathingActivity : Activity
{
   // Create a BreathingActivity object using constructor that supplies the name and description required by the
   // base class so the common starting message can be displayed
   public BreathingActivity()

      // Pass shared information to the base class  
      : base(
        // Set the activity name
        "Breathing Activity", 
        // Set the description
        "This activity will help you relax by walking you through breathing in and out slowly. " +
            "Clear your mind and focus on your breathing")
    {
       // The base constructor initializes the shared activity information 
    }

    // Run the breathing exercise for the duration selected by the user
    public override void Run()
    {
        // Display the common introduction and ask the user for a duration
        DisplayStartingMessage();

        // Start measuring the actual exercise duration
        Stopwatch timer = Stopwatch.StartNew();

        // Start by determining the breathing-in phase
        bool breatheIn = true;

        // Continue until the selected exercise duration is reached
        while (timer.Elapsed.TotalSeconds < Duration)
        {
            // Calculate the remaining exercise time
            double remaining = Duration - timer.Elapsed.TotalSeconds;

            // Limit the next breathing phase to four seconds or less
            int phaseSeconds = Math.Min(4,(int)Math.Ceiling(remaining));

            // Check whether the time has expired
            if (phaseSeconds <= 0)
            {
                // End the breathing loop
                break;
            }

            // Display the current breathing phase instruction
            Console.WriteLine(breatheIn ? "Breathe in..." : "Breathe out...");

            // Countdown during the current phase
            for (int count = phaseSeconds; count > 0; count--)
            {
                // Display the phase countdown
                Console.WriteLine($"\r{(breatheIn ? "Breathe in..." : "Breathe out...")}{count}  ");

                // Pause the program for a second before displaying the next number
                Thread.Sleep(1000);
                
                // Moves to the next console line after the countdown
                Console.WriteLine();

                // Check if the overall duration has expired
                if (timer.Elapsed.TotalSeconds >= Duration)
                {
                    // Stop the current phase when the time runs out
                    break;
                }
            }

            // Switch to the opposite breathing phase
            breatheIn = !breatheIn;
            Console.WriteLine();
        }

        // Display the shared completion sequence
        DisplayEndingMessage();
    }
}