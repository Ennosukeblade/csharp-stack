class Ninja : Human
{
    public Ninja(string name, int str, int intel, int hp) :
    base(name, str, intel, 75, hp)
    {

    }
    public override int Attack(Human target)
    {
        int dmg = Dexterity;
        Random rand = new Random();
        int additionalDamagePercentage = 20;

        int randomValueBetween0And99 = rand.Next(100);
        if (randomValueBetween0And99 < additionalDamagePercentage)
        {
            dmg += 10;
        }

        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;
    }
    public int Steal(Human target)
    {
        int damageSteal = 10;
        target.Health -= damageSteal;
        Health += damageSteal;
        return Health;
    }

}