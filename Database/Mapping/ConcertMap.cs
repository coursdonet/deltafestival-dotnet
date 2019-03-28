using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Mapping
{
    public class ConcertMap : IEntityTypeConfiguration<Concert>
    {
        public void Configure(EntityTypeBuilder<Concert> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Artist).IsRequired();
            builder.Property(p => p.Hour).IsRequired();
            builder.Property(p => p.Duration).IsRequired();
            builder.Property(p => p.ConcertLocationId).IsRequired();
        }
    }
}
