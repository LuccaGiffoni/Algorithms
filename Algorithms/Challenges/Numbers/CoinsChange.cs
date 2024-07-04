using Algorithms.DependencyInjection.Challenges;

namespace Algorithms.Challenges.Numbers;

public class CoinsChange : IChallenge
{
    public string Title => "Coins Change";
    public string Description => "Determine the minimum number of coins needed to make a given amount using floating-point denominations.";
    public EChallengeLevel Level => EChallengeLevel.Intermediate;
    
    private static readonly float[] Coins = [ 0.05f, 0.1f, 0.25f, 0.5f, 1f, 2f, 5f, 10f, 20f, 50f, 100f, 200f ];
    private const int ScalingFactor = 100;
    
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Enter the target amount (type 'exit' to quit):");
            var amountInput = Console.ReadLine();
            
            if (amountInput?.ToLower() == "exit") break;
            if ((bool)amountInput?.Contains('.'))
            {
                amountInput = amountInput.Replace('.', ',');
            }
            
            if (!float.TryParse(amountInput, out var amount))
            {
                Console.WriteLine("Invalid amount. Please enter a valid float number.");
                continue;
            }

            var result = MinimalCoinsForChange(amount, out var coinsUsed);
            if (result == -1)
            {
                Console.WriteLine("It's not possible to make the amount with the given coins.\n");
            }
            else
            {
                Console.WriteLine($"{result} coins used:");
                foreach (var coin in coinsUsed) Console.WriteLine($"Coin {coin.Key:F2}: {coin.Value} time(s)");
                
                Console.WriteLine("\n");
            }
        }
    }

    private static int MinimalCoinsForChange(float amount, out Dictionary<float, int> coinsUsed)
    {
        var scaledCoins = Coins.Select(c => (int)(c * ScalingFactor)).ToArray();
        var scaledAmount = (int)Math.Round(amount * ScalingFactor);

        var minimumCoins = new int[scaledAmount + 1];
        var coinTrack = new int[scaledAmount + 1];

        Array.Fill(minimumCoins, scaledAmount + 1);
        minimumCoins[0] = 0; // Base case

        for (var i = 1; i <= scaledAmount; i++)
        {
            foreach (var coin in scaledCoins)
            {
                if (i < coin || minimumCoins[i - coin] + 1 >= minimumCoins[i]) continue;
                
                minimumCoins[i] = minimumCoins[i - coin] + 1;
                coinTrack[i] = coin; // Track the coin used
            }
        }

        // Reconstruct the coins used from the coinTrack array
        coinsUsed = new Dictionary<float, int>();
        if (minimumCoins[scaledAmount] <= scaledAmount)
        {
            for (var i = scaledAmount; i > 0; i -= coinTrack[i])
            {
                var coinValue = (float)coinTrack[i] / ScalingFactor;
                if (coinsUsed.TryGetValue(coinValue, out var value))
                {
                    coinsUsed[coinValue] = ++value;
                }
                else
                {
                    coinsUsed[coinValue] = 1;
                }
            }
            return minimumCoins[scaledAmount];
        }

        coinsUsed.Clear();
        return -1;
    }
}