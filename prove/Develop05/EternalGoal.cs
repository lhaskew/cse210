using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
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
