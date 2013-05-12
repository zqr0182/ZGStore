using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZG.Domain.Models;

namespace ZG.Store.Presentation.ViewModels
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}