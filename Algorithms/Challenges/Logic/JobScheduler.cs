using System.Numerics;
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
        Console.WriteLine(MaximizeProfit(GenerateRandomJobs(10, 8, 18, 4, 18, 1, 10)));
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
    
    private static int FindLastNonOverlappingJob(List<Job> jobs, int index)
    {
        int low = 0, high = index - 1;

        while (low <= high)
        {
            var mid = (low + high) / 2;
            if (jobs[mid].EndTime <= jobs[index].StartTime)
            {
                if (jobs[mid + 1].EndTime <= jobs[index].StartTime)
                    low = mid + 1;
                else
                    return mid;
            }
            else
            {
                high = mid - 1;
            }
        }
        return -1;
    }
    
    private static Guid MaximizeProfit(List<Job> jobs)
    {
        foreach (var job in jobs)
        {
            Console.WriteLine($"{jobs.IndexOf(job)}: {job.Id}");
        }
        Console.WriteLine("\n");
        
        var n = jobs.Count;
        var dp = new int[n];
        dp[0] = jobs[0].Profit;

        for (var i = 1; i < n; i++)
        {
            var includeProfit = jobs[i].Profit;
            var lastNonConflictIndex = FindLastNonOverlappingJob(jobs, i);
            if (lastNonConflictIndex != -1)
            {
                includeProfit += dp[lastNonConflictIndex];
            }

            dp[i] = Math.Max(includeProfit, dp[i - 1]);
        }
        return jobs[n - 1].Id;
    }
}

public class Job(int startTime, int endTime, int profit)
{
    public Guid Id { get; } = Guid.NewGuid();
    public int StartTime { get; } = startTime;
    public int EndTime { get; } = endTime;
    public int Profit { get; } = profit;
}
