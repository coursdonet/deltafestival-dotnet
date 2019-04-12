using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Mapping
{
    public class UserConcertMap : IEntityTypeConfiguration<UserConcerts>
    {
        public void Configure(EntityTypeBuilder<UserConcerts> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}

