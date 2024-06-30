using Algorithms.DependencyInjection.Data;

namespace Algorithms.DependencyInjection;

public class Container
{
    private readonly Dictionary<int, IChallenge> _challenges = new();

    public void RegisterChallenge(int option, IChallenge challenge) => _challenges[option] = challenge;
    public IChallenge? GetChallenge(int option) => _challenges.GetValueOrDefault(option);
    
    public string GetMenu()
    {
        var groupedChallenges = _challenges.Values
            .GroupBy(c => c.Level)
            .OrderBy(g => g.Key)
            .ToDictionary(g => g.Key, g => g.ToList());

        var menu = new System.Text.StringBuilder();
        foreach (var level in groupedChallenges.Keys)
        {
            menu.AppendLine($"\n{level} Challenges:");
            foreach (var challenge in groupedChallenges[level])
            {
                var option = _challenges.FirstOrDefault(c => c.Value == challenge).Key;
                menu.AppendLine($"{option}. {challenge.Title}: {challenge.Description}");
            }
        }
        
        return menu.ToString();
    }
}