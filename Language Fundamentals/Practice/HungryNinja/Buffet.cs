public class Buffet
{
    public List<Food> Menu;

    //constructor
    public Buffet()
    {
        Menu = new List<Food>()
        {
            new Food("spaghetti", 1000, true, false),
            new Food("icecream", 1500, false, true),
            new Food("kafteji", 1100, true, false),
            new Food("borghol", 1800, true, false),
            new Food("kamoneya", 2000, true, false),
            new Food("carbonara", 1400, false, false),
            new Food("thé", 500, false, true),
        };
    }

    public Food Serve()
    {
        Random rand = new Random();
        return Menu[rand.Next(Menu.Count)];
    }
}

