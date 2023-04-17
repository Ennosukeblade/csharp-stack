class Human
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Dexterity { get; set; }
    public int Health { get; set; }

    public Human(string name)
    {
        Name = name;
        Strength = 3;
        Intelligence = 3;
        Dexterity = 3;
        Health = 100;
    }
    public Human(string name, int s, int i, int d, int h)
    {
        Name = name;
        Strength = s;
        Intelligence = i;
        Dexterity = d;
        Health = h;
    }

    public int Attack(Human target)
    {
        target.Health -= Strength * 3;
        return target.Health;
    }

}