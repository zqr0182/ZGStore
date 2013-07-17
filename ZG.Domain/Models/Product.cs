

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ZG.Common;
using ZG.Domain.Abstract;

namespace ZG.Domain.Models
{
    public partial class Product : IEntity  
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [MaxLength(50)]
        public string ProductName { get; set; }
        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        [MaxLength(50)]
        public string CatalogNumber { get; set; }
        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        public decimal Weight { get; set; }
        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        public decimal ShippingWeight { get; set; }
        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        public decimal Height { get; set; }
        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        public decimal ShippingHeight { get; set; }
        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        public decimal Length { get; set; }
        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        public decimal ShippingLength { get; set; }
        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        public decimal Width { get; set; }
        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        public decimal ShippingWidth { get; set; }
        [MaxLength(400)]
        public string ProductLink { get; set; }
        public bool IsDownloadable { get; set; }
        public Nullable<bool> IsDownloadKeyRequired { get; set; }
        public Nullable<bool> IsDownloadKeyUnique { get; set; }
        [MaxLength(400)]
        public string DownloadURL { get; set; }
        public bool IsReviewEnabled { get; set; }
        public int TotalReviewCount { get; set; }
        public Nullable<decimal> RatingScore { get; set; }
        [Required(ErrorMessage = ValidationErrorMessage.Required)]
        public bool Active { get; set; }
        public virtual ICollection<Coupon> Coupons { get; set; }
        public virtual ICollection<CustomField> CustomFields { get; set; }
        public virtual ICollection<FeaturedProduct> FeaturedProducts { get; set; }
        public virtual ICollection<GiftRegistryProduct> GiftRegistryProducts { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<ProductDownloadKey> ProductDownloadKeys { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<ProductOption> ProductOptions { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; }
        public virtual ICollection<RelatedProduct> RelatedProducts { get; set; }
        public virtual ICollection<RelatedProduct> RelatedProducts1 { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
