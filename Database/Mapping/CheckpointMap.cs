using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Mapping
{
    public class CheckpointMap : IEntityTypeConfiguration<Checkpoint>
    {
        public void Configure(EntityTypeBuilder<Checkpoint> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Longitude).IsRequired();
            builder.Property(p => p.Latitude).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.IsObsolete).HasDefaultValue(false);
        }
    }
}
