using System;
using System.Collections.Generic;

// This is responsible for storing and randomly selecting journal prompts when the program requests for it
public class PromptGenerator
{
    // Store all of the prompts available to the user as string
    private List<string> _prompts;

    // Generate a random number that selects one of the prompts from the list 
    private Random _random;

    // Use constructor to create and initialize the list of available prompts. Also use the constructor to create the 
    // Random object that will be used to select prompts
    public PromptGenerator()
    {
        // Create the list and add the journal prompts (including exceeded requirements) that the user can receive
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "What did I learn today that I did not know before?",
            "What is one thing I am grateful for today?",
            "What was the strongest emotion I felt today?",
            "What challenge did I face today, and how did I handle it?",
            "What is one thing I want to accomplish tomorrow?",
            "What made me smile today?"
        };

        // Create the Random object that will be used to generate random prompt indexes once the PromptGenerator is created
         _random = new Random();
    }

    // Select and return one prompt at random from the list
    public string GetRandomPrompt()
    {
      // Generate a random index from 0 upward, but not inclusing the number of promts in the list 
      int index = _random.Next(_prompts.Count);
      
      // Return the prompt stored at the randomly selected index
      return _prompts[index];
    }
}
 