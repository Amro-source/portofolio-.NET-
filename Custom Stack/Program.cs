using System;

class StackApp
{
    static void Main()
    {
        MyStack stack = new MyStack();

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Console.WriteLine("Stack Contents:");
        stack.Print(); // 30 -> 20 -> 10 -> null

        Console.WriteLine("\n\nPopping top item...");
        Console.WriteLine("Popped: " + stack.Pop());

        Console.WriteLine("\nStack after pop:");
        stack.Print(); // 20 -> 10 -> null

        Console.WriteLine("\n\nPeek top item: " + stack.Peek());
    }
}

// Node class for linked list
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

// Custom Stack class
public class MyStack
{
    private Node top;

    // Add item to the top of the stack
    public void Push(int value)
    {
        Node newNode = new Node(value);
        newNode.Next = top;
        top = newNode;
    }

    // Remove and return top item
    public int Pop()
    {
        if (top == null)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        int value = top.Value;
        top = top.Next;
        return value;
    }

    // Return top item without removing
    public int Peek()
    {
        if (top == null)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        return top.Value;
    }

    // Check if stack is empty
    public bool IsEmpty()
    {
        return top == null;
    }

    // Print entire stack
    public void Print()
    {
        Node current = top;
        while (current != null)
        {
            Console.Write(current.Value + " -> ");
            current = current.Next;
        }
        Console.Write("null");
    }
}