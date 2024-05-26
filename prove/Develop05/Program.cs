using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            EternalQuest quest = new EternalQuest();

            quest.AddGoal(new SimpleGoal("Run a marathon", 1000));
            quest.AddGoal(new EternalGoal("Read scriptures", 100));
            quest.AddGoal(new ChecklistGoal("Attend temple", 50, 10, 500));

            quest.RecordEvent("Read scriptures");
            quest.RecordEvent("Read scriptures");
            quest.RecordEvent("Attend temple");
            quest.RecordEvent("Attend temple");
            quest.RecordEvent("Run a marathon");

            quest.ShowGoals();

            quest.Save("goals.json");
            quest.Load("goals.json");
            quest.ShowGoals();
        }
    }
}
