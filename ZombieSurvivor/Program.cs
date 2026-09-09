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
    pasta
}

enum Drinks
{
    Water,
    Soda,
    Juice,
    Vodka
}
