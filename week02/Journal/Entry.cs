using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; }

    public Entry(string date, string prompt, string response, string mood)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nMood: {Mood}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }

    public string ToFileFormat()
    {
        return $"{Date}|{Mood}|{Prompt}|{Response}";
    }

    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length >= 4)
        {
            return new Entry(parts[0], parts[2], parts[3], parts[1]);
        }
        else
        {
            return new Entry(parts[0], parts[1], parts[2], "Unknown");
        }
    }
}