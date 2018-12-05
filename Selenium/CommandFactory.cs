namespace Selenium
{
    public static class CommandFactory
    {
        public static Application ValidApplication()
        {
            return new Application
            {
                ApplicantEmail = "paddy@paddy.com",
                ApplicantName = "paddy wood",
                ApplicantAcceptedUpdates = true
            };
        }

        public static BusinessDetails BusinessDetails()
        {
            return new BusinessDetails
            {
                BusinessName = "Paddy Business",
                BusinessAddress = "Business Address",
                BusinessType = BusinessType.LimitedCompany,
                MonthlySpend = 10000
            };
        }

        public static OfferDetails OfferDetails()
        {
            return new OfferDetails
            {
                MonthlySpend = 10000
            };
        }

        public static CreditCheckDetails CreditCheckDetails()
        {
            return new CreditCheckDetails {CompanyDirector = true, LegalName = "Paddy Wood"};
        }
    }
}