
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class GiftRegistryMap : EntityTypeConfiguration<GiftRegistry>
    {
        public GiftRegistryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("GiftRegistry");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.IsPublic).HasColumnName("IsPublic");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.GiftRegistries)
                .HasForeignKey(d => d.UserID);

        }
    }
}
