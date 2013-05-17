
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ZG.Domain.Models;

namespace ZG.Repository
{
    public partial class ZGStoreContext : DbContext
    {
        static ZGStoreContext()
        {
            Database.SetInitializer<ZGStoreContext>(null);
        }

        public ZGStoreContext()
            : base("Name=ZGStoreContext")
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CouponType> CouponTypes { get; set; }
        public DbSet<CustomField> CustomFields { get; set; }
        public DbSet<CustomFieldType> CustomFieldTypes { get; set; }
        public DbSet<FeaturedProduct> FeaturedProducts { get; set; }
        public DbSet<GiftRegistry> GiftRegistries { get; set; }
        public DbSet<GiftRegistryProduct> GiftRegistryProducts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryAction> InventoryActions { get; set; }
        public DbSet<InventoryProductOption> InventoryProductOptions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<OrderProductCustomField> OrderProductCustomFields { get; set; }
        public DbSet<OrderProductOption> OrderProductOptions { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductDownloadKey> ProductDownloadKeys { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<ProductReviewCaregoryProductReview> ProductReviewCaregoryProductReviews { get; set; }
        public DbSet<ProductReviewCategory> ProductReviewCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<RelatedProduct> RelatedProducts { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<ShippingProvider> ShippingProviders { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<StoreConfiguration> StoreConfigurations { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
