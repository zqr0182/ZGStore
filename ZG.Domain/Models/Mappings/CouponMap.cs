
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class CouponMap : EntityTypeConfiguration<Coupon>
    {
        public CouponMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CouponCode)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.CouponDescription)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Coupon");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CouponTypeID).HasColumnName("CouponTypeID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.CouponCode).HasColumnName("CouponCode");
            this.Property(t => t.CouponDescription).HasColumnName("CouponDescription");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.IsCouponUnique).HasColumnName("IsCouponUnique");
            this.Property(t => t.IsCanBeCombined).HasColumnName("IsCanBeCombined");
            this.Property(t => t.IssuedDate).HasColumnName("IssuedDate");
            this.Property(t => t.ExpirationDate).HasColumnName("ExpirationDate");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.CouponType)
                .WithMany(t => t.Coupons)
                .HasForeignKey(d => d.CouponTypeID);
            this.HasOptional(t => t.Product)
                .WithMany(t => t.Coupons)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
