namespace Algorithms.DependencyInjection.Challenges
{
    public interface IChallenge
    {
        void Run();
        string Description { get; }
        string Title { get; }
        EChallengeLevel Level { get; }
    }
}