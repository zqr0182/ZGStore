

using System;
using System.Collections.Generic;

namespace ZG.Domain.Models
{
    public partial class Product : IEntity  
    {
        public Product()
        {
            this.Coupons = new List<Coupon>();
            this.CustomFields = new List<CustomField>();
            this.FeaturedProducts = new List<FeaturedProduct>();
            this.GiftRegistryProducts = new List<GiftRegistryProduct>();
            this.Images = new List<Image>();
            this.Inventories = new List<Inventory>();
            this.OrderProducts = new List<OrderProduct>();
            this.ProductDownloadKeys = new List<ProductDownloadKey>();
            this.ProductCategories = new List<ProductCategory>();
            this.ProductOptions = new List<ProductOption>();
            this.ProductReviews = new List<ProductReview>();
            this.ProductTags = new List<ProductTag>();
            this.RelatedProducts = new List<RelatedProduct>();
            this.RelatedProducts1 = new List<RelatedProduct>();
            this.Shippings = new List<Shipping>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CatalogNumber { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<decimal> ShippingWeight { get; set; }
        public Nullable<decimal> Height { get; set; }
        public Nullable<decimal> ShippingHeight { get; set; }
        public Nullable<decimal> Length { get; set; }
        public Nullable<decimal> ShippingLength { get; set; }
        public Nullable<decimal> Width { get; set; }
        public Nullable<decimal> ShippingWidth { get; set; }
        public string ProductLink { get; set; }
        public bool IsDownloadable { get; set; }
        public Nullable<bool> IsDownloadKeyRequired { get; set; }
        public Nullable<bool> IsDownloadKeyUnique { get; set; }
        public string DownloadURL { get; set; }
        public bool IsReviewEnabled { get; set; }
        public int TotalReviewCount { get; set; }
        public Nullable<decimal> RatingScore { get; set; }
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
