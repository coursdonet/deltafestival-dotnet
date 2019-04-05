using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Mapping
{
    public class ConcertLocationMap : IEntityTypeConfiguration<ConcertLocation>
    {
        public void Configure(EntityTypeBuilder<ConcertLocation> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Location).IsRequired();
        }
    }
}
