using Algorithms.DependencyInjection.Challenges;

namespace Algorithms.Challenges.Logic;

public class Knapsack : IChallenge
{
    public string Title => "0/1 Knapsack Problem";
    public string Description => "Solve the 0/1 Knapsack problem using dynamic programming.";
    public EChallengeLevel Level => EChallengeLevel.Hard;
    
    public void Run()
    {
        Console.WriteLine("How much weight can you carry?");
        var maxWeight = Convert.ToInt32(Console.ReadLine());
        
        FindMaxItems(maxWeight, GenerateRandomItems(10));
    }

    private record Item(int Weight, int Value, string Name);

    private static List<Item> GenerateRandomItems(int quantity)
    {
        var randomWeight = new Random();
        var randomValue = new Random();
        
        var items = new List<Item>();
        for (var i = 0; i < quantity; i++)
        {
            items.Add(new Item(randomWeight.Next(1, 5), randomValue.Next(1, 10), $"Item {i}"));
        }

        var itemsString = string.Join(", ", items);
        Console.WriteLine($"{items.Count} items created: {itemsString}");
        
        return items;
    }
    
    private static void FindMaxItems(int maxWeight, List<Item> items)
    {
        var n = items.Count;
        var dp = new int[n + 1, maxWeight + 1]; // DP table
        var keep = new bool[n + 1, maxWeight + 1]; // Table to keep track of selected items

        for (var i = 1; i <= n; i++)
        {
            for (var w = 1; w <= maxWeight; w++)
            {
                if (items[i - 1].Weight <= w)
                {
                    var valueIfIncluded = items[i - 1].Value + dp[i - 1, w - items[i - 1].Weight];
                    var valueIfExcluded = dp[i - 1, w];
                        
                    if (valueIfIncluded > valueIfExcluded)
                    {
                        dp[i, w] = valueIfIncluded;
                        keep[i, w] = true;
                    }
                    else
                    {
                        dp[i, w] = valueIfExcluded;
                    }
                }
                else
                {
                    dp[i, w] = dp[i - 1, w];
                }
            }
        }

        var selectedItems = new List<Item>();
        var remainingWeight = maxWeight;
        for (var i = n; i > 0 && remainingWeight > 0; i--)
        {
            if (!keep[i, remainingWeight]) continue;
            
            selectedItems.Add(items[i - 1]);
            remainingWeight -= items[i - 1].Weight;
        }

        var itemsString = string.Join(", ", selectedItems.Select(x => new { x.Name, x.Weight }));
        Console.WriteLine($"Maximum value: {itemsString}");
    }
}