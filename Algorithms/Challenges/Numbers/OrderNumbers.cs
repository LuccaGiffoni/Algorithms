using Algorithms.DependencyInjection.Challenges;

namespace Algorithms.Challenges.Numbers;

public class OrderNumbers : IChallenge
{
    public string Title => "Order Numbers";
    public string Description => "Order an array of numbers. The even numbers ascending and the odds descending.";
    public EChallengeLevel Level => EChallengeLevel.Junior;
    
    private static readonly int[] Numbers = [1, 12, 90, 87, 345, 67, 98, 100, 124];
    
    public void Run() => Console.WriteLine(OrderNumber(Numbers));

    private static string OrderNumber(int[] input)
    {
        var oddNumbers = input.Where(x => x % 2 == 0).Order();
        var evenNumbers = input.Where(x => x % 2 != 0).OrderDescending();

        var oddString = string.Join(", ", oddNumbers);
        var evenString = string.Join(", ", evenNumbers);

        return $"{oddString}, {evenString}";
    }
}