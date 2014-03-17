using System;
using OpenQA.Selenium;

namespace FixieExample
{
    public abstract class WebDriverTestFixture : IDisposable
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

        protected WebDriverTestFixture()
        {
            _configuration = ConfigurationProvider.Current;
            _driver = DriverFactory.Current.Create(_configuration);
        }

        public void Dispose()
        {
            if (_driver != null)
            {
                _driver.Quit();
            }
        }
    }
}