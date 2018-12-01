using System;

namespace Selenium
{
    public class BusinessDetailsEntered
    {
        private Application _application;

        public BusinessDetailsEntered(Application application)
        {
            _application = application;
        }

        public OfferDetailsEntered The_business_details_have_been_entered(Action<BusinessDetails> command = null)
        {
            command?.Invoke(_application.BusinessDetails);

            return new OfferDetailsEntered();
        }
    }
}
