using System;
// Provide list for prompts and questions
using System.Collections.Generic;
// Provide stopwatch for session timing
using System.Diagnostics;

// Use the ReflectiveActivity class to keeps own prompts, questions and random selection logic together, while inheriting
// the shared attributes, messages and animations from Activity
public class ReflectionActivity : Activity
{

 // Store the experience prompts privately
    private readonly List<string> _prompts;

    // Store the complete collection of reflection questions
    private readonly List<string> _questions;

    // Select random prompts and questions
    private readonly Random _random;

    // Store questions that have not yet been used in the current cycle
    private List<string> _availableQuestions;

    // Create a ReflectionActivity object using constructor that will manage the reflection activity and its question collections
    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This " +
            "will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        // Initialize the random number generator
        _random = new Random();

        // Create the reflection experience prompts
        _prompts = new List<string>
        {
            // Encourage reflection on courage
            "Think of a time when you stood up for someone else",

            // Encourage reflection on perseverance
            "Think of a time when you did something really difficult",

            // Encourage reflection on kindness
            "Think of a time when you helped someone in need",

            // Encourage reflection on generosity
            "Think of a time when you did something truly selfless",

            // Encourage reflection on personal growth
            "Think of a time when you overcame a personal challenge",

            // Encourage reflection on unexpected favour
            "Think of a time when someone showed you unexpected kindness"
        };

        // Create the complete set of reflection questions
        _questions = new List<string>
        {
            // Explore the personal meaning of the experience
            "Why was this experience meaningful to you?",

            // Encourage comparison with earlier experiences
            "Have you ever done anything like this before?",

            // Explore how the experience began
            "How did you get started?",

            // Explore the user's emotions
            "How did you feel when it was complete?",

            // Examine differences from less successful experiences
            "What made this time different from other times when you were not as successful?",

            // Identify a favorite part of the experience
            "What is your favorite thing about this experience?",

            // Connect the experience to future situations
            "What could you learn from this experience that applies to other situations?",

            // Encourage personal discovery
            "What did you learn about yourself through this experience?",

            // Encourage future application
            "How can you keep this experience in mind in the future?"
        };

        // Copy all questions into the pool of unused questions
        _availableQuestions = new List<string>(_questions);
    }

    // Run the complete reflection activity
    public override void Run()
    {
        // Display the common starting message and obtains the duration
        DisplayStartingMessage();

        // Display a random experience prompt and preparation spinner
        DisplayPrompt();

        // Display reflection questions during the timed question period
        DisplayQuestions();

        // Display the common completion message
        DisplayEndingMessage();
    }

    // Select and returns a random experience prompt
    private string GetRandomPrompt()
    {
        // Generate a valid index for the prompt collection
        int index = _random.Next(_prompts.Count);

        // Return the selected experience prompt
        return _prompts[index];
    }

    // Select a question without repeating one until the current pool is empty
    private string GetRandomQuestion()
    {
        // Refill the pool after every question has been used once
        if (_availableQuestions.Count == 0)
        {
            // Copy the original questions into a fresh available pool
            _availableQuestions = new List<string>(_questions);
        }

        // Select a random index from the remaining questions
        int index = _random.Next(_availableQuestions.Count);

        // Save the selected question before removing it
        string question = _availableQuestions[index];

        // Remove the selected question to prevent an early repetition
        _availableQuestions.RemoveAt(index);

        // Return the selected question
        return question;
    }

    // Display the chosen experience prompt and preparation animation
    private void DisplayPrompt()
    {
        // Add spacing before the prompt
        Console.WriteLine();

        // Introduce the experience to consider
        Console.WriteLine("Consider the following experience:");

        // Add spacing before the selected experience
        Console.WriteLine();

        // Display one randomly selected experience prompt
        Console.WriteLine(GetRandomPrompt());

        // Add spacing before the preparation message
        Console.WriteLine();

        // Encourage the user to recall the experience
        Console.WriteLine("Take a moment to think about it...");

        // Provide five seconds of animated preparation
        ShowSpinner(5);

        // Move to the next line
        Console.WriteLine();
    }

    // Display reflection questions until the selected question duration expires
    private void DisplayQuestions()
    {
        // Start measuring the timed question period
        Stopwatch timer = Stopwatch.StartNew();

        // Continue displaying questions while time remains
        while (timer.Elapsed.TotalSeconds < Duration)
        {
            // Calculate the remaining time in the question period
            double remaining = Duration - timer.Elapsed.TotalSeconds;

            // Exit when the time limit has been reached
            if (remaining <= 0)
            {
                // Ends the question loop
                break;
            }

            Console.WriteLine();
            // Display a question that has not yet been used in this cycle
            Console.WriteLine(GetRandomQuestion());

            // Encourage the user to consider the question thoughtfully
            Console.WriteLine("Reflect on your answer while the spinner moves");

            // Limit each reflection pause to eight seconds or the remaining time
            int pauseSeconds = Math.Min(
                8,
                Math.Max(1, (int)Math.Ceiling(remaining)));

            // Display the spinner during the reflection pause
            ShowSpinner(pauseSeconds);

            // Move to the next line after the pause
            Console.WriteLine();
        }
       // Display the common completion message inherited from the activity
        DisplayEndingMessage();
    }
}
