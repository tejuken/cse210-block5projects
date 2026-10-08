using System;

// Use the Comment class to display a comment made on a YouTube video with its text and author
public class Comment
{
    // Create private fields to store the text and author of the comment
    // Store the author's name for the user to see when viewing the comment
    private string _authorName;

    // Store the comment text for the user to see when viewing the comment
    private string _commentText;
    
    // Create a Comment object using constructor that receives the author's name and comment text
    public Comment(string authorName, string commentText)
    {
        // Store the author's name provided by the user in the private fields for the Comment class
        _authorName = authorName;

        // Store the comment text provided by the user in the private fields for the Comment class
        _commentText = commentText;
    }

    // Return the author's name who madethe comment for the user to see when viewing the comment
    public string GetAuthorName()
    {
        return _authorName;
    }

    // Return the comment text for the user to see when viewing the comment
    public string GetCommentText()
    {
        return _commentText;
    }
}