using System.Security.Cryptography.X509Certificates;

namespace Algorithms.Numbers;

public class OrderNumbers
{
    private static readonly int[] Numbers = [1, 12, 90, 87, 345, 67, 98, 100, 124];
    
    public static void Run()
    {
        var orderedNumbers = OrderNumber(Numbers);
        Console.WriteLine(orderedNumbers);
    }

    private static string OrderNumber(int[] input)
    {
        var oddNumbers = input.Where(x => x % 2 == 0).Order();
        var evenNumbers = input.Where(x => x % 2 != 0).OrderDescending();

        var oddString = string.Join(", ", oddNumbers);
        var evenString = string.Join(", ", evenNumbers);

        return $"{oddString}, {evenString}";
    }
}