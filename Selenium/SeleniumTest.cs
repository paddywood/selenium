using Xunit.Abstractions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Reflection;
namespace Selenium
{
    public abstract class SeleniumTest : IDisposable
    {
        public Scenario If { get; }
        public IWebDriver WebDriver { get; set; }

        public SeleniumTest(ITestOutputHelper helper)
        {
            var type = helper.GetType();
            var testMember = type.GetField("test", BindingFlags.Instance | BindingFlags.NonPublic);
            var test = (ITest)testMember.GetValue(helper);
            var browser = test.TestCase.TestMethodArguments[0].ToString();
            //var driverService = EdgeDriverService.CreateDefaultService(@".");

            if (browser == "Chrome")
                WebDriver = new ChromeDriver(".");
            else
                WebDriver = new EdgeDriver(".");

            If = new Scenario(CommandFactory.StandardLimitedCompanyApplication(), WebDriver);

            WebDriver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            if (WebDriver != null)
            {
                WebDriver.Close();
                WebDriver.Dispose();
                WebDriver = null;
            }
        }
    }
}