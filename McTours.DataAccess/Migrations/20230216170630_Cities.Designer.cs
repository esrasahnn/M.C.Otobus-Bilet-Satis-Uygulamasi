﻿// <auto-generated />
using System;
using McTours.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace McTours.DataAccess.Migrations
{
    [DbContext(typeof(McToursContext))]
    [Migration("20230216170630_Cities")]
    partial class Cities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("McTours.Domain.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("McTours.Domain.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("date");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("VehicleDefinitionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleDefinitionId");

                    b.ToTable("Vehicle", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PlateNumber = "34TJ0350",
                            RegistrationDate = new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationNumber = "AA658549",
                            VehicleDefinitionId = 1
                        },
                        new
                        {
                            Id = 2,
                            PlateNumber = "34CRN470",
                            RegistrationDate = new DateTime(2021, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationNumber = "AB123478",
                            VehicleDefinitionId = 2
                        },
                        new
                        {
                            Id = 3,
                            PlateNumber = "53OZD47",
                            RegistrationDate = new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationNumber = "CD854621",
                            VehicleDefinitionId = 3
                        },
                        new
                        {
                            Id = 4,
                            PlateNumber = "21ABC737",
                            RegistrationDate = new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationNumber = "DE854746",
                            VehicleDefinitionId = 4
                        },
                        new
                        {
                            Id = 5,
                            PlateNumber = "47ZHR939",
                            RegistrationDate = new DateTime(2019, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationNumber = "EE217634",
                            VehicleDefinitionId = 5
                        });
                });

            modelBuilder.Entity("McTours.Domain.VehicleDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<int>("LineCount")
                        .HasColumnType("int");

                    b.Property<int>("SeatingType")
                        .HasColumnType("int");

                    b.Property<int>("Utilities")
                        .HasColumnType("int");

                    b.Property<int>("VehicleModelId")
                        .HasColumnType("int");

                    b.Property<short>("Year")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("VehicleModelId");

                    b.ToTable("VehicleDefinition", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FuelType = 1,
                            LineCount = 10,
                            SeatingType = 2,
                            Utilities = 9,
                            VehicleModelId = 1,
                            Year = (short)2023
                        },
                        new
                        {
                            Id = 2,
                            FuelType = 3,
                            LineCount = 11,
                            SeatingType = 4,
                            Utilities = 6,
                            VehicleModelId = 2,
                            Year = (short)2021
                        },
                        new
                        {
                            Id = 3,
                            FuelType = 1,
                            LineCount = 12,
                            SeatingType = 3,
                            Utilities = 1,
                            VehicleModelId = 3,
                            Year = (short)2020
                        },
                        new
                        {
                            Id = 4,
                            FuelType = 2,
                            LineCount = 10,
                            SeatingType = 1,
                            Utilities = 2,
                            VehicleModelId = 4,
                            Year = (short)2019
                        },
                        new
                        {
                            Id = 5,
                            FuelType = 2,
                            LineCount = 11,
                            SeatingType = 2,
                            Utilities = 5,
                            VehicleModelId = 5,
                            Year = (short)2022
                        },
                        new
                        {
                            Id = 6,
                            FuelType = 3,
                            LineCount = 12,
                            SeatingType = 4,
                            Utilities = 10,
                            VehicleModelId = 6,
                            Year = (short)2021
                        });
                });

            modelBuilder.Entity("McTours.Domain.VehicleMake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("VehicleMake", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mercedes"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Man"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Neoplan"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Setra"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Isuzu"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Temsa"
                        });
                });

            modelBuilder.Entity("McTours.Domain.VehicleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VehicleMakeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleMakeId");

                    b.ToTable("VehicleModel", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Travego",
                            VehicleMakeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tourismo",
                            VehicleMakeId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Novociti",
                            VehicleMakeId = 5
                        },
                        new
                        {
                            Id = 4,
                            Name = "Fortuna",
                            VehicleMakeId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Lions",
                            VehicleMakeId = 2
                        },
                        new
                        {
                            Id = 6,
                            Name = "Cityliner",
                            VehicleMakeId = 3
                        },
                        new
                        {
                            Id = 7,
                            Name = "Tourliner",
                            VehicleMakeId = 3
                        },
                        new
                        {
                            Id = 8,
                            Name = "S Serisi",
                            VehicleMakeId = 4
                        },
                        new
                        {
                            Id = 9,
                            Name = "Maraton",
                            VehicleMakeId = 6
                        },
                        new
                        {
                            Id = 10,
                            Name = "Safir",
                            VehicleMakeId = 6
                        });
                });

            modelBuilder.Entity("McTours.Domain.Vehicle", b =>
                {
                    b.HasOne("McTours.Domain.VehicleDefinition", "VehicleDefinition")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleDefinitionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("VehicleDefinition");
                });

            modelBuilder.Entity("McTours.Domain.VehicleDefinition", b =>
                {
                    b.HasOne("McTours.Domain.VehicleModel", "VehicleModel")
                        .WithMany("VehicleDefinitions")
                        .HasForeignKey("VehicleModelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("VehicleModel");
                });

            modelBuilder.Entity("McTours.Domain.VehicleModel", b =>
                {
                    b.HasOne("McTours.Domain.VehicleMake", "VehicleMake")
                        .WithMany("VehicleModels")
                        .HasForeignKey("VehicleMakeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("VehicleMake");
                });

            modelBuilder.Entity("McTours.Domain.VehicleDefinition", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("McTours.Domain.VehicleMake", b =>
                {
                    b.Navigation("VehicleModels");
                });

            modelBuilder.Entity("McTours.Domain.VehicleModel", b =>
                {
                    b.Navigation("VehicleDefinitions");
                });
#pragma warning restore 612, 618
        }
    }
}
