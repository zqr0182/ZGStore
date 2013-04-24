
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class OrderStatuMap : EntityTypeConfiguration<OrderStatu>
    {
        public OrderStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.OrderStatusName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("OrderStatus");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrderStatusName).HasColumnName("OrderStatusName");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
