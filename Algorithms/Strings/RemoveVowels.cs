namespace Algorithms.Strings
{
    public class RemoveVowels
    {
        private static readonly HashSet<char> Vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];

        public static void Run()
        {
            var input = Console.ReadLine();
            if (input == null) return;

            var vowelClear = ClearString(input);
            Console.WriteLine(vowelClear);
        }

        private static string ClearString(string input)
        {
            // Create a new string with fixed size - allocates less memory
            var result = new System.Text.StringBuilder(input.Length);

            // Instead of removing from created string, create a new one without any vowels
            foreach (var character in input.Where(character => !Vowels.Contains(character)))
            {
                result.Append(character);
            }

            return result.ToString();
        }
    }
}