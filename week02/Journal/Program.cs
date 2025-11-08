/*
Exceeding Requirements:
- Mood Tracker: asks "How are you feeling today?" and saves it with the entry
- Journaling Streak Counter: tracks consecutive days of journaling
- UTF-8 console output to support emojis (📅)
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Journal journal = new Journal();
        Random random = new Random();
        int streak = 0;

        List<string> prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is something I learned today?",
            "What made me smile today?"
        };

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("────────────────────────────");
            Console.WriteLine($"📅 Current Streak: {streak} day(s)");
            Console.WriteLine("────────────────────────────");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option (1-5): ");
            choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = prompts[random.Next(prompts.Count)];
                    Console.WriteLine(prompt);
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    Console.Write("How are you feeling today? ");
                    string mood = Console.ReadLine();

                    string date = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry(date, prompt, response, mood);
                    DateTime? lastDate = journal.GetLastEntryDate();

                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry added!\n");


                    if (lastDate != null && lastDate.Value.Date == DateTime.Now.Date.AddDays(-1))
                    {
                        streak++;
                    }
                    else if (lastDate == null)
                    {
                        streak = 1;
                    }
                    else
                    {
                        streak = 1;
                    }
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save to: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load from: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }
    }
}