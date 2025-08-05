using System.Text.RegularExpressions;

namespace WikipediaTestAutomation.Parsers
{
    public class WikipediaApiParser
    {
        
        /// Extracts the "Test-driven development" section from Wikipedia API.
        /// Cleans common wiki syntax such as links, templates, and references.
      
        public string ExtractTddSection(string rawWikiText)
        {
            if (string.IsNullOrWhiteSpace(rawWikiText))
                throw new ArgumentException("Input content is empty.");


            // Find the start and end of the desired section
            int indexStart = rawWikiText.IndexOf("Test-driven development");
            if (indexStart == -1)
                throw new Exception("'Test-driven development' section not found.");

            int indexEnd = rawWikiText.IndexOf("Continuous testing");
            string methodologySection_1 = rawWikiText.Substring(indexStart, indexEnd - indexStart);

            // Step 3: Clean API syntax
            string cleaned = Regex.Replace(methodologySection_1, @"\[\[(?:[^\]|]*\|)?([^\]]+)\]\]", "$1");
            cleaned = Regex.Replace(cleaned, @"\{\{.*?\}\}", "", RegexOptions.Singleline);
            cleaned = Regex.Replace(cleaned, @"<ref[^>]*>.*?</ref>", "", RegexOptions.Singleline);
            cleaned = Regex.Replace(cleaned, @"&[a-z]+;", " ");
            cleaned = Regex.Replace(cleaned, @"\s{2,}", " ");
            cleaned = cleaned.Replace("\n", " ").Replace("\r", " ");
            cleaned = cleaned.Replace("\\n", " ").Replace("\\r", " ");


            return cleaned.Trim();
        }
    }
}
