
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class ProductOptionMap : EntityTypeConfiguration<ProductOption>
    {
        public ProductOptionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ProductOptionName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ProductOptionGroup)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ProductOption");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProductOptionName).HasColumnName("ProductOptionName");
            this.Property(t => t.ProductOptionGroup).HasColumnName("ProductOptionGroup");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.PriceChange).HasColumnName("PriceChange");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.ProductOptions)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
