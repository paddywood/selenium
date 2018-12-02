using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElementById(this IWebDriver webDriver, string id, int timeout = 3000)
        {
            return FindElement(d => d.FindElement(By.Id(id)), webDriver, timeout);
        }

        private static IWebElement FindElement(Func<IWebDriver, IWebElement> eleFunc, IWebDriver webDriver, int timeout)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(timeout));

            var element = wait.Until(eleFunc);

            return element;
        }
    }
}