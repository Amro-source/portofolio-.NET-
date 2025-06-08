using System;

class Calculator
{
    static void Main()
    {
        Console.WriteLine("Simple Calculator");

        double num1 = GetValidNumber("Enter first number: ");
        char op = GetValidOperator();
        double num2 = GetValidNumber("Enter second number: ");

        double result;

        if (op == '/' && num2 == 0)
        {
            Console.WriteLine("Error: Cannot divide by zero.");
            return;
        }

        if (op == '+')
        {
            result = num1 + num2;
        }
        else if (op == '-')
        {
            result = num1 - num2;
        }
        else if (op == '*')
        {
            result = num1 * num2;
        }
        else if (op == '/')
        {
            result = num1 / num2;
        }
        else
        {
            Console.WriteLine("Invalid operator.");
            return;
        }

        Console.WriteLine($"Result: {result}");
    }

    static double GetValidNumber(string prompt)
    {
        double number;
        do
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (double.TryParse(input, out number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        } while (true);
    }

    static char GetValidOperator()
    {
        char op;
        do
        {
            Console.Write("Enter operator (+, -, *, /): ");
            string input = Console.ReadLine();

            if (input.Length == 1 && "+-*/".Contains(input))
            {
                return input[0];
            }
            else
            {
                Console.WriteLine("Invalid operator. Please use one of: +, -, *, /");
            }
        } while (true);
    }
}