using Algorithms.DependencyInjection.Challenges;

namespace Algorithms.Challenges.Numbers;

public class FizzBuzz : IChallenge
{
    public string Description => "Write a program that prints the numbers from 1 to N. But for multiples of three, print \"Fizz\" instead of the number and for the multiples of five, print \"Buzz\". For numbers which are multiples of both three and five, print \"FizzBuzz\".";
    public string Title => "FizzBuzz";
    public EChallengeLevel Level => EChallengeLevel.Junior;

    public void Run()
    {
        Console.WriteLine("The maximum number is: ");
        var max = Console.ReadLine();

        CheckAndPrint(Convert.ToInt32(max));
    }

    private static void CheckAndPrint(int max)
    {
        var items = new List<object>();
        for (var i = 1; i <= max; i++)
        {
            switch (i % 3)
            {
                case 0 when i % 5 == 0:
                    items.Add("FizzBuzz");
                    break;
                case 0:
                    items.Add("Fizz");
                    break;
                default:
                {
                    if (i % 5 == 0) items.Add("Buzz");
                    else items.Add(i);
                    break;
                }
            }
        }
        
        Console.WriteLine(string.Join(", ", items));
    }
}