using Algorithms.DependencyInjection.Data;

namespace Algorithms.Challenges.Numbers;

public class TwoArraysMedian : IChallenge
{
    public string Title => "Two Arrays Median";
    public string Description => "Concatenate two arrays and find the median of the merged array.";
    public EChallengeLevel Level => EChallengeLevel.Easy;
    
    // Parameters for random arrays
    private const int MaxArraySize = 10;
    private const int MaxValue = 100;
    
    public void Run()
    {
        var firstArray = GenerateRandomSortedArray();
        var secondArray = GenerateRandomSortedArray();

        Console.WriteLine("First Array: " + string.Join(", ", firstArray));
        Console.WriteLine("Second Array: " + string.Join(", ", secondArray));

        var median = FindMedian(firstArray, secondArray);
        Console.WriteLine($"Median: {median}");
    }

    private static int[] GenerateRandomSortedArray()
    {
        var random = new Random();
        var size = random.Next(1, MaxArraySize + 1); // Random size between 1 and MaxArraySize
        var array = new int[size];
        for (var i = 0; i < size; i++)
        {
            array[i] = random.Next(MaxValue + 1); // Random value between 0 and MaxValue
        }
        Array.Sort(array); // Sort the array
        return array;
    }

    private static float FindMedian(IEnumerable<int> firstArray, IEnumerable<int> secondArray)
    {
        // Merge both arrays and remove duplicates
        var mergedList = firstArray.Union(secondArray).OrderBy(x => x).ToList();

        var count = mergedList.Count;

        // Return median
        if (count % 2 != 0)
        {
            return mergedList[count / 2]; // Middle element for odd length
        }

        // Median for even length
        var middle1 = mergedList[(count / 2) - 1];
        var middle2 = mergedList[count / 2];
        return (middle1 + middle2) / 2.0f;
    }
}