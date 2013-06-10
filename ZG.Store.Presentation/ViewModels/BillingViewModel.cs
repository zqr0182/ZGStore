using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZG.Common.DTO;

namespace ZG.Store.Presentation.ViewModels
{
    public class BillingViewModel
    {
        public Address ShippingAddress { get; set; }
        public Address NewBillingAddress { get; set; }
        public Address ExistingBillingAddress { get; set; }

        public bool IsShippingAddressEmpty
        {
            get { return ShippingAddress == null || string.IsNullOrWhiteSpace(ShippingAddress.FullName); }
        }

        public bool IsExistingBillingAddressEmpty
        {
            get { return ExistingBillingAddress == null || string.IsNullOrWhiteSpace(ExistingBillingAddress.FullName); }
        }
    }
}