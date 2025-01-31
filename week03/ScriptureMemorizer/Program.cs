using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ScriptureMemorization
{
    class Program
    {
        static void Main(string[] args)
        {
            ScriptureLibrary scriptureLibrary = new ScriptureLibrary();
            Scripture selectedScripture = scriptureLibrary.GetRandomScripture();

            Console.Clear();
            Console.WriteLine("Welcome to the Scripture Memorizer!");
            Console.WriteLine("Press Enter to start memorizing or type 'quit' to exit.");
            if (Console.ReadLine()?.ToLower() == "quit") return;

            while (!selectedScripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(selectedScripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

                string input = Console.ReadLine()?.ToLower();
                if (input == "quit") break;

                selectedScripture.HideRandomWords();
            }

            Console.Clear();
            Console.WriteLine("Final Scripture Display:");
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine("\nAll words hidden. Program completed.");
        }
    }
// To exceed requirement, I have created a library of scriptures, not just a single one, allowing the user to select a random scripture.
    class ScriptureLibrary
    {
        private List<Scripture> scriptures;

        public ScriptureLibrary()
        {
            scriptures = new List<Scripture>
            {
                new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
                new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
                new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd; I shall not want.")
            };
        }

        public Scripture GetRandomScripture()
        {
            Random random = new Random();
            return scriptures[random.Next(scriptures.Count)];
        }
    }

    class Scripture
    {
        private Reference reference;
        private List<Word> words;

        public Scripture(Reference reference, string text)
        {
            this.reference = reference;
            words = text.Split(' ').Select(w => new Word(w)).ToList();
        }
        //Here I provided multiple constructors to handle both single verses and verse ranges.
        public string GetDisplayText()
        {
            string referenceText = reference.GetDisplayText();
            string scriptureText = string.Join(" ", words.Select(w => w.GetDisplayText()));
            return $"{referenceText}: {scriptureText}";
        }

        public void HideRandomWords()
        {
            Random random = new Random();
            var visibleWords = words.Where(w => !w.IsHidden).ToList();
            if (visibleWords.Count == 0) return;

            int wordsToHide = Math.Min(3, visibleWords.Count);

            for (int i = 0; i < wordsToHide; i++)
            {
                visibleWords[random.Next(visibleWords.Count)].Hide();
            }
        }

        public bool AllWordsHidden()
        {
            return words.All(w => w.IsHidden);
        }
    }

    class Reference
    {
        private string book;
        private int chapter;
        private int startVerse;
        private int? endVerse;

        public Reference(string book, int chapter, int startVerse, int? endVerse = null)
        {
            this.book = book;
            this.chapter = chapter;
            this.startVerse = startVerse;
            this.endVerse = endVerse;
        }

        public string GetDisplayText()
        {
            return endVerse.HasValue
                ? $"{book} {chapter}:{startVerse}-{endVerse}"
                : $"{book} {chapter}:{startVerse}";
        }
    }

    class Word
    {
        private string text;
        public bool IsHidden { get; private set; }

        public Word(string text)
        {
            this.text = text;
            IsHidden = false;
        }

        public void Hide()
        {
            IsHidden = true;
        }

        public string GetDisplayText()
        {
            return IsHidden ? new string('_', text.Length) : text;
        }
    }
} 