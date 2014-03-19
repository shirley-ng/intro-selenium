using System;
using System.Linq;
using OpenQA.Selenium;

namespace FluentPageObjectExample.PageObjects
{
    public class DuckDuckGoSearchPage : PageObject
    {
        private readonly DuckDuckGoSearchPageSelectors _duckDuckGoSearchPageSelectors;

        protected override string AbsolutePath
        {
            get { return "/"; }
        }

        public DuckDuckGoSearchPage(IWebDriver driver, string baseUriString)
            : base(driver, baseUriString)
        {
            ValidatePath();

            _duckDuckGoSearchPageSelectors = new DuckDuckGoSearchPageSelectors();
        }

        public void FeelingDucky(string term)
        {
            Search(String.Format("! {0}", term));
        }

        public DuckDuckGoSearchPage Search(string term)
        {
            Driver.FindElement(_duckDuckGoSearchPageSelectors.Term).SendKeys(term);
            Driver.FindElement(_duckDuckGoSearchPageSelectors.Search).Click();
            return new DuckDuckGoSearchPage(Driver, BaseUriString);
        }

        public bool HasSearchResults()
        {
            return Driver.FindElements(_duckDuckGoSearchPageSelectors.Results).Any();
        }

        public bool HasSuggestedSearchTerm()
        {
            return Driver.FindElement(_duckDuckGoSearchPageSelectors.DidYouMean).Displayed;
        }
    }
}