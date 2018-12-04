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

        public static IWebElement FindElementByName(this IWebDriver webDriver, string name, int timeout = 3000)
        {
            return FindElement(d => d.FindElement(By.Name(name)), webDriver, timeout);
        }

        public static IWebElement FindElementByCssSelector(this IWebDriver webDriver, string cssSelector, int timeout = 3000)
        {
            return FindElement(d => d.FindElement(By.CssSelector(cssSelector)), webDriver, timeout);
        }

        public static IWebElement FindElementByClassName(this IWebDriver webDriver, string className, int timeout = 3000)
        {
            return FindElement(d => d.FindElement(By.ClassName(className)), webDriver, timeout);
        }

        private static IWebElement FindElement(Func<IWebDriver, IWebElement> eleFunc, IWebDriver webDriver, int timeout)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 0, 0, timeout));

            var element = wait.Until(eleFunc);

            return element;
        }
    }
}