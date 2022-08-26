using Microsoft.EntityFrameworkCore;
using System;
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

            // -------------- Initialization
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

            // -------------- FLuent API configurations
            // for Airplanes
            modelBuilder.Entity<Airplane>().Property(a => a.Model)  // get property to configurate
                .IsRequired()                                       // not null
                .HasMaxLength(100);                                 // nvarchar(100)

            // for Clients
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
        }

        ///////////// Collections
        public DbSet<Client> Clients { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
    }
}
