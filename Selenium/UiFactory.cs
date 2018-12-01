using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    public class UiFactory
    {
        public IWebDriver WebDriver { get; }
        
        public UiFactory(string webDriver)
        {
            //TODO different drivers...
            var driverService = ChromeDriverService.CreateDefaultService(@"C:\dev\Selenium\Selenium");

            WebDriver = new ChromeDriver(driverService);
        }

        private IWebElement FindElement(Func<IWebDriver, IWebElement> eleFunc, int timeout)
        {
            var wait = new WebDriverWait(WebDriver, new TimeSpan(timeout));

            var element = wait.Until(eleFunc);

            return element;
        }

        public IWebElement FindElementById(string id, int timeout = 3000)
        {
            return FindElement(d => d.FindElement(By.Id(id)), timeout);
        }
    }
}