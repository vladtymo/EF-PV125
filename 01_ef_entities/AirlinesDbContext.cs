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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SuperAirlinesDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
}
