using System;
using System.Threading;
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
            Application.BusinessDetails = CommandFactory.BusinessDetails();

            command?.Invoke(Application.BusinessDetails);

            Application.BusinessDetails = Application.BusinessDetails;

            WebDriver.FindElementByName(Application.BusinessDetails.BusinessType.ToString()).Click();

            WebDriver.FindElementByName("BusinessNameSearch")
                .SendKeys(Application.BusinessDetails.BusinessName);

            WebDriver.FindElementByLinkText("Enter manually").Click();

            WebDriver.FindElementByCssSelector("#business-name > div > div > div:nth-child(3) > div > div > button").Click();

            WebDriver.FindElementByName("BusinessAddressSearch")
                .SendKeys(Application.BusinessDetails.BusinessAddress);

            WebDriver.FindElementByCssSelector("#app > div.v-menu__content.theme--light.menuable__content__active.v-autocomplete__content.autocomplete-content > div > div > div.no-data-tile > div > p > a").Click();

            WebDriver.FindElementByCssSelector("#physical-address > div > div > div:nth-child(3) > div > div > button").Click();

            //WebDriver.FindElementByName("MonthlyFuelAmount").Clear();
            //WebDriver.FindElementByName("MonthlyFuelAmount").SendKeys(businessDetails.MonthlySpend.GetValueOrDefault(100).ToString());

            WebDriver.FindElementByCssSelector("#fuel-amount > div.mobile-full-page-wrapper > div > div > div > div.layout.justify-center > div > button", sleepyTime: 1000).Click();

            return new BusinessDetailsEntered(Application, WebDriver);
        }
    }
}