using System;
using OpenQA.Selenium;

namespace Selenium
{
    public class OfferDetailsEntered : Scenario
    {
        public OfferDetailsEntered(Application application, IWebDriver webDriver) : base(application, webDriver)
        {
        }

        public CreditCheckDetailsEntered The_credit_check_details_have_been_entered(
            Action<CreditCheckDetails> setupCommand = null)
        {
            Application.CreditCheckDetails = CommandFactory.CreditCheckDetails();

            setupCommand?.Invoke(Application.CreditCheckDetails);

            if (Application.CreditCheckDetails.CompanyDirector)
                WebDriver.FindElementByName("IsDirectorButton", sleepyTime: 500).Click();
            else
                WebDriver.FindElementByName("IsNotDirectorButton", sleepyTime: 500).Click();

            WebDriver.FindElementByName("LegalName").SendKeys(Application.CreditCheckDetails.LegalName);

            WebDriver.FindElementByCssSelector("#legal-name > div > div > div.flex.no-grow > div > div > button", sleepyTime: 500).Click();

            WebDriver.FindElementByName(Application.CreditCheckDetails.Gender.ToString(), sleepyTime: 500).Click();

            foreach (var c in Application.CreditCheckDetails.Dob)
            {
                WebDriver.FindElementByName("DateOfBirth").SendKeys(c.ToString());
            }

            WebDriver.FindElementByCssSelector("#dob > div > div > div.flex.no-grow > div > div > button", sleepyTime:500).Click();

            WebDriver.FindElementByName("LicenceNumber").SendKeys(Application.CreditCheckDetails.LicenceNumber);

            WebDriver.FindElementByName("LicenseVersion").SendKeys(Application.CreditCheckDetails.LicenseVersion);

            WebDriver.FindElementByCssSelector("#drivers-license > div > div > div.flex.no-grow.mt-5 > div > div > button", sleepyTime: 200).Click();

            WebDriver.FindElementByName("AgreeToCreditCheck", sleepyTime: 300).Click();

            WebDriver.FindElementByCssSelector("#residential-address > div > div > div.flex.mt-5 > div:nth-child(2) > div > button", sleepyTime: 200).Click();

            return new CreditCheckDetailsEntered(Application, WebDriver);
        }
    }
}