
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class ImageMap : EntityTypeConfiguration<Image>
    {
        public ImageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ImageName)
                .HasMaxLength(200);

            this.Property(t => t.ImageURL)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Image");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ParentID).HasColumnName("ParentID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.SortOrder).HasColumnName("SortOrder");
            this.Property(t => t.ImageName).HasColumnName("ImageName");
            this.Property(t => t.ImageURL).HasColumnName("ImageURL");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.Images)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
