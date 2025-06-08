using System;
using System.Collections.Generic;

class RPGGame
{
    static void Main()
    {
        Console.WriteLine("=== Text-Based RPG ===");

        Player player = new Player("Hero", 100, 20, 10);
        Monster goblin = new Monster("Goblin", 30, 10, 5);

        Console.WriteLine($"\nA wild {goblin.Name} appears!\n");

        while (player.IsAlive && goblin.IsAlive)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Use Potion (heals 20 HP)");
            Console.Write("Choose an action: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                player.Attack(goblin);
            }
            else if (choice == "2")
            {
                player.UsePotion();
            }
            else
            {
                Console.WriteLine("Invalid choice.");
                continue;
            }

            if (!goblin.IsAlive) break;

            goblin.Attack(player);
        }

        if (player.IsAlive)
        {
            Console.WriteLine("You defeated the monster! Victory!");
        }
        else
        {
            Console.WriteLine("You were defeated... Game Over.");
        }
    }
}

// Base Character class
abstract class Character
{
    public string Name { get; set; }
    public int Health { get; protected set; }
    public int MaxHealth { get; protected set; }
    public int AttackPower { get; protected set; }
    public int Defense { get; protected set; }

    public bool IsAlive => Health > 0;

    public virtual void Attack(Character target)
    {
        int damage = Math.Max(0, AttackPower - target.Defense);
        target.TakeDamage(damage);
        Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
    }

    public virtual void TakeDamage(int damage)
    {
        Health = Math.Max(0, Health - damage);
        Console.WriteLine($"{Name} takes {damage} damage. Remaining HP: {Health}");
    }
}

// Player class
class Player : Character
{
    private int _potions = 3;

    public Player(string name, int health, int attack, int defense)
    {
        Name = name;
        Health = health;
        MaxHealth = health;
        AttackPower = attack;
        Defense = defense;
    }

    public void UsePotion()
    {
        if (_potions > 0)
        {
            int healAmount = 20;
            Health = Math.Min(MaxHealth, Health + healAmount);
            _potions--;
            Console.WriteLine($"You used a potion and healed {healAmount} HP. Current HP: {Health}");
        }
        else
        {
            Console.WriteLine("No potions left!");
        }
    }
}

// Monster class
class Monster : Character
{
    public Monster(string name, int health, int attack, int defense)
    {
        Name = name;
        Health = health;
        MaxHealth = health;
        AttackPower = attack;
        Defense = defense;
    }
}