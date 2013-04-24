
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class ProductDownloadKeyMap : EntityTypeConfiguration<ProductDownloadKey>
    {
        public ProductDownloadKeyMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.DownloadKey)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ProductDownloadKey");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.DownloadKey).HasColumnName("DownloadKey");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.ProductDownloadKeys)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
