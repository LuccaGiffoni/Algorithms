namespace Algorithms.LINQMethods;

public static class Aggregation
{
    private record Person(string Name, int Age);

    private static readonly IEnumerable<Person> People = [
        new Person("Lucca", 21),
        new Person("Enzo", 19),
        new Person("Maria", 20)];

    public static void Run()
    {
        // Print the age
        Console.WriteLine(People.Max(x => x.Age));
        
        // Print the object
        Console.WriteLine(People.MaxBy(x => x.Age));
    }
}