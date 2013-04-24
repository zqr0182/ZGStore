
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class ShippingMap : EntityTypeConfiguration<Shipping>
    {
        public ShippingMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Shipping");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CountryID).HasColumnName("CountryID");
            this.Property(t => t.StateID).HasColumnName("StateID");
            this.Property(t => t.ProvinceID).HasColumnName("ProvinceID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.ShippingProviderID).HasColumnName("ShippingProviderID");
            this.Property(t => t.Rate).HasColumnName("Rate");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.Country)
                .WithMany(t => t.Shippings)
                .HasForeignKey(d => d.CountryID);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.Shippings)
                .HasForeignKey(d => d.ProductID);
            this.HasOptional(t => t.Province)
                .WithMany(t => t.Shippings)
                .HasForeignKey(d => d.ProvinceID);
            this.HasRequired(t => t.ShippingProvider)
                .WithMany(t => t.Shippings)
                .HasForeignKey(d => d.ShippingProviderID);
            this.HasOptional(t => t.State)
                .WithMany(t => t.Shippings)
                .HasForeignKey(d => d.StateID);

        }
    }
}
