﻿// <auto-generated />
using System;
using DemoClass17.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DemoClass17.Migrations
{
    [DbContext(typeof(MusicDbContext))]
    [Migration("20180627233838_maketricks")]
    partial class maketricks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DemoClass17.Models.Playlist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("DemoClass17.Models.Song", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Album");

                    b.Property<string>("Artist");

                    b.Property<int>("MyPID");

                    b.Property<string>("Name");

                    b.Property<int?>("PlaylistID");

                    b.HasKey("ID");

                    b.HasIndex("PlaylistID");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("DemoClass17.Models.Song", b =>
                {
                    b.HasOne("DemoClass17.Models.Playlist")
                        .WithMany("Songs")
                        .HasForeignKey("PlaylistID");
                });
#pragma warning restore 612, 618
        }
    }
}
