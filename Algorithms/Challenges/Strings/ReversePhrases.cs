using Algorithms.DependencyInjection.Data;

namespace Algorithms.Challenges.Strings;

public class ReversePhrases : IChallenge
{
    public string Title => "Reverse Phrases";
    public string Description => "Reverse a string with special characters, letters and numbers.";
    public EChallengeLevel Level => EChallengeLevel.Easy;
    
    public void Run()
    {
        var input = Console.ReadLine();

        if (input == null) return;
        var reversed = ReversePhrase(input);
        Console.WriteLine(reversed);
    }

    private static string ReversePhrase(string input)
    {
        List<string> phrases = [];
        var currentPhrase = string.Empty;

        foreach (var c in input)
        {
            if (!char.IsLetterOrDigit(c))
            {
                phrases.Add(currentPhrase);
                phrases.Add(c.ToString());
                currentPhrase = string.Empty;
            }
            else
            {
                currentPhrase += c;
            }
        }

        phrases.Add(currentPhrase);
        phrases.Reverse();

        return string.Join("", phrases);
    }
}