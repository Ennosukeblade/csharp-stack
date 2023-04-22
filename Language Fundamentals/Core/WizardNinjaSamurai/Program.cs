Wizard w1 = new Wizard("Yon wizard", 50, 40);
Human h1 = new Human("John human", 40, 10, 50, 100);
Ninja n1 = new Ninja("Bill the ninja", 20, 30, 100);
Human h2 = new Human("John 2", 40, 10, 50, 100);
w1.Attack(h1);
Console.WriteLine(h1.Health);
Console.WriteLine(w1.Health);
Console.WriteLine(w1.Intelligence);
w1.Heal(h1);
Console.WriteLine(h1.Health);
System.Console.WriteLine("=====Ninja=====");
System.Console.WriteLine(n1.Dexterity);
n1.Attack(h2);
Console.WriteLine(h2.Health);
Console.WriteLine($"{h1.Name} initial Health: {h1.Health}");
int newHealth = n1.Steal(h1);
Console.WriteLine($"{n1.Name} new Health: {newHealth}");
Console.WriteLine($"{h1.Name} new Health: {h1.Health}");
Samurai s1 = new Samurai("Samurai Jack", 20, 50, 100);
int h1NewHealth = s1.Attack(h1);
System.Console.WriteLine(h1NewHealth);
System.Console.WriteLine(s1.Health);
n1.Attack(s1);
System.Console.WriteLine(s1.Health);
s1.Meditate();
System.Console.WriteLine(s1.Health);





