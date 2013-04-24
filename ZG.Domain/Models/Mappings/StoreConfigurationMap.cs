
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class StoreConfigurationMap : EntityTypeConfiguration<StoreConfiguration>
    {
        public StoreConfigurationMap()
        {
            // Primary Key
            this.HasKey(t => t.ConfigKey);

            // Properties
            this.Property(t => t.ConfigKey)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ConfigValue)
                .HasMaxLength(800);

            // Table & Column Mappings
            this.ToTable("StoreConfiguration");
            this.Property(t => t.ConfigKey).HasColumnName("ConfigKey");
            this.Property(t => t.ConfigValue).HasColumnName("ConfigValue");
        }
    }
}
