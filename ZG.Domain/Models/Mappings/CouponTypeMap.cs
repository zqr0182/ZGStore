
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class CouponTypeMap : EntityTypeConfiguration<CouponType>
    {
        public CouponTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CouponTypeName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CouponType");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CouponTypeName).HasColumnName("CouponTypeName");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
