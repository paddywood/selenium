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
                WouldLikeOffers = true
            };
        }

        public static BusinessDetails BusinessDetails()
        {
            return new BusinessDetails
            {
                BusinessName = "Paddy Business",
                BusinessAddress = "Bussiness Address",
                BusinessType = BusinessType.LimitedCompany
            };
        }

        public static OfferDetails OfferDetails()
        {
            return new OfferDetails
            {
                MonthlySpend = 10000
            };
        }
    }
}