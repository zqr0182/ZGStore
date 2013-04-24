
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class InventoryProductOptionMap : EntityTypeConfiguration<InventoryProductOption>
    {
        public InventoryProductOptionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("InventoryProductOption");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.InventoryID).HasColumnName("InventoryID");
            this.Property(t => t.ProductOptionID).HasColumnName("ProductOptionID");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.Inventory)
                .WithMany(t => t.InventoryProductOptions)
                .HasForeignKey(d => d.InventoryID);
            this.HasRequired(t => t.ProductOption)
                .WithMany(t => t.InventoryProductOptions)
                .HasForeignKey(d => d.ProductOptionID);

        }
    }
}
