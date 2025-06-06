public abstract class MindfulnessActivity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting: {_name}");
        Console.WriteLine(_description);
        Console.Write("Enter duration (in seconds): ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        PauseWithSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        Console.WriteLine($"You completed the {_name} activity for {_duration} seconds.");
        PauseWithSpinner(3);
    }

    protected void PauseWithSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds * 2; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(500);
            Console.Write("\b");
        }
    }

    protected void PauseWithCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void RunActivity();
}
