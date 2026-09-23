using System;
using System.Collections.Generic;

Game game = new Game();
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Exploration {i + 1}. ");
    game.Explore();
}

// Creating variables player stats

public class Game
{
    int life = 100;
    int hunger = 0;
    int thirst = 0;
    int day = 1;
    const int objectiveDays = 30;
    bool isAlive = true;
    bool run = true;

    List<Foods> foodInventory = new List<Foods>();

    List<Drinks> drinkInventory = new List<Drinks>();

    Random rng = new Random();

    public enum Actions
    {
        Run,
        Explore,
        Eat,
        Drink
    }

    public enum ExplorationEvents
    {
        NothingFound,
        Food,
        Drink,
        MedicalKit,
        ZombieAttack,
        AnimalBattle
    }

    public enum Foods
    {
        Fruit,
        Hamburguer,
        CornFlakes,
        RottenMeat,
        Meat,
        Pasta
    }

    public enum Drinks
    {
        Water,
        Soda,
        Juice,
        Vodka
    }

    public Foods SortFood()
    {
        int aleatorieNumberFood = rng.Next(0, 6);
        return (Foods)aleatorieNumberFood;
    }

    public Drinks SortDrink()
    {
        int aleatorieNumberDrink = rng.Next(0, 4);
        return (Drinks)aleatorieNumberDrink;
    }

    public ExplorationEvents SortEvent()
    {
        int aleatorieNumberEvent = rng.Next(0, 6);
        return (ExplorationEvents)aleatorieNumberEvent;
    }

    int HungerKiller(Foods f)
    {
        switch (f)
        {
            case Foods.Fruit: return -10;
            case Foods.Hamburguer: return -20;
            case Foods.CornFlakes: return -5;
            case Foods.RottenMeat: return +10;
            case Foods.Meat: return -15;
            case Foods.Pasta: return -15;
            default: return 0;
        }
    }

    int ThirstKiller(Drinks d)
    {
        switch (d)
        {
            case Drinks.Water: return -15;
            case Drinks.Soda: return -7;
            case Drinks.Juice: return -10;
            case Drinks.Vodka: return +10;
            default: return 0;
        }
    }

    void Eat(Foods f)
    {
        hunger += HungerKiller(f);

        if (hunger > 100)
        {
            hunger = 100;
        }
        if (hunger < 0)
        {
            hunger = 0;
        }
    }

    void Drink(Drinks d)
    {
        thirst += ThirstKiller(d);
        if (thirst > 100)
        {
            thirst = 100;
        }
        if (thirst < 0)
        {
            thirst = 0;
        }
    }

    void RunAway()
    {
        hunger += 7;
        thirst += 7;

        if (hunger > 100)
        {
            hunger = 100;
        }
        if (thirst > 100)
        {
            thirst = 100;
        }

        NextDay();
    }

    public void Explore()
    {
        int quantityEvents = rng.Next(1, 4);
        Console.WriteLine($"Quantidade de eventos hoje: {quantityEvents}");

        for (int i = 0; i < quantityEvents; i++)
        {
            ExplorationEvents events = SortEvent();

            switch (events)
            {
                case ExplorationEvents.NothingFound:
                    Console.WriteLine("You explored but found nothing.");
                    break;
                case ExplorationEvents.Drink:
                    Console.WriteLine("You found a drink");
                    break;
                case ExplorationEvents.Food:
                    Console.WriteLine("You found a food");
                    break;
                case ExplorationEvents.AnimalBattle:
                    Console.WriteLine("You battled with an animal.");
                    life -= 6;
                    if (life <= 0)
                    {
                        life = 0;
                    }
                    break;
                case ExplorationEvents.ZombieAttack:
                    Console.WriteLine("You were attacked by a zombie.");

                    life -= 10;

                    if (life <= 0)
                    {
                        life = 0;
                    }
                    break;
                case ExplorationEvents.MedicalKit:
                    Console.WriteLine("You found a medical kit");
                    life += 15;
                    if (life >= 100)
                    {
                        life = 100;
                    }
                    break;
            }
        }
    }

    void CheckDeath()
    {
        if (life <= 0)
        {
            isAlive = false;
            Console.WriteLine("You died");
        }
    }

    void NextDay()
    {
        day++;

        if (thirst > 50)
        {
            life -= 5;
        }
        if (hunger > 50)
        {
            hunger -= 5;
        }
    }
}