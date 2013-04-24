
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class ProductCategoryMap : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ProductCategory");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.Category)
                .WithMany(t => t.ProductCategories)
                .HasForeignKey(d => d.CategoryID);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.ProductCategories)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
