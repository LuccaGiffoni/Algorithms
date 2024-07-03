using Algorithms.DependencyInjection.Data;

namespace Algorithms.Challenges.Strings
{
    public class TriePrefixTree : IChallenge
    {
        public string Title => "Trie (Prefix Tree)";
        public string Description => "Implement a Trie (Prefix Tree) for efficient prefix-based searches. Allows user input and has some fixed words.";
        public EChallengeLevel Level => EChallengeLevel.Hard;

        public void Run()
        {
            var trie = new Trie();
            var fixedWords = new List<string> { "apple", "app", "application", "apt", "bat", "batch", "bath" };

            Console.WriteLine("Inserting fixed words into the Trie...");
            foreach (var word in fixedWords)
            {
                trie.Insert(word);
            }

            while (true)
            {
                Console.WriteLine("Choose an option:\n1. Insert Word\n2. Search Word\n3. Check Prefix\n4. Remove Word\n5. List All Words\n6. Exit");
                if (!int.TryParse(Console.ReadLine(), out var choice) || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    continue;
                }

                if (choice == 6)
                {
                    Console.WriteLine("Exiting...");
                    break;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter word to insert: ");
                        var insertWord = Console.ReadLine();
                        if (!string.IsNullOrEmpty(insertWord))
                        {
                            trie.Insert(insertWord);
                            Console.WriteLine($"Inserted '{insertWord}' into the Trie.");
                        }
                        break;
                    case 2:
                        Console.Write("Enter word to search: ");
                        var searchWord = Console.ReadLine();
                        Console.WriteLine($"Search '{searchWord}': {searchWord != null && trie.Search(searchWord)}");
                        break;
                    case 3:
                        Console.Write("Enter prefix to check: ");
                        var prefix = Console.ReadLine();
                        Console.WriteLine($"Starts with '{prefix}': {prefix != null && trie.StartsWith(prefix)}");
                        break;
                    case 4:
                        Console.Write("Enter word to remove: ");
                        var removeWord = Console.ReadLine();
                        Console.WriteLine(removeWord != null && trie.Remove(removeWord)
                            ? $"Removed '{removeWord}' from the Trie."
                            : $"Could not find '{removeWord}' in the Trie.");
                        break;
                    case 5:
                        Console.WriteLine("All words in the Trie:");
                        trie.ListWords();
                        break;
                }
            }
        }

        private class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; } = new();
            public bool IsEndOfWord { get; set; } = false;
        }

        private class Trie
        {
            private readonly TrieNode _root = new();

            public void Insert(string word)
            {
                var current = _root;
                foreach (var ch in word)
                {
                    if (!current.Children.ContainsKey(ch))
                    {
                        current.Children[ch] = new TrieNode();
                    }
                    current = current.Children[ch];
                }
                current.IsEndOfWord = true;
            }

            public bool Search(string word)
            {
                var current = _root;
                foreach (var ch in word)
                {
                    if (!current.Children.ContainsKey(ch))
                    {
                        return false;
                    }
                    current = current.Children[ch];
                }
                return current.IsEndOfWord;
            }

            public bool StartsWith(string prefix)
            {
                var current = _root;
                foreach (var ch in prefix)
                {
                    if (!current.Children.ContainsKey(ch))
                    {
                        return false;
                    }
                    current = current.Children[ch];
                }
                return true;
            }

            public bool Remove(string word)
            {
                return Remove(_root, word, 0);
            }

            private bool Remove(TrieNode current, string word, int index)
            {
                if (index == word.Length)
                {
                    if (!current.IsEndOfWord)
                    {
                        return false;
                    }
                    current.IsEndOfWord = false;
                    return current.Children.Count == 0;
                }

                var ch = word[index];
                if (!current.Children.ContainsKey(ch))
                {
                    return false;
                }

                var shouldDeleteCurrentNode = Remove(current.Children[ch], word, index + 1);

                if (shouldDeleteCurrentNode)
                {
                    current.Children.Remove(ch);
                    return current.Children.Count == 0 && !current.IsEndOfWord;
                }

                return false;
            }

            public void ListWords()
            {
                ListWords(_root, "");
            }

            private void ListWords(TrieNode node, string prefix)
            {
                if (node.IsEndOfWord)
                {
                    Console.WriteLine(prefix);
                }
                foreach (var child in node.Children)
                {
                    ListWords(child.Value, prefix + child.Key);
                }
            }
        }
    }
}
