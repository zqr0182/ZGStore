
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class ProductReviewCategoryMap : EntityTypeConfiguration<ProductReviewCategory>
    {
        public ProductReviewCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ProductReviewCategoryName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ProductReviewCategory");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProductReviewCategoryName).HasColumnName("ProductReviewCategoryName");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
