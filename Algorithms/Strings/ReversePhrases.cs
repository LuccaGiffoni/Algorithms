namespace Algorithms.Strings
{
    public class ReversePhrases
    {
        public static void Run()
        {
            var input = Console.ReadLine();

            if (input == null) return;
            var reversed = ReversePhrase(input);
            Console.WriteLine(reversed);
        }

        private static string ReversePhrase(string input)
        {
            List<string> phrases = [];
            var currentPhrase = string.Empty;

            foreach (var c in input)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    phrases.Add(currentPhrase);
                    phrases.Add(c.ToString());
                    currentPhrase = string.Empty;
                }
                else
                {
                    currentPhrase += c;
                }
            }

            phrases.Add(currentPhrase);
            phrases.Reverse();

            return string.Join("", phrases);
        }
    }
}