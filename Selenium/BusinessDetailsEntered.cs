using System;
using System.Threading;
using OpenQA.Selenium;

namespace Selenium
{
    public class BusinessDetailsEntered : Scenario
    {
        public BusinessDetailsEntered(Application application, IWebDriver webDriver) : base(application, webDriver)
        {
        }

        public OfferDetailsEntered The_offer_details_have_been_entered(Action<OfferDetails> command = null)
        {
            Application.OfferDetails = CommandFactory.OfferDetails();

            command?.Invoke(Application.OfferDetails);

            WebDriver.FindElementByCssSelector("#promo-code > div > div:nth-child(3) > div > button", sleepyTime: 1000).Click();

            WebDriver.FindElementByName("NoPointTypeButton", sleepyTime: 1000).Click();

            WebDriver.FindElementByCssSelector("#loyalty > div.flex.no-grow > div > div > button").Click();

            return new OfferDetailsEntered(Application, WebDriver);
        }
    }
}
