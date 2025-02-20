class Program
{
    static void Main()
    {
        EternalQuest quest = new EternalQuest();
        quest.LoadProgress();

        while (true)
        {
            Console.WriteLine("\n1. Create Goal\n2. Record Event\n3. Display Goals\n4. Save Progress\n5. Exit");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1) quest.CreateGoal();
            else if (choice == 2) quest.RecordEvent();
            else if (choice == 3) quest.DisplayGoals();
            else if (choice == 4) quest.SaveProgress();
            else if (choice == 5) break;
        }
    }
}
// using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 4.8),
            new Cycling(new DateTime(2022, 11, 3), 45, 20.0),
            new Swimming(new DateTime(2022, 11, 3), 25, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
