
using System;

namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nJournal Menu:");
                Console.WriteLine("1. Write a New Entry");
                Console.WriteLine("2. Display the Journal");
                Console.WriteLine("3. Save the Journal to a File");
                Console.WriteLine("4. Load the Journal from a File");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option (1-5): ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        journal.WriteNewEntry();
                        break;
                    case "2":
                        journal.DisplayJournal();
                        break;
                    case "3":
                        journal.SaveJournalToFile();
                        break;
                    case "4":
                        journal.LoadJournalFromFile();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

