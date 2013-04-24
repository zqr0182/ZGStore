
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class InventoryMap : EntityTypeConfiguration<Inventory>
    {
        public InventoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Inventory");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.InventoryActionID).HasColumnName("InventoryActionID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.ProductAmountInStock).HasColumnName("ProductAmountInStock");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.InventoryAction)
                .WithMany(t => t.Inventories)
                .HasForeignKey(d => d.InventoryActionID);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.Inventories)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
