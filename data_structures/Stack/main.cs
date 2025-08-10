using MyStructure; 

class Program
{
    static void Main()
    {
        // default capacity is 100
        var s1 = new MyStack<int>();

        Console.WriteLine("=== Push & PushRange ===");
        s1.Push(10);
        s1.Push(20);
        s1.PushRange(30, 40, 50);

        Console.WriteLine($"s1 size: {s1.Size()}"); // 5
        Console.WriteLine($"s1 top: {s1.Top()}");   // 50

        Console.WriteLine("\n=== Pop ===");
        s1.Pop();
        Console.WriteLine($"After pop, s1 top: {s1.Top()}"); // 40

        Console.WriteLine("\n=== Copy constructor ===");
        var s2 = new MyStack<int>(s1);
        Console.WriteLine($"s2 size: {s2.Size()}, top: {s2.Top()}");

        Console.WriteLine("\n=== Comparison operators ===");
        var s3 = new MyStack<int>();
        s3.PushRange(10, 20, 30, 40);

        Console.WriteLine($"s1 == s2 ? { (s1 == s3) }"); // true
        s3.Push(99);
        Console.WriteLine($"s1 < s3 ? { (s1 < s3) }");   // true
        Console.WriteLine($"s1 > s3 ? { (s1 > s3) }");   // false
        Console.WriteLine($"s1 != s3 ? { (s1 != s3) }"); // true

        Console.WriteLine("\n=== Empty & Capacity test ===");
        var smallStack = new MyStack<int>(3);
        smallStack.Push(1);
        smallStack.Push(2);
        smallStack.Push(3);

        try
        {
            smallStack.Push(4); //capacity exceeded
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Exception caught: {ex.Message}");
        }

        Console.WriteLine($"smallStack empty? {smallStack.Empty()}");

        Console.WriteLine("\n=== Pop all ===");
        while (!smallStack.Empty())
        {
            Console.WriteLine($"Popping: {smallStack.Top()}");
            smallStack.Pop();
        }

        try
        {
            smallStack.Pop(); 
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Exception caught: {ex.Message}");
        }
    }
}
