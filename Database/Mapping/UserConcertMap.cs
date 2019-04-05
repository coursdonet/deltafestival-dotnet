using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Mapping
{
    public class UserConcertMap : IEntityTypeConfiguration<UserConcert>
    {
        public void Configure(EntityTypeBuilder<UserConcert> builder)
        {
            builder.HasKey(p => new { p.UserId, p.ConcertId });
        }
    }
}

