
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class CustomFieldTypeMap : EntityTypeConfiguration<CustomFieldType>
    {
        public CustomFieldTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CustomFieldTypeName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CustomFieldType");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CustomFieldTypeName).HasColumnName("CustomFieldTypeName");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
