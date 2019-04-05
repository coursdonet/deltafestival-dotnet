using Database.Mapping;
using DeltaFestival.Models;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace Database
{
    public class EfContext : DbContext
    {
        public EfContext(DbContextOptions<EfContext> options)
          : base(options)
        {

        }
        public virtual  DbSet<User> Users { get; set; }
        public virtual DbSet<Localization> Localizations { get; set; }
        public virtual DbSet<Mood> Mood { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<TeamMembers> TeamMembers { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Checkpoint> Checkpoints { get; set; }
        public virtual DbSet<TeamCheckpoints> TeamCheckpoints { get; set; }
        public virtual DbSet<UserValidatedCheckpoints> UserValidatedCheckpoints { get; set; }
        public virtual DbSet<UserConcert> UserConcerts { get; set; }
        public virtual DbSet<Concert> Concert { get; set; }
        public virtual DbSet<ConcertLocation> ConcertLocation { get; set; }
        public virtual DbSet<SuperUser> SuperUser { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Publication> Publication { get; set; }
        public virtual DbSet<Checkpoint> Checkpoint { get; set; }
        public virtual DbSet<Crush> Crushes { get; set; }
        public virtual DbSet<Ignored> Ignoreds { get; set; }
        public virtual DbSet<Zone> Zones { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<PlaceCategory> PlaceCatergories { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        //public virtual DbSet<Tinder> Tinders { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TeamCheckpointsMap());
            modelBuilder.ApplyConfiguration(new UserValidatedCheckpointMap());
            modelBuilder.ApplyConfiguration(new CheckpointMap());
            modelBuilder.ApplyConfiguration(new ConcertMap());
            modelBuilder.ApplyConfiguration(new ConcertLocationMap());
            modelBuilder.ApplyConfiguration(new UserConcertMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ZoneMap());
            modelBuilder.ApplyConfiguration(new PlaceMap());
            modelBuilder.ApplyConfiguration(new PlaceCategoryMap());
        }

    }
}
