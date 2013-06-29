using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common;
using ZG.Common.DTO;

namespace ZG.Domain.Concrete
{
    public class CheckoutDetails
    {
        public ShippingDetails ShippingDetails { get; set; }
        public PaymentInformation PaymentInformation { get; set; }

        public CheckoutDetails()
        {
            ShippingDetails = new ShippingDetails();
            PaymentInformation = new PaymentInformation();
        }

        public bool IsShippingDetailsAvailable()
        {
            return !string.IsNullOrWhiteSpace(ShippingDetails.ShippingAddress.FullName);
        }

        public bool IsBillingAddressAvailable()
        {
            return !string.IsNullOrWhiteSpace(PaymentInformation.BillingAdress.FullName);
        }

        public bool IsBillingAddressSameAsShippingAddress()
        {
            return ShippingDetails.ShippingAddress.FullName.SameAs(PaymentInformation.BillingAdress.FullName)
                   && ShippingDetails.ShippingAddress.Address1.SameAs(PaymentInformation.BillingAdress.Address1)
                   && ShippingDetails.ShippingAddress.Address2.SameAs(PaymentInformation.BillingAdress.Address2)
                   && ShippingDetails.ShippingAddress.City.SameAs(PaymentInformation.BillingAdress.City)
                   && ShippingDetails.ShippingAddress.StateId == PaymentInformation.BillingAdress.StateId
                   && ShippingDetails.ShippingAddress.Province.SameAs(PaymentInformation.BillingAdress.Province)
                   && ShippingDetails.ShippingAddress.CountryId == PaymentInformation.BillingAdress.CountryId
                   && ShippingDetails.ShippingAddress.Zip.SameAs(PaymentInformation.BillingAdress.Zip);
        }
    }
}
