using Database.Mapping;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace Database
{
    public class CpContext : DbContext
    {
        public CpContext(DbContextOptions<CpContext> options)
          : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Checkpoint> Checkpoints { get; set; }
        public virtual DbSet<TeamCheckpoints> TeamCheckpoints { get; set; }
        public virtual DbSet<UserValidatedCheckpoints> UserValidatedCheckpoints { get; set; }
        public virtual DbSet<UserConcert> UserConcerts { get; set; }
        public virtual DbSet<Concert> Concert { get; set; }
        public virtual DbSet<ConcertLocation> ConcertLocation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<User>().HasKey(p=>p.Id);
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TeamCheckpointsMap());
            modelBuilder.ApplyConfiguration(new UserValidatedCheckpointMap());
            modelBuilder.ApplyConfiguration(new CheckpointMap());
            modelBuilder.ApplyConfiguration(new ConcertMap());
            modelBuilder.ApplyConfiguration(new ConcertLocationMap());
            modelBuilder.ApplyConfiguration(new UserConcertMap());
        }

    }
}
