using OpenQA.Selenium;

namespace FluentPageObjectExample.PageObjects
{
    public class DuckDuckGoSearchPageSelectors
    {
        public readonly By Term = By.Id("search_form_input_homepage");
        public readonly By Search = By.Id("search_button_homepage");
        public readonly By Results = By.ClassName("results_links_deep");
        public readonly By DidYouMean = By.Id("did_you_means");
    }
}