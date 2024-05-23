using System;
using System.Threading;

abstract class MindfulnessActivity
{
    protected string Name { get; set; }
    protected string Description { get; set; }

    public MindfulnessActivity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void StartActivity(int duration)
    {
        Console.WriteLine($"Starting {Name} Activity");
        Console.WriteLine(Description);
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine("Prepare to begin...");
        PauseWithCountdown(3);
    }

    public void EndActivity(int duration)
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {Name} Activity for {duration} seconds.");
        PauseWithCountdown(3);
    }

    protected void PauseWithCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"Starting in {i}...");
            Thread.Sleep(1000);
        }
        Console.WriteLine("Go!");
    }

    public abstract void PerformActivity(int duration);
}
