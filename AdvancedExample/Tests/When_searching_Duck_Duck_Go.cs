using AdvancedExample.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;

namespace AdvancedExample.Tests
{
    [TestFixture]
    public class When_searching_Duck_Duck_Go
    {
        [Test]
        public void Should_return_result_for_valid_term()
        {
            using (var driver = new FirefoxDriver())
            {
                var searchPage = new DuckDuckGoSearchPage(driver);
                searchPage.NavigateTo();

                searchPage.Search("Giraffes");

                Assert.That(searchPage.HasSearchResults(), "Expected to find giraffe links but did not");
            }
        }

        [Test]
        public void Should_not_return_suggested_result_for_valid_term()
        {
            using (var driver = new FirefoxDriver())
            {
                var searchPage = new DuckDuckGoSearchPage(driver);
                searchPage.NavigateTo();

                searchPage.Search("Giraffes");

                Assert.That(searchPage.HasSuggestedSearchTerm(), Is.False, "Expected to not find suggested giraffe text but did");
            }
        }

        [Test]
        public void Should_return_suggested_result_for_invalid_term()
        {
            using (var driver = new FirefoxDriver())
            {
                var searchPage = new DuckDuckGoSearchPage(driver);
                searchPage.NavigateTo();

                searchPage.Search("Giraffeslaugh");

                Assert.That(searchPage.HasSuggestedSearchTerm(), "Expected to find suggested giraffe text but did not");
            }
        }
    }
}