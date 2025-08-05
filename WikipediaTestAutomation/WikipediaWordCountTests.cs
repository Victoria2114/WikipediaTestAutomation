
using WikipediaTestAutomation.Pages;
using WikipediaTestAutomation.Services;
using WikipediaTestAutomation.Helpers;


namespace WikipediaTestAutomation.Tests
{
    [TestFixture]
    public class WikipediaWordCountTests
    {
        private WikipediaPage _uiPage;
        private WikipediaApi _apiService;
        private TextAnalyzer _analyzer;

        [SetUp]
        public void Setup()
        {
            _uiPage = new WikipediaPage();
            _apiService = new WikipediaApi();
            _analyzer = new TextAnalyzer();
        }

        [Test]
        public async Task UniqueWordCount_ShouldMatch_Between_UI_And_API()
        {
            // --- UI ---
            string uiRawText = _uiPage.GetUISectionText();
            Dictionary<string, int> uiWordCounts = _analyzer.AnalyzeText(uiRawText);
            int uiUniqueCount = uiWordCounts.Count;
            

            // --- API ---
            string apiRawText = await _apiService.GetExtractAsync();
            Dictionary<string, int> apiWordCounts = _analyzer.AnalyzeText(apiRawText);
            int apiUniqueCount = apiWordCounts.Count;
            

            // --- Output unique word counts ---
            TestContext.WriteLine("=== UI Unique Words Count ===");
            TestContext.WriteLine($"Total unique words in UI: {uiUniqueCount}");

            TestContext.WriteLine("\n=== API Unique Words Count ===");
            TestContext.WriteLine($"Total unique words in API: {apiUniqueCount}");


            // --- Assert ---
            Assert.AreEqual(uiUniqueCount, apiUniqueCount, "Mismatch in unique word count between UI and API");
        }

        [TearDown]
        public void Cleanup()
        {
            _uiPage.Quit(); // Close 
        }
    }
}
