
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class ProvinceMap : EntityTypeConfiguration<Province>
    {
        public ProvinceMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ProvinceName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ProvinceCode)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.Active)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Province");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProvinceName).HasColumnName("ProvinceName");
            this.Property(t => t.ProvinceCode).HasColumnName("ProvinceCode");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
