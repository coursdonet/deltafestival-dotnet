using Database.Mapping;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class BrownContext : DbContext
    {
        public BrownContext(DbContextOptions<BrownContext> options)
          : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Localization> Localizations { get; set; }
        public virtual DbSet<Mood> Mood { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<TeamMembers> TeamMembers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<User>().HasKey(p=>p.Id);
            modelBuilder.ApplyConfiguration(new UserMap());
        }

    }
}
