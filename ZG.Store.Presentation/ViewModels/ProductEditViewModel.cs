using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZG.Domain.Models;

namespace ZG.Store.Presentation.ViewModels
{
    public class ProductEditViewModel
    {
        public Product Product { get; set; }
        public string Category { get; set; }
        public int Page { get; set; }
    }
}