using System;
using System.Collections.Generic;

// Use the Program class to run the YouTubeVideos project
class Program
{
    static void Main(string[] args)
    {
        // Create a list to store the Video objects for the YouTubeVideos project
        List<Video> videos = new List<Video>();
        
        Console.WriteLine();
        // Create three Video objects with their title, author and length in seconds
        // Video 1
        // Create the first Video object with its title, author and length in seconds
        Video video1 = new Video("Introduction to Programming", "Annmarie SanSevero", 900);
        
        // Add three Comment objects to the first Video object with their author's name and comment text
        video1.AddComment(new Comment("Sister SanSevero", "This is a very helpful introduction!"));
        video1.AddComment(new Comment("Sister Annmarie", "I love how this video explains programming concepts"));
        video1.AddComment(new Comment("David", "I can see the value in learning programming"));
        
        // Video 2
        // Create the second Video object with its title, author and length in seconds
        Video video2 = new Video("Programming with Functions", "Sherlene Wattles", 720);
        
        // Add three Comment objects to the second Video object with their author's name and comment text
        video2.AddComment(new Comment("Sister Wattles", "I love how this video explains functions in programming!"));
        video2.AddComment(new Comment("Sister Sherlene", "I feel more confident I can write code after watching this video"));
        video2.AddComment(new Comment("Enny", "Programming with functions is a great way to organize code and make it more efficient"));
        
        // Video 3
        // Create the third Video object with its title, author and length in seconds
        Video video3 = new Video("Programming with Classes", "John Reading", 1200);
        
        // Add three Comment objects to the third Video object with their author's name and comment text
        video3.AddComment(new Comment("Brother Reading", "The video gives me a better understanding of classes in programming"));
        video3.AddComment(new Comment("Brother John", "I enjoyed learning about classes in programming"));
        video3.AddComment(new Comment("Leo", "This video really explains classes in programming well"));
        
        // Add the Three Video objects to the list of videos
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        
        // Loop through each video in the list and display its summary and comment count
        foreach (Video video in videos)
        {
            // Display the summary of the current video using the DisplayVideoSummary method
            video.DisplayVideoSummary();
            Console.WriteLine();
        }
    }
}