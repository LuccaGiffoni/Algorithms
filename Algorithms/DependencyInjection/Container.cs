using Algorithms.DependencyInjection.Benchmarks;
using Algorithms.DependencyInjection.Challenges;

namespace Algorithms.DependencyInjection
{
    public class Container
    {
        private readonly Dictionary<int, IChallenge> _challenges = new();
        private readonly Dictionary<int, IBenchmark> _benchmarks = new();

        public void RegisterChallenge(int id, IChallenge challenge)
        {
            _challenges[id] = challenge;
        }

        public void RegisterBenchmark(int id, IBenchmark benchmark)
        {
            _benchmarks[id] = benchmark;
        }

        public IChallenge? GetChallenge(int id) => _challenges.GetValueOrDefault(id);
        public IBenchmark? GetBenchmark(int id) => _benchmarks.GetValueOrDefault(id);

        public string GetChallengeMenu() =>
            string.Join("\n", _challenges.Select(c => $"{c.Key}. {c.Value.Title}: {c.Value.Description}"));

        public string GetBenchmarkMenu() =>
            string.Join("\n", _benchmarks.Select(b => $"{b.Key}. {b.Value.Title}"));
    }
}