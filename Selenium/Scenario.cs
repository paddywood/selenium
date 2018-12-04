using OpenQA.Selenium;
using System;
namespace Selenium
{
    public class Scenario
    {
        public IWebDriver WebDriver { get; }
        public Application Application { get; }

        public Scenario(Application application, IWebDriver webDriver)
        {
            WebDriver = webDriver;
            Application = application;
        }

        public ApplicationStarted An_application_has_been_started(Action<Application> setupCommand = null)
        {
            setupCommand?.Invoke(Application);

            WebDriver.FindElementById("Name").SendKeys(Application.ApplicantName);
            WebDriver.FindElementById("Email").SendKeys(Application.ApplicantEmail);

            if (Application.WouldLikeOffers)
                WebDriver.FindElementById("checkbox").Click();

            WebDriver.FindElementById("button").Click();

            WebDriver.FindElementById("letsdothis").Click();

            return new ApplicationStarted(Application, WebDriver);

        }
    }
}