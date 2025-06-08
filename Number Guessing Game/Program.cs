using System;

class GuessingGame
{
    static void Main()
    {
        Random rand = new Random();
        int secretNumber = rand.Next(1, 101);
        int guess = 0;
        int attempts = 0;

        Console.WriteLine("Guess the number between 1 and 100!");

        while (guess != secretNumber)
        {
            Console.Write("Enter your guess: ");
            guess = int.Parse(Console.ReadLine());
            attempts++;

            if (guess < secretNumber)
                Console.WriteLine("Too low!");
            else if (guess > secretNumber)
                Console.WriteLine("Too high!");
        }

        Console.WriteLine($"Correct! You guessed it in {attempts} attempts.");
    }
}