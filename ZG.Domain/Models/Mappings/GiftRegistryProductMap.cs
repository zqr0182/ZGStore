
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class GiftRegistryProductMap : EntityTypeConfiguration<GiftRegistryProduct>
    {
        public GiftRegistryProductMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("GiftRegistryProduct");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.GiftRegistryID).HasColumnName("GiftRegistryID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.GiftRegistry)
                .WithMany(t => t.GiftRegistryProducts)
                .HasForeignKey(d => d.GiftRegistryID);
            this.HasOptional(t => t.Product)
                .WithMany(t => t.GiftRegistryProducts)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
