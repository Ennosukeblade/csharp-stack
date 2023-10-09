// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Buffet TodayBuffet = new();
SweetTooth sweety = new("Sweety");
SpiceHound spicy = new("Spicy");

int i = 0;
while (!spicy.IsFull)
{
    spicy.Consume(TodayBuffet.Serve());
    i++;
}
int j = 0;
while (!sweety.IsFull)
{
    sweety.Consume(TodayBuffet.Serve());
    j++;
}
spicy.Consume(TodayBuffet.Serve());
sweety.Consume(TodayBuffet.Serve());

List<IConsumable> spicyHistory = spicy.ConsumptionHistory;
List<IConsumable> sweetyHistory = sweety.ConsumptionHistory;
if (spicyHistory.Count > sweetyHistory.Count)
{
    Console.WriteLine($"{spicy.Name} has consumed the most with {spicyHistory.Count} items");
    foreach (var item in spicyHistory)
    {
        Console.WriteLine(item.Name);
    }
}
else
{
    Console.WriteLine($"{sweety.Name} has consumed the most with {sweetyHistory.Count} items");
    foreach (var item in sweetyHistory)
    {
        Console.WriteLine(item.Name);
    }
}
//Console.WriteLine($"{spicy.Name} has taken {spicy.ConsumptionHistory}");




