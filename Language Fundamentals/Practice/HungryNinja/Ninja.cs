class Ninja
{
    private int calorieIntake;
    public List<Food> FoodHistory;

    public bool IsFull
    {
        get
        {
            return calorieIntake > 1200;
        }
    }

    // add a constructor
    public Ninja()
    {
        calorieIntake = 0;
        FoodHistory = new List<Food>();
    }

    // add a public "getter" property called "IsFull"

    // build out the Eat method
    public void Eat(Food item)
    {
        bool full = IsFull;
        if (!full)
        {
            calorieIntake += item.Calories;
            FoodHistory.Add(item);
            Console.WriteLine(item.Name);
            if (item.IsSpicy)
            {
                Console.WriteLine("is Spicy");
            }
            if (item.IsSweet)
            {
                Console.WriteLine("is so Sweet");
            }
        }
        else Console.WriteLine("Ninja is Full, stop eating");
    }
}

