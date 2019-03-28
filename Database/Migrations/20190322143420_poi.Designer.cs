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
    [DbContext(typeof(gestionContext))]
    [Migration("20190322143420_poi")]
    partial class poi
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

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsObsolete");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Checkpoint");
                });

            modelBuilder.Entity("Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Path")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("Entities.Publication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreationDate");

                    b.Property<bool>("IsCoupDeCoeur");

                    b.Property<int?>("SuperUserId");

                    b.HasKey("Id");

                    b.HasIndex("SuperUserId");

                    b.ToTable("Publication");
                });

            modelBuilder.Entity("Entities.SuperUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CanPublish");

                    b.Property<bool>("IsActive");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("Resign");

                    b.Property<int>("UserRoleId");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("SuperUser");
                });

            modelBuilder.Entity("Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Point");

                    b.Property<DateTime?>("WinDate");

                    b.HasKey("Id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Libelle")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Entities.Publication", b =>
                {
                    b.HasOne("Entities.SuperUser", "SuperUser")
                        .WithMany()
                        .HasForeignKey("SuperUserId");
                });

            modelBuilder.Entity("Entities.SuperUser", b =>
                {
                    b.HasOne("Entities.UserRole", "UserRole")
                        .WithMany("SuperUsers")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
