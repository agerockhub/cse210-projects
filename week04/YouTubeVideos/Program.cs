using System;
using System.Collections.Generic;

public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create a list of videos
        List<Video> videos = new List<Video>();

        // First video
        Video video1 = new Video("How to Cook Pasta", "Chef Anna", 300);
        video1.AddComment(new Comment("John", "Great recipe!"));
        video1.AddComment(new Comment("Maria", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Tom", "Tried this and loved it."));
        videos.Add(video1);

        // Second video
        Video video2 = new Video("Learn C# in 10 Minutes", "CodeAcademy", 600);
        video2.AddComment(new Comment("Alex", "Super useful."));
        video2.AddComment(new Comment("Lina", "Nice explanation!"));
        video2.AddComment(new Comment("David", "Helped me get started."));
        videos.Add(video2);

        // Third video
        Video video3 = new Video("DIY Wood Table", "HomeCraft", 450);
        video3.AddComment(new Comment("Sarah", "This was easier than I thought."));
        video3.AddComment(new Comment("George", "Clear and easy steps."));
        video3.AddComment(new Comment("Lucy", "Thanks!"));
        videos.Add(video3);

        // Display the videos and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (sec): {video.LengthInSeconds}");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}
