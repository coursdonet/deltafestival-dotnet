using Database.Mapping;
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
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Localization> Localizations { get; set; }
        public virtual DbSet<Checkpoint> Checkpoint { get; set; }
        public virtual DbSet<Mood> Mood { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<PlaceCategory> PlaceCategory { get; set; }
        public virtual DbSet<Publication> Publication { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<TeamCheckpoints> TeamCheckpoints { get; set; }
        public virtual DbSet<TeamMembers> TeamMembers { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserValidatedCheckpoints> UserValidatedCheckpoints { get; set; }
        public virtual DbSet<Zone> Zone { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<User>().HasKey(p=>p.Id);
            modelBuilder.ApplyConfiguration(new UserMap());
        }

    }
}
