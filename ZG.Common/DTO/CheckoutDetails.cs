using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Common.DTO
{
    public class CheckoutDetails
    {
        public ShippingDetails ShippingDetails { get; set; }
        public BillingDetails BillingDetails { get; set; }

        public CheckoutDetails()
        {
            ShippingDetails = new ShippingDetails();
            BillingDetails = new BillingDetails();
        }
    }
}
