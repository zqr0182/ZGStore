using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common;
using ZG.Domain.Models;

namespace ZG.Domain.DTO
{
    public class ProductEditViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Name is a required field")]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string CatalogNumber { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal SalePrice { get; set; }
        public decimal Weight { get; set; }
        public decimal ShippingWeight { get; set; }
        public decimal Height { get; set; }
        public decimal ShippingHeight { get; set; }
        public decimal Length { get; set; }
        public decimal ShippingLength { get; set; }
        public decimal Width { get; set; }
        public decimal ShippingWidth { get; set; }
        [MaxLength(400)]
        public string ProductLink { get; set; }
        public bool IsReviewEnabled { get; set; }
        public int TotalReviewCount { get; set; }
        public Nullable<decimal> RatingScore { get; set; }
        [Required(ErrorMessage = "Active is a required field")]
        public bool Active { get; set; }

        public List<ImageInfo> ProductImages { get; set; }
        public List<IdName> ProductCategories { get; set; }
        public List<InventoryViewModel> Inventories { get; set; }
    }
}
