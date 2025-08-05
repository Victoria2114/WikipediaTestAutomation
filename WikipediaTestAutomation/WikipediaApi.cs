using System.Text.Json;
using WikipediaTestAutomation.Parsers;

namespace WikipediaTestAutomation.Services
{
    public class WikipediaApi
    {
        private readonly HttpClient _httpClient;
        private readonly string _pageTitle = "Test_automation";

        public WikipediaApi()
        {
            _httpClient = new HttpClient();
        }

     
        /// plain text extract of the Wikipedia page.
    
        public async Task<string> GetExtractAsync()
        {
            string url = $"https://en.wikipedia.org/w/api.php?action=query&format=json&prop=extracts&titles={_pageTitle}&explaintext=true";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception("API request failed.");

            string json = await response.Content.ReadAsStringAsync();

            using JsonDocument doc = JsonDocument.Parse(json);
            var parser = new WikipediaApiParser();
            string cleaned = parser.ExtractTddSection(json);

            return cleaned;
        }
    }
}
