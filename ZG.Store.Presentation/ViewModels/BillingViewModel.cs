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
        public Address BillingAddress { get; set; }
    }
}