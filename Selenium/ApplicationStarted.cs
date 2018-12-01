using System;
using OpenQA.Selenium;
namespace Selenium
{
    public class ApplicationStarted
    {
        private readonly Application _application;
        private UiFactory _uiFactory;
        public IWebDriver WebDriver { get; }

        public ApplicationStarted(string driver)
        {
            _uiFactory = new UiFactory(driver);

            WebDriver = _uiFactory.WebDriver;

            _application = CommandFactory.StandardLimitedCompanyApplication();
        }

        public BusinessDetailsEntered An_application_has_been_started(Action<Application> command = null)
        {
            command?.Invoke(_application);

            if (_application.BusinessDetails.BusinessType == BusinessType.LimitedCompany)
                _uiFactory.FindElementById("BusinessTypeLimited", 2000).Click();
            else if (_application.BusinessDetails.BusinessType == BusinessType.SoleTrader)
                _uiFactory.FindElementById("BusinessTypeSltr").Click();
            else
                _uiFactory.FindElementById("BusinessTypeTrust").Click();

            _uiFactory.FindElementById("BusinessName")
                .SendKeys(_application.BusinessDetails.BusinessName);

            return new BusinessDetailsEntered(_application);
        }
    }
}