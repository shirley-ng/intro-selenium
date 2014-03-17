using FixieExample.PageObjects;
using Should;
using System;

namespace FixieExample.Tests
{
    public class When_feeling_ducky : WebDriverTestFixture
    {
        public void Should_navigate_directly_to_Google()
        {
            var searchPage = new DuckDuckGoSearchPage(Driver, Configuration.Uri);
            searchPage.NavigateTo();

            searchPage.FeelingDucky("Google");

            Driver.Title.ShouldEqual("Google");
        }

        public void Should_navigate_directly_to_Bing()
        {
            var searchPage = new DuckDuckGoSearchPage(Driver, Configuration.Uri);
            searchPage.NavigateTo();

            searchPage.FeelingDucky("Bing");

            Driver.Title.ShouldEqual("Bing");
        }

        public void Should_navigate_directly_to_Yahoo()
        {
            var searchPage = new DuckDuckGoSearchPage(Driver, Configuration.Uri);
            searchPage.NavigateTo();

            searchPage.FeelingDucky("Yahoo");

            Driver.Title.ShouldEqual("Yahoo");
        }

        public void Example_clean_up_on_error()
        {
            throw new Exception("WebDriverTestFixture will clean up this browser window");
        }
    }
}