
using System;

namespace JournalApp
{
    public class Entry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string Date { get; set; }

        // To exceed requirement I Automatically capture the full timestamp of when an entry is created.
        public Entry(string prompt, string response)
        {
            Prompt = prompt;
            Response = response;
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public override string ToString()
        {
            return $"[{Date}] {Prompt}\nResponse: {Response}\n";
        }
    }
}