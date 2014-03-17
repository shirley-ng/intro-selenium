using System.Linq;
using OpenQA.Selenium;

namespace AdvancedExample.PageObjects
{
    public class DuckDuckGoSearchPage
    {
        private readonly DuckDuckGoSearchPageSelectors _duckDuckGoSearchPageSelectors;
        private readonly IWebDriver _driver;

        public DuckDuckGoSearchPage(IWebDriver driver)
        {
            _duckDuckGoSearchPageSelectors = new DuckDuckGoSearchPageSelectors();
            _driver = driver;
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl("https://duckduckgo.com/");
        }

        public void Search(string term)
        {
            _driver.FindElement(_duckDuckGoSearchPageSelectors.Term).SendKeys(term);
            _driver.FindElement(_duckDuckGoSearchPageSelectors.Search).Click();
        }

        public bool HasSearchResults()
        {
            return _driver.FindElements(_duckDuckGoSearchPageSelectors.Results).Any();
        }

        public bool HasSuggestedSearchTerm()
        {
            return _driver.FindElement(_duckDuckGoSearchPageSelectors.DidYouMean).Displayed;
        }
    }
}