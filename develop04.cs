using System;
using System.Threading;

// Base class for all activities
public abstract class Activity {
    // Shared attributes
    private string name;
    private int duration;

    // Constructor
    public Activity(string name) {
        this.name = name;
    }

    // Method to set duration
    public void SetDuration(int duration) {
        this.duration = duration;
    }

    // Abstract method to start activity
    public abstract void Start();
}

// Subclass for breathing activity
public class BreathingActivity : Activity {
    // Constructor
    public BreathingActivity() : base("Breathing") {}

    // Method to start activity
    public override void Start() {
        Console.WriteLine("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Console.Write("Enter duration in seconds: ");
        int duration = Int32.Parse(Console.ReadLine());
        SetDuration(duration);
        Console.WriteLine("Get ready to start.");
        Thread.Sleep(3000); // Pause for 3 seconds with spinner animation

        for (int i = 1; i <= duration; i++) {
            if (i % 2 == 1) {
                Console.WriteLine("Breathe in...");
            } else {
                Console.WriteLine("Breathe out...");
            }
            Thread.Sleep(3000); // Pause for 3 seconds with countdown timer
        }

        Console.WriteLine("Good job! You completed the " + name + " activity for " + duration + " seconds.");
        Thread.Sleep(3000); // Pause for 3 seconds with period animation
    }
}

// Subclass for reflection activity
public class ReflectionActivity : Activity {
    // Private member variables
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    // Constructor
    public ReflectionActivity() : base("Reflection") {}

    // Method to start activity
    public override void Start() {
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Console.Write("Enter duration in seconds: ");
        int duration = Int32.Parse(Console.ReadLine());
        SetDuration(duration);
        Console.WriteLine("Get ready to start.");
        Thread.Sleep(3000); // Pause for 3 seconds with spinner animation

        Random rand = new Random();
        int promptIndex = rand.Next(prompts.Length);
        Console.WriteLine(prompts[promptIndex]);
        Thread.Sleep(3000); // Pause for 3 seconds with spinner animation

        foreach (string question in questions) {
            Console.WriteLine(question);
            Thread.Sleep(3000); // Pause for 3 seconds with spinner animation
        }

        Console.WriteLine("Good job! You completed the " + name + " activity for " + duration + " seconds.");
        Thread.Sleep(3000); // Pause for 3 seconds with period animation
    }
}

// Subclass for listing activity
public class ListingActivity : Activity {
    // Private member variables
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    // Constructor
    public ListingActivity() : base("Listing") {}

    // Method to start activity
    public override void Start() {
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.Write("Enter duration in seconds: ");
        int duration = Int32.Parse(Console.ReadLine());
        SetDuration(duration);
        Console.WriteLine("Get ready to start.");
        Thread.Sleep(3000); // Pause for 3 seconds with spinner animation

        Random rand = new Random();
        int promptIndex = rand.Next(prompts.Length);
        Console.WriteLine(prompts[promptIndex]);
        Thread.Sleep(5000); // Pause for 5 seconds with countdown timer

        int numItems = 0;
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < duration) {
            Console.Write("Enter an item: ");
            string item = Console.ReadLine();
            numItems++;
        }

        Console.WriteLine("You listed " + numItems + " items.");
        Console.WriteLine("Good job! You completed the " + name + " activity for " + duration + " seconds.");
        Thread.Sleep(3000); // Pause for 3 seconds with period animation
    }
}

// Menu class to display menu and interact with user
public class Menu {
    // Private member variables
    private Activity[] activities = { new BreathingActivity(), new ReflectionActivity(), new ListingActivity() };
    
    // Method to display menu
    public void ShowMenu() {
        while (true) {
            Console.WriteLine("Choose an activity:");
            for (int i = 0; i < activities.Length; i++) {
                Console.WriteLine((i + 1) + ". " + activities[i].GetName());
            }
            Console.WriteLine((activities.Length + 1) + ". Exit");

            int choice = Int32.Parse(Console.ReadLine());

            if (choice >= 1 && choice <= activities.Length) {
                activities[choice - 1].Start();
            } else if (choice == activities.Length + 1) {
                break;
            } else {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}

// Main function
class Program {
    static void Main(string[] args) {
        Menu menu = new Menu();
        menu.ShowMenu();
    }
}