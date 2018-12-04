using Xunit;
using Xunit.Abstractions;
namespace Selenium
{
    public class UnitTest1 : SeleniumTest
    { 
        public UnitTest1(ITestOutputHelper helper) : base(helper)
        {
        }

        [Theory]
        [InlineData("Chrome")]
        //[InlineData("Edge")]
        public void TestMethod1(string browser)
        {
            WebDriver.Url = "https://stuff.co.nz";

            If
                .An_application_has_been_started()
                .The_business_details_have_been_entered()
                .The_offer_details_have_been_entered();

            //Assert.True(WebDriver.FindElementById("reerer").Enabled);
        }
    }
}