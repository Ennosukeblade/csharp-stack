Console.WriteLine("==== Random Array ====");
static int[] RandomArray()
{
    int[] arr = new int[10];
    var rand = new Random();
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = rand.Next(5, 26);
    }
    //System.Console.WriteLine(arr);
    Array.ForEach(arr, s => Console.Write(s + " "));

    int min = arr[0];
    foreach (var item in arr)
    {
        if (item < min)
        {
            min = item;
        }
    }
    System.Console.WriteLine($"Min value of the array is {min}");

    int max = arr[0];
    foreach (var item in arr)
    {
        if (item > max)
        {
            max = item;
        }
    }
    System.Console.WriteLine($"Max value of the array is {max}");
    int sum = 0;
    foreach (var item in arr)
    {
        sum += item;
    }
    Console.WriteLine(sum);
    return arr;
}
RandomArray();
//System.Console.WriteLine(RandomArray());
Console.WriteLine("==== Coin Flip ====");
static string TossCoin()
{
    System.Console.WriteLine("Tossing a Coin!");
    Random rand = new Random();
    if (rand.Next(0, 2) == 0)
    {
        return "Heads";
    }
    else return "Tails";
}
System.Console.WriteLine(TossCoin());

Console.WriteLine("==== Names ====");
static List<string> Names()
{
    List<string> names = new List<string>() { "Todd", "Tiffany", "Charlie", "Geneva", "Sydney" };
    List<string> MoreThanFiveChar = new List<string>();
    foreach (var item in names)
    {
        if (item.Length > 5)
        {
            MoreThanFiveChar.Add(item);
        }
    }
    return MoreThanFiveChar;
}
List<string> MoreThanFiveChar = Names();
foreach (var item in MoreThanFiveChar)
{
    System.Console.WriteLine(item);
}