using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Mapping
{
    public class TeamCheckpointsMap : IEntityTypeConfiguration<TeamCheckpoints>
    {
        public void Configure(EntityTypeBuilder<TeamCheckpoints> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.TimeChecked).IsRequired();
            builder.Property(p => p.TeamId).IsRequired();
            builder.Property(p => p.CheckpointId).IsRequired();
        }
    }
}
