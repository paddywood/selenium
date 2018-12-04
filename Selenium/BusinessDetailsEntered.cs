using System;
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

            return new OfferDetailsEntered();
        }
    }
}
