using System;
using System.Collections.Generic;

// Creating variables player stats

class Game
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

    enum Actions
    {
        Run,
        Explore,
        Eat,
        Drink
    }

    enum ExplorationEvents
    {
        NothingFound,
        Food,
        Drink,
        MedicalKit,
        ZombieAttack,
        AnimalBattle
    }

    enum Foods
    {
        Fruit,
        Hamburguer,
        CornFlakes,
        RottenMeat,
        Meat,
        Pasta
    }

    enum Drinks
    {
        Water,
        Soda,
        Juice,
        Vodka
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

    void CheckDeath()
    {
        if (hunger >= 100 || thirst >= 100 || life <= 0)
        {
            isAlive = false;
        }
    }

    void NextDay()
    {
        day++;

        if(thirst > 50)
        {
            life -= 5;
        }
        if (hunger > 50)
        {
            hunger -= 5;
        }
    }
}