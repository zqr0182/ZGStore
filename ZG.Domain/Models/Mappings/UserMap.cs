
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FName)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.LName)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(75);

            this.Property(t => t.Password)
                .HasMaxLength(200);

            this.Property(t => t.PasswordSalt)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Fax)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Country)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.State)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.Company)
                .HasMaxLength(100);

            this.Property(t => t.Division)
                .HasMaxLength(100);

            this.Property(t => t.Title)
                .HasMaxLength(100);

            this.Property(t => t.BusinessType)
                .HasMaxLength(50);

            this.Property(t => t.BusinessSize)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FName).HasColumnName("FName");
            this.Property(t => t.LName).HasColumnName("LName");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.PasswordSalt).HasColumnName("PasswordSalt");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.Division).HasColumnName("Division");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.BusinessType).HasColumnName("BusinessType");
            this.Property(t => t.BusinessSize).HasColumnName("BusinessSize");
            this.Property(t => t.BillingAddressId).HasColumnName("BillingAddressId");
            this.Property(t => t.ShippingAddressId).HasColumnName("ShippingAddressId");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");
        }
    }
}
