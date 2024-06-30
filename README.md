# Algorithms Console Application
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
        /Data
            EChallengeLevel.cs      # Enum for challenge levels
            IChallenge.cs           # Interface for challenges
        Container.cs                # DI container for challenges
    /Numbers
        CoinsChange.cs              # Example numerical challenge
        OrderNumbers.cs             # Example numerical challenge
        TwoArraysMedian.cs          # Example numerical challenge
    /Strings
        AnagramGrouping.cs          # Example string challenge
        RemoveVowels.cs             # Example string challenge
        ReversePhrases.cs           # Example string challenge
    Program.cs                      # Main entry point for the application
```

&nbsp;
### Key Files
- Program.cs: Main entry point that sets up and runs the application.
- Container.cs: Handles registration and retrieval of challenges.
- IChallenge.cs: Interface defining the structure of a challenge.
- EChallengeLevel.cs: Enum defining the difficulty levels for challenges.

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
Open Program.cs and register your new challenge in the RegisterChallenges method:

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
## Contributing
**Contributions are welcome!**
&nbsp;

Please fork the repository and create a pull request for any enhancements, bug fixes, or new challenges. Follow the existing coding style and add appropriate documentation for new features.
