using Algorithms.DependencyInjection.Benchmarks;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;

namespace Algorithms.Benchmarks;

public class LogReaderBenchmark : IBenchmark
{
    private const string Binary = "1101010111001010";

    public string Title => "Log Reader";
    public EBenchmarkCategory Category => EBenchmarkCategory.Strings;

    [Benchmark] public void OriginalMethod() => Run();
    [Benchmark] public void OptimizedMethod() => _ = Optimized();

    private const string FileName = "logs.json";

    private async Task Run()
    {
        await SaveLogs(CreateLogs(CreateMachines()));
        await ReadLogs();
    }

    private async Task Optimized()
    {
        await SaveLogs(CreateLogs(CreateMachines()));
        await ReadLogs();
    }

    private static async Task ReadLogs()
    {
        if (File.Exists(FileName))
        {
            var json = await File.ReadAllTextAsync(FileName);
            var logs = JsonConvert.DeserializeObject<List<Log>>(json);

            if (logs?.Count <= 0) return;

            foreach (var log in logs)
            {
                Console.WriteLine($"{log.Id} from {log.MachineId} produced {log.Message} | {log.Result.ToString()}");
            }
        }
        else
        {
            Console.WriteLine($"File {FileName} not found.");
        }
    }
    private static async Task SaveLogs(List<Log> logs)
    {
        var json = JsonConvert.SerializeObject(logs, Formatting.Indented);
        await File.WriteAllTextAsync(FileName, json);
    }
    
    private static List<Machine> CreateMachines(int quantity = 3)
    {
        var machines = new List<Machine>();

        for (var i = 0; i < quantity; i++)
        {
            machines.Add(new Machine());
        }

        return machines;
    }

    private static List<Log> CreateLogs(List<Machine> machines, int quantity = 10)
    {
        var logs = new List<Log>();

        foreach (var machine in machines)
        {
            for (var i = 0; i < quantity; i++)
            {
                logs.Add(i % 2 != 0 ? new Log(machine.Id, false, $"Error {i * 100 + 40 }") : new Log(machine.Id, true, "Success"));
            }
        }

        return logs;
    }
    
    // Classes
    private record Machine
    {
        public Guid Id { get; } = Guid.NewGuid();
    }

    private record Log(Guid MachineId, bool Result, string? Message)
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}