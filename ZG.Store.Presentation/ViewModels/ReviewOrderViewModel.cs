using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZG.Common.DTO;
using ZG.Domain.Concrete;

namespace ZG.Store.Presentation.ViewModels
{
    public class ReviewOrderViewModel
    {
        public CheckoutDetails CheckoutDetails { get; set; }
        public Cart Cart { get; set; }
        //TODO: add shipping speed options
    }
}