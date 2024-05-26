using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EternalQuest
{
    // Main Program
    class EternalQuest
    {
        private List<Goal> goals;
        private int totalScore;

        public EternalQuest()
        {
            goals = new List<Goal>();
            totalScore = 0;
        }

        public void AddGoal(Goal goal)
        {
            goals.Add(goal);
        }

        public void RecordEvent(string goalName)
        {
            foreach (var goal in goals)
            {
                if (goal.Name == goalName)
                {
                    totalScore += goal.RecordEvent();
                    break;
                }
            }
        }

        public void ShowGoals()
        {
            foreach (var goal in goals)
            {
                Console.WriteLine(goal.DisplayStatus());
            }
            Console.WriteLine($"Total Score: {totalScore}");
        }

        public void Save(string filename)
        {
            var data = new
            {
                Goals = goals,
                TotalScore = totalScore
            };

            string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, jsonString);
        }

        public void Load(string filename)
        {
            if (File.Exists(filename))
            {
                string jsonString = File.ReadAllText(filename);
                var data = JsonSerializer.Deserialize<dynamic>(jsonString);
                totalScore = data.GetProperty("TotalScore").GetInt32();

                goals.Clear();
                foreach (var goalData in data.GetProperty("Goals").EnumerateArray())
                {
                    string type = goalData.GetProperty("Type").GetString();
                    string name = goalData.GetProperty("Name").GetString();
                    int pointsPerEvent = goalData.GetProperty("PointsPerEvent").GetInt32();

                    if (type == nameof(SimpleGoal))
                    {
                        bool isComplete = goalData.GetProperty("IsComplete").GetBoolean();
                        var goal = new SimpleGoal(name, pointsPerEvent) { IsComplete = isComplete };
                        goals.Add(goal);
                    }
                    else if (type == nameof(EternalGoal))
                    {
                        var goal = new EternalGoal(name, pointsPerEvent);
                        goals.Add(goal);
                    }
                    else if (type == nameof(ChecklistGoal))
                    {
                        int targetCount = goalData.GetProperty("TargetCount").GetInt32();
                        int currentCount = goalData.GetProperty("CurrentCount").GetInt32();
                        int bonusPoints = goalData.GetProperty("BonusPoints").GetInt32();
                        bool isComplete = goalData.GetProperty("IsComplete").GetBoolean();

                        var goal = new ChecklistGoal(name, pointsPerEvent, targetCount, bonusPoints)
                        {
                            CurrentCount = currentCount,
                            IsComplete = isComplete
                        };
                        goals.Add(goal);
                    }
                }
            }
        }
    }
}
