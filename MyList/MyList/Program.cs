using ClassLibrary;

int[] arr = new int[] { 2, 3, 1, 2, 3, 4 };
MyList<int> l = new MyList<int>();
l.Add(1);
l.Add(2);
l.Add(3);
l.Add(1);
l.AddRange(arr);
l.Add(4);
l.Add(1);
l.RemoveAt(0);
l.Add(2);
l.Add(2);
l.Sort();
l.Add(2);
l.Add(2);

l.Remove(2);

foreach (var i in l)
{
    Console.WriteLine(i);
}

Console.ReadLine();