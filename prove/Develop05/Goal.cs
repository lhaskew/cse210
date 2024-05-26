using System;

namespace EternalQuest
{
    // Base class
    abstract class Goal
    {
        public string Name { get; set; }
        public int PointsPerEvent { get; set; }

        public Goal(string name, int pointsPerEvent)
        {
            Name = name;
            PointsPerEvent = pointsPerEvent;
        }

        public abstract int RecordEvent();
        public abstract string DisplayStatus();
    }
}
