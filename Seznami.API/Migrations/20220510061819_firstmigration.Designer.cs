﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Seznami.API.Data;

#nullable disable

namespace Seznami.API.Migrations
{
    [DbContext(typeof(SeznamiFilmovDbContext))]
    [Migration("20220510061819_firstmigration")]
    partial class firstmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Seznami.API.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Naslov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SeznamFilmovId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SeznamFilmovId");

                    b.ToTable("Film");
                });

            modelBuilder.Entity("Seznami.API.Models.SeznamFilmov", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NazivSeznama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UporabnikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UporabnikId");

                    b.ToTable("SeznamiFilmov");
                });

            modelBuilder.Entity("Seznami.API.Models.Uporabnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PrikaznoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Uporabnik");
                });

            modelBuilder.Entity("Seznami.API.Models.Film", b =>
                {
                    b.HasOne("Seznami.API.Models.SeznamFilmov", null)
                        .WithMany("Filmi")
                        .HasForeignKey("SeznamFilmovId");
                });

            modelBuilder.Entity("Seznami.API.Models.SeznamFilmov", b =>
                {
                    b.HasOne("Seznami.API.Models.Uporabnik", "Uporabnik")
                        .WithMany()
                        .HasForeignKey("UporabnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Uporabnik");
                });

            modelBuilder.Entity("Seznami.API.Models.SeznamFilmov", b =>
                {
                    b.Navigation("Filmi");
                });
#pragma warning restore 612, 618
        }
    }
}