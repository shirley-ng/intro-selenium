using FluentPageObjectExample.PageObjects;
using NUnit.Framework;

namespace FluentPageObjectExample.Tests
{
    [TestFixture]
    public class When_searching : WebDriverTestFixture
    {
        [Test]
        public void Should_return_result_for_valid_term()
        {
            Driver.Navigate().GoToUrl(Configuration.Uri);

            bool result = new DuckDuckGoSearchPage(Driver, Configuration.Uri)
                .NavigateTo<DuckDuckGoSearchPage>()
                .Search("Giraffes")
                .HasSearchResults();

            Assert.That(result, "Expected to find giraffe links but did not");
        }

        [Test]
        public void Should_not_return_suggested_result_for_valid_term()
        {
            Driver.Navigate().GoToUrl(Configuration.Uri);

            bool result = new DuckDuckGoSearchPage(Driver, Configuration.Uri)
                .NavigateTo<DuckDuckGoSearchPage>()
                .Search("Giraffes")
                .HasSuggestedSearchTerm();

            Assert.That(result, Is.False, "Expected to not find suggested giraffe text but did");
        }

        [Test]
        public void Should_return_suggested_result_for_invalid_term()
        {
            Driver.Navigate().GoToUrl(Configuration.Uri);

            bool result = new DuckDuckGoSearchPage(Driver, Configuration.Uri)
                .NavigateTo<DuckDuckGoSearchPage>()
                .Search("Giraffeslaugh")
                .HasSuggestedSearchTerm();

            Assert.That(result, "Expected to find suggested giraffe text but did not");
        }
    }
}