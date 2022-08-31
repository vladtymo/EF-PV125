﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using data_access;

#nullable disable

namespace data_access.Migrations
{
    [DbContext(typeof(AirlinesDbContext))]
    partial class AirlinesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClientFlight", b =>
                {
                    b.Property<int>("ClientsCredentialsId")
                        .HasColumnType("int");

                    b.Property<int>("FlightsNumber")
                        .HasColumnType("int");

                    b.HasKey("ClientsCredentialsId", "FlightsNumber");

                    b.HasIndex("FlightsNumber");

                    b.ToTable("ClientFlight");
                });

            modelBuilder.Entity("data_access.Airplane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MaxPassengers")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Airplanes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MaxPassengers = 1200,
                            Model = "Boeing 765"
                        });
                });

            modelBuilder.Entity("data_access.Client", b =>
                {
                    b.Property<int>("CredentialsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CredentialsId"), 1L, 1);

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("FirstName");

                    b.HasKey("CredentialsId");

                    b.ToTable("Passengers", (string)null);

                    b.HasData(
                        new
                        {
                            CredentialsId = 1,
                            Birthdate = new DateTime(2003, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "super55@ukr.net",
                            Name = "Viktor"
                        },
                        new
                        {
                            CredentialsId = 2,
                            Birthdate = new DateTime(1995, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "gigigi@gmail.com",
                            Name = "Olga"
                        });
                });

            modelBuilder.Entity("data_access.Credentials", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique()
                        .HasFilter("[ClientId] IS NOT NULL");

                    b.ToTable("Credentials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "fly3434",
                            Password = "Qwer23"
                        },
                        new
                        {
                            Id = 2,
                            Login = "man66",
                            Password = "Blabla3"
                        });
                });

            modelBuilder.Entity("data_access.Flight", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"), 1L, 1);

                    b.Property<int>("AirplaneId")
                        .HasColumnType("int");

                    b.Property<string>("ArrivalCity")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartureCity")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Number");

                    b.HasIndex("AirplaneId");

                    b.ToTable("Flights");

                    b.HasData(
                        new
                        {
                            Number = 1,
                            AirplaneId = 1,
                            ArrivalCity = "Lviv",
                            ArrivalTime = new DateTime(2022, 8, 25, 18, 25, 0, 0, DateTimeKind.Unspecified),
                            DepartureCity = "Kyiv",
                            DepartureTime = new DateTime(2022, 8, 25, 13, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Number = 2,
                            AirplaneId = 1,
                            ArrivalCity = "Lviv",
                            ArrivalTime = new DateTime(2022, 9, 13, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartureCity = "Warsaw",
                            DepartureTime = new DateTime(2022, 9, 12, 15, 30, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ClientFlight", b =>
                {
                    b.HasOne("data_access.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientsCredentialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data_access.Flight", null)
                        .WithMany()
                        .HasForeignKey("FlightsNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("data_access.Credentials", b =>
                {
                    b.HasOne("data_access.Client", "Client")
                        .WithOne("Credentials")
                        .HasForeignKey("data_access.Credentials", "ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("data_access.Flight", b =>
                {
                    b.HasOne("data_access.Airplane", "Airplane")
                        .WithMany("Flights")
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airplane");
                });

            modelBuilder.Entity("data_access.Airplane", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("data_access.Client", b =>
                {
                    b.Navigation("Credentials")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
