class SweetTooth : Ninja
{
    public SweetTooth(string name) : base(name) { }
    public override bool IsFull
    {
        get
        {
            if (calorieIntake >= 1500)
            {
                return true;
            }
            return false;
        }
    }

    public override void Consume(IConsumable item)
    {
        if (IsFull)
        {
            Console.WriteLine($"'{Name}' the SweetTooth is full and cannot eat anymore");
        }
        else
        {
            ConsumptionHistory.Add(item);
            calorieIntake += item.Calories;
            if (item.IsSweet)
            {
                calorieIntake += 10;
            }
            Console.WriteLine(item.GetInfo());

        }
    }
}
class SweetTooth : Ninja
{
    public SweetTooth(string name) : base(name) { }
    public override bool IsFull
    {
        get
        {
            if (calorieIntake >= 1500)
            {
                return true;
            }
            return false;
        }
    }

    public override void Consume(IConsumable item)
    {
        if (IsFull)
        {
            Console.WriteLine($"'{Name}' the SweetTooth is full and cannot eat anymore");
        }
        else
        {
            ConsumptionHistory.Add(item);
            calorieIntake += item.Calories;
            if (item.IsSweet)
            {
                calorieIntake += 10;
            }
            Console.WriteLine(item.GetInfo());

        }
    }
}