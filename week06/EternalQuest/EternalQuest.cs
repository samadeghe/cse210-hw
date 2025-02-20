using System;
using System.Collections.Generic;
using System.IO;

class EternalQuest
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void CreateGoal()
    {
        Console.WriteLine("Choose goal type:\n1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal\n4. Progress Goal\n5. Negative Goal");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter point value: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, points));
                break;
            case 3:
                Console.Write("Enter target count: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, points, targetCount, bonusPoints));
                break;
            case 4:
                Console.Write("Enter goal completion value: ");
                int goalValue = int.Parse(Console.ReadLine());
                _goals.Add(new ProgressGoal(name, points, goalValue));
                break;
            case 5:
                _goals.Add(new NegativeGoal(name, points));
                break;
        }
        Console.WriteLine("Goal Created!");
    }

    public void RecordEvent()
    {
        Console.WriteLine("Choose a goal to record progress:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].Name} - {_goals[i].GetProgress()}");
        }
        int choice = int.Parse(Console.ReadLine()) - 1;
        int pointsEarned = _goals[choice].RecordEvent();
        _score += pointsEarned;
        Console.WriteLine($"Event recorded! You earned {pointsEarned} points.");
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine($"- {goal.Name}: {goal.GetProgress()}");
        }
        Console.WriteLine($"Total Score: {_score}");
    }

    public void SaveProgress()
    {
        using (StreamWriter file = new StreamWriter("progress.txt"))
        {
            file.WriteLine(_score);
            foreach (var goal in _goals)
            {
                file.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Points}");
            }
        }
        Console.WriteLine("Progress saved!");
    }

    public void LoadProgress()
    {
        if (!File.Exists("progress.txt")) return;

        using (StreamReader file = new StreamReader("progress.txt"))
        {
            _score = int.Parse(file.ReadLine());
            _goals.Clear();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                var parts = line.Split(',');
                string type = parts[0];
                string name = parts[1];
                int points = int.Parse(parts[2]);

                if (type == "SimpleGoal") _goals.Add(new SimpleGoal(name, points));
                else if (type == "EternalGoal") _goals.Add(new EternalGoal(name, points));
                else if (type == "NegativeGoal") _goals.Add(new NegativeGoal(name, points));
            }
        }
        Console.WriteLine("Progress loaded!");
    }
}
