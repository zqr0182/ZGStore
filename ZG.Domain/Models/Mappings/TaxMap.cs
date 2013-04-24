
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class TaxMap : EntityTypeConfiguration<Tax>
    {
        public TaxMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.TaxName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Tax");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TaxName).HasColumnName("TaxName");
            this.Property(t => t.Fixed).HasColumnName("Fixed");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.IsAfterShipping).HasColumnName("IsAfterShipping");
            this.Property(t => t.CountryID).HasColumnName("CountryID");
            this.Property(t => t.StateID).HasColumnName("StateID");
            this.Property(t => t.ProvinceID).HasColumnName("ProvinceID");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.Country)
                .WithMany(t => t.Taxes)
                .HasForeignKey(d => d.CountryID);
            this.HasOptional(t => t.Province)
                .WithMany(t => t.Taxes)
                .HasForeignKey(d => d.ProvinceID);
            this.HasOptional(t => t.State)
                .WithMany(t => t.Taxes)
                .HasForeignKey(d => d.StateID);

        }
    }
}
