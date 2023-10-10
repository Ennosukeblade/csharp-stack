class SpiceHound : Ninja
{
    public SpiceHound(string name) : base(name) { }
    // provide override for IsFull (Full at 1200 Calories)
    public override bool IsFull
    {
        get
        {
            if (calorieIntake >= 1200)
            {
                return true;
            }
            return false;
        }
    }


    public override void Consume(IConsumable item)
    {
        // provide override for Consume
        if (IsFull)
        {
            Console.WriteLine($"'{Name}' the SpiceHound is full and cannot eat anymore");
        }
        else
        {
            ConsumptionHistory.Add(item);
            calorieIntake += item.Calories;
            if (item.IsSpicy)
            {
                calorieIntake -= 5;
            }
            Console.WriteLine(item.GetInfo());
        }
    }
}

