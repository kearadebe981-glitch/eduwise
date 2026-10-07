using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// EduWise Companion (C#)
// A separate, lightweight exploration of the same EduWise idea: keeping
// track of academic deadlines, this time as a C# console app. Deadlines
// are saved to deadlines.txt so they persist between runs.

class Deadline
{
    public string Name;
    public DateTime Due;

    public Deadline(string name, DateTime due)
    {
        Name = name;
        Due = due;
    }

    public int DaysLeft()
    {
        return (Due.Date - DateTime.Today).Days;
    }
}

class Program
{
    static string dataFile = "deadlines.txt";
    static List<Deadline> deadlines = new List<Deadline>();

    static void Main()
    {
        Load();
        Console.WriteLine("=== EduWise Companion (C#) ===");
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Add a deadline");
            Console.WriteLine("2. View deadlines (soonest first)");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    AddDeadline();
                    break;
                case "2":
                    ViewDeadlines();
                    break;
                case "3":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Please choose 1, 2 or 3.");
                    break;
            }
        }
    }

    static void AddDeadline()
    {
        Console.Write("Deadline name: ");
        string name = Console.ReadLine()?.Trim();

        Console.Write("Due date (yyyy-MM-dd): ");
        string dateInput = Console.ReadLine()?.Trim();

        if (DateTime.TryParse(dateInput, out DateTime due))
        {
            deadlines.Add(new Deadline(name, due));
            Save();
            Console.WriteLine($"Added \"{name}\".");
        }
        else
        {
            Console.WriteLine("Could not understand that date. Use yyyy-MM-dd, e.g. 2026-11-20.");
        }
    }

    static void ViewDeadlines()
    {
        if (deadlines.Count == 0)
        {
            Console.WriteLine("No deadlines added yet.");
            return;
        }

        Console.WriteLine("\n--- Your Deadlines ---");
        foreach (var d in deadlines.OrderBy(d => d.Due))
        {
            int daysLeft = d.DaysLeft();
            string status = daysLeft < 0 ? "OVERDUE" : $"{daysLeft} day(s) left";
            Console.WriteLine($"{d.Name} | Due: {d.Due:yyyy-MM-dd} | {status}");
        }
    }

    static void Save()
    {
        using (var writer = new StreamWriter(dataFile, false))
        {
            foreach (var d in deadlines)
            {
                writer.WriteLine($"{d.Name}|{d.Due:yyyy-MM-dd}");
            }
        }
    }

    static void Load()
    {
        if (!File.Exists(dataFile)) return;

        foreach (var line in File.ReadAllLines(dataFile))
        {
            var parts = line.Split('|');
            if (parts.Length == 2 && DateTime.TryParse(parts[1], out DateTime due))
            {
                deadlines.Add(new Deadline(parts[0], due));
            }
        }
    }
}
