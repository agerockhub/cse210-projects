using System;

class Program
{
    static void Main()
    {
        GoalManager manager = new();
        string file = "goals.txt";

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Goal Type (simple/eternal/checklist): ");
                    string type = Console.ReadLine();
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Description: ");
                    string desc = Console.ReadLine();
                    Console.Write("Points: ");
                    int points = int.Parse(Console.ReadLine());

                    if (type == "simple")
                        manager.AddGoal(new SimpleGoal(name, desc, points));
                    else if (type == "eternal")
                        manager.AddGoal(new EternalGoal(name, desc, points));
                    else if (type == "checklist")
                    {
                        Console.Write("Target Count: ");
                        int target = int.Parse(Console.ReadLine());
                        Console.Write("Bonus: ");
                        int bonus = int.Parse(Console.ReadLine());
                        manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                    }
                    break;

                case "2":
                    manager.ListGoals();
                    break;

                case "3":
                    manager.ListGoals();
                    Console.Write("Which goal number? ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordEvent(index);
                    break;

                case "4":
                    Console.WriteLine($"Current Score: {manager.Score}");
                    break;

                case "5":
                    manager.SaveGoals(file);
                    Console.WriteLine("Goals saved!");
                    break;

                case "6":
                    manager.LoadGoals(file);
                    Console.WriteLine("Goals loaded!");
                    break;

                case "7":
                    return;
            }
        }
    }
}