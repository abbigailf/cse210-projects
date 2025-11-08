using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries yet.\n");
            return;
        }

        foreach (Entry entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                outputFile.WriteLine(entry.ToFileFormat());
            }
        }
        Console.WriteLine($"Journal saved to {filename}\n");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            entries.Add(Entry.FromFileFormat(line));
        }

        Console.WriteLine($"Loaded {entries.Count} entries from {filename}\n");
    }

    public DateTime? GetLastEntryDate()
    {
        if (entries.Count == 0)
            return null;

        Entry lastEntry = entries[entries.Count - 1];
        if (DateTime.TryParse(lastEntry.Date, out DateTime parsedDate))
        {
            return parsedDate;
        }
        return null;
    }
}