using Algorithms.DependencyInjection.Data;

namespace Algorithms.Challenges.Logic;

public class JobScheduler : IChallenge
{
    public string Title => "JobScheduler";
    public string Description => "You are given N jobs, each with a start time, end time, and profit associated with it." +
                                 "You need to find the maximum profit you can achieve by scheduling these jobs such that no two jobs overlap.";
    public EChallengeLevel Level => EChallengeLevel.Hard;
    
    public void Run()
    {
        FindMaxProfitSchedule(5);
    }

    private static List<Job> GenerateRandomJobs(int count, int minStartTime, int maxStartTime, int minDuration, int maxDuration, int minProfit, int maxProfit)
    {
        var jobs = new List<Job>();
        var random = new Random();

        for (var i = 0; i < count; i++)
        {
            var startTime = random.Next(minStartTime, maxStartTime + 1);
            var endTime = startTime + random.Next(minDuration, maxDuration + 1);
            var profit = random.Next(minProfit, maxProfit + 1);
            jobs.Add(new Job(startTime, endTime, profit));
        }

        return jobs;
    }
    
    private static void FindMaxProfitSchedule(int quantity)
    {
        var randomJobs = GenerateRandomJobs(quantity, 1, 10, 1, 5, 10, 100);
        
        foreach (var job in randomJobs)
        {
            Console.WriteLine($"Job {job.Id} StartTime = {job.StartTime}, EndTime = {job.EndTime}, Profit = {job.Profit}");
        }
    }
}

public class Job(int startTime, int endTime, int profit)
{
    public Guid Id { get; } = Guid.NewGuid();
    public int StartTime { get; } = startTime;
    public int EndTime { get; } = endTime;
    public int Profit { get; } = profit;
}
