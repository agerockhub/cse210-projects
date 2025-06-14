using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new();
    private int _score = 0;

    public int Score => _score;

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void ListGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }
    }

    public void RecordEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            int earned = _goals[index].RecordEvent();
            _score += earned;
            Console.WriteLine($"You earned {earned} points! Total score: {_score}");
        }
    }

    public void SaveGoals(string filename)
    {
        using StreamWriter writer = new(filename);
        writer.WriteLine(_score);
        foreach (var goal in _goals)
        {
            writer.WriteLine(goal.Serialize());
        }
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename)) return;

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];
            string name = parts[1];
            string desc = parts[2];
            int points = int.Parse(parts[3]);

            switch (type)
            {
                case "SimpleGoal":
                    bool isComplete = bool.Parse(parts[4]);
                    var sg = new SimpleGoal(name, desc, points);
                    if (isComplete) sg.RecordEvent();
                    _goals.Add(sg);
                    break;

                case "EternalGoal":
                    _goals.Add(new EternalGoal(name, desc, points));
                    break;

                case "ChecklistGoal":
                    int target = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    int current = int.Parse(parts[6]);
                    var cg = new ChecklistGoal(name, desc, points, target, bonus);
                    for (int j = 0; j < current; j++) cg.RecordEvent();
                    _goals.Add(cg);
                    break;
            }
        }
    }
}