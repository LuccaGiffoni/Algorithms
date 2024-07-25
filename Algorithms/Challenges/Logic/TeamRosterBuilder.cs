using Algorithms.DependencyInjection.Challenges;

namespace Algorithms.Challenges.Logic;

public class TeamRosterBuilder : IChallenge
{
    public string Title => "Team Roster Builder";
    public string Description => "Create a team roster for the next 4 weeks the best way possible, keeping all parameters safe";
    public EChallengeLevel Level => EChallengeLevel.Harder;

    private static readonly List<Person?> Team =
    [
        new Person("Vinícius Tamanhão", ERole.Worship, ERegion.Urbanova),
        new Person("João Tamanhão", ERole.Kids, ERegion.Urbanova),

        new Person("Luan Santos", ERole.Worship, ERegion.South),

        new Person("Duda Finzzeto", ERole.Worship, ERegion.Urbanova),
        new Person("Murilo Pereira", ERole.Worship, ERegion.West),

        new Person("Marcio Giffoni", ERole.Safety, ERegion.External),
        new Person("Enzo Giffoni", ERole.Kids, ERegion.External),

        new Person("Daltro Calasans", ERole.Safety, ERegion.South),
        new Person("Duda Calasans", ERole.Kids, ERegion.South),

        new Person("Renato Brites", ERole.Safety, ERegion.Central),
        new Person("Bárbara Brites", ERole.Safety, ERegion.Central)
    ];

    private List<Rule> Rules = 
    [
        new Rule(ERuleType.Family, Team.Find(x => x!.Name == "Daltro Calasans")!, Team.Find(x => x!.Name == "Duda Calasans")!),
        new Rule(ERuleType.Family, Team.Find(x => x!.Name == "Renato Brites")!, Team.Find(x => x!.Name == "Bárbara Brites")!),
    ];
    
    public void Run()
    {
        CheckRules();
    }

    private void CheckRules()
    {
        foreach (var rule in Rules)
        {
            Console.WriteLine($"{rule.RuleType}-type rule: {rule.Id} with {string.Join(", ", rule.People.ToList().Select(x => x.Name))}");
        }
    }
    
    // Classes
    private class Rule(ERuleType ruleType, params Person[] people)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Person[] People { get; set; } = people;
        public ERuleType RuleType { get; set; } = ruleType;
    }
    
    private class Person(string name, ERole role, ERegion region)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; } = name;
        public ERole Role { get; set; } = role;
        public ERegion Region { get; set; } = region;
    }
    
    // Enums
    private enum ERuleType { Family }
    private enum ERole { Worship, Safety, Kids }
    private enum ERegion { North, South, Central, East, West, External, Urbanova }
}