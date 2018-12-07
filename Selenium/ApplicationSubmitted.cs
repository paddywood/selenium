using OpenQA.Selenium;

namespace Selenium
{
    public class ApplicationSubmitted : Scenario
    {
        public ApplicationSubmitted(Application application, IWebDriver webDriver) : base(application, webDriver)
        {
        }

        public void The_application_has_been_submitted()
        {
            //WebDriver.FindElements(By.)
            WebDriver.FindElementByCssSelector(
                    "#bank-details > div > div > div:nth-child(3) > div:nth-child(2) > div > button", sleepyTime: 400)
                .Click();
        }
    }
}