using NUnit.Framework;
using OpenQA.Selenium;

namespace FrameworkExample
{
    public abstract class SharedWebDriverTestFixture
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IWebDriver _driver;

        protected IConfigurationProvider Configuration
        {
            get { return _configuration; }
        }

        protected IWebDriver Driver
        {
            get { return _driver; }
        }

        protected SharedWebDriverTestFixture()
        {
            _configuration = ConfigurationProvider.Current;
            _driver = DriverFactory.Current.Create(_configuration);
        }

        [TestFixtureSetUp]
        public void TestFixtureSetUpBase()
        {
            try
            {
                TestFixtureSetUp();
            }
            catch
            {
                TestFixtureTearDownBase();

                throw;
            }
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDownBase()
        {
            try
            {
                TestFixtureTearDown();
            }
            finally
            {
                if (_driver != null)
                {
                    _driver.Quit();
                }
            }
        }

        protected virtual void TestFixtureSetUp()
        {
        }

        protected virtual void TestFixtureTearDown()
        {
        }
    }
}