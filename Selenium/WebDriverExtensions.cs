using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElementById(this IWebDriver webDriver, string id, int? timeout = null, int? sleepyTime = null)
        {
            return FindElement(d => d.FindElement(By.Id(id)), webDriver, timeout, sleepyTime);
        }

        public static IWebElement FindElementByName(this IWebDriver webDriver, string name, int? timeout = null, int? sleepyTime = null)
        {
            return FindElement(d => d.FindElement(By.Name(name)), webDriver, timeout, sleepyTime);
        }

        public static IWebElement FindElementByCssSelector(this IWebDriver webDriver, string cssSelector, int? timeout = null, int? sleepyTime = null)
        {
            return FindElement(d => d.FindElement(By.CssSelector(cssSelector)), webDriver, timeout, sleepyTime);
        }

        public static IWebElement FindElementByClassName(this IWebDriver webDriver, string className, int? timeout = null, int? sleepyTime = null)
        {
            return FindElement(d => d.FindElement(By.ClassName(className)), webDriver, timeout, sleepyTime);
        }

        public static IWebElement FindElementByLinkText(this IWebDriver webDriver, string linkText, int? timeout = null, int? sleepyTime = null)
        {
            return FindElement(d => d.FindElement(By.LinkText(linkText)), webDriver, timeout, sleepyTime);
        }

        private static IWebElement FindElement(Func<IWebDriver, IWebElement> eleFunc, IWebDriver webDriver, int? timeout = null, int? sleepyTime = null)
        {
            Thread.Sleep(sleepyTime.GetValueOrDefault());

            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 0, 0, timeout.GetValueOrDefault(5000)));

            var element = wait.Until(eleFunc);

            return element;
        }
    }
}