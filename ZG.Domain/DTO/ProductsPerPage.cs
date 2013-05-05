using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Domain.DTO
{
    public class ProductsPerPage
    {
        public IQueryable<Product> Products { get; set; }
        public int TotalProducts { get; set; }
    }
}
