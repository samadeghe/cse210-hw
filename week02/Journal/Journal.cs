
using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    public class Journal
    {
        private List<Entry> entries = new List<Entry>();
        private List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        public void WriteNewEntry()
        {
            Random random = new Random();
            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine($"\nPrompt: {prompt}");
            Console.Write("Your response: ");
            string response = Console.ReadLine();

            Entry entry = new Entry(prompt, response);
            entries.Add(entry);
            Console.WriteLine("Entry added successfully!\n");
        }

        public void DisplayJournal()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("The journal is empty.");
                return;
            }

            Console.WriteLine("\nJournal Entries:");
            foreach (Entry entry in entries)
            {
                Console.WriteLine(entry);
            }
        }

        public void SaveJournalToFile()
        {
            Console.Write("Enter the filename to save the journal: ");
            string filename = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    // To exceed requirement I Save entries in a structured "|"-separated format for easier parsing.
                    foreach (Entry entry in entries)
                    {
                        writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                    }
                }
                Console.WriteLine("Journal saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving journal: {ex.Message}");
            }
        }

        public void LoadJournalFromFile()
        {
            Console.Write("Enter the filename to load the journal: ");
            string filename = Console.ReadLine();

            try
            {
                if (!File.Exists(filename))
                {
                    Console.WriteLine("File not found.");
                    return;
                }

                entries.Clear();

                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length == 3)
                        {
                            Entry entry = new Entry(parts[1], parts[2])
                            {
                                Date = parts[0]
                            };
                            entries.Add(entry);
                        }
                    }
                }
                Console.WriteLine("Journal loaded successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading journal: {ex.Message}");
            }
        }
    }
}
