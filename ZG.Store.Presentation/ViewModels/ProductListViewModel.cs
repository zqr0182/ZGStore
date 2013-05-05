using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZG.Domain.Models;

namespace ZG.Store.Presentation.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        //public long TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPageNum { get; set; }
        public int RecordsPerPage { get; set; }
    }
}