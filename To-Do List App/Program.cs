using System;
using System.Collections.Generic;
using System.IO;

class TodoList
{
    private const string FileName = "todo.txt";

    static void Main()
    {
        List<string> tasks = LoadTasks();

        while (true)
        {
            Console.WriteLine("\n--- To-Do List ---");
            Console.WriteLine("1. View Tasks");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Remove Task");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewTasks(tasks);
                    break;
                case "2":
                    AddTask(tasks);
                    break;
                case "3":
                    RemoveTask(tasks);
                    break;
                case "4":
                    SaveTasks(tasks);
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static List<string> LoadTasks()
    {
        if (!File.Exists(FileName)) return new List<string>();
        return new List<string>(File.ReadAllLines(FileName));
    }

    static void SaveTasks(List<string> tasks)
    {
        File.WriteAllLines(FileName, tasks);
    }

    static void ViewTasks(List<string> tasks)
    {
        Console.WriteLine("\nYour Tasks:");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }

    static void AddTask(List<string> tasks)
    {
        Console.Write("Enter task: ");
        string task = Console.ReadLine();
        tasks.Add(task);
    }

    static void RemoveTask(List<string> tasks)
    {
        ViewTasks(tasks);
        Console.Write("Enter task number to remove: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            tasks.RemoveAt(index - 1);
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }
}