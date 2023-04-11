// // Data types
// // String
// string UserName = "alex";
// Console.WriteLine(UserName);
// // Integer
// int AlexAge = 25;
// Console.WriteLine(value: AlexAge);
// // Float = 32bits
// float Rate = 1.20f;
// // Decimal = 64bits
// decimal tax = 1.5015M;

// // * Data Structure
// // Array
// int[] FirstArray = new int[5] { 1, 2, 3, 4, 5 };
// Console.WriteLine(value: FirstArray);
// float[] SecondArray = { 1.25f, 0.89f, 5.75f };
// // List
// // New object or new instance of the class List
// List<string> names = new List<string>();
// names.Add(item: UserName);
// names.Add("15");
// names.Add("Sarah");
// names.Remove("15");
// // you can put the index: or not
// names.RemoveAt(index: 1);

// Console.WriteLine(value: names[0]);

Console.WriteLine("My name is {0}, I am " + 28 + " years old", "Tim");
Console.WriteLine($"My name is {0}, I am " + 28 + " years old", "Tim");

Random rand = new Random();
for (int val = 0; val < 10; val++)
{
    //Prints the next random value between 2 and 8
    Console.WriteLine(rand.Next(2, 8));
}