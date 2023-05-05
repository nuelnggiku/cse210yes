using System;
using System.Collections.Generic;
using System.IO;
DateTime theCurrentTime = DateTime.Now;
string dateText = theCurrentTime.ToShortDateString();

class Entry {
    public string prompt { get; set; }
    public string response { get; set; }
    public string date { get; set; }

    public Entry(string prompt, string response, string date) {
        this.prompt = prompt;
        this.response = response;
        this.date = date;
    }

    public override string ToString() {
        return $"[{date}] {prompt}: {response}";
    }
}


class Journal {
    private List<string> prompts = new List<string>() {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    private List<Entry> entries = new List<Entry>();
    private string currentFilename = "";

    public void NewEntry() {
        Random rand = new Random();
        int index = rand.Next(prompts.Count);
        Console.WriteLine(prompts[index]);
        string response = Console.ReadLine();
        Entry entry = new Entry(prompts[index], response, DateTime.Now.ToString());
        entries.Add(entry);
    }

    public void DisplayJournal() {
        foreach (Entry entry in entries) {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile() {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename)) {
            foreach (Entry entry in entries) {
                writer.WriteLine($"{entry.prompt},{entry.response},{entry.date}");
            }
        }
        currentFilename = filename;
    }

    public void LoadFromFile() {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();
        entries.Clear();
        using (StreamReader reader = new StreamReader(filename)) {
            while (!reader.EndOfStream) {
                string line = reader.ReadLine();
                string[] fields = line.Split(',');
                if (fields.Length == 3) {
                    Entry entry = new Entry(fields[0], fields[1], fields[2]);
                    entries.Add(entry);
                }
            }
        }
        currentFilename = filename;
    }

    public void MainMenu() {
        bool done = false;
        while (!done) {
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save to file");
            Console.WriteLine("4. Load from file");
            Console.WriteLine("5. Quit");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();
            switch (choice) {
                case "1":
                    NewEntry();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    SaveToFile();
                    break;
                case "4":
                    LoadFromFile();
                    break;
                case "5":
                    done = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

class Program {
    static void Main(string[] args) {
        Journal journal = new Journal();
        journal.MainMenu();
    }
}

using System;
using System.Collections.Generic;
using System.IO;
DateTime theCurrentTime = DateTime.Now;
string dateText = theCurrentTime.ToShortDateString();

class Entry {
    public string prompt { get; set; }
    public string response { get; set; }
    public string date { get; set; }

    public Entry(string prompt, string response, string date) {
        this.prompt = prompt;
        this.response = response;
        this.date = date;
    }

    public override string ToString() {
        return $"[{date}] {prompt}: {response}";
    }
}


class Journal {
    private List<string> prompts = new List<string>() {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    private List<Entry> entries = new List<Entry>();
    private string currentFilename = "";

    public void NewEntry() {
        Random rand = new Random();
        int index = rand.Next(prompts.Count);
        Console.WriteLine(prompts[index]);
        string response = Console.ReadLine();
        Entry entry = new Entry(prompts[index], response, DateTime.Now.ToString());
        entries.Add(entry);
    }

    public void DisplayJournal() {
        foreach (Entry entry in entries) {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile() {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename)) {
            foreach (Entry entry in entries) {
                writer.WriteLine($"{entry.prompt},{entry.response},{entry.date}");
            }
        }
        currentFilename = filename;
    }

    public void LoadFromFile() {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();
        entries.Clear();
        using (StreamReader reader = new StreamReader(filename)) {
            while (!reader.EndOfStream) {
                string line = reader.ReadLine();
                string[] fields = line.Split(',');
                if (fields.Length == 3) {
                    Entry entry = new Entry(fields[0], fields[1], fields[2]);
                    entries.Add(entry);
                }
            }
        }
        currentFilename = filename;
    }

    public void MainMenu() {
        bool done = false;
        while (!done) {
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save to file");
            Console.WriteLine("4. Load from file");
            Console.WriteLine("5. Quit");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();
            switch (choice) {
                case "1":
                    NewEntry();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    SaveToFile();
                    break;
                case "4":
                    LoadFromFile();
                    break;
                case "5":
                    done = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

class Program {
    static void Main(string[] args) {
        Journal journal = new Journal();
        journal.MainMenu();
    }
}

using System;
using System.Collections.Generic;
using System.IO;
DateTime theCurrentTime = DateTime.Now;
string dateText = theCurrentTime.ToShortDateString();

class Entry {
    public string prompt { get; set; }
    public string response { get; set; }
    public string date { get; set; }

    public Entry(string prompt, string response, string date) {
        this.prompt = prompt;
        this.response = response;
        this.date = date;
    }

    public override string ToString() {
        return $"[{date}] {prompt}: {response}";
    }
}


class Journal {
    private List<string> prompts = new List<string>() {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    private List<Entry> entries = new List<Entry>();
    private string currentFilename = "";

    public void NewEntry() {
        Random rand = new Random();
        int index = rand.Next(prompts.Count);
        Console.WriteLine(prompts[index]);
        string response = Console.ReadLine();
        Entry entry = new Entry(prompts[index], response, DateTime.Now.ToString());
        entries.Add(entry);
    }

    public void DisplayJournal() {
        foreach (Entry entry in entries) {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile() {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename)) {
            foreach (Entry entry in entries) {
                writer.WriteLine($"{entry.prompt},{entry.response},{entry.date}");
            }
        }
        currentFilename = filename;
    }

    public void LoadFromFile() {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();
        entries.Clear();
        using (StreamReader reader = new StreamReader(filename)) {
            while (!reader.EndOfStream) {
                string line = reader.ReadLine();
                string[] fields = line.Split(',');
                if (fields.Length == 3) {
                    Entry entry = new Entry(fields[0], fields[1], fields[2]);
                    entries.Add(entry);
                }
            }
        }
        currentFilename = filename;
    }

    public void MainMenu() {
        bool done = false;
        while (!done) {
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save to file");
            Console.WriteLine("4. Load from file");
            Console.WriteLine("5. Quit");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();
            switch (choice) {
                case "1":
                    NewEntry();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    SaveToFile();
                    break;
                case "4":
                    LoadFromFile();
                    break;
                case "5":
                    done = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

class Program {
    static void Main(string[] args) {
        Journal journal = new Journal();
        journal.MainMenu();
    }
}