using MyStructure;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Test MyQueue<T> ===");

        // 1. Create a queue and add values
        var q1 = new MyQueue<int>(5);
        q1.Enqueue(10);
        q1.Enqueue(20);
        q1.Enqueue(30);
        Console.Write("q1: "); q1.Print();

        // 2. Test Front()
        Console.WriteLine($"\nFront of q1 = {q1.Front()}"); // Expected: 10

        // 3. Dequeue test
        q1.Dequeue();
        Console.Write("\nq1 after Dequeue: "); q1.Print();
        Console.WriteLine($"Front of q1 = {q1.Front()}"); // Expected: 20

        // 4. Copy constructor test
        var q2 = new MyQueue<int>(q1);
        Console.Write("\nq2 (copy of q1): "); q2.Print();
        Console.WriteLine($"q1 == q2 ? {q1 == q2}"); // Expected: True

        // 5. Initializer list test
        var q3 = new MyQueue<int>(new[] { 5, 15, 25 }, 5);
        Console.Write("\nq3: "); q3.Print();

        // 6. Comparison test
        Console.WriteLine($"\nq3 < q1 ? {q3 < q1}");
        Console.WriteLine($"q3 > q1 ? {q3 > q1}");

        // 7. Enqueue until full
        try
        {
            q3.Enqueue(35);
            q3.Enqueue(45);
            q3.Enqueue(55); // This should throw an exception
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("\nExpected error: " + ex.Message);
        }

        // 8. Equality check after modifying q2
        q2.Enqueue(40);
        Console.WriteLine($"\nq1 == q2 ? {q1 == q2}"); // Expected: False
    }
}
