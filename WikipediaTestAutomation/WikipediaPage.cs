
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace WikipediaTestAutomation.Pages
{
    public class WikipediaPage
    {
        private IWebDriver _driver;               
        private WebDriverWait _wait;           
        private readonly string _url = "https://en.wikipedia.org/wiki/Test_automation";

        // creat WkikipediaPage constructor 
        public WikipediaPage()
        {
            _driver = new ChromeDriver(); 
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); //timeout 10 seconds
        }

        // Method to extract the text from the "Test-driven development" section
        public string GetUISectionText()
        {
            _driver.Navigate().GoToUrl(_url);

            // Find the <h3> heading with the given id
            var h3Element = _wait.Until(driver => driver.FindElement(By.CssSelector("h3#Test-driven_development")));

            // Navigate to its parent (usually div.mw-parser-output) and collect following siblings
            var parent = h3Element.FindElement(By.XPath("./ancestor::div[contains(@class, 'mw-parser-output')]"));
            var allElements = parent.FindElements(By.XPath(".//*"));

            List<string> paragraphs = new List<string>();
            bool collecting = false;

            foreach (var el in allElements)
            {
                if (el.Equals(h3Element))
                {
                    collecting = true; // start collecting after we reach the h3
                    continue;
                }

                if (collecting)
                {
                    if (el.TagName.StartsWith("h", StringComparison.OrdinalIgnoreCase))
                        break; // stop if we hit next heading

                    if (el.TagName == "p")
                        paragraphs.Add(el.Text);
                }
            }

            string fullText = "Test-driven development " + string.Join(" ", paragraphs);
            return fullText;

        }



        // Close the browser 
        public void Quit()
        {
            _driver.Quit();
        }
    }
}
