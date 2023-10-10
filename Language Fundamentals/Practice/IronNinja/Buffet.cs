class Buffet
{
    public List<IConsumable> Menu;

    //constructor
    public Buffet()
    {
        Menu = new List<IConsumable>()
        {
            new Food("spaghetti", 500, true, false),
            new Food("kafteji", 400, true, false),
            new Food("borghol", 1000, true, false),
            new Food("kamoneya", 300, true, false),
            new Food("carbonara", 600, false, false),
            new Food("icecream", 300, false, true),
            new Drink("thé", 500),
            new Drink("soda", 400),
            new Drink("Water", 0)

        };
    }

    public IConsumable Serve()
    {
        Random rand = new Random();
        return Menu[rand.Next(Menu.Count)];
    }
}

