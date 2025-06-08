using System;

class LinkedListApp
{
    static void Main()
    {
        MyLinkedList list = new MyLinkedList();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Console.WriteLine("Linked List:");
        list.Print(); // Output: 10 -> 20 -> 30 -> null

        list.Remove(20);
        Console.WriteLine("\nAfter removing 20:");
        list.Print(); // Output: 10 -> 30 -> null

        list.Add(40);
        Console.WriteLine("\nAfter adding 40:");
        list.Print(); // Output: 10 -> 30 -> 40 -> null
    }
}

// Node class
public class Node
{
    public int Value { get; set; }
    public Node Next { get; set; }

    public Node(int value)
    {
        Value = value;
        Next = null;
    }
}

// Linked List class
public class MyLinkedList
{
    private Node head;

    // Add node at the end
    public void Add(int value)
    {
        Node newNode = new Node(value);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    // Remove node by value
    public void Remove(int value)
    {
        if (head == null) return;

        // If head is the node to remove
        if (head.Value == value)
        {
            head = head.Next;
            return;
        }

        Node current = head;
        while (current.Next != null && current.Next.Value != value)
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            current.Next = current.Next.Next; // Skip the node
        }
    }

    // Print entire list
    public void Print()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Value + " -> ");
            current = current.Next;
        }
        Console.Write("null");
    }
}