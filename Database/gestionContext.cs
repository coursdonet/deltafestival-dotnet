using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Database
{
    public class gestionContext : DbContext
    {
        public gestionContext(DbContextOptions<gestionContext> options)
            : base(options)
        {
        }
        public DbSet<Entities.SuperUser> SuperUser { get; set; }
        public DbSet<Entities.Team> Team { get; set; }
        public DbSet<Entities.Photo> Photo { get; set; }
        public DbSet<Entities.UserRole> UserRole { get; set; }
        public DbSet<Entities.Publication> Publication { get; set; }
        public DbSet<Entities.Checkpoint> Checkpoint { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<User>().HasKey(p=>p.Id);

        }

    }
}
