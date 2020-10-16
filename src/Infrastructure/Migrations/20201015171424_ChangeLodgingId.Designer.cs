﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(TourismContext))]
    [Migration("20201015171424_ChangeLodgingId")]
    partial class ChangeLodgingId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Administrator", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("Entities.Booking", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LodgingId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int?>("TouristId")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.HasIndex("LodgingId");

                    b.HasIndex("TouristId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Entities.Lodging", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CostPerNight")
                        .HasColumnType("float");

                    b.Property<int>("CurrentlyOccupiedPlaces")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionForBookings")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Images")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaximumSize")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfStars")
                        .HasColumnType("int");

                    b.Property<int?>("TouristPointId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TouristPointId");

                    b.ToTable("Lodgings");
                });

            modelBuilder.Entity("Entities.Region", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("Entities.Tourist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tourist");
                });

            modelBuilder.Entity("Entities.TouristPoint", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RegionName");

                    b.ToTable("TouristPoints");
                });

            modelBuilder.Entity("Entities.TouristPointCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("TouristPointId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryName");

                    b.HasIndex("TouristPointId");

                    b.ToTable("TouristPointCategory");
                });

            modelBuilder.Entity("Entities.Booking", b =>
                {
                    b.HasOne("Entities.Lodging", "Lodging")
                        .WithMany("Bookings")
                        .HasForeignKey("LodgingId");

                    b.HasOne("Entities.Tourist", "Tourist")
                        .WithMany()
                        .HasForeignKey("TouristId");
                });

            modelBuilder.Entity("Entities.Lodging", b =>
                {
                    b.HasOne("Entities.TouristPoint", "TouristPoint")
                        .WithMany("Lodgings")
                        .HasForeignKey("TouristPointId");
                });

            modelBuilder.Entity("Entities.TouristPoint", b =>
                {
                    b.HasOne("Entities.Region", "Region")
                        .WithMany("TouristPoints")
                        .HasForeignKey("RegionName");
                });

            modelBuilder.Entity("Entities.TouristPointCategory", b =>
                {
                    b.HasOne("Entities.Category", "Category")
                        .WithMany("CategoryTouristPoints")
                        .HasForeignKey("CategoryName");

                    b.HasOne("Entities.TouristPoint", "TouristPoint")
                        .WithMany("TouristPointCategories")
                        .HasForeignKey("TouristPointId");
                });
#pragma warning restore 612, 618
        }
    }
}