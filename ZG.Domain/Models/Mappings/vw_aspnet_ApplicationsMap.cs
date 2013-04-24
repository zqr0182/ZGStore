
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class VwAspnetApplicationsMap : EntityTypeConfiguration<VwAspnetApplications>
    {
        public VwAspnetApplicationsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ApplicationName, t.LoweredApplicationName, t.ApplicationId });

            // Properties
            this.Property(t => t.ApplicationName)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.LoweredApplicationName)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Description)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("vw_aspnet_Applications");
            this.Property(t => t.ApplicationName).HasColumnName("ApplicationName");
            this.Property(t => t.LoweredApplicationName).HasColumnName("LoweredApplicationName");
            this.Property(t => t.ApplicationId).HasColumnName("ApplicationId");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
