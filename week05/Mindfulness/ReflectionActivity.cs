using System;
using System.Collections.Generic;

public class ReflectionActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something very difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you acted selflessly."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "How did you get started?",
        "What did you learn about yourself?",
        "How did this change you?",
        "How can this help you in the future?"
    };

    public ReflectionActivity()
        : base("Reflection Activity",
               "This activity helps you reflect on moments of personal strength or growth.")
    { }

    public override void Run()
    {
        StartActivity();

        Random rand = new Random();

        SetPromptColor();
        Console.WriteLine("\nConsider the following prompt:");
        ResetColor();

        SetTitleColor();
        Console.WriteLine($"--- {_prompts[rand.Next(_prompts.Count)]} ---");
        ResetColor();

        Console.WriteLine("\nPress Enter when you are ready.");
        Console.ReadLine();

        Console.WriteLine("\nPonder each of the following questions:");

        DateTime end = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < end)
        {
            string q = _questions[rand.Next(_questions.Count)];

            SetPromptColor();
            Console.Write($"\n{q} ");
            ResetColor();

            ShowSpinner(5);
        }

        EndActivity();
    }
}