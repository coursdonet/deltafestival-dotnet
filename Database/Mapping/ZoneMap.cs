using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Mapping
{
    class ZoneMap : IEntityTypeConfiguration<Zone>
    {
        public void Configure(EntityTypeBuilder<Zone> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.HasMany(p => p.Places);
            //builder.Property(p => p.PolyZone).HasColumnName("PolyZone");

            builder.ToTable("Zone");

        }
    }
}
