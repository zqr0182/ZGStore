
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class ProductReviewCaregoryProductReviewMap : EntityTypeConfiguration<ProductReviewCaregoryProductReview>
    {
        public ProductReviewCaregoryProductReviewMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ProductReviewCaregoryProductReview");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProductReviewCategoryID).HasColumnName("ProductReviewCategoryID");
            this.Property(t => t.ProductReviewID).HasColumnName("ProductReviewID");
            this.Property(t => t.Rating).HasColumnName("Rating");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.ProductReview)
                .WithMany(t => t.ProductReviewCaregoryProductReviews)
                .HasForeignKey(d => d.ProductReviewID);
            this.HasRequired(t => t.ProductReviewCategory)
                .WithMany(t => t.ProductReviewCaregoryProductReviews)
                .HasForeignKey(d => d.ProductReviewCategoryID);

        }
    }
}
