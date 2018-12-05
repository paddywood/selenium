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
            var offer = CommandFactory.OfferDetails();

            command?.Invoke(offer);

            Application.OfferDetails = offer;

            WebDriver.FindElementByCssSelector("#promo-code > div > div:nth-child(3) > div > button", sleepyTime: 2000).Click();

            WebDriver.FindElementByName("NoPointTypeButton", sleepyTime: 2000).Click();

            WebDriver.FindElementByCssSelector("#loyalty > div.flex.no-grow > div > div > button").Click();



            return new OfferDetailsEntered(Application, WebDriver);
        }
    }
}
