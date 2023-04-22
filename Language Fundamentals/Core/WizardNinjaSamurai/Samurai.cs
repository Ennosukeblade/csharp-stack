class Samurai : Human
{
    public Samurai(string name, int str, int intel, int dex) :
    base(name, str, intel, dex, 200)
    {

    }
    public override int Attack(Human target)
    {
        base.Attack(target);
        if (target.Health < 50)
        {
            target.Health = 0;
        }
        return target.Health;
    }
    public void Meditate()
    {
        Health = 200;
    }

}