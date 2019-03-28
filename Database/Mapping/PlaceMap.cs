using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Mapping
{
    class PlaceMap : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.longi);
            builder.Property(p => p.lat);
            //builder.Property(p => p.PlacePoly).HasColumnName("PlacePoly");
            //builder.ToTable("Zone");
        }
    }
}
