using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        int index = 1;
        foreach (var g in _goals)
        {
            Console.WriteLine($"{index}. {g.GetStatusString()} {g.GetName()} — {g.GetDescription()}");
            index++;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record!");
            return;
        }

        ListGoals();
        Console.Write("\nWhich goal did you accomplish? ");

        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= _goals.Count)
        {
            Goal g = _goals[choice - 1];
            int gained = g.RecordEvent();
            _score += gained;
            CheckLevelUp();
            Console.WriteLine($"\nYou earned {gained} points!");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    private void CheckLevelUp()
    {
        int oldLevel = _level;
        _level = (_score / 1000) + 1;
        if (_level > oldLevel)
            Console.WriteLine($"\n🎉 LEVEL UP! You reached Level {_level}! 🎉");
    }

    public void DisplayScore() => Console.WriteLine($"\nScore: {_score}  |  Level: {_level}");

    public void SaveGoals()
    {
        Console.Write("Filename: ");
        string filename = Console.ReadLine();

        try
        {
            using StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(_score);
            sw.WriteLine(_level);

            foreach (Goal g in _goals)
                sw.WriteLine(g.GetSaveString());

            Console.WriteLine("Saved successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving file: {e.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("Filename: ");
        string filename = Console.ReadLine();

        try
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _level = int.Parse(lines[1]);
            _goals.Clear();

            for (int i = 2; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(":");
                string type = parts[0];
                string[] data = parts[1].Split("|");

                switch (type)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3])));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(
                            data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]),
                            int.Parse(data[5]), bool.Parse(data[6])));
                        break;
                    case "NegativeGoal":
                        _goals.Add(new NegativeGoal(data[0], data[1], int.Parse(data[2])));
                        break;
                }
            }

            Console.WriteLine("Loaded successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading file: {e.Message}");
        }
    }
}