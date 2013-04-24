
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZG.Domain.Models.Mapping
{
    public class StateMap : EntityTypeConfiguration<State>
    {
        public StateMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.StateName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.StateCode)
                .IsRequired()
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("State");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.StateName).HasColumnName("StateName");
            this.Property(t => t.StateCode).HasColumnName("StateCode");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
