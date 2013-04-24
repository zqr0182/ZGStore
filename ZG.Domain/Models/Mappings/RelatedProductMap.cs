
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class RelatedProductMap : EntityTypeConfiguration<RelatedProduct>
    {
        public RelatedProductMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("RelatedProduct");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProductOneID).HasColumnName("ProductOneID");
            this.Property(t => t.ProductTwoID).HasColumnName("ProductTwoID");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.RelatedProducts)
                .HasForeignKey(d => d.ProductOneID);
            this.HasRequired(t => t.Product1)
                .WithMany(t => t.RelatedProducts1)
                .HasForeignKey(d => d.ProductTwoID);

        }
    }
}
