using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;

namespace FixieExample
{
    public class DriverFactory
    {
        private static DriverFactory _current;

        public static DriverFactory Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new DriverFactory();
                }
                return _current;
            }
        }

        private DriverFactory()
        {
        }

        public IWebDriver Create(IConfigurationProvider configuration)
        {
            IWebDriver driver;
            switch (configuration.Browser)
            {
                case "ie":
                    driver = new InternetExplorerDriver();
                    break;
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver(new FirefoxProfile());
                    break;
                case "phantomjs":
                    var phantomJsDriverService = PhantomJSDriverService.CreateDefaultService();
                    phantomJsDriverService.AddArgument("--ignore-ssl-errors=true");
                    driver = new PhantomJSDriver(phantomJsDriverService);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            driver.Manage().Timeouts().ImplicitlyWait(configuration.Timeout);

            return driver;
        }
    }
}