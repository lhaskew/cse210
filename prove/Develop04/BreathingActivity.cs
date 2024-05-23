class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void PerformActivity(int duration)
    {
        StartActivity(duration);
        int secondsPerBreath = 4;
        int totalBreaths = duration / (secondsPerBreath * 2);

        for (int i = 0; i < totalBreaths; i++)
        {
            Console.WriteLine("Breathe in...");
            PauseWithCountdown(secondsPerBreath);
            Console.WriteLine("Breathe out...");
            PauseWithCountdown(secondsPerBreath);
        }

        EndActivity(duration);
    }
}
