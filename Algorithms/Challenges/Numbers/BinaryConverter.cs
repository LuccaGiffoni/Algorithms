using Algorithms.DependencyInjection.Data;
using System;
using System.Diagnostics;

namespace Algorithms.Challenges.Numbers
{
    public class BinaryConverter : IChallenge
    {
        public string Description => "Create a function that receives a binary string and returns its value as a base ten number.";
        public string Title => "Binary Converter";
        public EChallengeLevel Level => EChallengeLevel.Easy;

        public void Run()
        {
            Console.WriteLine("Type your binary:");
            var binary = Console.ReadLine()?.Trim();

            if (binary == null) return;
            
            var decimalValue = ConvertBinary(binary);
            Console.WriteLine(decimalValue != -1
                ? $"Decimal value: {decimalValue}"
                : "Invalid binary input. Only '0' and '1' are allowed.");
        }

        private static int ConvertBinary(string binary)
        {
            var decimalValue = 0;

            foreach (var bit in binary)
            {
                if (bit != '0' && bit != '1') return -1; // Invalid input

                // Shift the current value to the left (multiply by 2) and add the bit's value
                decimalValue = (decimalValue << 1) | (bit - '0');
            }
            
            return decimalValue;
        }
    }
}