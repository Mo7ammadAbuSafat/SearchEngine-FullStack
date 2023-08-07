using System.Text.RegularExpressions;

namespace SearchApi.Utills
{
    public static class EnglishTokenizer
    {
        private static readonly HashSet<string> StopWords = new HashSet<string>()
        {
            "a", "an", "the", "is", "and", "its", "of", "to", "in", "for", "on", "with",
            "as", "at", "by", "from", "up", "but", "so", "not", "only", "too", "here",
            "there", "when", "why", "how", "all", "any", "both", "each", "more", "most",
            "other", "some", "such", "no", "own", "same", "than", "that", "these",
            "this", "which", "you", "he", "him", "his", "she", "her", "it", "we",
            "us", "our", "they", "them", "their", "i", "me", "my", "myself",
            "your", "yourself", "he", "himself", "she", "herself", "we", "ourselves", "us",
            "ourselves", "they", "themselves"
        };

        public static IEnumerable<string> Tokenize(string text, string tokenizerType, bool isAllowedFrequency)
        {
            string pattern = @"[\W_]+";
            IEnumerable<string> tokens = Regex.Split(text, pattern)
                        .Where(word => !string.IsNullOrWhiteSpace(word))
                        .Select(word => word.ToLower())
                        .ToList();

            if (tokenizerType == "without-stop-words")
            {
                tokens = tokens
                    .Where(word => !StopWords.Contains(word))
                    .ToList();
            }

            if (!isAllowedFrequency)
            {
                tokens = tokens.ToHashSet();
            }

            return tokens;
        }
    }
}
