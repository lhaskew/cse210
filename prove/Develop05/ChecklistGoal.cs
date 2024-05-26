using System;

namespace EternalQuest
{
    // Derived class for checklist goals
    class ChecklistGoal : Goal
    {
        public int TargetCount { get; set; }
        public int CurrentCount { get; set; }
        public int BonusPoints { get; set; }
        public bool IsComplete { get; set; }

        public ChecklistGoal(string name, int pointsPerEvent, int targetCount, int bonusPoints)
            : base(name, pointsPerEvent)
        {
            TargetCount = targetCount;
            CurrentCount = 0;
            BonusPoints = bonusPoints;
            IsComplete = false;
        }

        public override int RecordEvent()
        {
            if (!IsComplete)
            {
                CurrentCount++;
                if (CurrentCount >= TargetCount)
                {
                    IsComplete = true;
                    return PointsPerEvent + BonusPoints;
                }
                return PointsPerEvent;
            }
            return 0;
        }

        public override string DisplayStatus()
        {
            string status = IsComplete ? "[X]" : "[ ]";
            return $"{status} {Name} (Completed {CurrentCount}/{TargetCount} times)";
        }
    }
}
