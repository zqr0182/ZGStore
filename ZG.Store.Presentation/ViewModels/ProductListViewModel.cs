using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZG.Domain.DTO;
using ZG.Domain.Models;

namespace ZG.Store.Presentation.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductBriefInfo> Products { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPageNum { get; set; }
        public int RecordsPerPage { get; set; }
        public string CurrentCategory { get; set; }
    }
}