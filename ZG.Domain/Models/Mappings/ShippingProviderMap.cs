
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class ShippingProviderMap : EntityTypeConfiguration<ShippingProvider>
    {
        public ShippingProviderMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ShippingProviderName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ShippingProvider");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ShippingProviderName).HasColumnName("ShippingProviderName");
            this.Property(t => t.ShippingCost).HasColumnName("ShippingCost");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
