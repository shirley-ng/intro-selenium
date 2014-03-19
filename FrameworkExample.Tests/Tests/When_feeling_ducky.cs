using System;
using FrameworkExample.PageObjects;
using NUnit.Framework;

namespace FrameworkExample.Tests
{
    [TestFixture]
    public class When_feeling_ducky : WebDriverTestFixture
    {
        [Test]
        public void Should_navigate_directly_to_Google()
        {
            var searchPage = new DuckDuckGoSearchPage(Driver, Configuration.Uri);
            searchPage.NavigateTo();

            searchPage.FeelingDucky("Google");

            Assert.That(Driver.Title, Is.EqualTo("Google"));
        }

        [Test]
        public void Should_navigate_directly_to_Bing()
        {
            var searchPage = new DuckDuckGoSearchPage(Driver, Configuration.Uri);
            searchPage.NavigateTo();

            searchPage.FeelingDucky("Bing");

            Assert.That(Driver.Title, Is.EqualTo("Bing"));
        }

        [Test]
        public void Should_navigate_directly_to_Yahoo()
        {
            var searchPage = new DuckDuckGoSearchPage(Driver, Configuration.Uri);
            searchPage.NavigateTo();

            searchPage.FeelingDucky("Yahoo");

            Assert.That(Driver.Title, Is.EqualTo("Yahoo"));
        }

        [Test]
        [Explicit]
        public void Example_clean_up_on_error()
        {
            throw new Exception("WebDriverTestFixture will clean up this browser window");
        }
    }
}