using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;

namespace BasicExample
{
    [TestFixture]
    public class When_searching_Duck_Duck_Go
    {
        [Test]
        public void Should_return_result_for_valid_term()
        {
            using (var driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("https://duckduckgo.com/");
                driver.FindElement(By.Name("q")).SendKeys("Giraffes");
                driver.FindElement(By.Id("search_button_homepage")).Click();

                Assert.That(driver.FindElements(By.ClassName("results_links_deep")).Any(), 
                    "Expected to find giraffe links but did not");
            }
        }

        [Test]
        public void Should_not_return_suggested_result_for_valid_term()
        {
            using (var driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("https://duckduckgo.com/");
                driver.FindElement(By.Name("q")).SendKeys("Giraffes");
                driver.FindElement(By.Id("search_button_homepage")).Click();

                Assert.That(driver.FindElement(By.Id("did_you_means")).Displayed, Is.False, 
                    "Expected to not find suggested giraffe text but did");
            }
        }

        [Test]
        public void Should_return_suggested_result_for_invalid_term()
        {
            using (var driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("https://duckduckgo.com/");
                driver.FindElement(By.Name("q")).SendKeys("Giraffeslaugh");
                driver.FindElement(By.Id("search_button_homepage")).Click();

                Assert.That(driver.FindElement(By.Id("did_you_means")).Displayed, 
                    "Expected to find suggested giraffe text but did not");
            }
        }

        [Test]
        [Explicit]
        public void Example_driver_types()
        {
            // FirefoxDriver, ChromeDriver, PhantomJSDriver, InternetExplorerDriver
            // FirefoxDriver ships with Selenium but the others need to be downloaded and added manually. 
            // Set Build Action = Content and Copy to Output Directory = Copy if newer on the .exe
            using (var driver = new PhantomJSDriver())
            {
                driver.Navigate().GoToUrl("https://duckduckgo.com/");
                driver.FindElement(By.Name("q")).SendKeys("Giraffes");
                driver.FindElement(By.Id("search_button_homepage")).Click();

                Assert.That(driver.FindElements(By.ClassName("results_links_deep")).Any(), 
                    "Expected to find giraffe links but did not");
            }
        }

        [Test]
        [Explicit]
        public void Example_web_elements()
        {
            using (var driver = new FirefoxDriver())
            {
                // Properties
                driver.Navigate().GoToUrl("https://duckduckgo.com/");
                IWebElement logoDivElement1 = driver.FindElement(By.Id("logo_homepage"));
                Console.WriteLine("Text: " + logoDivElement1.Text);
                Console.WriteLine("Displayed: " + logoDivElement1.Displayed);

                /*// Click it
                driver.Navigate().GoToUrl("https://duckduckgo.com/");
                IWebElement logoDivElement2 = driver.FindElement(By.Id("logo_homepage"));
                logoDivElement2.Click();

                // Send keys to it
                driver.Navigate().GoToUrl("https://duckduckgo.com/");
                IWebElement logoDivElement3 = driver.FindElement(By.Id("logo_homepage"));
                logoDivElement3.SendKeys(Keys.Enter);*/
            }
        }

        [Test]
        [Explicit]
        public void Example_stale_element_exception()
        {
            // You should not hold onto a reference to an IWebElement unless you are sure the page will not be posted to 
            // while you are interacting with the page. You'll get a StaleElementException when attempting to interact with it.
            // Here the example is forced with a refresh but you'll normally run into this scenario 
            // while interacting with elements on the page that cause a postback.
            using (var driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("https://duckduckgo.com/");
                IWebElement searchTermInputElement = driver.FindElement(By.Name("q"));

                driver.Navigate().Refresh();
                searchTermInputElement.SendKeys("Giraffes");
            }
        }

        [Test]
        [Explicit]
        public void Example_selector_types()
        {
            // Id > Name > CSS > XPath > Text
            using (var driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("https://duckduckgo.com/");

                driver.FindElement(By.Id("search_form_input_homepage")).SendKeys("Id");
                driver.FindElement(By.Name("q")).SendKeys(", Name");
                driver.FindElement(By.CssSelector("#search_form_input_homepage")).SendKeys(", CSS Selector");
                driver.FindElement(By.XPath("//form[@name='x']//input[@type='text' and @name='q']")).SendKeys(", XPath");
            }
        }

        [Test]
        [Explicit]
        public void Example_wait()
        {
            // With client side script you will sometimes need to add waits. The Driver will wait for 
            // page load complete before interacting with the page (most cases). The Driver does not know 
            // to wait for JS animations or AJAX calls so you need to handle these cases yourself using
            // WebDriverWait. Do not System.Threading.Thread.Sleep() the tests. You will only make them slow!
            using (var driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("https://duckduckgo.com/");

                driver.FindElement(By.Id("search_dropdown_homepage")).Click();
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(d => d.FindElement(By.Id("newbang")).Displayed);

                driver.FindElement(By.LinkText("I'm feeling ducky")).Click();
            }
        }
    }
}