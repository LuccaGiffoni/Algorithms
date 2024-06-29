using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Strings
{
    public class AnagramGrouping
    {
        // Write a function that takes a list of strings and groups them by anagrams.
        // Anagrams are strings made up of the same characters in different orders.

        private static readonly List<string> Input = [ "listen", "silent", "enlist", "rat", "tar", "art" ];

        public static void Run()
        {
            var groups = GroupAnagrams(Input);
            foreach (var group in groups)
            {
                Console.WriteLine($"Key: {group.Key}, Anagrams: {string.Join(", ", group.Value)}");
            }
        }

        private static Dictionary<string, List<string>> GroupAnagrams(IEnumerable<string> input)
        {
            var dic = new Dictionary<string, List<string>>();
            
            foreach (var str in input)
            {
                // Sort the characters of the string to create the key
                var key = new string(str.OrderBy(c => c).ToArray());
                
                // Add the string to the appropriate group in the dictionary
                if (!dic.TryGetValue(key, out var value))
                {
                    value = new List<string>();
                    dic[key] = value;
                }

                value.Add(str);
            }

            return dic;
        }
    }
}