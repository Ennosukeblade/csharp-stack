// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// Three Basic Arrays:
Console.WriteLine("=======Three Basic Arrays=======");
int[] ZeroThroughNine = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
string[] names = new string[] { "Tim", "Martin", "Nikki", "Sara" };

bool[] TrueFalse = new bool[10];
Console.WriteLine(TrueFalse.Length);
for (int i = 0; i < TrueFalse.Length; i++)
{
    if (i % 2 == 0)
    {
        TrueFalse[i] = true;
    }
    else TrueFalse[i] = false;
    Console.WriteLine(TrueFalse[i]);
}
Console.WriteLine("=======List of Flavors=======");
List<string> IceCreamFlavors = new List<string>();
IceCreamFlavors.Add("Chocolate");
IceCreamFlavors.Add("Vanilla");
IceCreamFlavors.Add("Strawberry");
IceCreamFlavors.Add("Mint Chocolate Chip");
IceCreamFlavors.Add("Butter Pecan");
List<string> IceCreamFlavors2 = new List<string>()
{
    "Chocolate",
    "Vanilla",
    "Strawberry",
    "Mint Chocolate Chip",
    "Butter Pecan",
    "Cookies n' Cream",
};
Console.WriteLine($"IceCreamFlavors count: {IceCreamFlavors.Count()}");
Console.WriteLine($"IceCreamFlavors2 count: {IceCreamFlavors2.Count()}");
Console.WriteLine($"Third flavor: {IceCreamFlavors[2]}");
IceCreamFlavors.Remove("Strawberry");
Console.WriteLine($"IceCreamFlavors count: {IceCreamFlavors.Count()}");

Console.WriteLine("=======User Info Dictionary=======");
Dictionary<string, string> UserInfo = new Dictionary<string, string>();
Random rand = new Random();
foreach (var name in names)
{
    int RandomFlavorIndex = rand.Next(0, IceCreamFlavors.Count);
    UserInfo.Add(name, IceCreamFlavors[RandomFlavorIndex]);
}
foreach (var item in UserInfo)
{
    Console.WriteLine(item.Key + " -> " + item.Value);
}






