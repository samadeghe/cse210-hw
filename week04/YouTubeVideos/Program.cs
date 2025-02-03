using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    public override string ToString()
    {
        return $"{CommenterName}: {Text}";
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"  - {comment}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create sample videos
        Video video1 = new Video("Understanding C# Classes", "John Doe", 600);
        Video video2 = new Video("Top 10 Programming Tips", "Jane Smith", 720);
        Video video3 = new Video("Mastering Data Structures", "Alex Johnson", 900);

        // Add comments to each video
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "This cleared up my confusion."));

        video2.AddComment(new Comment("Dave", "Nice tips, will try them out."));
        video2.AddComment(new Comment("Eve", "Could you cover more advanced topics next time?"));
        video2.AddComment(new Comment("Frank", "Loved this video, learned a lot."));

        video3.AddComment(new Comment("Grace", "Excellent content."));
        video3.AddComment(new Comment("Heidi", "Perfect for my exam prep."));
        video3.AddComment(new Comment("Ivan", "Amazing work, thank you!"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video details and comments
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}
