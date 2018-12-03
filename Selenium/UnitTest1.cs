using Xunit;
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

    public class UnitTest1 : SeleniumTest
    { 
        public UnitTest1(ITestOutputHelper helper) : base(helper)
        {

        }
        [Theory]
        [InlineData("Chrome")]
        [InlineData("Edge")]
        public void TestMethod1(string browser)
        {            
            var scenario = new ApplicationStarted(WebDriver);

            WebDriver.Url = "https://stuff.co.nz";

            //scenario
            //    .An_application_has_been_started()
            //    .The_business_details_have_been_entered(b => b.BusinessType = BusinessType.SoleTrader);

        }
    }
}