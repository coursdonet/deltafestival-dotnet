﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Database.Migrations
{
    [DbContext(typeof(CpContext))]
    [Migration("20190322083226_adding-concert")]
    partial class addingconcert
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Checkpoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<bool>("IsObsolete")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<float>("Latitude");

                    b.Property<float>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Checkpoints");
                });

            modelBuilder.Entity("Entities.Concert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Artist")
                        .IsRequired();

                    b.Property<int>("ConcertLocationId");

                    b.Property<DateTime>("Hour");

                    b.HasKey("Id");

                    b.HasIndex("ConcertLocationId");

                    b.ToTable("Concert");
                });

            modelBuilder.Entity("Entities.ConcertLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ConcertLocation");
                });

            modelBuilder.Entity("Entities.Mood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Mood");
                });

            modelBuilder.Entity("Entities.Publication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreationDate");

                    b.Property<bool>("IsCoupDeCoeur");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Publication");
                });

            modelBuilder.Entity("Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MembersCount");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("WinDate");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Entities.TeamCheckpoints", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CheckpointId");

                    b.Property<int>("TeamId");

                    b.Property<DateTime>("TimeChecked");

                    b.HasKey("Id");

                    b.HasIndex("CheckpointId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamCheckpoints");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CanPublish");

                    b.Property<int>("Demission");

                    b.Property<bool>("IsActive");

                    b.Property<int>("MoodId");

                    b.Property<string>("TicketCode")
                        .HasMaxLength(50);

                    b.Property<int>("UserRoleId");

                    b.HasKey("Id");

                    b.HasIndex("MoodId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.UserConcert", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ConcertId");

                    b.Property<int>("Id");

                    b.HasKey("UserId", "ConcertId");

                    b.HasIndex("ConcertId");

                    b.ToTable("UserConcerts");
                });

            modelBuilder.Entity("Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Libelle");

                    b.HasKey("Id");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Entities.UserValidatedCheckpoints", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CheckpointId");

                    b.Property<int>("TeamId");

                    b.Property<DateTime>("TimeChecked");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CheckpointId");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("UserValidatedCheckpoints");
                });

            modelBuilder.Entity("Entities.Concert", b =>
                {
                    b.HasOne("Entities.ConcertLocation", "ConcertLocation")
                        .WithMany()
                        .HasForeignKey("ConcertLocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Publication", b =>
                {
                    b.HasOne("Entities.User")
                        .WithMany("Publications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.TeamCheckpoints", b =>
                {
                    b.HasOne("Entities.Checkpoint", "Checkpoint")
                        .WithMany()
                        .HasForeignKey("CheckpointId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.HasOne("Entities.Mood", "ActualMood")
                        .WithMany()
                        .HasForeignKey("MoodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.UserRole", "Role")
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.UserConcert", b =>
                {
                    b.HasOne("Entities.Concert", "Concert")
                        .WithMany()
                        .HasForeignKey("ConcertId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.UserValidatedCheckpoints", b =>
                {
                    b.HasOne("Entities.Checkpoint", "Checkpoint")
                        .WithMany()
                        .HasForeignKey("CheckpointId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
