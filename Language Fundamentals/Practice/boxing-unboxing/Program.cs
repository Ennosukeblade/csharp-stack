List<object> MyObjects = new List<object>();
MyObjects.Add(7);
MyObjects.Add(28);
MyObjects.Add(-1);
MyObjects.Add(true);
MyObjects.Add("chair");
int sum = 0;
foreach (var item in MyObjects)
{
    System.Console.WriteLine(item);
    if (item is int)
    {
        sum += (int)item;
    }
}
System.Console.WriteLine(sum);

