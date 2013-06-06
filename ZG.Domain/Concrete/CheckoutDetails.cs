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

        public bool IsBillingAddressSameAsShippingAddress()
        {
            return ShippingDetails.ShippingAddress.FullName.SameAs(PaymentInformation.BillingAdress.FullName)
                   && ShippingDetails.ShippingAddress.Address1.SameAs(PaymentInformation.BillingAdress.Address1)
                   && ShippingDetails.ShippingAddress.Address2.SameAs(PaymentInformation.BillingAdress.Address2)
                   && ShippingDetails.ShippingAddress.City.SameAs(PaymentInformation.BillingAdress.City)
                   && ShippingDetails.ShippingAddress.State.SameAs(PaymentInformation.BillingAdress.State)
                   && ShippingDetails.ShippingAddress.Province.SameAs(PaymentInformation.BillingAdress.Province)
                   && ShippingDetails.ShippingAddress.Country.SameAs(PaymentInformation.BillingAdress.Country)
                   && ShippingDetails.ShippingAddress.Zip.SameAs(PaymentInformation.BillingAdress.Zip);
        }
    }
}
