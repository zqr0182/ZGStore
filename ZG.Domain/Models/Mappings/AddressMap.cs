
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Address1)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Address2)
                .HasMaxLength(50);

            this.Property(t => t.Zipcode)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Address");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.CountryID).HasColumnName("CountryID");
            this.Property(t => t.StateID).HasColumnName("StateID");
            this.Property(t => t.ProvinceID).HasColumnName("ProvinceID");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Address1).HasColumnName("Address");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.Zipcode).HasColumnName("Zipcode");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");
            this.Property(t => t.IsBilling).HasColumnName("IsBilling");
            this.Property(t => t.IsShipping).HasColumnName("IsShipping");

            // Relationships
            this.HasRequired(t => t.Country)
                .WithMany(t => t.Addresses)
                .HasForeignKey(d => d.CountryID);
            this.HasOptional(t => t.Province)
                .WithMany(t => t.Addresses)
                .HasForeignKey(d => d.ProvinceID);
            this.HasOptional(t => t.State)
                .WithMany(t => t.Addresses)
                .HasForeignKey(d => d.StateID);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Addresses)
                .HasForeignKey(d => d.UserID);

        }
    }
}
