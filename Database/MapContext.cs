using Database.Mapping;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace Database
{
    public class MapContext : DbContext
    {
        public MapContext(DbContextOptions<MapContext> options)
          : base(options)
        {

        }

        public virtual DbSet<Zone> Zones { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<PlaceCategory> PlaceCatergories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<User>().HasKey(p=>p.Id);
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ZoneMap());
            modelBuilder.ApplyConfiguration(new PlaceMap());
            modelBuilder.ApplyConfiguration(new PlaceCategoryMap());
        }
    }
}
