using Algorithms.DependencyInjection;
using Algorithms.LINQMethods;
using Algorithms.Numbers;
using Algorithms.Strings;

namespace Algorithms;

public static class Program
{
    public static void Main()
    {
        ChallengePicker();
    }

    private static void ChallengePicker()
    {
        while (true)
        {
            Console.WriteLine("Choose your option:\n" +
                              "\nStrings:\n0. Reverse Phrases\n1. Remove Vowels\n2. Anagram Grouping\n" +
                              "\nNumbers:\n3. Order Numbers\n4. Coin Change\n5. Arrays Median\n" +
                              "\nDI:\n6. Dependency Injection\n");
            
            var option = Convert.ToInt16(Console.ReadLine());
            switch (option)
            {
                case 0: ReversePhrases.Run();
                    break;
                case 1: RemoveVowels.Run();
                    break;
                case 2: AnagramGrouping.Run();
                    break;
                case 3: OrderNumbers.Run();
                    break; 
                case 4: CoinsChange.Run();
                    break; 
                case 5: TwoArraysMedian.Run();
                    break; 
                case 6: Container.Run();
                    break;
                case 7: Aggregation.Run();
                    break;
                default: Console.WriteLine("None option selected. Please, type a valid option: ");
                    break;
            }
        }
    }
}