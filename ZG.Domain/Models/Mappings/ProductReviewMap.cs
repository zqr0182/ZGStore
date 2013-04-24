
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class ProductReviewMap : EntityTypeConfiguration<ProductReview>
    {
        public ProductReviewMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ReviewText)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("ProductReview");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.ReviewText).HasColumnName("ReviewText");
            this.Property(t => t.ReviewDate).HasColumnName("ReviewDate");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.ProductReviews)
                .HasForeignKey(d => d.CustomerID);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.ProductReviews)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
