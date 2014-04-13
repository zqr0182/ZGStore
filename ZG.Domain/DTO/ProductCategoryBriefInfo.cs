using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Domain.DTO
{
    public class ProductCategoryBriefInfo
    {
        public int Id { get; set; }
        public int? ParentCategoryID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
