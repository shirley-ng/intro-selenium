using FixieExample.PageObjects;
using Should;

namespace FixieExample.Tests
{
    public class When_searching : WebDriverTestFixture
    {
        private readonly DuckDuckGoSearchPage _searchPage;

        public When_searching()
        {
            _searchPage = new DuckDuckGoSearchPage(Driver, Configuration.Uri);
        }

        public void Should_return_result_for_valid_term()
        {
            _searchPage.NavigateTo();

            _searchPage.Search("Giraffes");

            _searchPage.HasSearchResults().ShouldBeTrue("Expected to find giraffe links but did not");
        }

        public void Should_not_return_suggested_result_for_valid_term()
        {
            _searchPage.NavigateTo();

            _searchPage.Search("Giraffes");

            _searchPage.HasSuggestedSearchTerm().ShouldBeFalse("Expected to not find suggested giraffe text but did");
        }

        public void Should_return_suggested_result_for_invalid_term()
        {
            _searchPage.NavigateTo();

            _searchPage.Search("Giraffeslaugh");

            _searchPage.HasSuggestedSearchTerm().ShouldBeTrue("Expected to find suggested giraffe text but did not");
        }
    }
}