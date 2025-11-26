using System;
using System.Collections.Generic;

public class ListingActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are your personal strengths?",
        "Who have you helped recently?",
        "What made you smile this week?",
        "What blessings are you grateful for?"
    };

    public ListingActivity()
        : base("Listing Activity",
               "This activity helps you focus on the positive aspects of your life by listing uplifting thoughts.")
    { }

    public override void Run()
    {
        StartActivity();

        Random rand = new Random();

        SetPromptColor();
        Console.WriteLine("\nList as many responses as you can to this prompt:");
        ResetColor();

        SetTitleColor();
        Console.WriteLine($"--- {_prompts[rand.Next(_prompts.Count)]} ---");
        ResetColor();

        Console.Write("\nYou may begin in: ");
        ShowCountdown(5);

        List<string> items = new List<string>();

        DateTime end = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            items.Add(Console.ReadLine());
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nYou listed {items.Count} uplifting items!");
        Console.ResetColor();

        EndActivity();
    }
}