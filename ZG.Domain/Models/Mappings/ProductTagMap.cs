
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class ProductTagMap : EntityTypeConfiguration<ProductTag>
    {
        public ProductTagMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ProductTag");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.TagID).HasColumnName("TagID");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.ProductTags)
                .HasForeignKey(d => d.ProductID);
            this.HasRequired(t => t.Tag)
                .WithMany(t => t.ProductTags)
                .HasForeignKey(d => d.TagID);

        }
    }
}
