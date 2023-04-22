class Wizard : Human
{
    public Wizard(string name, int str, int dex) :
    base(name, str, 25, dex, 50)
    {

    }
    public override int Attack(Human target)
    {
        int dmg = Intelligence * 3;
        target.Health -= dmg;
        Health += dmg;
        Console.WriteLine($"{Name} attacked {target.Name} by {dmg} damage!");
        return target.Health;
    }
    public void Heal(Human target)
    {
        int heal = Intelligence * 3;
        target.Health += heal;
        Console.WriteLine($"{Name} heal {target.Name} by {heal} HP points!");

    }
}