
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class OrderProductOptionMap : EntityTypeConfiguration<OrderProductOption>
    {
        public OrderProductOptionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("OrderProductOption");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrderProductID).HasColumnName("OrderProductID");
            this.Property(t => t.ProductOptionID).HasColumnName("ProductOptionID");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.OrderProduct)
                .WithMany(t => t.OrderProductOptions)
                .HasForeignKey(d => d.OrderProductID);
            this.HasRequired(t => t.ProductOption)
                .WithMany(t => t.OrderProductOptions)
                .HasForeignKey(d => d.ProductOptionID);

        }
    }
}
