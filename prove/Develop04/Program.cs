using System;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, MindfulnessActivity> activities = new Dictionary<string, MindfulnessActivity>
        {
            { "1", new BreathingActivity() },
            { "2", new ReflectionActivity() },
            { "3", new ListingActivity() }
        };

        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Quit");

            string choice = Console.ReadLine();
            if (choice == "4")
            {
                break;
            }

            if (activities.ContainsKey(choice))
            {
                Console.Write("Enter the duration in seconds: ");
                if (int.TryParse(Console.ReadLine(), out int duration))
                {
                    activities[choice].PerformActivity(duration);
                }
                else
                {
                    Console.WriteLine("Invalid duration. Please enter a number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}
