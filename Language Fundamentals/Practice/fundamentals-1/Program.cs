// See https://aka.ms/new-console-template for more information
Console.WriteLine("===== For Loops =====");
for (int i = 1; i <= 255; i++)
{
    Console.WriteLine(i);
}
Console.WriteLine("--------------------------");
for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0 && i % 5 != 0 || i % 5 == 0 && i % 3 != 0)
    {
        Console.WriteLine(i);
    }

}
Console.WriteLine("--------------------------");
for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0 && i % 5 != 0)
    {
        Console.WriteLine(i + " Fizz");
    }
    else if (i % 5 == 0 && i % 3 != 0)
    {
        Console.WriteLine(i + " Buzz");
    }
    else if (i % 5 == 0 && i % 3 == 0)
    {
        Console.WriteLine(i + " FizzBuzz");
    }
    else Console.WriteLine(i);
}
Console.WriteLine("===== While Loops =====");
// * While Loops
int x = 1;

while (x <= 255)
{
    Console.WriteLine(x);
    x++;
}
Console.WriteLine("--------------------------");
int y = 1;
while (y <= 100)
{
    if (y % 3 == 0 && y % 5 != 0 || y % 5 == 0 && y % 3 != 0)
    {
        Console.WriteLine(y);
    }
    y++;
}
Console.WriteLine("--------------------------");
int z = 1;
while (z <= 100)
{
    if (z % 3 == 0 && z % 5 != 0)
    {
        Console.WriteLine(z + " Fizz");
    }
    else if (z % 5 == 0 && z % 3 != 0)
    {
        Console.WriteLine(z + " Buzz");
    }
    else if (z % 5 == 0 && z % 3 == 0)
    {
        Console.WriteLine(z + " FizzBuzz");
    }
    else Console.WriteLine(z);
    z++;
}

