using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZG.Domain.DTO
{
    public class ProductEditViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CatalogNumber { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Weight { get; set; }
        public decimal ShippingWeight { get; set; }
        public decimal Height { get; set; }
        public decimal ShippingHeight { get; set; }
        public decimal Length { get; set; }
        public decimal ShippingLength { get; set; }
        public decimal Width { get; set; }
        public decimal ShippingWidth { get; set; }
        public string ProductLink { get; set; }
        public bool IsReviewEnabled { get; set; }
        public int TotalReviewCount { get; set; }
        public Nullable<decimal> RatingScore { get; set; }
        public bool Active { get; set; }

        public List<string> ProductImageNames { get; set; }
    }
}
