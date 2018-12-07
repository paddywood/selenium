using System;
using OpenQA.Selenium;

namespace Selenium
{
    public class CreditCheckDetailsEntered : Scenario
    {
        public CreditCheckDetailsEntered(Application application, IWebDriver webDriver) : base(application, webDriver)
        {
        }

        public ApplicationSubmitted The_final_details_have_been_entered(Action<FinalDetails> setupCommand = null)
        {
            Application.FinalDetails = CommandFactory.FinalDetails();

            setupCommand?.Invoke(Application.FinalDetails);

            WebDriver.FindElementByCssSelector("#delivery-address > div > div > div.flex.no-grow > div > div > button", sleepyTime: 500).Click();

            WebDriver.FindElementByName("ContactNumber").SendKeys(Application.FinalDetails.ContactNumber);

            WebDriver.FindElementByCssSelector("#contact-number > div > div > div.flex.no-grow > div > div > button", sleepyTime: 200).Click();

            // invoice email next button
            WebDriver.FindElementByCssSelector("#invoice-email > div > div > div.flex.no-grow > div > div > button", sleepyTime: 500).Click();

            // invoice date
            WebDriver.FindElementByCssSelector("#invoice-date > div > div.layout.justify-center > div > div > div:nth-child(1)", sleepyTime: 500).Click();

            // fee button
            WebDriver.FindElementByCssSelector("#payment-plan > div > div > div:nth-child(2) > div > div:nth-child(1) > div > button", sleepyTime: 500).Click();


            WebDriver.FindElementByName("BankName", sleepyTime: 500).Click();
            WebDriver.FindElementByLinkText("Other").Click();
            WebDriver.FindElementByName("BankAccountName").SendKeys(Application.FinalDetails.BankAccountName);

            WebDriver.FindElementByName("BankAccountNumber")
                .SendKeysOneByOne(Application.FinalDetails.BankAccountNumber);

            WebDriver.FindElementByName("HasBankSigningAuthority", sleepyTime:1000).Click();
            WebDriver.FindElementByCssSelector("#bank-details > div > div > div:nth-child(3) > div:nth-child(1) > div > div > div.layout.pr-5 > div > div > div.v-input__slot > div").Click();

            return new ApplicationSubmitted(Application, WebDriver);
        }
    }
}