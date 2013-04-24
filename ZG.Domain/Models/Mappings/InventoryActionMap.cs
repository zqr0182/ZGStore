
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class InventoryActionMap : EntityTypeConfiguration<InventoryAction>
    {
        public InventoryActionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.InventoryActionName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("InventoryAction");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.InventoryActionName).HasColumnName("InventoryActionName");
        }
    }
}
