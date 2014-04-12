using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Domain.DTO
{
    public class ProductCategoryListViewModel
    {
        public IEnumerable<ProductCategoryBriefInfo> Categories { get; set; }
        public int Total { get; set; }
    }
}
