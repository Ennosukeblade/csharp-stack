Card card1 = new Card("Heart", 1);
card1.print();
Deck deck1 = new Deck();
System.Console.WriteLine("======BEFORE shuffling======");
foreach (var card in deck1.cards)
{
    Console.WriteLine($"{card.Name} {card.Suit} {card.Val}");
}

deck1.Shuffle();
System.Console.WriteLine("======AFTER shuffling======");
foreach (var card in deck1.cards)
{
    Console.WriteLine($"{card.Name} {card.Suit} {card.Val}");
}
Console.WriteLine($"Deck Before deal count: {deck1.cards.Count}");
System.Console.WriteLine(deck1.Deal());
Console.WriteLine($"Deck After deal count: {deck1.cards.Count}");

Console.WriteLine();

PLayer newPlayer = new PLayer("John");
newPlayer.Draw(deck1);
newPlayer.Draw(deck1);
newPlayer.Draw(deck1);
System.Console.WriteLine($"Cards drawn by {newPlayer.Name}:");
newPlayer.Hand.ForEach(c => Console.WriteLine($"{c.Name} of {c.Suit}"));
System.Console.WriteLine($"Cards number left in the deck: {deck1.cards.Count}");
Card discardedCard = newPlayer.Discard(1);
System.Console.WriteLine($"{newPlayer.Name} discard the {discardedCard.Name} of {discardedCard.Suit} ");
System.Console.WriteLine($"For now {newPlayer.Name} has:");
newPlayer.Hand.ForEach(c => Console.WriteLine($"{c.Name} of {c.Suit}"));

