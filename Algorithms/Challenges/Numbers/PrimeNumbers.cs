using Algorithms.DependencyInjection.Challenges;

namespace Algorithms.Challenges.Numbers;

public class PrimeNumbers : IChallenge
{
    public string Description => "Find a list of prime numbers until given number";
    public string Title => "Prime Numbers";
    public EChallengeLevel Level => EChallengeLevel.Easy;
    
    public void Run()
    {
        var maxNumber = Console.ReadLine();
        FindPrimeNumbers(Convert.ToInt32(maxNumber));
    }

    private static void FindPrimeNumbers(int max)
    {
        var primeNumbers = new List<int>();
        for (var i = 0; i < max; i++) if (IsPrime(i)) primeNumbers.Add(i);

        Console.WriteLine(string.Join(",", primeNumbers));
    }
    
    private static bool IsPrime(int n)
    {
        switch (n)
        {
            case <= 1:
                return false;
            case 2:
                return true;
        }

        if (n % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(n));
        for (var i = 3; i <= boundary; i += 2) if (n % i == 0) return false;

        return true;
    }

}