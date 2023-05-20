using System;
using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public int GetNumComments()
    {
        return Comments.Count;
    }
}

public class Comment 
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create 3-4 videos with comments and add them to a list
        List<Video> videos = new List<Video>();

        Video video1 = new Video("First Video", "John Smith", 120);
        video1.Comments.Add(new Comment("Alice", "This was really helpful!"));
        video1.Comments.Add(new Comment("Bob", "Great job explaining things."));
        video1.Comments.Add(new Comment("Charlie", "I didn't understand this part."));

        Video video2 = new Video("Second Video", "Jane Doe", 180);
        video2.Comments.Add(new Comment("Eve", "Thanks for the tips!"));
        video2.Comments.Add(new Comment("Frank", "Very informative."));
        
        videos.Add(video1);
        videos.Add(video2);

        // Iterate through the list of videos and display information
        foreach (var video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length (seconds): " + video.Length);
            Console.WriteLine("Number of comments: " + video.GetNumComments());

            foreach (var comment in video.Comments)
            {
                Console.WriteLine(comment.Name + ": " + comment.Text);
            }

            Console.WriteLine();
        }

        Console.ReadLine();

        //This code defines a Video class with properties for its title, author, and length (in seconds). It also includes a List object to store the comments and a method GetNumComments() that returns the count of comments for each video. The Comment class has properties for name and text.

//In the Main() method, we create 2 videos with 3-4 comments each and add them to the list. Then, we iterate through the list and display the relevant information using Console.WriteLine() statements.
    }
}

