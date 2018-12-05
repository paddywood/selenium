using System.Threading;
using Xunit;
using Xunit.Abstractions;
namespace Selenium
{
    public class CreateApplicationTests : SeleniumTest
    { 
        public CreateApplicationTests(ITestOutputHelper helper) : base(helper)
        {
        }

        [Fact]
        //[Theory]
        //[InlineData("Chrome")]
        //[InlineData("Edge")]
        public void Create_a_standard_approved_application()
        {
            WebDriver.Url = "http://localhost:4001/";

            If
                .An_application_has_been_started()
                .The_business_details_have_been_entered()
                .The_offer_details_have_been_entered()
                .The_credit_check_details_have_been_entered();

            Thread.Sleep(5000);
            //Assert.True(WebDriver.FindElementById("reerer").Enabled);
        }
    }
}