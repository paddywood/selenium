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
            WebDriver.Url = "https://stuff.co.nz";

            If
                .An_application_has_been_started()
                .The_business_details_have_been_entered()
                .The_offer_details_have_been_entered();

            //Assert.True(WebDriver.FindElementById("reerer").Enabled);
        }
    }
}