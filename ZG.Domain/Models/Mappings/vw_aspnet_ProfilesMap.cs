
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class VwAspnetProfilesMap : EntityTypeConfiguration<VwAspnetProfiles>
    {
        public VwAspnetProfilesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserId, t.LastUpdatedDate });

            // Properties
            // Table & Column Mappings
            this.ToTable("vw_aspnet_Profiles");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.LastUpdatedDate).HasColumnName("LastUpdatedDate");
            this.Property(t => t.DataSize).HasColumnName("DataSize");
        }
    }
}
