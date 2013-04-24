
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ProductName)
                .HasMaxLength(50);

            this.Property(t => t.CatalogNumber)
                .HasMaxLength(50);

            this.Property(t => t.ProductLink)
                .HasMaxLength(400);

            this.Property(t => t.DownloadURL)
                .HasMaxLength(400);

            // Table & Column Mappings
            this.ToTable("Product");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.CatalogNumber).HasColumnName("CatalogNumber");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.SalePrice).HasColumnName("SalePrice");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.ShippingWeight).HasColumnName("ShippingWeight");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.ShippingHeight).HasColumnName("ShippingHeight");
            this.Property(t => t.Length).HasColumnName("Length");
            this.Property(t => t.ShippingLength).HasColumnName("ShippingLength");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.ShippingWidth).HasColumnName("ShippingWidth");
            this.Property(t => t.ProductLink).HasColumnName("ProductLink");
            this.Property(t => t.IsDownloadable).HasColumnName("IsDownloadable");
            this.Property(t => t.IsDownloadKeyRequired).HasColumnName("IsDownloadKeyRequired");
            this.Property(t => t.IsDownloadKeyUnique).HasColumnName("IsDownloadKeyUnique");
            this.Property(t => t.DownloadURL).HasColumnName("DownloadURL");
            this.Property(t => t.IsReviewEnabled).HasColumnName("IsReviewEnabled");
            this.Property(t => t.TotalReviewCount).HasColumnName("TotalReviewCount");
            this.Property(t => t.RatingScore).HasColumnName("RatingScore");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
