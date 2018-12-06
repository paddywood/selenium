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

            WebDriver.FindElementByName("ApplicantName").SendKeys(Application.ApplicantName);
            WebDriver.FindElementByName("ApplicantEmail").SendKeys(Application.ApplicantEmail);

            if (Application.ApplicantAcceptedUpdates)
                WebDriver.FindElementByName("ApplicantAcceptedUpdates").Click();

            WebDriver.FindElementByName("GetStartedButton").Click();

            WebDriver.FindElementByCssSelector("#app > div > main > div > div > div > div:nth-child(2) > div > div > div > div > div > div:nth-child(5) > div > button").Click();

            return new ApplicationStarted(Application, WebDriver);

        }

        public void Save_and_share()
        {
            WebDriver.FindElementByCssSelector("#app > div.application--wrap > header > button", sleepyTime:500).Click();

            WebDriver.FindElementByCssSelector("#app > div.v-dialog__content.v-dialog__content--active > div > div > div.dialog-content > div > div > div > div.copy-text.copy-text > span:nth-child(2)").Click();

            //WebDriver.FindElementByCssSelector("#app > div.v-dialog__content.v-dialog__content--active > div > div > footer > button:nth-child(2)").Click();
        }
    }
}