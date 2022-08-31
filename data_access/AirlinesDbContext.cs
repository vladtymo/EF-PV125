﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access
{
    public class AirlinesDbContext : DbContext
    {
        public AirlinesDbContext()
        {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();

            // Use Migrations instead: (install NuGet: EFCore.Tools)
            // - add-migration <MigrationName> - add new migration with available changes
            // - update-migration              - update the database by the newest migration
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SuperAirlinesDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -------------- FLuent API configurations
            // for Airplanes
            modelBuilder.Entity<Airplane>().Property(a => a.Model)  // get property to configurate
                .IsRequired()                                       // not null
                .HasMaxLength(100);                                 // nvarchar(100)

            // for Clients
            modelBuilder.Entity<Client>().HasKey(c => c.CredentialsId);
            modelBuilder.Entity<Client>().ToTable("Passengers");    // set table name
            modelBuilder.Entity<Client>().Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("FirstName");                      
            modelBuilder.Entity<Client>().Property(c => c.Email)  
               .IsRequired()                                      
               .HasMaxLength(100);

            // for Flights
            modelBuilder.Entity<Flight>().HasKey(f => f.Number);    // set primary key
            modelBuilder.Entity<Flight>().Property(f => f.DepartureCity)
              .IsRequired()
              .HasMaxLength(100);
            modelBuilder.Entity<Flight>().Property(f => f.ArrivalCity)
              .IsRequired()
              .HasMaxLength(100);

            // -------------- Relationships configuration
            // Relationship Type: One to Many (1...*)
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Airplane)
                .WithMany(a => a.Flights)
                .HasForeignKey(f => f.AirplaneId);

            // Relationship Type: Many to Many (*...*)
            modelBuilder.Entity<Flight>().HasMany(f => f.Clients).WithMany(c => c.Flights);

            // Relationship Type: One to One (1...1)
            modelBuilder.Entity<Client>().HasOne(c => c.Credentials).WithOne(c => c.Client)
                .HasForeignKey<Credentials>(c => c.ClientId);

            // -------------- Initialization
            modelBuilder.SeedAirplanes();
            modelBuilder.SeedFlights();
            modelBuilder.SeedCredentials(); // principal table
            modelBuilder.SeedClients();     // dependent table
        }

        ///////////// Collections
        public DbSet<Client> Clients { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
    }
}
