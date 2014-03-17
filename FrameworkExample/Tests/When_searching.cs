using System;
using FrameworkExample.PageObjects;
using NUnit.Framework;

namespace FrameworkExample.Tests
{
    [TestFixture]
    public class When_searching : SharedWebDriverTestFixture
    {
        private DuckDuckGoSearchPage _searchPage;

        protected override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();

            _searchPage = new DuckDuckGoSearchPage(Driver, Configuration.Uri);
        }

        [Test]
        public void Should_return_result_for_valid_term()
        {
            _searchPage.NavigateTo();

            _searchPage.Search("Giraffes");

            Assert.That(_searchPage.HasSearchResults(), "Expected to find giraffe links but did not");
        }

        [Test]
        public void Should_not_return_suggested_result_for_valid_term()
        {
            _searchPage.NavigateTo();

            _searchPage.Search("Giraffes");

            Assert.That(_searchPage.HasSuggestedSearchTerm(), Is.False, "Expected to not find suggested giraffe text but did");
        }

        [Test]
        public void Should_return_suggested_result_for_invalid_term()
        {
            _searchPage.NavigateTo();

            _searchPage.Search("Giraffeslaugh");

            Assert.That(_searchPage.HasSuggestedSearchTerm(), "Expected to find suggested giraffe text but did not");
        }

        [Test]
        [Explicit]
        public void Example_clean_up_on_error()
        {
            throw new Exception("SharedWebDriverTestFixture will clean up this browser window");
        }

        [Test]
        [Explicit]
        public void Example_not_on_correct_page()
        {
            Driver.Navigate().GoToUrl("https://duckduckgo.com/goodies/");
            _searchPage.Search("Giraffes");
        }
    }
}