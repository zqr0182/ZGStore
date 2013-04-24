
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class VwAspnetUsersinrolesMap : EntityTypeConfiguration<VwAspnetUsersinroles>
    {
        public VwAspnetUsersinrolesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserId, t.RoleId });

            // Properties
            // Table & Column Mappings
            this.ToTable("vw_aspnet_UsersInRoles");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
        }
    }
}
