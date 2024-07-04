using Algorithms.DependencyInjection.Benchmarks;
using BenchmarkDotNet.Attributes;

namespace Algorithms.Benchmarks;

public class BinaryConverterBenchmark : IBenchmark
{
    private const string Binary = "1101010111001010";

    public string Title => "Binary Converter";
    public EBenchmarkCategory Category => EBenchmarkCategory.Numbers;

    [Benchmark] public void OriginalMethod() => OriginalConvertBinary(Binary);
    [Benchmark] public void OptimizedMethod() => OptimizedConvertBinary(Binary);

    private static int OriginalConvertBinary(string binary)
    {
        var digits = binary.ToCharArray().Select(character => character.ToString()).ToList();

        if (!digits.All(digit => digit is "0" or "1")) return -1;

        digits.Reverse();
        return digits.Select((t, i) => Convert.ToInt32(t) * (int)Math.Pow(2, i)).Sum();
    }

    private static int OptimizedConvertBinary(string binary)
    {
        var decimalValue = 0;

        foreach (var bit in binary)
        {
            if (bit != '0' && bit != '1')
            {
                return -1;
            }

            decimalValue = (decimalValue << 1) | (bit - '0');
        }

        return decimalValue;
    }
}