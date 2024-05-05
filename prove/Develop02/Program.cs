using System;

class Program
{
    static Journal journal = new Journal();

    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Welcome to Your Daily Journal!");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    SaveJournalToFile();
                    break;
                case "4":
                    LoadJournalFromFile();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine(); // Add a line break for better readability
        }
    }

    static void WriteNewEntry()
    {
        Console.WriteLine("Write a new entry:");
        Console.WriteLine("Choose a prompt:");

        string[] prompts = {
            "Who was the most interesting person you interacted with today?",
            "What was the best part of your day?",
            "How did you see the hand of the Lord in your life today?",
            "What was the strongest emotion you felt today?",
            "If you could do one thing over today, what would it be?"
        };

        for (int i = 0; i < prompts.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {prompts[i]}");
        }

        Console.Write("Enter the number of the prompt: ");
        int promptIndex;
        while (!int.TryParse(Console.ReadLine(), out promptIndex) || promptIndex < 1 || promptIndex > prompts.Length)
        {
            Console.Write("Invalid input. Enter the number of the prompt: ");
        }

        string selectedPrompt = prompts[promptIndex - 1];

        Console.WriteLine($"Prompt: {selectedPrompt}");
        Console.Write("Enter your response: ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("yyyy-MM-dd");

        JournalEntry entry = new JournalEntry
        {
            Prompt = selectedPrompt,
            Response = response,
            Date = date
        };

        journal.AddEntry(entry);

        Console.WriteLine("Entry added successfully!");
    }

    static void DisplayJournal()
    {
        Console.WriteLine("Journal Entries:");
        journal.DisplayEntries();
    }

    static void SaveJournalToFile()
    {
        Console.Write("Enter filename to save: ");
        string saveFile = Console.ReadLine();
        journal.SaveToFile(saveFile);
        Console.WriteLine("Journal saved to file successfully!");
    }

    static void LoadJournalFromFile()
    {
        Console.Write("Enter filename to load: ");
        string loadFile = Console.ReadLine();
        journal.LoadFromFile(loadFile);
        Console.WriteLine("Journal loaded from file successfully!");
    }
}
