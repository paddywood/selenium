namespace Selenium
{
    public static class CommandFactory
    {
        public static Application StandardLimitedCompanyApplication()
        {
            return new Application
            {
                ApplicantEmail = "paddy@paddy.com",
                ApplicantName = "paddy wood",
                WouldLikeOffers = true,
                BusinessDetails = new BusinessDetails
                {
                    BusinessName = "Paddy Business",
                    BusinessAddress = "Bussiness Address",
                    BusinessType = BusinessType.LimitedCompany
                },
                OfferDetails = new OfferDetails()
            };
        }
    }
}
