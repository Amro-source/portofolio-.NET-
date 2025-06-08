using System;
using System.Text;
using System.Security.Cryptography;

class PasswordGenerator
{
    static void Main()
    {
        Console.Write("Enter desired password length: ");
        int length = int.Parse(Console.ReadLine());

        Console.Write("Include uppercase letters? (y/n): ");
        bool upper = Console.ReadLine().ToLower() == "y";

        Console.Write("Include lowercase letters? (y/n): ");
        bool lower = Console.ReadLine().ToLower() == "y";

        Console.Write("Include numbers? (y/n): ");
        bool digits = Console.ReadLine().ToLower() == "y";

        Console.Write("Include symbols? (y/n): ");
        bool symbols = Console.ReadLine().ToLower() == "y";

        string chars = "";
        if (upper) chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        if (lower) chars += "abcdefghijklmnopqrstuvwxyz";
        if (digits) chars += "0123456789";
        if (symbols) chars += "!@#$%^&*()-_=+[]{}|;:,.<>?";

        if (chars.Length == 0)
        {
            Console.WriteLine("You must select at least one character type.");
            return;
        }

        string password = GeneratePassword(chars, length);
        Console.WriteLine("Generated Password: " + password);
    }

    static string GeneratePassword(string validChars, int length)
    {
        byte[] data = new byte[length];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(data);
        }

        StringBuilder result = new StringBuilder(length);
        foreach (byte b in data)
        {
            result.Append(validChars[b % validChars.Length]);
        }

        return result.ToString();
    }
}