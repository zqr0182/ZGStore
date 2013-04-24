
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Company)
                .HasMaxLength(50);

            this.Property(t => t.FirstName)
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.Zipcode)
                .HasMaxLength(50);

            this.Property(t => t.DayPhone)
                .HasMaxLength(50);

            this.Property(t => t.EveningPhone)
                .HasMaxLength(50);

            this.Property(t => t.CellPhone)
                .HasMaxLength(50);

            this.Property(t => t.Fax)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Customer");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MemberID).HasColumnName("MemberID");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.StateID).HasColumnName("StateID");
            this.Property(t => t.ProvinceID).HasColumnName("ProvinceID");
            this.Property(t => t.CountryID).HasColumnName("CountryID");
            this.Property(t => t.Zipcode).HasColumnName("Zipcode");
            this.Property(t => t.DayPhone).HasColumnName("DayPhone");
            this.Property(t => t.EveningPhone).HasColumnName("EveningPhone");
            this.Property(t => t.CellPhone).HasColumnName("CellPhone");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateUpdated).HasColumnName("DateUpdated");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasOptional(t => t.Country)
                .WithMany(t => t.Customers)
                .HasForeignKey(d => d.CountryID);
            this.HasOptional(t => t.Province)
                .WithMany(t => t.Customers)
                .HasForeignKey(d => d.ProvinceID);
            this.HasOptional(t => t.State)
                .WithMany(t => t.Customers)
                .HasForeignKey(d => d.StateID);

        }
    }
}
