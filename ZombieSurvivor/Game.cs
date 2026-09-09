using System;

// Creating variables player stats
int life = 100;
int hunger = 100;
int thirst = 100;
int day = 1;
const int objectiveDays = 30;
bool isAlive = true;
bool run = true;

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
    MedicalKit
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

class Game
{
    int HungerKiller(Foods f, int hunger)
    {
        switch (f)
        {
            case Foods.Fruit: return 10;
            case Foods.Hamburguer: return 20;
            case Foods.CornFlakes: return 5;
            case Foods.RottenMeat: return -10;
            case Foods.Meat: return 15;
            case Foods.Pasta: return 15;
            default: return 0;
        }

        int ThirstKiller(Drinks d, int thirst)
        {
            switch (d)
            {
                case Drinks.Water: return 15;
                case Drinks.Soda: return 7;
                case Drinks.Juice: return 10;
                case Drinks.Vodka: return -10;
                default: return 0;
            }
        }
    }