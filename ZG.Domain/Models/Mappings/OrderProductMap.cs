
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class OrderProductMap : EntityTypeConfiguration<OrderProduct>
    {
        public OrderProductMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.DownloadKey)
                .HasMaxLength(50);

            this.Property(t => t.DownloadURL)
                .HasMaxLength(400);

            // Table & Column Mappings
            this.ToTable("OrderProduct");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.PricePerUnit).HasColumnName("PricePerUnit");
            this.Property(t => t.TotalPrice).HasColumnName("TotalPrice");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.Shipping).HasColumnName("Shipping");
            this.Property(t => t.DownloadKey).HasColumnName("DownloadKey");
            this.Property(t => t.DownloadURL).HasColumnName("DownloadURL");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.Order)
                .WithMany(t => t.OrderProducts)
                .HasForeignKey(d => d.OrderID);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.OrderProducts)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
