using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ef_entities
{
    public class AirlinesDbContext : DbContext
    {
        public AirlinesDbContext()
        {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-O0M8V28\SQLEXPRESS;Initial Catalog=SuperAirlinesDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Initialization
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
                {
                    new Airplane()
                    {
                        Id = 1,
                        Model = "Boeing 765",
                        MaxPassengers = 1200
                    }
                }
            );

            modelBuilder.Entity<Flight>().HasData(new Flight[]
                {
                    new Flight()
                    {
                        Number = 1,
                        AirplaneId = 1,
                        DepartureCity = "Kyiv",
                        ArrivalCity = "Lviv",
                        DepartureTime = new DateTime(2022, 8, 25, 13, 30, 0),
                        ArrivalTime = new DateTime(2022, 8, 25, 18, 25, 0)
                    },
                    new Flight()
                    {
                        Number = 2,
                        AirplaneId = 1,
                        DepartureCity = "Warsaw",
                        ArrivalCity = "Lviv",
                        DepartureTime = new DateTime(2022, 9, 12, 15, 30, 0),
                        ArrivalTime = new DateTime(2022, 9, 13, 05, 0, 0)
                    }
                }
            );
        }

        ///////////// Collections
        public DbSet<Client> Clients { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
    }

    //////////////// Entities
    [Table("Passengers")] // set table name
    public class Client
    {
        // Primary Key naming: Id/id/ID EntityName+Id
        public int Id { get; set; }

        [Required]              // not null
        [MaxLength(100)]        // nvarchar(100)
        [Column("FirstName")]   // set column name
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        public DateTime? Birthdate { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }

    public class Flight
    {
        [Key] // set primary key
        public int Number { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        [Required, MaxLength(100)]
        public string DepartureCity { get; set; }
        [Required, MaxLength(100)]
        public string ArrivalCity { get; set; }

        // Foreign Key naming: RelatedEntityName+RelatedEntityPrimaryKeyName
        public int AirplaneId { get; set; }

        // Relationship Type: One to Many (1...*)
        public Airplane Airplane { get; set; }

        // Relationship Type: Many to Many (*...*)
        public ICollection<Client> Clients { get; set; }
    }

    public class Airplane
    {
        public int Id { get; set; }
        [Required, MaxLength(100)] 
        public string Model { get; set; }
        public int MaxPassengers { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
}
