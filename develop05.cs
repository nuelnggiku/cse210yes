using System;
using System.Collections.Generic;

// Base class for activities
public class Activity {
    public string Name { get; set; }
    public int Points { get; set; }

    // Constructor
    public Activity(string name) {
        Name = name;
        Points = 0;
    }

    // Method to start activity (to be overridden by subclasses)
    public virtual void Start() {}

    // Method to display activity status
    public virtual string Status() {
        return $"{Name}: {Points} points";
    }
}

// Subclass for marathon running activity
public class MarathonActivity : Activity {
    // Constructor
    public MarathonActivity() : base("Run a marathon") {}

    // Method to start activity
    public override void Start() {
        Console.WriteLine("You just ran a marathon!");
        Points += 1000;
    }
}

// Subclass for reading scriptures activity
public class ScripturesActivity : Activity {
    // Constructor
    public ScripturesActivity() : base("Read scriptures") {}

    // Method to start activity
    public override void Start() {
        Console.WriteLine("You just read your scriptures!");
        Points += 100;
    }
}

// Subclass for temple attendance activity
public class TempleActivity : Activity {
    private const int NUM_GOALS = 10;
    private const int POINTS_PER_VISIT = 50;
    private const int BONUS_POINTS = 500;

    private int goalsCompleted = 0;

    // Constructor
    public TempleActivity() : base("Attend the temple") {}

    // Method to start activity
    public override void Start() {
        Console.WriteLine("You just attended the temple!");
        Points += POINTS_PER_VISIT;
        goalsCompleted++;

        if (goalsCompleted >= NUM_GOALS) {
            Console.WriteLine($"Congratulations! You completed all {NUM_GOALS} goals and received a bonus of {BONUS_POINTS} points.");
            Points += BONUS_POINTS;
        }
    }

    // Method to display activity status
    public override string Status() {
        return $"{Name}: {Points} points (completed {goalsCompleted}/{NUM_GOALS} goals)";
    }
}

// Class for interacting with user and displaying menu
public class QuestMenu {
    private const string FILENAME = "quest_data.txt";

    private List<Activity> activities = new List<Activity>();

    // Constructor
    public QuestMenu() {
        LoadData();
        AddDefaults();
    }

    // Method to add default activities
    private void AddDefaults() {
        activities.Add(new MarathonActivity());
        activities.Add(new ScripturesActivity());
        activities.Add(new TempleActivity());
    }

    // Method to show menu and interact with user
    public void ShowMenu() {
        while (true) {
            Console.Clear();
            Console.WriteLine("Welcome to Quest!");
            Console.WriteLine("------------------");

            int i = 1;
            foreach (Activity activity in activities) {
                Console.WriteLine($"{i++}. {activity.Status()}");
            }

            Console.WriteLine($"{i++}. Add new goal");
            Console.WriteLine($"{i++}. Record event");
            Console.WriteLine($"{i++}. Quit");

            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice)) {
                if (choice >= 1 && choice <= activities.Count) {
                    activities[choice - 1].Start();
                    SaveData();
                } else if (choice == i - 3) {
                    AddGoal();
                } else if (choice == i - 2) {
                    RecordEvent();
                    SaveData();
                } else if (choice == i - 1) {
                    break;
                } else {
                    Console.WriteLine("Invalid choice.");
                }
            } else {
                Console.WriteLine("Invalid input.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }

    // Method to add a new goal
    private void AddGoal() {
        Console.Write("Enter the name of the goal: ");
        string name = Console.ReadLine();
        activities.Add(new Activity(name));
        SaveData();
    }

    // Method to record an event for a given goal
    private void RecordEvent() {
        while (true) {
            Console.Clear();
            Console.WriteLine("Record Event");
            Console.WriteLine("------------");

            int i = 1;
            foreach (Activity activity in activities) {
                Console.WriteLine($"{i++}. {activity.Name}");
            }

            Console.WriteLine($"{i++}. Cancel");

            Console.Write("Enter the number of the goal you completed: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice)) {
                if (choice >= 1 && choice <= activities.Count) {
                    activities[choice - 1].Start();
                    return;
                } else if (choice == i - 1) {
                    return;
                } else {
                    Console.WriteLine("Invalid choice.");
                }
            } else {
                Console.WriteLine("Invalid input.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }

    // Method to load data from file
    private void LoadData() {
        try {
            string[] lines = System.IO.File.ReadAllLines(FILENAME);
            foreach (string line in lines) {
                string[] parts = line.Split(',');
                if (parts.Length == 2) {
                    string name = parts[0];
                    int points = int.Parse(parts[1]);
                    activities.Add(new Activity(name) { Points = points });
                }
            }
        } catch (Exception) {
            // Ignore errors
        }
    }

    // Method to save data to file
    private void SaveData() {
        try {
            List<string> lines = new List<string>();
            foreach (Activity activity in activities) {
                lines.Add($"{activity.Name},{activity.Points}");
            }
            System.IO.File.WriteAllLines(FILENAME, lines);
        } catch (Exception) {
            // Ignore errors
        }
    }
}

// Main program class
class Program {
    static void Main(string[] args) {
        QuestMenu menu = new QuestMenu();
        menu.ShowMenu();
    }
}