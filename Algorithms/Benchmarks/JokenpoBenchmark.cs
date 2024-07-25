using Algorithms.DependencyInjection.Benchmarks;
using BenchmarkDotNet.Attributes;

namespace Algorithms.Benchmarks;

public class JokenpoBenchmark : IBenchmark
{
    public string Title => "Jokenpo";
    public EBenchmarkCategory Category => EBenchmarkCategory.Numbers;

    [Benchmark] public void MatrixMethod() => RunTestWithMatrix();
    [Benchmark] public void OriginalMethod() => RunTestWithOriginal();
    [Benchmark] public void OptimizedMethod() => RunTestWithDictionary();
    
    // Original
    private static PlayResult RunTestWithOriginal()
    {
        var playOne = new OriginalPlay([PlayType.Paper, PlayType.Lizard])
        {
            Type = PlayType.Spock
        };

        var playTwo = new OriginalPlay([PlayType.Scissor, PlayType.Rock])
        {
            Type = PlayType.Lizard
        };
        
        return playOne.EvaluateScenarios(playTwo.Type);
    }

    private class OriginalPlay(PlayType[] weakness)
    {
        public PlayType Type { get; set; }
        private PlayType[] Weakness { get; set; } = weakness;

        public PlayResult EvaluateScenarios(PlayType otherPlay)
        {
            if (otherPlay == Type) return PlayResult.Draw;

            return Weakness.Any(x => x == otherPlay) ? PlayResult.Defeat : PlayResult.Victory;
        }
    }
    
    // Dictionary
    private static PlayResult RunTestWithDictionary()
    {
        var playOne = new Play(PlayType.Spock);
        var playTwo = new Play(PlayType.Lizard);
        
        return playOne.EvaluateScenarios(playTwo.Type);
    }

    private class Play(PlayType type)
    {
        private static readonly Dictionary<PlayType, HashSet<PlayType>> WeaknessMap = new Dictionary<PlayType, HashSet<PlayType>>
        {
            { PlayType.Rock, new HashSet<PlayType> { PlayType.Paper, PlayType.Spock } },
            { PlayType.Paper, new HashSet<PlayType> { PlayType.Scissor, PlayType.Lizard } },
            { PlayType.Scissor, new HashSet<PlayType> { PlayType.Rock, PlayType.Spock } },
            { PlayType.Spock, new HashSet<PlayType> { PlayType.Paper, PlayType.Lizard } },
            { PlayType.Lizard, new HashSet<PlayType> { PlayType.Rock, PlayType.Scissor } }
        };

        public PlayType Type { get; set; } = type;

        public PlayResult EvaluateScenarios(PlayType otherPlay)
        {
            if (otherPlay == Type) return PlayResult.Draw;
        
            return WeaknessMap[Type].Contains(otherPlay) ? PlayResult.Defeat : PlayResult.Victory;
        }
    }
    
    // Matrix
    private static readonly int[,] ResultMatrix =
    {
        
        // R   P   S   L   Sp
        {  0, -1,  1,  1, -1 }, // Rock
        {  1,  0, -1, -1,  1 }, // Paper
        { -1,  1,  0,  1, -1 }, // Scissor
        { -1,  1, -1,  0,  1 }, // Lizard
        {  1, -1,  1, -1,  0 }  // Spock1
    };

    private static void RunTestWithMatrix()
    {
        var playOne = PlayType.Spock;
        var playTwo = PlayType.Lizard;

        Console.WriteLine($"Jogada do Jogador A: {EvaluatePlay(playOne, playTwo)}");
    }

    private static PlayResult EvaluatePlay(PlayType playOne, PlayType playTwo)
    {
        var result = ResultMatrix[(int)playOne, (int)playTwo];
        
        return result switch
        {
            0 => PlayResult.Draw,
            1 => PlayResult.Victory,
            _ => PlayResult.Defeat
        };
    }
    
    // Enums
    private enum PlayType
    {
        Rock,
        Paper,
        Scissor,
        Spock,
        Lizard
    }

    private enum PlayResult
    {
        Draw,
        Victory,
        Defeat
    }
}