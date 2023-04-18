class Card
{
    public string Name { get; set; }
    public string Suit { get; set; }
    public int Val { get; set; }

    public Card(string suit, int val)
    {
        switch (val)
        {
            case 11:
                Name = "Jack";
                break;
            case 12:
                Name = "Queen";
                break;
            case 13:
                Name = "King";
                break;
            case 1:
                Name = "Ace";
                break;
            default:
                Name = val.ToString();
                break;
        }
        Suit = suit;
        Val = val;

    }

    public void print()
    {
        Console.WriteLine($"Name: {Name}\nSuit: {Suit}\nValue: {Val}");
    }
}