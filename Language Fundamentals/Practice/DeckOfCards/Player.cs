class PLayer
{
    public string? Name { get; set; }
    public List<Card> Hand = new List<Card>();

    public PLayer(string name)
    {
        Name = name;
    }
    public Card Draw(Deck deck)
    {
        Card card = deck.Deal();
        Hand.Add(card);
        return card;
    }
    public Card Discard(int i)
    {
        Card card;
        if (i < Hand.Count)
        {
            card = Hand[i];
            Hand.RemoveAt(i);
            return card;
        }
        else { return null!; }
    }
}