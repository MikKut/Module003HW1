using MyList.MyListCollection;

CustomList<int> list = new (10);
list.Add(1);
list.Add(2);
list.Add(3);
list.Add(5);
list.Add(4);
Console.WriteLine("Initial list");
foreach (var t in list)
{
    Console.WriteLine(t);
}

var arrToAdd = new int[10];
list.AddRange(arrToAdd);
Console.WriteLine("After insertion of a range:");
foreach (var t in list)
{
    Console.WriteLine(t);
}

if (list.Remove(6))
{
    Console.WriteLine($"\"6\" was deleted successfuly in {nameof(list)}");
}

if (list.Remove(4))
{
    Console.WriteLine($"\"4\" was deleted successfuly in {nameof(list)}");
}

Console.WriteLine("After \"4\" was deleted:");
foreach (var t in list)
{
    Console.WriteLine(t);
}

list.Sort();

Console.WriteLine("Sorted _collection:");
foreach (var t in list)
{
    Console.WriteLine(t);
}