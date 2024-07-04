using Algorithms.DependencyInjection.Data;

namespace Algorithms.Challenges.Numbers;

public class BinaryConverter : IChallenge
{
    public string Description => "Create a function that receives a binary and returns its value as a base ten number";
    public string Title => "Binary Converter";
    public EChallengeLevel Level => EChallengeLevel.Easy;
    
    public void Run()
    {
        Console.WriteLine("Type your binary:");
        var binary = Console.ReadLine();

        if (binary != null) Console.WriteLine(ConvertBinary(binary.Trim()));
    }

    private static int ConvertBinary(string binary)
    {
        var digits = binary.ToCharArray().Select(character => character.ToString()).ToList();

        // Throw error if it's any of the digits is not a 0 or 1
        if (!digits.All(digit => digit is "0" or "1")) return -1;
        
        // Reverse to sync indexing and exponential factor
        digits.Reverse();

        // Select all, calculate the exponential and summing all
        return digits.Select((t, i) => Convert.ToInt32(t) * (int)Math.Pow(2, i)).Sum();
    }
}