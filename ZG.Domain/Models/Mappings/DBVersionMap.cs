
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class DBVersionMap : EntityTypeConfiguration<DBVersion>
    {
        public DBVersionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Sprint, t.Patch });

            // Properties
            this.Property(t => t.Sprint)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Patch)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Story)
                .IsRequired();

            this.Property(t => t.Description)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("DBVersion");
            this.Property(t => t.Sprint).HasColumnName("Sprint");
            this.Property(t => t.Patch).HasColumnName("Patch");
            this.Property(t => t.Story).HasColumnName("Story");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.DeployedOn).HasColumnName("DeployedOn");
        }
    }
}
