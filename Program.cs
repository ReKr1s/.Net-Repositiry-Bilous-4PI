using System;
using System.Collections.Generic;
using Bilous.TaskPlanner.Domain.Models;
using Bilous.TaskPlanner.Domain.Models.Enums;
using Bilous.TaskPlanner.Domain.Logic;

internal static class Program
{
    public static void Main(string[] args)
    {
        var items = new List<WorkItem>();

        Console.WriteLine("=== Task Planner ===");
        while (true)
        {
            Console.Write("Title (or 'exit' to stop): ");
            string title = Console.ReadLine();
            if (title?.ToLower() == "exit")
                break;

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("Creation date (yyyy-MM-dd): ");
            DateTime creationDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString());

            Console.Write("Due date (yyyy-MM-dd): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString());

            Console.Write("Priority (None, Low, Medium, High, Urgent): ");
            Priority priority = Enum.Parse<Priority>(Console.ReadLine() ?? "None", true);

            Console.Write("Complexity (None, Minutes, Hours, Days, Weeks): ");
            Complexity complexity = Enum.Parse<Complexity>(Console.ReadLine() ?? "None", true);

            items.Add(new WorkItem
            {
                Title = title,
                Description = description,
                CreationDate = creationDate,
                DueDate = dueDate,
                Priority = priority,
                Complexity = complexity,
                IsCompleted = false
            });

            Console.WriteLine("Task added!\n");
        }

        var planner = new SimpleTaskPlanner();
        var sorted = planner.CreatePlan(items.ToArray());

        Console.WriteLine("\n=== Sorted Tasks ===");
        foreach (var item in sorted)
        {
            Console.WriteLine(item);
        }
    }
}