using System.Text.RegularExpressions;


namespace WikipediaTestAutomation.Helpers
{
    public class TextAnalyzer
    {
        // Cleans the raw text and returns word counts
        public Dictionary<string, int> AnalyzeText(string rawText)
        {
            if (string.IsNullOrWhiteSpace(rawText))
                return new Dictionary<string, int>();

            // Step 1: Remove brackets and their content)
            string noBrackets = Regex.Replace(rawText, @"\[[^\]]*\]", "");

            // Step 2: Convert to lowercase 
            string lower = noBrackets.ToLower();

            // Step 3: Remove punctuation 
            string cleaned = Regex.Replace(lower, @"[^\w\s]", " ");

            // Step 4: Split into words
            string[] words = cleaned.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // Step 5: Count word frequency
            Dictionary<string, int> wordCounts = words
                .GroupBy(w => w)
                .ToDictionary(g => g.Key, g => g.Count());

            return wordCounts;
        }

        // returns the number of unique words
        public int CountUniqueWords(string rawText)
        {
            var result = AnalyzeText(rawText);
            return result.Keys.Count;
        }
    }
}
