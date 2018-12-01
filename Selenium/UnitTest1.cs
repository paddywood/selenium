using Xunit;
namespace Selenium
{
    public class UnitTest1
    { 
        [Theory]
        [InlineData("Chrome")]
        [InlineData("IE")]
        public void TestMethod1(string driver)
        {            
            var scenario = new ApplicationStarted(driver);
            scenario.WebDriver.Url = "https://stuff.co.nz";

            scenario
                .An_application_has_been_started()
                .The_business_details_have_been_entered(b => b.BusinessType = BusinessType.SoleTrader);
        }
    }
}