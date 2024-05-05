using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry(JournalEntry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}\n");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"Date: {entry.Date}");
                writer.WriteLine($"Prompt: {entry.Prompt}");
                writer.WriteLine($"Response: {entry.Response}");
                writer.WriteLine(); // Add an empty line between entries
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear(); // Clear existing entries before loading from file

        using (StreamReader reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                string date = reader.ReadLine().Substring(6); // Remove "Date: " prefix
                string prompt = reader.ReadLine().Substring(8); // Remove "Prompt: " prefix
                string response = reader.ReadLine().Substring(10); // Remove "Response: " prefix
                reader.ReadLine(); // Skip empty line

                JournalEntry entry = new JournalEntry
                {
                    Date = date,
                    Prompt = prompt,
                    Response = response
                };

                entries.Add(entry);
            }
        }
    }
}
