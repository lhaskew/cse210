using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EternalQuest
{
    public class EternalQuest
    {
        private Dictionary<string, Goal> goals;
        private int totalScore;

        public EternalQuest()
        {
            goals = new Dictionary<string, Goal>();
            totalScore = 0;
        }

        public void AddGoal(Goal goal)
        {
            goals[goal.Name] = goal;
        }

        public void RecordEvent(string goalName)
        {
            if (goals.ContainsKey(goalName))
            {
                totalScore += goals[goalName].RecordEvent();
            }
            else
            {
                Console.WriteLine($"Goal '{goalName}' not found.");
            }
        }

        public void ShowGoals()
        {
            foreach (var goal in goals.Values)
            {
                Console.WriteLine(goal.DisplayStatus());
            }
            Console.WriteLine($"Total Score: {totalScore}");
        }

        public void Save(string filename)
        {
            var goalList = new List<dynamic>();
            
            foreach (var goal in goals.Values)
            {
                dynamic goalData = new System.Dynamic.ExpandoObject();
                goalData.Name = goal.Name;
                goalData.PointsPerEvent = goal.PointsPerEvent;
                goalData.Type = goal.GetType().Name;
                
                if (goal is SimpleGoal simpleGoal)
                {
                    goalData.IsComplete = simpleGoal.IsComplete;
                }
                else if (goal is EternalGoal)
                {
                    // No additional properties for EternalGoal
                }
                else if (goal is ChecklistGoal checklistGoal)
                {
                    goalData.TargetCount = checklistGoal.TargetCount;
                    goalData.CurrentCount = checklistGoal.CurrentCount;
                    goalData.BonusPoints = checklistGoal.BonusPoints;
                    goalData.IsComplete = checklistGoal.IsComplete;
                }

                goalList.Add(goalData);
            }

            string jsonString = JsonSerializer.Serialize(goalList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, jsonString);
        }

        public void Load(string filename)
        {
            if (File.Exists(filename))
            {
                string jsonString = File.ReadAllText(filename);
                var goalList = JsonSerializer.Deserialize<List<dynamic>>(jsonString);
                
                goals.Clear();
                
                foreach (var goalData in goalList)
                {
                    string type = goalData.Type;
                    string name = goalData.Name;
                    int pointsPerEvent = goalData.PointsPerEvent;
                    
                    Goal goal = null;
                    
                    if (type == nameof(SimpleGoal))
                    {
                        bool isComplete = goalData.IsComplete;
                        goal = new SimpleGoal(name, pointsPerEvent) { IsComplete = isComplete };
                    }
                    else if (type == nameof(EternalGoal))
                    {
                        goal = new EternalGoal(name, pointsPerEvent);
                    }
                    else if (type == nameof(ChecklistGoal))
                    {
                        int targetCount = goalData.TargetCount;
                        int currentCount = goalData.CurrentCount;
                        int bonusPoints = goalData.BonusPoints;
                        bool isComplete = goalData.IsComplete;

                        goal = new ChecklistGoal(name, pointsPerEvent, targetCount, bonusPoints)
                        {
                            CurrentCount = currentCount,
                            IsComplete = isComplete
                        };
                    }
                    
                    if (goal != null)
                    {
                        goals[name] = goal;
                    }
                }
            }
        }

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
