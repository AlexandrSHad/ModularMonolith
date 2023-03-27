﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModularMonolith.Modules.Speakers.Core.DAL.EF;

#nullable disable

namespace ModularMonolith.Modules.Speakers.Core.DAL.EF.Migrations
{
    [DbContext(typeof(SpeakersDbContext))]
    [Migration("20230327082126_Speakers_Module_init")]
    partial class Speakers_Module_init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("speakers")
                .HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("ModularMonolith.Modules.Speakers.Core.Entities.Speaker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AvatarUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Speakers", "speakers");
                });
#pragma warning restore 612, 618
        }
    }
}
