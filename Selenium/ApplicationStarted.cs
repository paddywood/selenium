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
            var businessDetails = CommandFactory.BusinessDetails();

            command?.Invoke(businessDetails);

            Application.BusinessDetails = businessDetails;

            if (businessDetails.BusinessType == BusinessType.LimitedCompany)
                WebDriver.FindElementByName("LimitedCompanyButton").Click();
            else if (businessDetails.BusinessType == BusinessType.SoleTrader)
                WebDriver.FindElementByName("SoleTraderButton").Click();
            else if (businessDetails.BusinessType == BusinessType.Partnership)
                WebDriver.FindElementByName("PartnershipButton").Click();
            else if (businessDetails.BusinessType == BusinessType.TrustOrSociety)
                WebDriver.FindElementByName("TrustOrSocietyButton").Click();
            else
                WebDriver.FindElementByName("OtherBusinessTypeButton").Click();

            WebDriver.FindElementByName("BusinessNameSearch")
                .SendKeys(businessDetails.BusinessName);

            WebDriver.FindElementByLinkText("Enter manually").Click();

            WebDriver.FindElementByCssSelector("#business-name > div > div > div:nth-child(3) > div > div > button").Click();

            WebDriver.FindElementByName("BusinessAddressSearch")
                .SendKeys(businessDetails.BusinessAddress);

            WebDriver.FindElementByCssSelector("#app > div.v-menu__content.theme--light.menuable__content__active.v-autocomplete__content.autocomplete-content > div > div > div.no-data-tile > div > p > a").Click();

            WebDriver.FindElementByCssSelector("#physical-address > div > div > div:nth-child(3) > div > div > button").Click();

            //WebDriver.FindElementByName("MonthlyFuelAmount").Clear();
            //WebDriver.FindElementByName("MonthlyFuelAmount").SendKeys(businessDetails.MonthlySpend.GetValueOrDefault(100).ToString());

            WebDriver.FindElementByCssSelector("#fuel-amount > div.mobile-full-page-wrapper > div > div > div > div.layout.justify-center > div > button", sleepyTime: 2000).Click();

            return new BusinessDetailsEntered(Application, WebDriver);
        }
    }
}