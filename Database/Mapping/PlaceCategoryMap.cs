using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Mapping
{
    class PlaceCategoryMap : IEntityTypeConfiguration<PlaceCategory>
    {
        public void Configure(EntityTypeBuilder<PlaceCategory> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            //builder.Property(p => p.PlaceCategoryPosition);
            builder.ToTable("PlaceCategory");
        }
    }
}
