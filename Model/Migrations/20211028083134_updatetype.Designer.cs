﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.DBContext;

namespace Model.Migrations
{
    [DbContext(typeof(CarParkDbContext))]
    [Migration("20211028083134_updatetype")]
    partial class updatetype
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Entity.BookingOffice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ContractEnds")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ContractStarts")
                        .HasColumnType("datetime2");

                    b.Property<string>("OfficeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Place")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("BookingOffices");
                });

            modelBuilder.Entity("Model.Entity.Car", b =>
                {
                    b.Property<string>("LicensePlate")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ParkingLotId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LicensePlate");

                    b.HasIndex("ParkingLotId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Model.Entity.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Model.Entity.ParkingLot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ParkingLots");
                });

            modelBuilder.Entity("Model.Entity.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CarLicensePlate")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarLicensePlate");

                    b.HasIndex("TripId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Model.Entity.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookedTicketNumber")
                        .HasColumnType("int");

                    b.Property<string>("CarType")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Driver")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MaxTicketNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Model.Entity.BookingOffice", b =>
                {
                    b.HasOne("Model.Entity.Trip", "Trip")
                        .WithMany("BookingOffices")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Model.Entity.Car", b =>
                {
                    b.HasOne("Model.Entity.ParkingLot", "ParkingLot")
                        .WithMany("Cars")
                        .HasForeignKey("ParkingLotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingLot");
                });

            modelBuilder.Entity("Model.Entity.Ticket", b =>
                {
                    b.HasOne("Model.Entity.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarLicensePlate");

                    b.HasOne("Model.Entity.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Model.Entity.ParkingLot", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Model.Entity.Trip", b =>
                {
                    b.Navigation("BookingOffices");
                });
#pragma warning restore 612, 618
        }
    }
}
