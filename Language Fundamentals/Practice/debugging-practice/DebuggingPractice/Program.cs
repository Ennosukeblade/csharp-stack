// See https://aka.ms/new-console-template for more information
// Challenge 1
bool amProgrammer = true; // "true" is a string and the variable must be boolean
int Age = 27;
List<string> Names = new List<string>();
//Names = "Monica"; // we can't assign a string type to a list type
Names.Add("Monica");
//Console.WriteLine(Names[0]);
Dictionary<string, string> MyDictionary = new Dictionary<string, string>();
MyDictionary.Add("Hello", "0");
//MyDictionary.Add("Hi there", 0); // key value in the MyDictionary are both strings we cannot add an integer value
// This is a tricky one! Hint: look up what a char is in C#
string MyName = 'MyName'; // single quote is for a single character...
// Challenge 2
List<int> Numbers = new List<int>() { 2, 3, 6, 7, 1, 5 };
for (int i = Numbers.Count - 1; i >= 0; i--)
{
    Console.WriteLine(Numbers[i]); // i must less than List length
}
// Challenge 3
List<int> MoreNumbers = new List<int>() { 12, 7, 10, -3, 9 };
foreach (int i in MoreNumbers)
{
    //Console.WriteLine(MoreNumbers[i]);
    // "i" is the value not the index, here we tried to print MoreNumbers[12] 12 is out of range
    Console.WriteLine(i);
}
// Challenge 4
List<int> EvenMoreNumbers = new List<int> { 3, 6, 9, 12, 14 };
/* foreach (int num in EvenMoreNumbers)
{
    if (num % 3 == 0)
    {
        num = 0; // num is an iteration variable, we cannot assign a variable to it
        
    }
} */
for (int i = 0; i < EvenMoreNumbers.Count; i++)
{
    if (EvenMoreNumbers[i] % 3 == 0)
    {
        EvenMoreNumbers[i] = 0;
    }
}
Console.WriteLine(EvenMoreNumbers[2]);
// Challenge 5
// What can we learn from this error message?
string MyString = "superduberawesome";
MyString[7] = "p"; // String objects are immutable 
// Challenge 6
// Hint: some bugs don't come with error messages
Random rand = new Random();
int randomNum = rand.Next(12); // 12 is not included in the range of randomNum
if (randomNum == 12) // This condition will never happen
{
    Console.WriteLine("Hello");
}

