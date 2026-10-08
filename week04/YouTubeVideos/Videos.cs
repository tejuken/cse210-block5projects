using System;
using System.Collections.Generic;

// Use the Video class to represent a YouTube video with its title, author, length and comments
public class Video
{
    // Create private fields to store the title, author, length in seconds and comments of the video
    // Store the video title for the user to see when viewing the video
    private string _title;

    // Store the video author for the user to see when viewing the video
    private string _author;

    // Store the video length in seconds for the user to see when viewing the video
    private int _lengthInSeconds;

    // Store all Comment objects that belongs to the video for the user to see when viewing the video
    private List<Comment> _comments;

    // Create a Video object using constructor that receives the title, author and length in seconds of the video
    public Video(string title, string author, int lengthInSeconds)
    {
        // Store the title provided by the user in the private fields for the Video class
        _title = title;

        // Store the author provided by the user in the private fields for the Video class
        _author = author;

        // Store the length in seconds provided by the user in the private fields for the Video class
        _lengthInSeconds = lengthInSeconds;

        // Create an empty list to store the comments for the video
        _comments = new List<Comment>();
    }
    
    // Add a Comment object to the list of comments in the video for the user to see when viewing the video
    public void AddComment(Comment comment)
    {
        // Add the Comment object provided by the user to the list of comments in the video
        _comments.Add(comment);
    }

    // Return the total number of comments for the video for the user to see when viewing the video
    public int GetCommentCount()
    {
        // Return the total number of comments in the list of comments for the video
        return _comments.Count;
    }

    // Display the video summary
    public void DisplayVideoSummary()
    {
        // Display the video title for the user to see when viewing the video
        Console.WriteLine($"Title: {_title}");

        // Display the video author for the user to see when viewing the video
        Console.WriteLine($"Author: {_author}");
        
        // Display the video length in seconds for the user to see when viewing the video
        Console.WriteLine($"Length: {_lengthInSeconds} seconds");
        
        // Display the total number of comments for the video for the user to see when viewing the video
        Console.WriteLine($"Total Comments: {GetCommentCount()}");
    
        // Display each comment's text and author for the user to see when viewing the video
        Console.WriteLine("Comments:");

        // Loop through each Comment object in the list of comments for the video and display its text and author
        foreach (Comment comment in _comments)
        {
            // Display the comment's author and text for the user to see when viewing the video
            Console.WriteLine($"{comment.GetAuthorName()}: {comment.GetCommentText()}");
        }

        // Add an empty line between videos for better readability
        Console.WriteLine(); 
    }
}