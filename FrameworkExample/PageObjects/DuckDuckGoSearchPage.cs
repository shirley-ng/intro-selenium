using System;
using System.Linq;
using OpenQA.Selenium;

namespace FrameworkExample.PageObjects
{
    public class DuckDuckGoSearchPage : PageObject
    {
        private readonly DuckDuckGoSearchPageSelectors _duckDuckGoSearchPageSelectors;

        protected override string AbsolutePath
        {
            get { return "/"; }
        }

        protected override string Query
        {
            get { return "Test=Foo"; }
        }

        public DuckDuckGoSearchPage(IWebDriver driver, string baseUriString)
            : base(driver, baseUriString)
        {
            _duckDuckGoSearchPageSelectors = new DuckDuckGoSearchPageSelectors();
        }

        public void FeelingDucky(string term)
        {
            Search(String.Format("! {0}", term));
        }

        public void Search(string term)
        {
            ValidatePath();
            Driver.FindElement(_duckDuckGoSearchPageSelectors.Term).SendKeys(term);
            Driver.FindElement(_duckDuckGoSearchPageSelectors.Search).Click();
        }

        public bool HasSearchResults()
        {
            ValidatePath();
            return Driver.FindElements(_duckDuckGoSearchPageSelectors.Results).Any();
        }

        public bool HasSuggestedSearchTerm()
        {
            ValidatePath();
            return Driver.FindElement(_duckDuckGoSearchPageSelectors.DidYouMean).Displayed;
        }
    }
}