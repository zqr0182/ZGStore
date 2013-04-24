
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class OrderProductCustomFieldMap : EntityTypeConfiguration<OrderProductCustomField>
    {
        public OrderProductCustomFieldMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.OrderProductCustomFieldValue)
                .HasMaxLength(400);

            // Table & Column Mappings
            this.ToTable("OrderProductCustomField");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrderProductID).HasColumnName("OrderProductID");
            this.Property(t => t.CustomFieldID).HasColumnName("CustomFieldID");
            this.Property(t => t.OrderProductCustomFieldValue).HasColumnName("OrderProductCustomFieldValue");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.CustomField)
                .WithMany(t => t.OrderProductCustomFields)
                .HasForeignKey(d => d.CustomFieldID);
            this.HasRequired(t => t.OrderProduct)
                .WithMany(t => t.OrderProductCustomFields)
                .HasForeignKey(d => d.OrderProductID);

        }
    }
}
