
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class CustomFieldMap : EntityTypeConfiguration<CustomField>
    {
        public CustomFieldMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CustomFieldName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CustomField");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.CustomFieldName).HasColumnName("CustomFieldName");
            this.Property(t => t.CustomFieldTypeID).HasColumnName("CustomFieldTypeID");
            this.Property(t => t.IsRequired).HasColumnName("IsRequired");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.CustomFieldType)
                .WithMany(t => t.CustomFields)
                .HasForeignKey(d => d.CustomFieldTypeID);
            this.HasOptional(t => t.Product)
                .WithMany(t => t.CustomFields)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
