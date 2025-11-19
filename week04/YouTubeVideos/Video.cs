using System;
using System.Collections.Generic;

public class Video
{
    // Attributes
    private string _title;
    private string _author;
    private int _length; // seconds
    private List<Comment> _comments = new List<Comment>();

    // Constructor
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    // Add a comment
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Return number of comments
    public int GetCommentCount()
    {
        return _comments.Count;
    }

    // Return the list of comments
    public List<Comment> GetComments()
    {
        return _comments;
    }

    // Display video info
    public void Display()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");

        int minutes = _length / 60;
        int seconds = _length % 60;
        Console.WriteLine($"Length: {minutes}m {seconds}s");

        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");

        foreach (Comment c in _comments)
        {
            Console.WriteLine($" - {c.GetName()}: {c.GetText()}");
        }

        Console.WriteLine();
    }
}