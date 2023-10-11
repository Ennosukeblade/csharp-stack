List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
//IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
//PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}

//* Use LINQ to find the first eruption that is in Chile and print the result.
Eruption FirstChile = eruptions.First(c => c.Location == "Chile");
System.Console.WriteLine(FirstChile);

System.Console.WriteLine("==================================");
//* Find the first eruption from the "Hawaiian Is" location and print it. 
//* If none is found, print "No Hawaiian Is Eruption found."
IEnumerable<Eruption> FirstHawai = eruptions.Where(c => c.Location == "Hawaiian Is").Take(1);
//? Any() method returns true if the IEnumerable contains at least one element, and false otherwise
if (FirstHawai.Any())
{
    PrintEach(FirstHawai, "Hawaiian Is:");
}
else
{
    System.Console.WriteLine("No Hawaiian Is Eruption found.");
}

System.Console.WriteLine("==================================");
//* Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
IEnumerable<Eruption> newZealand = eruptions.Where(y => y.Year > 1900).Where(l => l.Location == "New Zealand").Take(1);
PrintEach(newZealand, "First eruption that is after the year 1900 AND in 'New Zealand'");

IEnumerable<Eruption> volcano = eruptions.Where(predicate: e => e.ElevationInMeters > 2000);
PrintEach(volcano, "Find all eruptions where the volcano's elevation is over 2000m and print them.");

IEnumerable<Eruption> volcanoWithL = eruptions.Where(predicate: e => e.Volcano.StartsWith('L'));
PrintEach(volcanoWithL, "Find all eruptions where the volcano's name starts with 'L' and print them. Also print the number of eruptions found.");
System.Console.WriteLine(volcanoWithL.Count());

double highestElevation = eruptions.Max(e => e.ElevationInMeters);
System.Console.WriteLine(highestElevation);

IEnumerable<Eruption> highestEruption = eruptions.Where(i => i.ElevationInMeters == highestElevation).Take(1);
PrintEach(highestEruption, "Use the highest elevation variable to find a print the name of the Volcano with that elevation.");
System.Console.WriteLine($"Highest volcano: {highestEruption.First().Volcano}");

IEnumerable<Eruption> OrderedVolcanos = eruptions.OrderBy(v => v.Volcano);
PrintEach(OrderedVolcanos, "Print all Volcano names alphabetically");
foreach (var item in OrderedVolcanos)
{
    System.Console.WriteLine(item.Volcano);
}
IEnumerable<Eruption> OrderedVolcanosBefore1000 = eruptions.Where(v => v.Year < 1000).OrderBy(v => v.Volcano);
PrintEach(OrderedVolcanosBefore1000, "Print all Volcano names alphabetically");
foreach (var item in OrderedVolcanosBefore1000)
{
    System.Console.WriteLine(item.Volcano);
}







