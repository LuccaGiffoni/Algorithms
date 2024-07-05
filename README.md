# Algorithms
This repository contains a console application for running various algorithmic challenges. The application is modular, allowing for easy addition of new challenges organized by difficulty levels such as Junior, Easy, Intermediate, Hard, Harder, and Expert.

&nbsp;
## Getting Started
### Pre-requisites
Ensure you have the following installed:

- .NET 6.0 SDK
- Any IDE for .NET development

&nbsp;
### Clone the Repository
Clone the Project
```bash
git clone https://github.com/LuccaGiffoni/Algorithms.git
cd Algorithms
```

Build the Project
```bash
dotnet build
```

Running the Application

``` bash
dotnet run --project Algorithms
```

You'll be prompted with a menu to select a challenge to run. The challenges are grouped by their difficulty level.

&nbsp;
### Repository Structure
```bash
/Algorithms
    /DependencyInjection
        /Benchmarks
            EBenchmarkCategory.cs      # Enum for benchmark categories
            IBenchmark.cs              # Interface for benchmarks
        /Challenges
            EChallengeLevel            # Enum for challenge levels
            IChallenge.cs              # Interface for challenges
        Container.cs               # DI container for challenges and benchmarks

    /Benchmarks
        BinaryConverterBenchmark.cs # Benchmark for binary conversion

    /Challenges
        /Logic
            JobScheduler.cs         # Challenge for job scheduling
        /Numbers
            BinaryConverter.cs      # Challenge for binary conversion
            CoinsChange.cs          # Challenge for calculating minimum coins for change
            OrderNumbers.cs         # Challenge for ordering numbers
            TwoArraysMedian.cs      # Challenge for finding the median of two arrays
        /Strings
            AnagramGrouping.cs      # Challenge for grouping anagrams
            RemoveVowels.cs         # Challenge for removing vowels
            ReversePhrases.cs       # Challenge for reversing phrases
            Trie.cs                 # Challenge for implementing a trie

    Program.cs                      # Main entry point for the application

```

&nbsp;
### Key Files
- `Program.cs`: Main entry point that sets up and runs the application.
- `Container.cs`: Handles registration and retrieval of challenges and benchmarks.
- `IChallenge.cs`: Interface defining the structure of a challenge.
- `EChallengeLevel.cs`: Enum defining the difficulty levels for challenges.
- `IBenchmark`: Interface defining the structure of a benchmark - using BenchmarkDotNet
- `EBenchmarkCategory`: Enum with benchmarks' categories

&nbsp;
## Creating a New Challenge
To add a new challenge to the application, follow these steps:

### Create your class:
```csharp
using Algorithms.DependencyInjection.Data;

namespace Algorithms.Strings
{
    public class YourNewChallenge : IChallenge
    {
        public void Run()
        {
            // Implement the logic for your challenge here
            Console.WriteLine("Your new challenge is running...");
        }

        public string Description => "Brief description of what the challenge does.";
        public string Title => "Your New Challenge";
        public EChallengeLevel Level => EChallengeLevel.Intermediate;  // Set appropriate level
    }
}
```

&nbsp;
### Register the Challenge
Open `Program.cs` and register your new challenge in the RegisterChallenges method:

``` csharp
private static void RegisterChallenges()
{
    Container.RegisterChallenge(0, new ReversePhrases());
    Container.RegisterChallenge(1, new RemoveVowels());
    Container.RegisterChallenge(2, new AnagramGrouping());
    Container.RegisterChallenge(3, new OrderNumbers());
    Container.RegisterChallenge(4, new CoinsChange());
    Container.RegisterChallenge(5, new TwoArraysMedian());
    Container.RegisterChallenge(6, new DependencyInjectionChallenge());
    Container.RegisterChallenge(7, new YourNewChallenge());  // Register your new challenge
}
```
**Ensure that each challenge has a unique option number.**

&nbsp;
### Test Your Challenge
Run the application and select your new challenge from the menu to ensure it works as expected.

``` bash
dotnet run --project Algorithms
```

&nbsp;
## Creating a New Benchmark
To add a new benchmark to the application, follow these steps:

### Create your class:

``` csharp
using Algorithms.DependencyInjection.Data;
using BenchmarkDotNet.Attributes;

namespace Algorithms.Benchmarks
{
    public class YourNewBenchmark : IBenchmark
    {
        public string Title => "Your New Benchmark";
        public EBenchmarkCategory Category => EBenchmarkCategory.Numbers;

        [Benchmark]
        public int OriginalMethod()
        {
            // Implement the original method for your benchmark here
            return 0; // Example return value
        }

        [Benchmark]
        public int OptimizedMethod()
        {
            // Implement the optimized method for your benchmark here
            return 0; // Example return value
        }
    }
}
```

&nbsp;
### Register the Benchmark
Open `Program.cs` and register your new benchmark in the RegisterBenchmarks method:

``` csharp
Copiar código
private static void RegisterBenchmarks()
{
    Container.RegisterBenchmark(0, new BinaryConverterBenchmark());
    // Register your new benchmark
    Container.RegisterBenchmark(1, new YourNewBenchmark());
}
```
**Ensure that each benchmark has a unique option number.**

&nbsp;
### Run Benchmarks with BenchmarkDotNet
You can execute all benchmarks using BenchmarkDotNet to analyze performance by running the project as Release selecting the "Benchmark" option and choosing one benchmark to run:

``` bash
dotnet run --configuration Release
```

&nbsp;
## Contributing
**Contributions are welcome!**
&nbsp;

Please fork the repository and create a pull request for any enhancements, bug fixes, or new challenges. Follow the existing coding style and add appropriate documentation for new features.
