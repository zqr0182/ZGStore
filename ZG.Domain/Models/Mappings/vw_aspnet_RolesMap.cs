
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class VwAspnetRolesMap : EntityTypeConfiguration<VwAspnetRoles>
    {
        public VwAspnetRolesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ApplicationId, t.RoleId, t.RoleName, t.LoweredRoleName });

            // Properties
            this.Property(t => t.RoleName)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.LoweredRoleName)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Description)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("vw_aspnet_Roles");
            this.Property(t => t.ApplicationId).HasColumnName("ApplicationId");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.RoleName).HasColumnName("RoleName");
            this.Property(t => t.LoweredRoleName).HasColumnName("LoweredRoleName");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
