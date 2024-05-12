using System;

public class Program
{
    static void Main(string[] args)
    {
        ScriptureReference reference = new ScriptureReference("John 3:16");
        string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        Scripture scripture = new Scripture(reference, text);

        bool continueHiding = true;
        while (continueHiding)
        {
            Console.Clear();
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide another word or type 'quit' to exit:");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
                continueHiding = false;
            else
                continueHiding = scripture.HideRandomWord();
        }
    }
}
