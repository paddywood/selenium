using System;
using OpenQA.Selenium;
namespace Selenium
{
    public class ApplicationStarted
    {
        private readonly Application _application;
        private IWebDriver WebDriver { get; }

        public ApplicationStarted(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            _application = CommandFactory.StandardLimitedCompanyApplication();
        }

        public BusinessDetailsEntered An_application_has_been_started(Action<Application> command = null)
        {
            command?.Invoke(_application);

            if (_application.BusinessDetails.BusinessType == BusinessType.LimitedCompany)
                WebDriver.FindElementById("BusinessTypeLimited", 2000).Click();
            else if (_application.BusinessDetails.BusinessType == BusinessType.SoleTrader)
                WebDriver.FindElementById("BusinessTypeSltr").Click();
            else
                WebDriver.FindElementById("BusinessTypeTrust").Click();

            WebDriver.FindElementById("BusinessName")
                .SendKeys(_application.BusinessDetails.BusinessName);

            return new BusinessDetailsEntered(_application, WebDriver);
        }
    }
}