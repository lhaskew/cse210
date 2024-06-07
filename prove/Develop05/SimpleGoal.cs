namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public bool IsComplete { get; set; }

        public SimpleGoal(string name, int pointsPerEvent) : base(name, pointsPerEvent)
        {
            IsComplete = false;
        }

        public override int RecordEvent()
        {
            if (!IsComplete)
            {
                IsComplete = true;
                return PointsPerEvent;
            }
            return 0;
        }

        public override string DisplayStatus()
        {
            string status = IsComplete ? "[X]" : "[ ]";
            return $"{status} {Name}";
        }
    }
}
