using System;
using OpenQA.Selenium;
namespace Selenium
{
    public class ApplicationStarted : Scenario
    {
        public ApplicationStarted(Application app, IWebDriver webDriver) : base(app, webDriver)
        {

        }

        public BusinessDetailsEntered The_business_details_have_been_entered(Action<BusinessDetails> command = null)
        {
            var businessDetails = CommandFactory.BusinessDetails();

            command?.Invoke(businessDetails);

            Application.BusinessDetails = businessDetails;

            /*
            if (businessDetails.BusinessType == BusinessType.LimitedCompany)
                WebDriver.FindElementById("BusinessTypeLimited", 2000).Click();
            else if (businessDetails.BusinessType == BusinessType.SoleTrader)
                WebDriver.FindElementById("BusinessTypeSltr").Click();
            else
                WebDriver.FindElementById("BusinessTypeTrust").Click();

            WebDriver.FindElementById("BusinessName")
                .SendKeys(businessDetails.BusinessName);
            */
            return new BusinessDetailsEntered(Application, WebDriver);
        }
    }
}