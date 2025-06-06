public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    public override void RunActivity()
    {
        DisplayStartingMessage();
        int cycle = _duration / 6; // Each cycle has 3s in + 3s out

        for (int i = 0; i < cycle; i++)
        {
            Console.Write("Breathe in... ");
            PauseWithCountdown(3);
            Console.Write("Now breathe out... ");
            PauseWithCountdown(3);
        }

        DisplayEndingMessage();
    }
}
