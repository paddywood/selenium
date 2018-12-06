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
                BusinessType = BusinessType.LimitedCompanyButton,
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

        public static FinalDetails FinalDetails()
        {
            return new FinalDetails
            {
                ContactNumber = "02203488378",
                BankAccountName = "Paddy Bank",
                BankAccountNumber = "3128000000000000"
            };
        }
        public static CreditCheckDetails CreditCheckDetails()
        {
            return new CreditCheckDetails
            {
                CompanyDirector = true,
                LegalName = "___Approve",
                Dob = "15041966",
                LicenseVersion = "111",
                LicenceNumber = "11111111"
            };
        }
    }
}