using Algorithms.DependencyInjection;

namespace Algorithms
{
    public static class Program
    {
        private static readonly Container Container = new();

        public static void Main()
        {
            RegisterChallenges();
            ChallengePicker();
        }

        private static void RegisterChallenges()
        {
            Container.RegisterChallenge(0, new Challenges.Strings.ReversePhrases());
            Container.RegisterChallenge(1, new Challenges.Strings.RemoveVowels());
            Container.RegisterChallenge(2, new Challenges.Strings.AnagramGrouping());
            Container.RegisterChallenge(3, new Challenges.Numbers.OrderNumbers());
            Container.RegisterChallenge(4, new Challenges.Numbers.CoinsChange());
            Container.RegisterChallenge(5, new Challenges.Numbers.TwoArraysMedian());
            Container.RegisterChallenge(6, new Challenges.Logic.JobScheduler());
            Container.RegisterChallenge(7, new Challenges.Strings.TriePrefixTree());
            Container.RegisterChallenge(8, new Challenges.Numbers.BinaryConverter());
        }

        private static void ChallengePicker()
        {
            while (true)
            {
                Console.WriteLine("Choose your option (type -1 to exit):");
                Console.WriteLine(Container.GetMenu());

                if (!int.TryParse(Console.ReadLine(), out var option) || option == -1)
                {
                    Console.WriteLine("Exiting...");
                    break;
                }

                var challenge = Container.GetChallenge(option);
                if (challenge != null)
                {
                    challenge.Run();
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }
    }
}