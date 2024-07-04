using BenchmarkDotNet.Attributes;

namespace Algorithms.DependencyInjection.Benchmarks;

public interface IBenchmark
{ 
    string Title { get; }
    EBenchmarkCategory Category { get; }

    [Benchmark] public void OriginalMethod();
    [Benchmark] public void OptimizedMethod();
}
