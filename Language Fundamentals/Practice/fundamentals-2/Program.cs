//* 1. Print 1-255

static void PrintNumbers()
{
    // Print all of the integers from 1 to 255.
    for (int i = 1; i <= 255; i++)
    {
        System.Console.WriteLine(i);
    }
}
//* 2. Print odd numbers between 1-255
static void PrintOdds()
{
    // Print all of the odd integers from 1 to 255.
    for (int i = 1; i <= 255; i++)
    {
        if (i % 2 != 0)
        {
            System.Console.WriteLine(i);

        }
    }
}
//* 3. Print Sum
static void PrintSum()
{
    // Print all of the numbers from 0 to 255, 
    // but this time, also print the sum as you go. 
    // For example, your output should be something like this:

    // New number: 0 Sum: 0
    // New number: 1 Sum: 1
    // New number: 2 Sum: 3
    int sum = 0;
    for (int i = 0; i <= 255; i++)
    {
        sum += i;
        Console.WriteLine($"New number: {i} Sum: {sum}");
    }
}
//* 4. Iterating through an Array
static void LoopArray(int[] numbers)
{
    // Write a function that would iterate through each item of the given integer array and 
    // print each value to the console.
    foreach (var item in numbers)
    {
        Console.WriteLine(item);
    }
}
// int[] arr = { 1, 2, 3 };
// LoopArray(arr);

//* 5. Find Max
static int FindMax(int[] numbers)
{
    // Write a function that takes an integer array and prints and returns the maximum value in the array. 
    // Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), 
    // or even a mix of positive numbers, negative numbers and zero.
    int max = numbers[0];
    foreach (var item in numbers)
    {

        if (item >= max)
        {
            max = item;
        }
    }
    return max;
}
// int[] arr1 = { -5, -2, -3, -7 };
// Console.WriteLine(FindMax(arr1));

//* 6. Get Average
static void GetAverage(int[] numbers)
{
    // Write a function that takes an integer array and prints the AVERAGE of the values in the array.
    // For example, with an array [2, 10, 3], your program should write 5 to the console.
    int sum = 0;
    foreach (var item in numbers)
    {
        sum += item;
    }
    Console.WriteLine($"Sum: {sum}");
    float average = (float)sum / numbers.Length;
    Console.WriteLine($"Average of the array: {average}");
}

// int[] arr2 = { -5, -5, -7 };
// GetAverage(arr2);

//* 7. List with Odd Numbers

static List<int> OddList()
{
    // Write a function that creates, and then returns, a List that contains all the odd numbers between 1 to 255. 
    // When the program is done, the List should have the values of [1, 3, 5, 7, ... 255].
    //int[] odds = new int[256/2];
    List<int> odds = new List<int>();
    for (int i = 1; i <= 255; i++)
    {
        if (i % 2 != 0)
        {
            odds.Add(i);

        }
    }
    return odds;
}
// System.Console.WriteLine(OddList());
// foreach (var item in OddList())
// {
//     System.Console.WriteLine(item);
// }

//* 8. Greater than Y

static int GreaterThanY(List<int> numbers, int y)
{
    // Write a function that takes an integer List, and an integer "y" and returns the number of values 
    // That are greater than the "y" value. 
    // For example, if our List contains 1, 3, 5, 7 and y is 3. Your function should return 2 
    // (since there are two values in the List that are greater than 3).
    int count = 0;
    foreach (var item in numbers)
    {
        if (item > y)
        {
            count++;
        }
    }
    return count;
}
// List<int> numbers = new List<int>() { 1, 2, 3, 5, 10 };
// int greaters = GreaterThanY(numbers, 3);
// System.Console.WriteLine(greaters);

//* 9. Square the Values

static void SquareArrayValues(List<int> numbers)
{
    // Write a function that takes a List of integers called "numbers", and then multiplies each value by itself.
    // For example, [1,5,10,-10] should become [1,25,100,100]
    for (int i = 0; i < numbers.Count; i++)
    {
        numbers[i] *= numbers[i];
    }
    //System.Console.WriteLine(numbers);
    foreach (var item in numbers)
    {
        Console.WriteLine(item);
    }
}
// SquareArrayValues(new List<int>() { 1, 3, 5 });

//* 10. Eliminate Negative Numbers
static void EliminateNegatives(List<int> numbers)
{
    // Given a List of integers called "numbers", say [1, 5, 10, -2], create a function that replaces any negative number with the value of 0. 
    // When the program is done, "numbers" should have no negative values, say [1, 5, 10, 0].
    for (int i = 0; i < numbers.Count; i++)
    {
        if (numbers[i] < 0)
        {
            numbers[i] = 0;
        }
        Console.WriteLine(numbers[i]);
    }
}
EliminateNegatives(new List<int>() { 0, 3, -2, 7 });















