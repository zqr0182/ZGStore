
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ZG.Domain.Models;
using ZG.Domain.Models.Mapping;

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
        public DbSet<DBVersion> DBVersions { get; set; }
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
        public DbSet<OrderStatu> OrderStatus { get; set; }
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
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new CouponMap());
            modelBuilder.Configurations.Add(new CouponTypeMap());
            modelBuilder.Configurations.Add(new CustomFieldMap());
            modelBuilder.Configurations.Add(new CustomFieldTypeMap());
            modelBuilder.Configurations.Add(new DBVersionMap());
            modelBuilder.Configurations.Add(new FeaturedProductMap());
            modelBuilder.Configurations.Add(new GiftRegistryMap());
            modelBuilder.Configurations.Add(new GiftRegistryProductMap());
            modelBuilder.Configurations.Add(new ImageMap());
            modelBuilder.Configurations.Add(new InventoryMap());
            modelBuilder.Configurations.Add(new InventoryActionMap());
            modelBuilder.Configurations.Add(new InventoryProductOptionMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderProductMap());
            modelBuilder.Configurations.Add(new OrderProductCustomFieldMap());
            modelBuilder.Configurations.Add(new OrderProductOptionMap());
            modelBuilder.Configurations.Add(new OrderStatuMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductCategoryMap());
            modelBuilder.Configurations.Add(new ProductDownloadKeyMap());
            modelBuilder.Configurations.Add(new ProductOptionMap());
            modelBuilder.Configurations.Add(new ProductReviewMap());
            modelBuilder.Configurations.Add(new ProductReviewCaregoryProductReviewMap());
            modelBuilder.Configurations.Add(new ProductReviewCategoryMap());
            modelBuilder.Configurations.Add(new ProductTagMap());
            modelBuilder.Configurations.Add(new ProvinceMap());
            modelBuilder.Configurations.Add(new RelatedProductMap());
            modelBuilder.Configurations.Add(new ShippingMap());
            modelBuilder.Configurations.Add(new ShippingProviderMap());
            modelBuilder.Configurations.Add(new StateMap());
            modelBuilder.Configurations.Add(new StoreConfigurationMap());
            modelBuilder.Configurations.Add(new TagMap());
            modelBuilder.Configurations.Add(new TaxMap());
            modelBuilder.Configurations.Add(new UsersMap());
        }
    }
}
