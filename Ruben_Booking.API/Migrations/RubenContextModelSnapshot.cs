﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ruben_Booking.API.Database;

#nullable disable

namespace Ruben_Booking.API.Migrations
{
    [DbContext(typeof(RubenContext))]
    partial class RubenContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ruben_Booking.API.Database.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Participants")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Ruben_Booking.API.Database.Models.Consultant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserCredential")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Consultants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Janne.Claesson@Firman.se",
                            Password = "wx09ehRK2UGh3/5fJdPqmp9a/Y2DWx6cmoEkaKuU854=",
                            Salt = "0xC31D3D7A144AD941A1DFFE5F25D3EA9A",
                            UserCredential = "CSKED18372"
                        });
                });

            modelBuilder.Entity("Ruben_Booking.API.Database.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserCredential")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Hasse.Jansson@Snut.se",
                            Password = "wO9z6fREqcI0DubZUixB5VCeu01MUUQDYCXylmRbziM=",
                            PhoneNumber = "0738239122",
                            Salt = "0xC0EF73E9F444A9C2340EE6D9522C41E5",
                            UserCredential = "EOESK20193"
                        });
                });

            modelBuilder.Entity("Ruben_Booking.API.Database.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasProjector")
                        .HasColumnType("bit");

                    b.Property<bool>("HasWhiteBoard")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInService")
                        .HasColumnType("bit");

                    b.Property<int>("MaxSeats")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Längst ner i korridoren till höger om den vänstra dörren.",
                            HasProjector = true,
                            HasWhiteBoard = true,
                            IsInService = true,
                            MaxSeats = 8,
                            Name = "Sommarängen"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}