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
