using System;
using System.Collections.Generic;

namespace YouTubeVideoTracker
{
    // this is the Comment class to track commenter's name and comment text
    public class Comment
    {
        public string CommenterName { get; set; }
        public string CommentText { get; set; }

        public Comment(string commenterName, string commentText)
        {
            CommenterName = commenterName;
            CommentText = commentText;
        }

        public override string ToString()
        {
            return $"{CommenterName}: {CommentText}";
        }
    }

    // this is the video class to store information about a video and its comments
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthSeconds { get; set; }
        private List<Comment> Comments { get; set; }

        public Video(string title, string author, int lengthSeconds)
        {
            Title = title;
            Author = author;
            LengthSeconds = lengthSeconds;
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

        public override string ToString()
        {
            int minutes = LengthSeconds / 60;
            int seconds = LengthSeconds % 60;
            string lengthFormatted = $"{minutes}m {seconds}s";

            string result = $"Title: {Title}\nAuthor: {Author}\nLength: {lengthFormatted}\nComments ({GetCommentCount()}):";

            foreach (var comment in Comments)
            {
                result += $"\n  {comment}";
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create sample videos
            var video1 = new Video("Python Programming Basics", "TechGuru", 300);
            var video2 = new Video("Top 10 Gadgets of 2025", "GadgetFan", 600);
            var video3 = new Video("How to Cook Pasta Perfectly", "ChefExtraordinaire", 420);

            // Add comments to video1
            video1.AddComment(new Comment("Alice", "Great explanation!"));
            video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
            video1.AddComment(new Comment("Charlie", "What about advanced topics?"));

            // Add comments to video2
            video2.AddComment(new Comment("Dana", "Love these recommendations!"));
            video2.AddComment(new Comment("Eve", "Can you do a 2026 list?"));

            // Add comments to video3
            video3.AddComment(new Comment("Frank", "Delicious recipe!"));
            video3.AddComment(new Comment("Grace", "Tried this, and it worked perfectly."));
            video3.AddComment(new Comment("Hannah", "Any tips for gluten-free pasta?"));

            // Store videos in a list
            var videos = new List<Video> { video1, video2, video3 };

            // Display video information
            foreach (var video in videos)
            {
                Console.WriteLine(video);
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}