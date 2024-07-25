using Algorithms.Benchmarks;
using Algorithms.Challenges.Numbers;
using Algorithms.Challenges.Strings;
using Algorithms.Challenges.Logic;
using Algorithms.DependencyInjection;
using BenchmarkDotNet.Running;

namespace Algorithms
{
    public static class Program
    {
        private static readonly Container Container = new();

        public static void Main()
        {
            RegisterChallenges();
            RegisterBenchmarks();
            MainMenu();
        }

        private static void RegisterChallenges()
        {
            Container.RegisterChallenge(0, new ReversePhrases());
            Container.RegisterChallenge(1, new RemoveVowels());
            Container.RegisterChallenge(2, new AnagramGrouping());
            Container.RegisterChallenge(3, new OrderNumbers());
            Container.RegisterChallenge(4, new CoinsChange());
            Container.RegisterChallenge(5, new TwoArraysMedian());
            Container.RegisterChallenge(6, new JobScheduler());
            Container.RegisterChallenge(7, new BinaryConverter());
            Container.RegisterChallenge(8, new PrimeNumbers());
            Container.RegisterChallenge(9, new FizzBuzz());
            Container.RegisterChallenge(10, new LogReader());
            Container.RegisterChallenge(11, new Knapsack());
            
            Container.RegisterChallenge(12, new TeamRosterBuilder());
        }

        private static void RegisterBenchmarks()
        {
            Container.RegisterBenchmark(0, new BinaryConverterBenchmark());
            Container.RegisterBenchmark(1, new LogReaderBenchmark());
            Container.RegisterBenchmark(2, new JokenpoBenchmark());
        }

        private static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("Choose your option (type -1 to exit):");
                Console.WriteLine("0: Run Challenges");
                Console.WriteLine("1: Run Benchmarks");

                if (!int.TryParse(Console.ReadLine(), out var option) || option == -1)
                {
                    Console.WriteLine("Exiting...");
                    break;
                }

                switch (option)
                {
                    case 0:
                        ChallengePicker();
                        break;
                    case 1:
                        BenchmarkPicker();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void ChallengePicker()
        {
            while (true)
            {
                Console.WriteLine("\nChoose your challenge (type -1 to go back):");
                Console.WriteLine(Container.GetChallengeMenu());

                if (!int.TryParse(Console.ReadLine(), out var option) || option == -1)
                {
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

        private static void BenchmarkPicker()
        {
            while (true)
            {
                Console.WriteLine("Choose your benchmark (type -1 to go back):");
                Console.WriteLine(Container.GetBenchmarkMenu());

                if (!int.TryParse(Console.ReadLine(), out var option) || option == -1)
                {
                    break;
                }

                var benchmark = Container.GetBenchmark(option);
                if (benchmark != null)
                {
                    BenchmarkRunner.Run(benchmark.GetType());
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }
    }
}
