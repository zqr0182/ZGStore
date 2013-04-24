
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class FeaturedProductMap : EntityTypeConfiguration<FeaturedProduct>
    {
        public FeaturedProductMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("FeaturedProduct");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasOptional(t => t.Category)
                .WithMany(t => t.FeaturedProducts)
                .HasForeignKey(d => d.CategoryID);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.FeaturedProducts)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
