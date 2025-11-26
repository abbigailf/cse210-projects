using System;
using System.Threading;

public abstract class MindfulnessActivity
{
    private string _name;
    private string _description;
    private int _duration;

    public MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"--- {_name} ---\n");
        Console.ResetColor();

        Console.WriteLine(_description);
        Console.Write("\nEnter duration of activity in seconds: ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nPrepare to begin...");
        ShowSpinner(3);
    }

    public void EndActivity()
    {
        Console.WriteLine("\nGreat job!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(4);
    }

    public int GetDuration() => _duration;

    // ---------------- COLOR HELPERS ----------------
    protected void SetBreathingColor(bool inhale)
    {
        Console.ForegroundColor = inhale ? ConsoleColor.Cyan : ConsoleColor.Green;
    }

    protected void SetPromptColor()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
    }

    protected void SetTitleColor()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
    }

    protected void ResetColor()
    {
        Console.ResetColor();
    }

    // ---------------- SPINNER ----------------
    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < end)
        {
            Console.Write(spinner[index]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            index = (index + 1) % spinner.Length;
        }
    }

    // ---------------- COUNTDOWN ----------------
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // ---------------- ENHANCED BREATH ANIMATION ----------------
    protected void ShowBreathGrowth(string label, int seconds)
    {
        bool inhale = label.ToLower().Contains("in");
        SetBreathingColor(inhale);

        Console.WriteLine($"\n{label}");

        string[] bubble = { ".", "..", "...", "....", ".....", "......", ".......", "........", ".........", ".........." };

        DateTime end = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        int fast = 120;
        int slow = 280;
        int steps = bubble.Length;

        while (DateTime.Now < end)
        {
            double progress = (double)index / (steps - 1);
            int delay = (int)((1 - progress) * fast + progress * slow);

            Console.Write("\r" + bubble[index] + " ");
            Thread.Sleep(delay);

            index = (index + 1) % steps;
        }

        Console.Write("\r               \r");
        ResetColor();
    }

    // ---------------- MUST BE OVERRIDDEN ----------------
    public abstract void Run();
}