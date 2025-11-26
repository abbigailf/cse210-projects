using System;
using System.Collections.Generic;
using System.Threading;

public class MantraMeditationActivity : MindfulnessActivity
{
    private List<string> _mantras = new List<string>()
    {
        "I am kind.",
        "I am strong.",
        "I am patient.",
        "I can do hard things.",
        "I am a child of God."
    };

    public MantraMeditationActivity()
        : base("Mantra Meditation Activity",
               "This activity helps you repeat a positive mantra to build peace, strength, and identity.")
    { }

    public override void Run()
    {
        StartActivity();

        Random rand = new Random();
        string mantra = _mantras[rand.Next(_mantras.Count)];

        Console.WriteLine("\nYour mantra for this meditation is:");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"--- {mantra} ---");
        Console.ResetColor();

        Console.WriteLine("\nRepeat this phrase silently or out loud as it appears on the screen...");
        Thread.Sleep(2000);
        Console.WriteLine();

        DateTime end = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < end)
        {
            // Appear (calm green)
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(mantra);
            Thread.Sleep(1500);

            // Fade-out erasing one char at a time
            for (int i = mantra.Length; i > 0; i--)
            {
                Console.Write("\b \b");
                Thread.Sleep(50);
            }
        }

        Console.ResetColor();
        EndActivity();
    }
}
