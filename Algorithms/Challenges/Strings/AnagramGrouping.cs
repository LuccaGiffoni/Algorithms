using Algorithms.DependencyInjection.Challenges;

namespace Algorithms.Challenges.Strings
{
    public class AnagramGrouping : IChallenge
    {
        public string Title => "Anagram Grouping";
        public string Description => "Write a function that takes a list of strings and groups them by anagrams.";
        public EChallengeLevel Level => EChallengeLevel.Easy;

        private static readonly List<string> Input = [ "listen", "silent", "enlist", "rat", "tar", "art" ];

        public void Run()
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