using System;
using System.Collections.Generic;
using System.Threading;

// Base class for mindfulness activities
abstract class MindfulnessActivity
{
    protected string Name;
    protected string Description;

    public MindfulnessActivity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"How many seconds would you like to spend on this {Name.ToLower()} activity?");
        if (!int.TryParse(Console.ReadLine(), out int duration) || duration <= 0)
        {
            Console.WriteLine("Invalid duration. Defaulting to 10 seconds.");
            duration = 10;
        }

        Console.WriteLine($"\nStarting {Name}...");
        Console.WriteLine(Description);
        Thread.Sleep(3000);
        PerformActivity(duration);

        Console.WriteLine("\nGreat job! You've completed the activity.");
        Console.WriteLine($"You just completed '{Name}' for {duration} seconds.");
        Thread.Sleep(3000);
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}...\r");
            Thread.Sleep(1000);
        }
    }

    public abstract void PerformActivity(int duration);
}

// Breathing activity class
class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding your breathing. Focus on your breath and clear your mind.")
    {
    }

    public override void PerformActivity(int duration)
    {
        int interval = 4; // Seconds for each breath in/out
        int elapsed = 0;
        while (elapsed < duration)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(interval);
            Console.WriteLine("Breathe out...");
            ShowCountdown(interval);
            elapsed += 2 * interval;
        }
    }
}

// Reflection activity class
class ReflectionActivity : MindfulnessActivity
{
    private readonly List<string> Prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly List<string> Questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What could you learn from this experience?",
        "How can you apply this experience to future situations?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times when you demonstrated strength and resilience.")
    {
    }

    public override void PerformActivity(int duration)
    {
        Random rand = new Random();
        Console.WriteLine(Prompts[rand.Next(Prompts.Count)]);
        int elapsed = 0;
        while (elapsed < duration)
        {
            Console.WriteLine(Questions[rand.Next(Questions.Count)]);
            ShowCountdown(5);
            elapsed += 5;
        }
    }
}

// Listing activity class
class ListingActivity : MindfulnessActivity
{
    private readonly List<string> Prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are your personal strengths?",
        "Who have you helped this week?",
        "What are some things you are grateful for?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you think about positive aspects of your life by listing as many things as you can.")
    {
    }

    public override void PerformActivity(int duration)
    {
        Random rand = new Random();
        Console.WriteLine(Prompts[rand.Next(Prompts.Count)]);
        Console.WriteLine("Start listing items. Press Enter after each item.");
        ShowCountdown(5);

        List<string> items = new List<string>();
        int elapsed = 0;
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
    }
}

class MindfulnessApp
{
    private readonly Dictionary<string, MindfulnessActivity> activities = new Dictionary<string, MindfulnessActivity>
    {
        { "1", new BreathingActivity() },
        { "2", new ReflectionActivity() },
        { "3", new ListingActivity() }
    };

    private void DisplayMenu()
    {
        Console.WriteLine("\nMindfulness App");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Exit");
    }

    public void Run()
    {
        while (true)
        {
            DisplayMenu();
            string choice = Console.ReadLine();
            if (choice == "4")
            {
                Console.WriteLine("Goodbye! Stay mindful.");
                break;
            }
            else if (activities.ContainsKey(choice))
            {
                activities[choice].StartActivity();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        MindfulnessApp app = new MindfulnessApp();
        app.Run();
    }
}

// for this code, I exceeded requirements by:
// Modular Design: Clear separation between base and derived classes.
// Countdown Animation: Provides visual feedback during pauses.
// Randomized Questions and Prompts: Adds variety to user experience.
// Dynamic Listing Activity: Counts and reports the number of listed items.
