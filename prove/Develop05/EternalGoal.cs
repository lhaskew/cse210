using System;

namespace EternalQuest
{
    // Derived class for eternal goals
    class EternalGoal : Goal
    {
        public EternalGoal(string name, int pointsPerEvent) : base(name, pointsPerEvent) { }

        public override int RecordEvent()
        {
            return PointsPerEvent;
        }

        public override string DisplayStatus()
        {
            return $"[∞] {Name}";
        }
    }
}
