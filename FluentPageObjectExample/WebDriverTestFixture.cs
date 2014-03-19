using NUnit.Framework;
using OpenQA.Selenium;

namespace FluentPageObjectExample
{
    public abstract class WebDriverTestFixture
    {
        private readonly IConfigurationProvider _configuration;
        private IWebDriver _driver;

        protected IConfigurationProvider Configuration
        {
            get { return _configuration; }
        }

        protected IWebDriver Driver
        {
            get { return _driver; }
        }

        protected WebDriverTestFixture()
        {
            _configuration = ConfigurationProvider.Current;
            
        }

        [SetUp]
        public void TestSetUpBase()
        {
            try
            {
                _driver = DriverFactory.Current.Create(_configuration);

                TestSetUp();
            }
            catch
            {
                TestTearDownBase();

                throw;
            }
        }

        [TearDown]
        public void TestTearDownBase()
        {
            try
            {
                TestTearDown();
            }
            finally
            {
                if (_driver != null)
                {
                    _driver.Quit();
                }
            }
        }

        protected virtual void TestSetUp()
        {
        }

        protected virtual void TestTearDown()
        {
        }
    }
}