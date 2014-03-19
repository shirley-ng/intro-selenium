using FluentPageObjectExample.PageObjects;
using NUnit.Framework;

namespace FluentPageObjectExample.Tests
{
    [TestFixture]
    public class When_feeling_ducky : WebDriverTestFixture
    {
        [Test]
        public void Should_navigate_directly_to_Google()
        {
            Driver.Navigate().GoToUrl(Configuration.Uri);

            new DuckDuckGoSearchPage(Driver, Configuration.Uri)
                .FeelingDucky("Google");

            Assert.That(Driver.Title, Is.EqualTo("Google"));
        }

        [Test]
        public void Should_navigate_directly_to_Bing()
        {
            Driver.Navigate().GoToUrl(Configuration.Uri);

            new DuckDuckGoSearchPage(Driver, Configuration.Uri)
                .FeelingDucky("Bing");

            Assert.That(Driver.Title, Is.EqualTo("Bing"));
        }

        [Test]
        public void Should_navigate_directly_to_Yahoo()
        {
            Driver.Navigate().GoToUrl(Configuration.Uri);

            new DuckDuckGoSearchPage(Driver, Configuration.Uri)
                 .FeelingDucky("Yahoo");

            Assert.That(Driver.Title, Is.EqualTo("Yahoo"));
        }
    }
}