using Algorithms.DependencyInjection.Challenges;
using Newtonsoft.Json;

namespace Algorithms.Challenges.Strings;

public class LogReader : IChallenge
{
    public string Description => "Read logs from local file";
    public string Title => "Log Reader";
    public EChallengeLevel Level => EChallengeLevel.Intermediate;

    private const string FileName = "logs.json";

    public async void Run()
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
    
    private List<Machine> CreateMachines(int quantity = 3)
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
    private class Machine
    {
        public Guid Id { get; } = Guid.NewGuid();
    }

    private class Log(Guid machineId, bool result, string? message = null)
    {
        public Guid Id { get; } = Guid.NewGuid();
        public Guid MachineId { get; } = machineId;
        public bool Result { get; } = result;
        public string? Message { get; } = message;
    }
}