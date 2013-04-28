
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.OrderNumber)
                .HasMaxLength(50);

            this.Property(t => t.ShippingNumber)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.Zipcode)
                .HasMaxLength(50);

            this.Property(t => t.Comments)
                .HasMaxLength(400);

            // Table & Column Mappings
            this.ToTable("Order");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.OrderNumber).HasColumnName("OrderNumber");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");
            this.Property(t => t.OrderStatusID).HasColumnName("OrderStatusID");
            this.Property(t => t.ShippingProviderID).HasColumnName("ShippingProviderID");
            this.Property(t => t.ShippingNumber).HasColumnName("ShippingNumber");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.StateID).HasColumnName("StateID");
            this.Property(t => t.ProvinceID).HasColumnName("ProvinceID");
            this.Property(t => t.CountryID).HasColumnName("CountryID");
            this.Property(t => t.Zipcode).HasColumnName("Zipcode");
            this.Property(t => t.Comments).HasColumnName("Comments");
            this.Property(t => t.DatePlaced).HasColumnName("DatePlaced");
            this.Property(t => t.DateShipped).HasColumnName("DateShipped");
            this.Property(t => t.Total).HasColumnName("Total");
            this.Property(t => t.Shipping).HasColumnName("Shipping");
            this.Property(t => t.Tax).HasColumnName("Tax");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasOptional(t => t.Country)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.CountryID);
            this.HasOptional(t => t.OrderStatu)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.OrderStatusID);
            this.HasOptional(t => t.Province)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.ProvinceID);
            this.HasOptional(t => t.ShippingProvider)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.ShippingProviderID);
            this.HasOptional(t => t.State)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.StateID);

        }
    }
}
