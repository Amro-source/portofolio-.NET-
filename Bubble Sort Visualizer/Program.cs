using System;
using System.Threading;

class SortingVisualizer
{
    static void Main()
    {
        Random rand = new Random();
        int[] array = new int[20];

        // Initialize array with random values
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(1, 20);
        }

        Console.WriteLine("=== Bubble Sort Visualizer ===");
        Console.CursorVisible = false; // Hide cursor for cleaner animation

        BubbleSort(array, rand);

        Console.CursorVisible = true;
        Console.WriteLine("\nSorting complete!");
    }

    static void BubbleSort(int[] arr, Random rand)
    {
        bool swapped;
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;

            for (int j = 0; j < n - 1 - i; j++)
            {
                // Clear screen and redraw current state
                Console.Clear();
                PrintArray(arr, j, j + 1);
                Thread.Sleep(300); // Delay for visualization

                if (arr[j] > arr[j + 1])
                {
                    // Swap elements
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }

            if (!swapped) break; // Optimization: early exit if sorted
        }
    }

    static void PrintArray(int[] arr, int highlight1 = -1, int highlight2 = -1)
    {
        Console.WriteLine("Bubble Sort Animation:");
        for (int i = 0; i < arr.Length; i++)
        {
            string v = new String('#', arr[i]);
            string bar = v;
            if (i == highlight1 || i == highlight2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[" + bar.PadRight(20) + "]");
                Console.ResetColor();
            }
            else
            {
                Console.Write("[" + bar.PadRight(20) + "]");
            }
            Console.WriteLine($" {arr[i]}");
        }
    }
}